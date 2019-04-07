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
        private CellOld[] cell= new CellOld[9];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                cell[i] = new CellOld(this, 25, i * 90, 90, 90, Color.White, Color.LightGray, Color.LightGreen, Color.DarkGray, Color.DarkGreen, Color.Red, Color.Yellow);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (cell != null)
            //    cell.ToggleHighlight();
        }

        private void chkNotes_CheckedChanged(object sender, EventArgs e)
        {
            //if (cell != null)
            //    cell.IsNoteMode = chkNotes.Checked;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (cell != null)
            //    cell.ToggleNote(Convert.ToInt32(textBox1.Text));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Game game = Game.GetInstance(BoardType.Bitmap);

            Game.Board.Render();
            pictureBox1.Image = ((BitmapBoard)Game.Board).Image;
            textBox2.Text = Game.Board.ToJson();
        }
    }
}
