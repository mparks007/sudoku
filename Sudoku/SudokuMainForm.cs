using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class frmMain : Form
    {
        private Graphics _gr;
        private Timer _doubleClickTimer = new Timer();
        private bool _isFirstClick = true;
        private bool _isRightClick;
        private bool _isDoubleClick;
        private int _milliseconds;
        private int _clickX;
        private int _clickY;
        private int _activeNumber = 1;
        private RadioButton _priorFocusNumber;
        private int xOffset = 20;
        private int yOffset = 20;
        private ModifierKey _modifierKey = ModifierKey.None;

        public frmMain()
        {
            InitializeComponent();
            _priorFocusNumber = this.rad1;
            _gr = this.CreateGraphics();

            _doubleClickTimer.Interval = 35;
            _doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);

            Game game = Game.GetInstance(BoardType.Bitmap, cellSize: 60);

            // test code vvv
            Game.Board.SelectHousesOfCellAtRowCol(3, 3);
            Game.Board.SelectCellAtRowCol(1, 1);
            Game.Board.Cells[6][3].SetNote(2);
            Game.Board.Cells[2][5].SetNote(2);

            Game.Board.Cells[6][3].HighlightNote(2, NoteHighlightType.Info);
            Game.Board.Cells[2][5].HighlightNote(2, NoteHighlightType.Info);

            Game.Board.Cells[3][6].SetNumber(6, isGiven: false);
            Game.Board.Cells[2][2].SetNumber(2, isGiven: true);

            Game.Board.Cells[1][6].SetNote(8);
            Game.Board.Cells[1][6].HighlightNote(8, NoteHighlightType.Weak);

            Game.Board.Cells[4][4].SetNote(3);
            Game.Board.Cells[4][4].HighlightNote(3, NoteHighlightType.Strong);

            Game.Board.Cells[7][5].SetNote(7);
            Game.Board.Cells[7][5].HighlightNote(7, NoteHighlightType.Info);

            Game.Board.Cells[8][7].SetNote(1);
            Game.Board.Cells[8][7].SetNote(2);
            Game.Board.Cells[8][7].HighlightNote(2, NoteHighlightType.Bad);

            Game.Board.Cells[0][0].SetNote(1);
            Game.Board.Cells[8][8].SetNote(4);
            Game.Board.Cells[0][7].SetNote(5);
            Game.Board.Cells[8][0].SetNote(6);
            Game.Board.Cells[3][7].SetNote(9);

            Game.Board.HighlightCellsWithNoteOrNumber(2);
            // test code ^^^

            Render();
        }

        private void Render()
        {
            Game.Board.Render();
            PaintEventArgs e = new PaintEventArgs(_gr, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImageUnscaled(((BitmapBoard)Game.Board).Image, xOffset, yOffset);
        }


        private void btnHiWithValue_Click(object sender, EventArgs e)
        {
            Game.Board.HighlightCellsWithNoteOrNumber(_activeNumber);
            Render();
        }

        private void btnSetNote_Click(object sender, EventArgs e)
        {
            Game.Board.Cells[Game.Board.SelectedCell.Row-1][Game.Board.SelectedCell.Column-1].SetNote(_activeNumber);
            Render();
        }


        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (radSetNone.Checked)
                Game.Board.Cells[Game.Board.SelectedCell.Row-1][Game.Board.SelectedCell.Column-1].SetNumber(0, isGiven: false);
            else
                Game.Board.Cells[Game.Board.SelectedCell.Row-1][Game.Board.SelectedCell.Column-1].SetNumber(_activeNumber, isGiven: radSetGiven.Checked);

            Game.Board.Cells[Game.Board.SelectedCell.Row-1][Game.Board.SelectedCell.Column-1].IsInvalid = radSetInvalid.Checked;
            Render();
        }

        private void btnHiNote_Click(object sender, EventArgs e)
        {
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

            Game.Board.Cells[Game.Board.SelectedCell.Row-1][Game.Board.SelectedCell.Column-1].HighlightNote(_activeNumber, type);
            Render();
        }

        // Arrow keys act funky on Forms and move through various controls so I am trapping them early, pretending was KeyDown, then eating the key to avoid further form processing
        // Also needing to trap the modifiers keys to pass them down to mouse click events
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            _modifierKey = ModifierKey.None;

            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
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

            // otherwise, process as normal (which will get other keys over to KeyDown automatically)
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            UserInput input = UserInput.None;

            int numPressed;
            // if a number key
            if (int.TryParse(((char)e.KeyValue).ToString(), out numPressed) && numPressed != 0)
            {
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
                if (e.Shift || chkNotesMode.Checked)
                    _modifierKey |= ModifierKey.Shift;
                if (e.Alt)
                    _modifierKey |= ModifierKey.Alt;
                if (e.Control)
                    _modifierKey |= ModifierKey.Control;

                Game.Board.HandleKeyUserInput(input, _modifierKey);
                Render();
            }
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            _isRightClick = (e.Button == MouseButtons.Right);

            if (_isFirstClick)
            {
                _isFirstClick = false;
                    
                // offset since the args x/y are form based and I want the board area instead
                _clickX = ((MouseEventArgs)e).X - xOffset;
                _clickY = ((MouseEventArgs)e).Y - yOffset;
                _doubleClickTimer.Start();
            }
            else
            {
                if (_milliseconds < SystemInformation.DoubleClickTime)
                    _isDoubleClick = true;
            }
        }

        void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            _milliseconds += 150;

            // The timer has reached the double click time limit.
            if (_milliseconds >= SystemInformation.DoubleClickTime)
            {
                _doubleClickTimer.Stop();

                BitmapBoard board = (BitmapBoard)Game.Board;

                // if clicked in the board area of the form
                if (_clickX >= 0 && _clickX <= board.BoardSize && _clickY >= 0 && _clickY <= board.BoardSize)
                {
                    if (_isDoubleClick)
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.DoubleClick, _modifierKey, _clickX, _clickY);
                    else if (_isRightClick)
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.RightClick, _modifierKey, _clickX, _clickY);
                    else
                        ((BitmapBoard)Game.Board).HandleXYClick(UserInput.LeftClick, _modifierKey, _clickX, _clickY);
                }

                // Allow the MouseDown event handler to process clicks again.
                _isFirstClick = true;
                _isDoubleClick = false;
                _milliseconds = 0;

                Render();
            }
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            _priorFocusNumber.BackColor = SystemColors.Highlight;
            rad.BackColor = SystemColors.GradientActiveCaption;
            _priorFocusNumber = rad;

            _activeNumber = Int32.Parse(rad.Tag.ToString());
        }
    }
}
