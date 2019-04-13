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
        private Graphics gr;
        private Timer doubleClickTimer = new Timer();
        private bool isFirstClick = true;
        private bool isDoubleClick;
        private int milliseconds;
        private int clickX;
        private int clickY;
        private int _activeNumber = 1;
        private RadioButton priorNumber;

        public frmMain()
        {
            InitializeComponent();
            priorNumber = this.rad1;
            gr = this.CreateGraphics();

            doubleClickTimer.Interval = 35;
            doubleClickTimer.Tick += new EventHandler(doubleClickTimer_Tick);

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
            PaintEventArgs e = new PaintEventArgs(gr, new Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImageUnscaled(((BitmapBoard)Game.Board).Image, 20, 20);
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
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Up:
                case Keys.Down:
                case Keys.Left:
                case Keys.Right:
                    frmMain_KeyDown(this, new KeyEventArgs(keyData));
                    return true;
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
                var modifierKey = ModifierKey.None;
                if (e.Shift)
                    modifierKey |= ModifierKey.Shift;
                if (e.Alt || chkNotesMode.Checked)
                    modifierKey |= ModifierKey.Alt;
                if (e.Control)
                    modifierKey |= ModifierKey.Control;

                Game.Board.HandleKeyUserInput(input, modifierKey);
                Render();
            }
        }

        private void frmMain_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }

        private void frmMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (isFirstClick)
            {
                isFirstClick = false;
                clickX = ((MouseEventArgs)e).X;
                clickY = ((MouseEventArgs)e).Y;
                doubleClickTimer.Start();
            }
            else
            {
                if (milliseconds < SystemInformation.DoubleClickTime)
                    isDoubleClick = true;
            }
        }

        void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            milliseconds += 150;

            // The timer has reached the double click time limit.
            if (milliseconds >= SystemInformation.DoubleClickTime)
            {
                doubleClickTimer.Stop();

                if (isDoubleClick)
                {
                    Game.Board.HandleMouseUserInput(UserInput.DoubleClick, clickX, clickY);
                }
                else
                {
                    Game.Board.HandleMouseUserInput(UserInput.LeftClick, clickX, clickY);
                }

                // Allow the MouseDown event handler to process clicks again.
                isFirstClick = true;
                isDoubleClick = false;
                milliseconds = 0;

                Render();
            }
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            RadioButton rad = (RadioButton)sender;

            priorNumber.BackColor = SystemColors.Highlight;
            rad.BackColor = SystemColors.GradientActiveCaption;
            priorNumber = rad;

            _activeNumber = Int32.Parse(rad.Tag.ToString());
        }
    }
}
