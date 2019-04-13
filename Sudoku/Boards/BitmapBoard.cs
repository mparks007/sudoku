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
        public static Graphics Graphics;
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

        public BitmapBoard(int cellSize)
        {
            _boardImage = new Bitmap(cellSize * 9, cellSize * 9);
            _boardSize = _boardImage.Width;

            _cells = new Cell[9][];
            for (int r = 0; r < 9; r++)
            {
                _cells[r] = new Cell[9];
                for (int c = 0; c < 9; c++)
                {
                    int v = (r / 3);
                    int h = (c / 3);
                    int block = (3 * v) + h;

                    // making as derived class here vs. just Board
                    _cells[r][c] = new BitmapCell(r + 1, c + 1, block + 1);
                }
            }
        }

        // set state data based on which cell was clicked and which note-in-cell was clicked
        public void HandleXYClick(int x, int y)
        {
            if (_boardImage == null)
                throw new InvalidOperationException("No board exists");

            if (x < 0 || x > _boardImage.Height || y < 0 || y > _boardImage.Width)
                throw new ArgumentException(String.Format("Invalid point requested (x:{0}, y:{1})", x, y));

            // do stuff to calculate the cell loc
            // TODO
        }

        // build a bitmap based on the board state
        public override void Render()
        {
            // will share this same Graphics object down into cell and note rendering
            using (BitmapBoard.Graphics = Graphics.FromImage(_boardImage))
            {
                int cellSize = _boardImage.Width / 9;

                // render all the cells (which will render their own notes)
                for (int r = 0; r < 9; r++)
                    for (int c = 0; c < 9; c++)
                        _cells[r][c].Render(cellSize);

                // render board border
                BitmapBoard.Graphics.DrawRectangle(new Pen(Color.Black, 4), 0, 0, _boardImage.Width, _boardImage.Height);

                // render block borders
                Pen p = new Pen(Color.Black, 2);
                int blockSize = _boardImage.Height / 3;
                // horizontal bars
                BitmapBoard.Graphics.DrawLine(p, 0, blockSize, _boardImage.Width, blockSize);
                BitmapBoard.Graphics.DrawLine(p, 0, blockSize * 2, _boardImage.Width, blockSize * 2);
                // vertical bars
                BitmapBoard.Graphics.DrawLine(p, blockSize, 0, blockSize, _boardImage.Height);
                BitmapBoard.Graphics.DrawLine(p, blockSize * 2, 0, blockSize * 2, _boardImage.Height);
                BitmapBoard.Graphics.Flush();
            }
        }
    }
}
