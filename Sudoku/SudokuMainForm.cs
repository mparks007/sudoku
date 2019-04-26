using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class frmMain : Form
    {
        private Graphics _gr;                                                       // to snag the Form's graphics object for use in Render call vs. snagging it every time Render is called
        private int _xOffset = 20;                                                  // how far over from Form's left edge to start painting the board
        private int _yOffset = 20;                                                  // how far down from Form's top edge to start painting the board
        private ModifierKey _modifierKey = ModifierKey.None;                        // keeping track of alt, shift, ctrl state at the time of early key trapping and normal keypress events

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
            _gr = CreateGraphics();

            SetupUI();

            // load up all the "Find pattern blah" items
            LoadPatternList();
            cbxPatterns.SelectedIndex = 0;

            // setup time for click/doubleclick hack code :(
            _doubleClickTimer.Interval = 35;
            _doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);

            Game.CreateInstance(BoardType.Bitmap, cellSize: 60);
            Board.ValidationMode = ValidationMode.Off;
            Game.Board.SetDefaultState();
            Game.Board.SelectCellAtRowCol(5, 5);

            Render();
        }

        /// <summary>
        /// Setup various button/checkbox controls to the appropriate text and coloring
        /// </summary>
        private void SetupUI()
        {
            // listen for numbers clicking
            pnlFocusNumber.NumberClicked += pnlSetNumbers_NumberClicked;

            // component setup for Cell Highlight control
            pnlCellHighlightPicker.SetButtonTags((int)CellHighlightType.None, (int)CellHighlightType.Value, (int)CellHighlightType.Special, (int)CellHighlightType.Pivot, (int)CellHighlightType.Pincer);
            pnlCellHighlightPicker.SetButtonText(CellHighlightType.None.Description(), CellHighlightType.Value.Description(), CellHighlightType.Special.Description(), CellHighlightType.Pivot.Description(), CellHighlightType.Pincer.Description());
            pnlCellHighlightPicker.SetButtonColors(BitmapBoard.Colors.CellHighlightNone, BitmapBoard.Colors.CellHighlightValue, BitmapBoard.Colors.CellHighlightSpecial, BitmapBoard.Colors.CellHighlightPivot, BitmapBoard.Colors.CellHighlightPincer);
            pnlCellHighlightPicker.SetButtonFontColors(BitmapBoard.Colors.CellTextOnHighlightNone, BitmapBoard.Colors.CellTextOnHighlightValue, BitmapBoard.Colors.CellTextOnHighlightSpecial, BitmapBoard.Colors.CellTextOnHighlightPivot, BitmapBoard.Colors.CellTextOnHighlightPincer);
            pnlCellHighlightPicker.ButtonClicked += pnlCellHighlightPicker_Clicked;

            // component setup for Note Highlight control
            pnlNoteHighlightPicker.SetButtonTags((int)NoteHighlightType.None, (int)NoteHighlightType.Info, (int)NoteHighlightType.Strong, (int)NoteHighlightType.Weak, (int)NoteHighlightType.Bad);
            pnlNoteHighlightPicker.SetButtonText(NoteHighlightType.None.Description(), NoteHighlightType.Info.Description(), NoteHighlightType.Strong.Description(), NoteHighlightType.Weak.Description(), NoteHighlightType.Bad.Description());
            pnlNoteHighlightPicker.SetButtonColors(BitmapBoard.Colors.NoteHighlightNone, BitmapBoard.Colors.NoteHighlightInfo, BitmapBoard.Colors.NoteHighlightStrong, BitmapBoard.Colors.NoteHighlightWeak, BitmapBoard.Colors.NoteHighlightBad);
            pnlNoteHighlightPicker.SetButtonFontColors(BitmapBoard.Colors.NoteTextOnHighlightNone, BitmapBoard.Colors.NoteTextOnHighlightInfo, BitmapBoard.Colors.NoteTextOnHighlightStrong, BitmapBoard.Colors.NoteTextOnHighlightWeak, BitmapBoard.Colors.NoteTextOnHighlightBad);
            pnlNoteHighlightPicker.ButtonClicked += pnlNoteHighlightPicker_Clicked;

            // options buttons setup
            chkHighlightClickMode.SetButtonText(HighlightClickMode.Cell.Description(), HighlightClickMode.Note.Description(), HighlightClickMode.Manual.Description());
            chkHighlightClickMode.ButtonClicked += chkHighlightClickMode_ButtonClicked;
            chkNotesHold.SetButtonText(YesNo.No.Description(), YesNo.Yes.Description());
            chkNumberKeysMode.SetButtonText(NumberKeysMode.Numbers.Description(), NumberKeysMode.Notes.Description());
            chkRemoveOldNotes.SetButtonText(YesNo.No.Description(), YesNo.Yes.Description());
            chkRemoveOldNotes.ButtonClicked += chkRemoveOldNotes_ButtonClicked;
            chkValidationMode.SetButtonText(ValidationMode.Numbers.Description(), ValidationMode.Notes.Description(), ValidationMode.Off.Description());
            chkValidationMode.ButtonClicked += chkValidationMode_ButtonClicked;
            chkHighlightHavingValue.SetButtonText(YesNo.No.Description(), YesNo.Yes.Description());
            chkHighlightHavingValue.ButtonClicked += chkHighlightHavingValue_ButtonClicked;
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
        /// Common method to redraw the board based on current state
        /// </summary>
        private void Render()
        {
            Game.Board.Render();

            // now paint the board directly on the Form
            PaintEventArgs e = new PaintEventArgs(_gr, new Rectangle(0, 0, Width, Height));
            e.Graphics.DrawImageUnscaled(((BitmapBoard)Game.Board).Image, _xOffset, _yOffset);  // Offset x/y to prevent board from being in the far upper left (0,0) of the form 
        }

        /// <summary>
        /// Callback/Event from cell click mode to track mode and to manipulate the UI a bit per mode
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkHighlightClickMode_ButtonClicked(object sender, EventArgs e)
        {
            switch (chkHighlightClickMode.CheckState)
            {
                case CheckState.Unchecked:
                    pnlCellHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Visible = false;
                    pnlHiNumbersList.Visible = false;
                    break;
                case CheckState.Checked:
                    pnlNoteHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Top = 48;
                    pnlCellHighlightPicker.Visible = false;
                    pnlHiNumbersList.Visible = false;
                    break;
                case CheckState.Indeterminate:
                    pnlCellHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Visible = true;
                    pnlNoteHighlightPicker.Top = 79;
                    pnlHiNumbersList.Visible = true;
                    break;
            }
        }

        /// <summary>
        /// Callback/Event from Cell Highlight control to maybe trigger highlighting
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void pnlCellHighlightPicker_Clicked(object sender, EventArgs e)
        {
            // if shift click on the X, clear all cell hightlights
            if (pnlCellHighlightPicker.ClearSelected && (Control.ModifierKeys == Keys.Shift))
            {
                Game.Board.HighlightCellsWithNoteOrNumber(0);
                Render();
            }
            else if (chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Manual)
            {
                Game.Board.HighlightCell((CellHighlightType)pnlCellHighlightPicker.ActiveValue);
                Render();
            }
        }
 
        /// <summary>
        /// Callback/Event from Note Highlight control to maybe trigger highlighting
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void pnlNoteHighlightPicker_Clicked(object sender, EventArgs e)
        {
            // if shift click on the X, clear all note hightlights
            if (pnlNoteHighlightPicker.ClearSelected && (Control.ModifierKeys == Keys.Shift))
            {
                Game.Board.ClearNoteHighlights();
                Render();
            }
            else if ((chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Manual) && !Game.Board.SelectedCell.HasAnswer) // if every click needs to update the selected cell (manual mode) && the cell has note visable (no answer set)
            {
                Game.Board.HighlightNote(pnlHiNumbersList.ActiveValue, (NoteHighlightType)pnlNoteHighlightPicker.ActiveValue);
                Render();
            }
        }

        /// <summary>
        /// Set the current cell to the selected number (as a solution guess)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnSetGuess_Click(object sender, EventArgs e)
        {
            Game.Board.SetGuess(pnlFocusNumber.ActiveValue);

            if (chkHighlightHavingValue.Checked)
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            Render();
            CheckForSolved();
        }

        /// <summary>
        /// Callback/Event from Set Numbers control to maybe trigger value highlight
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void pnlSetNumbers_NumberClicked(object sender, EventArgs e)
        {
            bool render = false;

            if (chkNotesHold.Checked)
            {
                btnToggleNote_Click(sender, e);
                render = true;
            }

            if (chkHighlightHavingValue.Checked)
            {
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
                render = true;
            }
        
            if (render)
                Render();
        }

        /// <summary>
        /// Toggle select note on/off in the selected cell
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnToggleNote_Click(object sender, EventArgs e)
        {
            Game.Board.ToggleNote(pnlFocusNumber.ActiveValue);

            if (chkHighlightHavingValue.Checked)
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            Render();
        }

        /// <summary>
        /// Set the current cell to the selected number (as a Given)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnSetGiven_Click(object sender, EventArgs e)
        {
            Game.Board.SetGiven(pnlFocusNumber.ActiveValue);

            if (chkHighlightHavingValue.Checked)
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

            Render();
            CheckForSolved();
        }

        /// <summary>
        /// Find the pattern selected in the patter combo box
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnFind_Click(object sender, EventArgs e)
        {
            Pattern pattern = ((KeyValuePair<string, Pattern>)cbxPatterns.SelectedItem).Value;


            //Render();
        }

        /// <summary>
        /// Callback/Event from Value Highlight control
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkHighlightHavingValue_ButtonClicked(object sender, EventArgs e)
        {
            if (chkHighlightHavingValue.Checked)
                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
            else
                Game.Board.HighlightCellsWithNoteOrNumber(0);

            Render();
        }

        /// <summary>
        /// Callback/Event from option to remove old notes or not
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkRemoveOldNotes_ButtonClicked(Object sender, EventArgs e)
        {
            Board.RemoveOldNotes = (YesNo)chkRemoveOldNotes.CheckState;
            if ((Game.Board != null) && (Board.RemoveOldNotes != YesNo.No))
            {
                Game.Board.RemoveNotes();

                if (chkHighlightHavingValue.Checked)
                    Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

                Render();
            }
        }

        /// <summary>
        /// Callback/Event from validation options changing
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void chkValidationMode_ButtonClicked(Object sender, EventArgs e)
        {
            Board.ValidationMode = (ValidationMode)chkValidationMode.CheckState;
            if ((Game.Board != null) && (Board.ValidationMode != ValidationMode.Off))
            {
                Game.Board.CheckAndMarkDupes();
                Render();
            }
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
        /// Handle all the key events we care about, converting their value to built-in enumerations
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms key-event args</param>
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            UserInput input = UserInput.None;
            int numPressed;

            // if a non-zero number key, remember it (any better way to do this check?)
            if (int.TryParse(((char)e.KeyValue).ToString(), out numPressed) && (numPressed != 0))
            {
                // convert to custom number enum
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
                    case Keys.Z:
                        input = UserInput.Z;
                        break;
                    case Keys.Y:
                        input = UserInput.Y;
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
                    // Shift while in Numbers mode is Notes mode (so turn shift on in the modifiers flags)
                    if (!chkNumberKeysMode.Checked)
                        _modifierKey |= ModifierKey.Shift;
                }
                else
                {
                    // Non-Shift while in Notes mode means do note (so turn shift on in the modifiers flags)
                    if (chkNumberKeysMode.Checked)
                        _modifierKey |= ModifierKey.Shift;
                }

                if (e.Alt)
                    _modifierKey |= ModifierKey.Alt;

                if (e.Control)
                {
                    _modifierKey |= ModifierKey.Control;

                    // For Control-#, pretend the user selected that # as focus number
                    if ((input >= UserInput.One) && (input <= UserInput.Nine))
                    {
                        pnlFocusNumber.SimulateClick((int)input);

                        // but don't pass the key press down to cells since don't need ctrl-# to be cell based, just this outer form number selector
                        return;
                    }

                    // ctrl-z and ctrl-y
                    if (input == UserInput.Z)
                        Undo();
                    else if (input == UserInput.Y)
                        Redo();
                }

                Game.Board.HandleKeyUserInput(input, _modifierKey);

                // if in auto-highlight mode AND (pressed a number OR just deleted main number, exposing potential notes), update highlighting
                if (chkHighlightHavingValue.Checked && ((numPressed != 0) || (input == UserInput.Delete)))
                    Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);

                Render();
                CheckForSolved();
            }
        }

        // dabbling with undo/redo.  no major plans yet
        private void Undo()
        {
            ActionManager.Undo();
            Render();
        }

        // dabbling with undo/redo.  no major plans yet
        private void Redo()
        {
            ActionManager.Redo();
            Render();
        }

        /// <summary>
        /// Check if board solved
        /// </summary>
        public void CheckForSolved()
        {
            if (Game.Board.IsBoardSolved())
                MessageBox.Show("Congratulations!", "Solved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                _clickX = ((MouseEventArgs)e).X - _xOffset;
                _clickY = ((MouseEventArgs)e).Y - _yOffset;

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
                if ((_clickX >= 0) && (_clickX < board.BoardSize) && (_clickY >= 0) && (_clickY < board.BoardSize))
                {
                    if (_isDoubleClick)
                    {
                        ((BitmapBoard)Game.Board).HandlePixelXYClick(UserInput.DoubleClick, _modifierKey, _clickX, _clickY);

                        // if auto-highlighting cells and if the cell now has an answer and it does NOT match the "highlight all of that number" number, ensure it unhighlights
                        if (chkHighlightHavingValue.Checked && (Game.Board.SelectedCell.Answer != pnlFocusNumber.ActiveValue))
                            Game.Board.HighlightCell(CellHighlightType.None);

                        // if has a guess/given and old notes are to be cleared, do that
                        if (Game.Board.SelectedCell.HasAnswer && (Board.RemoveOldNotes == YesNo.Yes))
                        {
                            Game.Board.RemoveNotes(Game.Board.SelectedCell.Answer);

                            if (chkHighlightHavingValue.Checked)
                                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
                        }

                        Render();
                        CheckForSolved();
                    }
                    else if (_isRightClick)
                    {
                        ((BitmapBoard)Game.Board).HandlePixelXYClick(UserInput.RightClick, _modifierKey, _clickX, _clickY);

                        // if has a guess value, delete it
                        if (Game.Board.SelectedCell.HasAnswer && (Game.Board.SelectedCell.IsGiven.HasValue && !Game.Board.SelectedCell.IsGiven.Value))
                            frmMain_KeyDown(this, new KeyEventArgs(Keys.Delete));
                            
                        Render();
                    }
                    else // left-click
                    {
                        ((BitmapBoard)Game.Board).HandlePixelXYClick(UserInput.LeftClick, _modifierKey, _clickX, _clickY);

                        // if toggle note on click is on, do that
                        if (chkNotesHold.Checked)
                        {
                            Game.Board.ToggleNote(pnlFocusNumber.ActiveValue);

                            if (chkHighlightHavingValue.Checked)
                                Game.Board.HighlightCellsWithNoteOrNumber(pnlFocusNumber.ActiveValue);
                        }

                        // do special highlighting if Control WASN'T clicked (Control-Left click is for special strong/week coloring done in HandleXYClick)
                        if ((_modifierKey & ModifierKey.Control) == 0)
                        {
                            if (chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Cell)
                                Game.Board.HighlightCell((CellHighlightType)pnlCellHighlightPicker.ActiveValue);
                            else if ((chkHighlightClickMode.CheckState == (CheckState)HighlightClickMode.Note) && !Game.Board.SelectedCell.HasAnswer)
                                Game.Board.HighlightSelectedNote((NoteHighlightType)pnlNoteHighlightPicker.ActiveValue);
                        }

                        Render();
                    }
                }

                // allow the MouseDown event handler to process clicks again
                _isFirstClick = true;
                _isDoubleClick = false;
                _milliseconds = 0;
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
    }
}
