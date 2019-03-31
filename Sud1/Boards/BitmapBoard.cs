using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class BitmapBoard : Board
    {
        private Bitmap _boardImage;

        public Bitmap Image
        {
            get
            {
                if (_boardImage == null)
                    throw new InvalidOperationException("No board exists");

                return _boardImage;
            }
        }

        public BitmapBoard(int size)
        {
            _boardImage = new Bitmap(size, size);
        }

        // set state data based on which cell was clicked and which note-in-cell was clicked
        public void HandleXYClick(int x, int y)
        {
            if (_boardImage == null)
                throw new InvalidOperationException("No board exists");

            if (x < 0 || x > _boardImage.Height || y < 0 || y > _boardImage.Width)
                throw new ArgumentException(String.Format("Invalid point requested (x:{0}, y:{1})", x, y));

            // do stuff to calculate the cell loc
            //Cell cell = null;
        }


        // build a bitmap based on the board state
        public override void Render()
        {
            using (Graphics gr = Graphics.FromImage(_boardImage))
            {
                gr.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(10, 10, 50, 90);
                gr.FillEllipse(Brushes.LightGreen, rect);
                using (Pen thick_pen = new Pen(Color.Blue, 5))
                {
                    gr.DrawEllipse(thick_pen, rect);
                }

                gr.DrawString("board", new Font("Tahoma", 10), Brushes.Black, rect);
            }
        }
    }
}
