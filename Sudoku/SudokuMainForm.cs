﻿using System;
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

        public frmMain()
        {
            InitializeComponent();
            button4_Click(this, new EventArgs());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int cellSize = Convert.ToInt32(txtSize.Text);

            pictureBox1.Image = null;
            pictureBox1.Width = pictureBox1.Height = cellSize * 9;

            Game game = Game.GetInstance(BoardType.Bitmap, cellSize);

            // test code vvv
            Game.Board.SelectHousesOfCellAtRowCol(3, 3);
            Game.Board.SelectCellAtRowCol(6, 6, deselectOthers: true);
            Game.Board._cells[6][3].SetNote(2, doSet: true);
            Game.Board._cells[2][5].SetNote(2, doSet: true);

            Game.Board._cells[6][3].HighlightNote(2, NoteHighlightType.Info);
            Game.Board._cells[2][5].HighlightNote(2, NoteHighlightType.Info);

            Game.Board._cells[3][6].SetNumber(6, isGiven: false);
            Game.Board._cells[2][2].SetNumber(2, isGiven: true);

            Game.Board._cells[1][6].SetNote(8, doSet: true);
            Game.Board._cells[1][6].HighlightNote(8, NoteHighlightType.Weak);

            Game.Board._cells[4][4].SetNote(3, doSet: true);
            Game.Board._cells[4][4].HighlightNote(3, NoteHighlightType.Strong);

            Game.Board._cells[7][5].SetNote(7, doSet: true);
            Game.Board._cells[7][5].HighlightNote(7, NoteHighlightType.Info);

            Game.Board._cells[8][7].SetNote(1, doSet: true);
            Game.Board._cells[8][7].SetNote(2, doSet: true);
            Game.Board._cells[8][7].HighlightNote(2, NoteHighlightType.Bad);

            Game.Board._cells[0][0].SetNote(1, doSet: true);
            Game.Board._cells[8][8].SetNote(4, doSet: true);
            Game.Board._cells[0][7].SetNote(5, doSet: true);
            Game.Board._cells[8][0].SetNote(6, doSet: true);
            Game.Board._cells[3][7].SetNote(9, doSet: true);

            Game.Board.HighlightCellsWithNoteOrNumber(2);

            // test code ^^^
            Render();
        }

        private void Render()
        {
            Game.Board.Render();
            pictureBox1.Image = ((BitmapBoard)Game.Board).Image;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (sender == pictureBox1)
                txtCoords.Text = String.Format("X:{0},Y:{1}", e.Location.X, e.Location.Y);
        }

        private void btnSelCell_Click(object sender, EventArgs e)
        {
            Game.Board.SelectCellAtRowCol(Convert.ToInt32(txtRow.Text), Convert.ToInt32(txtCol.Text), deselectOthers:true);
            Game.Board.SelectHousesOfCellAtRowCol(Convert.ToInt32(txtRow.Text), Convert.ToInt32(txtCol.Text));
            Render();
        }

        private void btnHiWithValue_Click(object sender, EventArgs e)
        {
            Game.Board.HighlightCellsWithNoteOrNumber(Convert.ToInt32(txtValue.Text));
            Render();
        }

        private void btnSetNote_Click(object sender, EventArgs e)
        {
            Game.Board._cells[Convert.ToInt32(txtRow.Text)-1][Convert.ToInt32(txtCol.Text)-1].SetNote(Convert.ToInt32(txtNote.Text), doSet: true);
            Render();
        }

        private void btnClearNote_Click(object sender, EventArgs e)
        {
            Game.Board._cells[Convert.ToInt32(txtRow.Text) - 1][Convert.ToInt32(txtCol.Text) - 1].SetNote(Convert.ToInt32(txtNote.Text), doSet: false);
            Render();
        }

        private void btnSelHouse_Click(object sender, EventArgs e)
        {
            Game.Board.SelectHousesOfCellAtRowCol(Convert.ToInt32(txtRow.Text), Convert.ToInt32(txtCol.Text));
            Render();
        }

        private void btnAnswer_Click(object sender, EventArgs e)
        {
            if (radSetNone.Checked)
                Game.Board._cells[Convert.ToInt32(txtRow.Text) - 1][Convert.ToInt32(txtCol.Text) - 1].SetNumber(0, isGiven: false);
            else
                Game.Board._cells[Convert.ToInt32(txtRow.Text) - 1][Convert.ToInt32(txtCol.Text) - 1].SetNumber(Convert.ToInt32(txtNum.Text), isGiven: radSetGiven.Checked);

            Game.Board._cells[Convert.ToInt32(txtRow.Text) - 1][Convert.ToInt32(txtCol.Text) - 1].IsInvalid = radSetInvalid.Checked;
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

            Game.Board._cells[Convert.ToInt32(txtRow.Text) - 1][Convert.ToInt32(txtCol.Text) - 1].HighlightNote(Convert.ToInt32(txtNote.Text), type);
            Render();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            UserInput input = UserInput.None;

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
                    if (e.Alt)
                        input = UserInput.AltHome;
                    else if (e.Control)
                        input = UserInput.CtrlHome;
                    else
                        input = UserInput.Home;
                    break;
                case Keys.End:
                    if (e.Alt)
                        input = UserInput.AltEnd;
                    else if (e.Control)
                        input = UserInput.CtrlEnd;
                    else
                        input = UserInput.End;
                    break;
                case Keys.Tab:
                    input = (e.Shift ? UserInput.ShiftTab : UserInput.Tab);
                    break;
            }
            Game.Board.HandleKeyUserInput(input);
            Render();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Game.Board.HandleMouseUserInput(UserInput.LeftClick, ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            // how do I hit this vs. click always happening even when I double click??
            Game.Board.HandleMouseUserInput(UserInput.DoubleClick, ((MouseEventArgs)e).X, ((MouseEventArgs)e).Y);
        }
    }
}
