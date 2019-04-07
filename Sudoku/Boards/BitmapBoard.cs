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

        public BitmapBoard(int cellSize) : base()
        {
            _boardImage = new Bitmap(cellSize * 9, cellSize * 9);

            _cells = new Cell[9][];
            for (int r = 0; r < 9; r++)
            {
                _cells[r] = new Cell[9];
                for (int c = 0; c < 9; c++)
                {
                    int v = (r / 3);
                    int h = (c / 3);
                    int block = (3 * v) + h;

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
            
        }

        // build a bitmap based on the board state
        public override void Render()
        {
            // test code vvv
            SelectHouseOfCellAtRowCol(3, 3, HouseType.Row, deselectOthers: true);
            SelectHouseOfCellAtRowCol(3, 3, HouseType.Column, deselectOthers: false);
            SelectHouseOfCellAtRowCol(3, 3, HouseType.Block, deselectOthers: false);
            SelectCellAtRowCol(5, 5, deselectOthers: true);
            _cells[6][3].SetNote(2, doSet: true);
            _cells[2][5].SetNote(2, doSet: true);
            HighlightCellsWithNote(2);
            _cells[3][6].SetSolve(6, isGiven: false);
            _cells[2][2].SetSolve(2, isGiven: true);
            _cells[4][4].SetNote(8, doSet: true);
            _cells[7][5].SetNote(7, doSet: true);
            _cells[8][7].SetNote(1, doSet: true);
            _cells[8][7].SetNote(2, doSet: true);
            // test code ^^^

            // render all the cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].Render(_boardImage);

            // then render board-level aspects
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
