using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class frmMain : Form
    {
        private Graphics _gr;                   // to snag the Form's graphics object for use in Render call vs. snagging it every time Render is called
        private int _activeNumber = 1;          // the starting selected number
        private RadioButton _priorFocusNumber;  // the number selected before selecting a new number (to toggle UI look back to unselected)
        private int xOffset = 20;               // how far over from Form's left edge to start painting the board
        private int yOffset = 20;               // how far down from Form's top edge to start painting the board
        private ModifierKey _modifierKey = ModifierKey.None;    // keeping track of atl, shift, ctrl state at the time of early key trapping and normal keypress events

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
            _priorFocusNumber = this.rad1;
            _gr = this.CreateGraphics();

            // setup time for click/doubleclick hack code :(
            _doubleClickTimer.Interval = 35;
            _doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);

            Game.CreateInstance(BoardType.Bitmap, cellSize: 60);
            Game.Board.SelectCellAtRowCol(1, 1);

            //// test code start vvv
            //Game.Board.SelectHousesOfCellAtRowCol(3, 3);
            //Game.Board.SelectCellAtRowCol(1, 1);
            //Game.Board.Cells[6][3].ToggleNote(2);
            //Game.Board.Cells[2][5].ToggleNote(2);

            //Game.Board.Cells[6][3].HighlightNote(2, NoteHighlightType.Info);
            //Game.Board.Cells[2][5].HighlightNote(2, NoteHighlightType.Info);

            //Game.Board.Cells[3][6].SetGuess(6);
            //Game.Board.Cells[2][2].SetGiven(2);

            //Game.Board.Cells[1][6].ToggleNote(8);
            //Game.Board.Cells[1][6].HighlightNote(8, NoteHighlightType.Weak);

            //Game.Board.Cells[4][4].ToggleNote(3);
            //Game.Board.Cells[4][4].HighlightNote(3, NoteHighlightType.Strong);

            //Game.Board.Cells[7][5].ToggleNote(7);
            //Game.Board.Cells[7][5].HighlightNote(7, NoteHighlightType.Info);

            //Game.Board.Cells[8][7].ToggleNote(1);
            //Game.Board.Cells[8][7].ToggleNote(2);
            //Game.Board.Cells[8][7].HighlightNote(2, NoteHighlightType.Bad);

            //Game.Board.Cells[0][0].ToggleNote(1);
            //Game.Board.Cells[8][8].ToggleNote(4);
            //Game.Board.Cells[0][7].ToggleNote(5);
            //Game.Board.Cells[8][0].ToggleNote(6);
            //Game.Board.Cells[3][7].ToggleNote(9);

            //Game.Board.HighlightCellsWithNoteOrNumber(2);
            //// test code end ^^^

            Render();
        }

        /// <summary>
        /// Common method to redraw the board based on current state
        /// </summary>
        private void Render()
        {
            Game.Board.Render();

            // now paint the board directly on the Form
            PaintEventArgs e = new PaintEventArgs(_gr, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImageUnscaled(((BitmapBoard)Game.Board).Image, xOffset, yOffset);  // Offset x/y to prevent board from being in the far upper left (0,0) of the form 
        }

        /// <summary>
        /// Highlight all cells that have the selected number in them (whether as a Given, an Answer, or a Note)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnHighlightHavingValue_Click(object sender, EventArgs e)
        {
            Game.Board.HighlightCellsWithNoteOrNumber(_activeNumber);
            Render();
        }

        /// <summary>
        /// Add or Remove a Note of the currently selected number
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnToggleNote_Click(object sender, EventArgs e)
        {
            Game.Board.ToggleNote(_activeNumber);
            Render();
        }

        /// <summary>
        /// Toggle the note highlight option and try to hightlight the note for the number of choice
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms radiocheck-event args</param>
        private void radHighlightNoteClick(object sender, EventArgs e)
        {
            pnlHiNoteOuter.BackColor = ((RadioButton)sender).BackColor;

            NoteHighlightType type = NoteHighlightType.None;

            if (radHiNone.Checked)
                type = NoteHighlightType.None;
            else if (radHiInfo.Checked)
                type = NoteHighlightType.Info;
            else if (radHiBad.Checked)
                type = NoteHighlightType.Bad;
            else if (radHiStrong.Checked)
                type = NoteHighlightType.Strong;
            else if (radHiWeak.Checked)
                type = NoteHighlightType.Weak;

            Game.Board.HighlightNote(_activeNumber, type);
            Render();
        }

        /// <summary>
        /// Set the current cell to the selected number (as a solution guess)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnSetGuess_Click(object sender, EventArgs e)
        {
            Game.Board.SetGuess(_activeNumber);
            Render();
        }

        /// <summary>
        /// Set the current cell to the selected number (as a Given)
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnSetGiven_Click(object sender, EventArgs e)
        {
            Game.Board.SetGiven(_activeNumber);
            Render();
        }

        /// <summary>
        /// Clicking one of the "this is my current number to mess with" buttons
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms click-event args</param>
        private void btnNumbers_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            // flip the prior number seletion back to un-selected look/feel
            _priorFocusNumber.BackColor = SystemColors.Highlight;
            _priorFocusNumber.ForeColor = SystemColors.GradientInactiveCaption;
            // flip the new selection to unique look/feel
            rad.BackColor = SystemColors.GradientActiveCaption;
            rad.ForeColor = SystemColors.Highlight;

            _priorFocusNumber = rad;

            _activeNumber = Int32.Parse(rad.Tag.ToString());
        }

        /// <summary>
        /// Toggle Notes/Numbers mode (and button text to make it look "checked")
        /// </summary>
        /// <param name="sender">Standard WinForms sender</param>
        /// <param name="e">Standard WinForms check-event args</param>
        private void chkNumberMode_CheckedChanged(object sender, EventArgs e)
        {
            chkNumberMode.Text = (chkNumberMode.Checked ? "Notes" : "Numbers");
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
                if (e.Shift || chkNumberMode.Checked)    // borrowing Shift to also allow quick Note adding
                    _modifierKey |= ModifierKey.Shift;
                if (e.Alt)
                    _modifierKey |= ModifierKey.Alt;
                if (e.Control)
                {
                    _modifierKey |= ModifierKey.Control;

                    // Contrl-#, pretend the user selected that # as focus number
                    if (input >= UserInput.One && input <= UserInput.Nine)
                    {
                        RadioButton[] numButtons = { rad1, rad2, rad3, rad4, rad5, rad6, rad7, rad8, rad9 };
                        btnNumbers_Click(numButtons[(int)input-1], new EventArgs());

                        // but don't pass the key press down to cells since don't want ctrl-# to be cell based, just this outer form number selector
                        return;
                    }
                }

                Game.Board.HandleKeyUserInput(input, _modifierKey);
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
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.DoubleClick, _modifierKey, _clickX, _clickY);
                    else if (_isRightClick)
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.RightClick, _modifierKey, _clickX, _clickY);
                    else
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.LeftClick, _modifierKey, _clickX, _clickY);
                }

                // allow the MouseDown event handler to process clicks again
                _isFirstClick = true;
                _isDoubleClick = false;
                _milliseconds = 0;

                Render();
            }
        }
    }
}
