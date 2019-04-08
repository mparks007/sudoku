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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Game game = Game.GetInstance(BoardType.Bitmap, 60);

            Game.Board.Render();
            pictureBox1.Image = ((BitmapBoard)Game.Board).Image;
            textBox2.Text = Game.Board.ToJson();

            // test code vvv
            Game.Board.SelectHouseOfCellAtRowCol(3, 3, HouseType.Row, deselectOthers: true);
            Game.Board.SelectHouseOfCellAtRowCol(3, 3, HouseType.Column, deselectOthers: false);
            Game.Board.SelectHouseOfCellAtRowCol(3, 3, HouseType.Block, deselectOthers: false);
            Game.Board.SelectCellAtRowCol(6, 6, deselectOthers: true);
            Game.Board._cells[6][3].SetNote(2, doSet: true);
            Game.Board._cells[2][5].SetNote(2, doSet: true);

            Game.Board.HighlightCellsWithNote(2);
            Game.Board._cells[6][3].HighlightNote(2, NoteHighlightType.Info);
            Game.Board._cells[2][5].HighlightNote(2, NoteHighlightType.Info);

            Game.Board._cells[3][6].SetSolve(6, isGiven: false);
            Game.Board._cells[2][2].SetSolve(2, isGiven: true);

            Game.Board._cells[1][6].SetNote(8, doSet: true);
            Game.Board._cells[1][6].HighlightNote(8, NoteHighlightType.Weak);

            Game.Board._cells[4][4].SetNote(3, doSet: true);
            Game.Board._cells[4][4].HighlightNote(3, NoteHighlightType.Strong);

            Game.Board._cells[7][5].SetNote(7, doSet: true);
            Game.Board._cells[7][5].HighlightNote(7, NoteHighlightType.Info);

            //_cells[8][7].SetNote(1, doSet: true);
            Game.Board._cells[8][7].SetNote(2, doSet: true);
            Game.Board._cells[8][7].HighlightNote(2, NoteHighlightType.Bad);

            Game.Board._cells[0][0].SetNote(1, doSet: true);
            Game.Board._cells[8][8].SetNote(4, doSet: true);
            Game.Board._cells[0][7].SetNote(5, doSet: true);
            Game.Board._cells[8][0].SetNote(6, doSet: true);
            Game.Board._cells[3][7].SetNote(9, doSet: true);

            // test code ^^^
            Game.Board.Render();
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            textBox3.Text = String.Format("X:{0},Y:{1}", e.Location.X, e.Location.Y);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Game.Board.HighlightCellsWithNote(Convert.ToInt32(txtNote.Text));
            Game.Board.Render();
        }
    }
}
