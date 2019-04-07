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

        public BitmapBoard(int size) : base()
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
            
        }

        // build a bitmap based on the board state
        public override void Render()
        {
            // draw all the cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].Render(_boardImage);

            // then board level things
            using (Graphics gr = Graphics.FromImage(_boardImage))
            {
                // render board border
                gr.DrawRectangle(new Pen(Color.Black, 4), 0, 0, _boardImage.Width, _boardImage.Height);

                // render block borders
                Pen p = new Pen(Color.Black, 2);
                int blockSize = _boardImage.Height / 3;
                // horizontal
                gr.DrawLine(p, 0, blockSize, _boardImage.Width, blockSize);
                gr.DrawLine(p, 0, blockSize * 2, _boardImage.Width, blockSize * 2);
                // vertical
                gr.DrawLine(p, blockSize, 0, blockSize, _boardImage.Height);
                gr.DrawLine(p, blockSize * 2, 0, blockSize * 2, _boardImage.Height);
            }
        }
    }
}
