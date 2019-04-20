using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class frmMain : Form
    {
        private Graphics _gr;                   // to snag the Form's graphics object for use in Render call vs. snagging it every time Render is called
        private int _activeSetNumber = 1;       // the starting selected Set number
        private RadioButton _priorSetNumber;    // the Set number selected before selecting a new number (to toggle UI look back to unselected)
        private int _activeHiNumber = 1;        // the starting selected Highlight number
        private RadioButton _priorHiNumber;     // the Highlight number selected before selecting a new number (to toggle UI look back to unselected)
        private RadioButton _priorHiNoteType;   // the Highlight type selected for notes before selecting a new number (to toggle UI look back to unselected)
        private RadioButton _priorHiCellType;   // the Highlight type selected for cells before selecting a new number (to toggle UI look back to unselected)
        private int xOffset = 20;               // how far over from Form's left edge to start painting the board
        private int yOffset = 20;               // how far down from Form's top edge to start painting the board
        private ModifierKey _modifierKey = ModifierKey.None;                        // keeping track of atl, shift, ctrl state at the time of early key trapping and normal keypress events
        private HighlightClickMode _highlightClickMode = HighlightClickMode.Manual; // if on manual, cell, or note mode for highlight buttons

        // components for click/doubleclick hack code :(
        private Timer _doubleClickTimer = new Timer();
        private bool _isFirstClick = true;
        private bool _isRightClick;
        private bool _isDoubleClick;
        private int _milliseconds;
        private int _clickX;
        private int _clickY;

        /// <summary>
        /// Standard WinForms ctor for one-time setup things 
        /// </summary>
        public frmMain()
        {
            InitializeComponent();

            LoadPatternList();
            cbxPatterns.SelectedIndex = 0;

            _priorSetNumber = radSet1;
            _priorHiNumber = radHi1;
            _priorHiNoteType = radHiNoteNone;
            _priorHiCellType = radHiCellNone;
            _gr = CreateGraphics();

            // setup time for click/doubleclick hack code :(
            _doubleClickTimer.Interval = 35;
            _doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);

            Game.CreateInstance(BoardType.Bitmap, cellSize: 60);
            Game.Board.SelectCellAtRowCol(5, 5);
            
            SetTestState();
            Render();
        }

        /// <summary>
        /// Setup the Patterns combo box
        /// </summary>
        private void LoadPatternList()
        {
            cbxPatterns.Items.Clear();
            cbxPatterns.DisplayMember = "Key";
            cbxPatterns.ValueMember = "Value";

            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.XWing.Description(), Pattern.XWing));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.Skyscraper.Description(), Pattern.Skyscraper));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.TwoStringKite.Description(), Pattern.TwoStringKite));
            cbxPatterns.Items.Add(new KeyValuePair<string, Pattern>(Pattern.XYWing.Description(), Pattern.XYWing));
        }

        /// <summary>
        /// Default board setup for testing
        /// </summary>
        private void SetTestState()
        {
            //// test code start vvv
            Game.Board.ToggleNote(7, 4, 2);
            Game.Board.HighlightNote(7, 4, 2, NoteHighlightType.Info);
            Game.Board.ToggleNote(3, 6, 2);
            Game.Board.HighlightNote(3, 6, 2, NoteHighlightType.Info);
            Game.Board.SetGuess(4, 7, 6);
            Game.Board.SetGiven(3, 3, 3);
            Game.Board.ToggleNote(2, 7, 8);
            Game.Board.HighlightNote(2, 7, 8, NoteHighlightType.Weak);
            Game.Board.ToggleNote(5, 5, 3);
            Game.Board.HighlightNote(5, 5, 3, NoteHighlightType.Strong);
            Game.Board.ToggleNote(8, 6, 7);
            Game.Board.HighlightNote(8, 6, 7, NoteHighlightType.Info);
            Game.Board.ToggleNote(9, 8, 1);
            Game.Board.ToggleNote(9, 8, 2);
            Game.Board.ToggleNote(1, 1, 1);
            Game.Board.ToggleNote(9, 9, 4);
            Game.Board.ToggleNote(1, 8, 5);
            Game.Board.ToggleNote(9, 1, 6);
            Game.Board.ToggleNote(4, 8, 9);
            Game.Board.ToggleNote(1, 2, 2);

            // xwing (corners)
            Game.Board.ToggleNote(2, 2, 1);
            Game.Board.ToggleNote(2, 8, 1);
            Game.Board.ToggleNote(6, 2, 1);
            Game.Board.ToggleNote(6, 8, 1);
            // xwing eliminations
            Game.Board.ToggleNote(1, 2, 1);
            Game.Board.ToggleNote(3, 2, 1);

            // xy wing (pivot and two pincers)
            Game.Board.ToggleNote(3, 5, 1);
            Game.Board.ToggleNote(3, 5, 2);
            Game.Board.ToggleNote(3, 9, 2);
            Game.Board.ToggleNote(3, 9, 9);
            Game.Board.ToggleNote(8, 5, 1);
            Game.Board.ToggleNote(8, 5, 9);
            // xy wing elimination
            Game.Board.ToggleNote(8, 9, 9);

            Game.Board.HighlightCellsWithNoteOrNumber(1);

            //// test code end ^^^
        }

        /// <summary>
        /// Common method to redraw the board based on current state
        /// </summary>
        private void Render()
        {
            Game.Board.Render();

            // now paint the board directly on the Form
            PaintEventArgs e = new PaintEventArgs(_gr, new Rectangle(0, 0, Width, Height));
            e.Graphics.DrawImageUnscaled(((BitmapBoard)Game.Board).Image, xOffset, yOffset);  // Offset x/y to prevent board from being in the far upper left (0,0) of the form 
        }

        /// <summary>
        /// Cycle through the three states of the Highlight Click Mode
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms check-event args</param>
        private void chkHiMode_CheckStateChanged(object sender, EventArgs e)
        {
            switch (chkHiMode.CheckState)
            {
                case CheckState.Unchecked:
                    chkHiMode.Text = "Cell Select";
                    pnlHiCellOuter.Visible = true;
                    pnlHiNoteOuter.Visible = false;
                    pnlHiNumbers.Visible = false;
                    _highlightClickMode = HighlightClickMode.Cell;
                    break;
                case CheckState.Indeterminate:
                    chkHiMode.Text = "Manual";
                    pnlHiCellOuter.Visible = true;
                    pnlHiNoteOuter.Visible = true;
                    pnlHiNoteOuter.Top = 97;
                    pnlHiNumbers.Visible = true;
                    _highlightClickMode = HighlightClickMode.Manual;
                    break;
                case CheckState.Checked:
                    chkHiMode.Text = "Note Select";
                    pnlHiNoteOuter.Visible = true;
                    pnlHiNoteOuter.Top = 52;
                    pnlHiCellOuter.Visible = false;
                    pnlHiNumbers.Visible = false;
                    _highlightClickMode = HighlightClickMode.Note;
                    break;
            }
        }

        /// <summary>
        /// Toggle the cell highlight option (am borrowing the radio button Tag property to hold the highlight type enum)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms radiocheck-event args</param>
        private void radHighlightCell_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            // flip the prior number seletion back to un-selected look/feel
            _priorHiCellType.FlatStyle = FlatStyle.Popup;
            // flip the new selection to unique look/feel
            rad.FlatStyle = FlatStyle.Standard;

            _priorHiCellType = rad;

            // if shift click on the X, clear all cell hightlights
            if ((rad == radHiCellNone) && (Control.ModifierKeys == Keys.Shift))
                Game.Board.HighlightCellsWithNoteOrNumber(0);
            else if (_highlightClickMode == HighlightClickMode.Manual)
                Game.Board.HighlightCell(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, (CellHighlightType)Convert.ToInt32(rad.Tag));

            Render();
        }

        /// <summary>
        /// Toggle the note highlight option (am borrowing the radio button Tag property to hold the highlight type enum)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms radiocheck-event args</param>
        private void radHighlightNote_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            // flip the prior number seletion back to un-selected look/feel
            _priorHiNoteType.FlatStyle = FlatStyle.Popup;
            // flip the new selection to unique look/feel
            rad.FlatStyle = FlatStyle.Standard;

            _priorHiNoteType = rad;

            // if shift click on the X, clear all note hightlights
            if ((rad == radHiNoteNone) && (Control.ModifierKeys == Keys.Shift))
                Game.Board.ClearNoteHighlights();
            else if ((_highlightClickMode == HighlightClickMode.Manual) && !Game.Board.SelectedCell.HasAnswer) // if every click needs to update the selected cell (manual mode) && the cell has note visable (no answer set)
                Game.Board.HighlightNote(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, _activeHiNumber, (NoteHighlightType)Convert.ToInt32(rad.Tag));

            Render();
        }

        /// <summary>
        /// Clicking one of the "this is my current Highlight focus number to mess with" buttons
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void radHiNumbers_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            if (rad == _priorHiNumber)
                return;

            // flip the prior number seletion back to un-selected look/feel
            _priorHiNumber.BackColor = SystemColors.Highlight;
            _priorHiNumber.ForeColor = SystemColors.GradientInactiveCaption;
            _priorHiNumber.FlatStyle = FlatStyle.Popup;
            // flip the new selection to unique look/feel
            rad.BackColor = SystemColors.GradientActiveCaption;
            rad.ForeColor = SystemColors.Highlight;
            rad.FlatStyle = FlatStyle.Standard;

            _priorHiNumber = rad;

            _activeHiNumber = Int32.Parse(rad.Tag.ToString());
        }

        /// <summary>
        /// Toggle Notes/Numbers mode (and button text to make it look "checked")
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms check-event args</param>
        private void chkNumberMode_CheckedChanged(object sender, EventArgs e)
        {
            chkKeysNotesMode.Text = (chkKeysNotesMode.Checked ? "Notes" : "Numbers");
        }

        /// <summary>
        /// Add or Remove a Note of the currently selected number
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnToggleNote_Click(object sender, EventArgs e)
        {
            Game.Board.ToggleNote(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, _activeSetNumber);
            Render();
        }

        /// <summary>
        /// Highlight all cells that have the selected number in them (whether as a Given, an Answer, or a Note)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms check-event args</param>
        private void chkHighlightHavingValue_CheckedChanged(object sender, EventArgs e)
        {
            // toggle look and feel of button to make it look like it is "on mode" or not
            chkHighlightHavingValue.FlatStyle = (chkHighlightHavingValue.Checked ? FlatStyle.Standard : FlatStyle.Popup);

            if (chkHighlightHavingValue.Checked)
                Game.Board.HighlightCellsWithNoteOrNumber(_activeSetNumber);
            else
                Game.Board.HighlightCellsWithNoteOrNumber(0);

            Render();
        }

        /// <summary>
        /// Set the current cell to the selected number (as a solution guess)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnSetGuess_Click(object sender, EventArgs e)
        {
            Game.Board.SetGuess(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, _activeSetNumber);
            Render();
        }

        /// <summary>
        /// Clicking one of the "this is my current Set number to mess with" buttons
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void radSetNumbers_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            // flip the prior number seletion back to un-selected look/feel
            _priorSetNumber.BackColor = SystemColors.Highlight;
            _priorSetNumber.ForeColor = SystemColors.GradientInactiveCaption;
            _priorSetNumber.FlatStyle = FlatStyle.Popup;
            // flip the new selection to unique look/feel
            rad.BackColor = SystemColors.GradientActiveCaption;
            rad.ForeColor = SystemColors.Highlight;
            rad.FlatStyle = FlatStyle.Standard;

            _priorSetNumber = rad;

            _activeSetNumber = Int32.Parse(rad.Tag.ToString());

            if (chkHighlightHavingValue.Checked)
            {
                Game.Board.HighlightCellsWithNoteOrNumber(_activeSetNumber);
                Render();
            }
        }

        /// <summary>
        /// Set the current cell to the selected number (as a Given)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnSetGiven_Click(object sender, EventArgs e)
        {
            Game.Board.SetGiven(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, _activeSetNumber);
            Render();
        }

        /// <summary>
        /// Arrow Keys act funky on Forms and move through various controls regardless of tabstop settings so I am trapping them early, pretending was KeyDown, then eating the key to avoid further form processing 
        /// Also, I am having to remember (but not trap/eat) the modifier keys (alt, shift, ctrl) to pass them down to mouse click events
        /// </summary>
        /// <param name="msg">Don't care, just passed along</param>
        /// <param name="keyData">Which key was pressed</param>
        /// <returns>Force True if I chose to eat the key or stanadard bool if I let it flow into base class processing</returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            _modifierKey = ModifierKey.None;

            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    // send directly to KeyDown since returning True here would prevent KeyDown from getting these keystrokes
                    frmMain_KeyDown(this, new KeyEventArgs(keyData));
                    return true;
                case (Keys.Shift | Keys.ShiftKey):
                    _modifierKey |= ModifierKey.Shift;
                    break;
                case (Keys.Alt | Keys.Menu):
                    _modifierKey |= ModifierKey.Alt;
                    break;
                case (Keys.Control | Keys.ControlKey):
                    _modifierKey |= ModifierKey.Control;
                    break;
            }

            // otherwise, process as normal (which will get non-eaten keys over to KeyDown automatically)
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Handle all the key events I care about, converting their value to my built-in enumerations
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms key-event args</param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            UserInput input = UserInput.None;

            int numPressed;
            // if a non-zero number key (any better way to do this check?)
            if (int.TryParse(((char)e.KeyValue).ToString(), out numPressed) && numPressed != 0)
            {
                // convert to my custom number enum
                UserInput[] possibleNums = { UserInput.One, UserInput.Two, UserInput.Three, UserInput.Four, UserInput.Five, UserInput.Six, UserInput.Seven, UserInput.Eight, UserInput.Nine };
                input = possibleNums[numPressed - 1];
            }
            else // non-number
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        input = UserInput.UpArrow;
                        break;
                    case Keys.Down:
                        input = UserInput.DownArrow;
                        break;
                    case Keys.Left:
                        input = UserInput.LeftArrow;
                        break;
                    case Keys.Right:
                        input = UserInput.RightArrow;
                        break;
                    case Keys.Home:
                        input = UserInput.Home;
                        break;
                    case Keys.End:
                        input = UserInput.End;
                        break;
                    case Keys.Delete:
                        input = UserInput.Delete;
                        break;
                }
            }

            // if pressed something worthwhile
            if (input != UserInput.None)
            {
                // trap the modifier keys too
                _modifierKey = ModifierKey.None;
                if (e.Shift)
                {
                    // Shift while in Numbers mode is Notes mode (so turn shift on in my modifiers flags)
                    if (!chkKeysNotesMode.Checked)
                        _modifierKey |= ModifierKey.Shift;
                }
                else
                {
                    // Non-Shift while in Notes mode means do note (so turn shift on in my modifiers flags)
                    if (chkKeysNotesMode.Checked)    
                        _modifierKey |= ModifierKey.Shift;
                }

                if (e.Alt)
                    _modifierKey |= ModifierKey.Alt;

                if (e.Control)
                {
                    _modifierKey |= ModifierKey.Control;

                    // Contrl-#, pretend the user selected that # as focus number
                    if (input >= UserInput.One && input <= UserInput.Nine)
                    {
                        RadioButton[] numButtons = { radSet1, radSet2, radSet3, radSet4, radSet5, radSet6, radSet7, radSet8, radSet9 };
                        radSetNumbers_Click(numButtons[(int)input - 1], new EventArgs());

                        // but don't pass the key press down to cells since don't want ctrl-# to be cell based, just this outer form number selector
                        return;
                    }
                }

                Game.Board.HandleKeyUserInput(input, _modifierKey);

                // if in auto-highlight mode AND (pressed a number OR just deleted main number, exposing potential notes), update highlighting
                if (chkHighlightHavingValue.Checked && ((numPressed != 0) || (input == UserInput.Delete)))
                    Game.Board.HighlightCellsWithNoteOrNumber(_activeSetNumber);

                Render();
            }
        }

        /// <summary>
        /// When the Main Form wants to repaint, also Render the latest board
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms paint-event args</param>
        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        /// <summary>
        /// Trapping Mouse Down as a part of the hack to determine Single vs. Double-Click, otherwise Single-Click was always being trapped regardless of trying Double-Click (what is a better way?)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            _isRightClick = (e.Button == MouseButtons.Right);

            // if first time in here, consider this will be a single click
            if (_isFirstClick)
            {
                _isFirstClick = false;

                // offset since the args x/y are FORM-based and I want the board area instead, which is NOT at 0,0 in the form
                _clickX = ((MouseEventArgs)e).X - xOffset;
                _clickY = ((MouseEventArgs)e).Y - yOffset;

                _doubleClickTimer.Start();
            }
            else // another click came in before the click processing in the Timer event dealt with the prior click
            {
                // if second click was fast enough to beat the built in double-click timing, flag as double
                if (_milliseconds < SystemInformation.DoubleClickTime)
                    _isDoubleClick = true;
            }
        }

        /// <summary>
        /// Timer firing to deal with the Single vs. Double-Click hack (did a second click come in fast enough to be considered a double-click?)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms timer-event args</param>
        void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            _milliseconds += 150;

            // if the timer has reached the double click time limit
            if (_milliseconds >= SystemInformation.DoubleClickTime)
            {
                _doubleClickTimer.Stop();

                BitmapBoard board = (BitmapBoard)Game.Board;

                // if clicked in the board area of the form
                if (_clickX >= 0 && _clickX < board.BoardSize && _clickY >= 0 && _clickY < board.BoardSize)
                {
                    if (_isDoubleClick)
                    {
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.DoubleClick, _modifierKey, _clickX, _clickY);

                        // if the cell has an answer and it does NOT match the "highlight all of that number", ensure it unhighlights
                        if (chkHighlightHavingValue.Checked && (Game.Board.SelectedCell.Answer != _activeSetNumber))
                            Game.Board.HighlightCell(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, CellHighlightType.None);

                    }
                    else if (_isRightClick)
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.RightClick, _modifierKey, _clickX, _clickY);
                    else
                    {
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.LeftClick, _modifierKey, _clickX, _clickY);

                        // do special highlighting if Control not clicked (Control-RightClick is for special strong/week coloring done in HandleXYClick)
                        if ((_modifierKey & ModifierKey.Control) == 0)
                        {
                            if (_highlightClickMode == HighlightClickMode.Cell)
                                Game.Board.HighlightCell(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, (CellHighlightType)Convert.ToInt32(_priorHiCellType.Tag));
                            else if (_highlightClickMode == HighlightClickMode.Note && !Game.Board.SelectedCell.HasAnswer)
                            {
                                int selectedNote = (Game.Board.SelectedCell.HasNoteSelected ? Game.Board.SelectedCell.SelectedNote.Candidate : 0);
                                // if even clicked a note area that had a note set
                                if (selectedNote != 0)
                                    Game.Board.HighlightNote(Game.Board.SelectedCell.Row, Game.Board.SelectedCell.Column, selectedNote, (NoteHighlightType)Convert.ToInt32(_priorHiNoteType.Tag));
                            }
                        }
                    }
                }

                // allow the MouseDown event handler to process clicks again
                _isFirstClick = true;
                _isDoubleClick = false;
                _milliseconds = 0;

                Render();
            }
        }

        /// <summary>
        /// Needing to reset the state of the active modifier after the click is done so it doesn't think one is still down since KeyUp doesn't get just modifier un-presses
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void frmMain_MouseUp(object sender, MouseEventArgs e)
        {
            _modifierKey = ModifierKey.None;
            if ((ModifierKeys & Keys.Shift) == Keys.Shift)
                _modifierKey |= ModifierKey.Shift;
            if ((ModifierKeys & Keys.Control) == Keys.Control)
                _modifierKey |= ModifierKey.Control;
            if ((ModifierKeys & Keys.Alt) == Keys.Alt)
                _modifierKey |= ModifierKey.Alt;
        }

        /// <summary>
        /// Find the pattern selected in the patter combo box
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            Pattern pattern = ((KeyValuePair<string,Pattern>)cbxPatterns.SelectedItem).Value;

            // FORCED TEST CODE!!!!!!! 
            switch (pattern)
            {
                case Pattern.XWing:
                    // xwing (corners)
                    Game.Board.HighlightCell(2, 2, CellHighlightType.Special);
                    Game.Board.HighlightCell(2, 8, CellHighlightType.Special);
                    Game.Board.HighlightCell(6, 2, CellHighlightType.Special);
                    Game.Board.HighlightCell(6, 8, CellHighlightType.Special);
                    // xwing eliminations
                    Game.Board.HighlightNote(1, 2, 1, NoteHighlightType.Bad);
                    Game.Board.HighlightNote(3, 2, 1, NoteHighlightType.Bad);
                    Game.Board.HighlightNote(9, 8, 1, NoteHighlightType.Bad);
                    // undo xy wing elimination
                    Game.Board.HighlightNote(8, 9, 9, NoteHighlightType.None);
                    break;
                case Pattern.XYWing:
                    Game.Board.HighlightCell(3, 5, CellHighlightType.Pivot);
                    Game.Board.HighlightCell(3, 9, CellHighlightType.Pincer);
                    Game.Board.HighlightCell(8, 5, CellHighlightType.Pincer);
                    // xy wing elimination
                    Game.Board.HighlightNote(8, 9, 9, NoteHighlightType.Bad);
                    // undo xwing eliminations
                    Game.Board.HighlightNote(1, 2, 1, NoteHighlightType.None);
                    Game.Board.HighlightNote(3, 2, 1, NoteHighlightType.None);
                    Game.Board.HighlightNote(9, 8, 1, NoteHighlightType.None);
                    break;
            }

            Render();
        }
    }
}
