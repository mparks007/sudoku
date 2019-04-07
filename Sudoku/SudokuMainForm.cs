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
        }
    }
}
