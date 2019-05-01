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
        private Bitmap _boardImage;         // bitmap that everything draws on for this board type

        public static Graphics Graphics;    // sharing common graphics object for board, its children cells, and their notes vs. asking for a new one at each level
       
        public Bitmap Image
        {
            get
            {
                if (_boardImage == null)
                    throw new InvalidOperationException("No board exists");

                return _boardImage;
            }
        }

        /// <summary>
        /// Ctor to create all cells
        /// </summary>
        /// <param name="cellSize">Pixel size of each cell (used in render calculations)</param>
        public BitmapBoard(int cellSize) : base()
        {
            _boardSize = cellSize * 9;
            _boardImage = new Bitmap(_boardSize, _boardSize);

            // create all the child cells as two-dimensional array
            _cells = new BitmapCell[9][];
            for (int r = 0; r < 9; r++)
            {
                _cells[r] = new BitmapCell[9];
                for (int c = 0; c < 9; c++)
                {
                    int v = (r / 3);
                    int h = (c / 3);
                    int block = (3 * v) + h; // thanks, Cody!

                    // making as derived class here vs. just Board
                    _cells[r][c] = new BitmapCell(cellSize, r + 1, c + 1, block + 1);
                }
            }
        }

        /// <summary>
        /// Set state data based on which cell in the board was clicked 
        /// </summary>
        /// <param name="input">Type of click (right, left, double)</param>
        /// <param name="modifierKey">Key modifier (shift, alt, control)</param>
        /// <param name="x">X pixel location clicked in the main board</param>
        /// <param name="y">Y pixel location clicked in the main board</param>
        public void HandlePixelXYClick(UserInput input, ModifierKey modifierKey, int x, int y)
        {
            if (_boardImage == null)
                throw new InvalidOperationException("No board exists");

            // make sure didn't click outside the board
            if ((x < 0) || (x > _boardImage.Height) || (y < 0) || (y > _boardImage.Width))
                throw new ArgumentException(String.Format("Invalid point requested (x:{0}, y:{1})", x, y));

            // convert clicked pixels to specific row/col in main board
            int row = y / (_boardSize / 9) + 1;
            int col = x / (_boardSize / 9) + 1;

            SelectCellAtRowCol(row, col);

            // if notes are visible (no answer set), trigger special cell-level events
            if (!_selectedCell.HasAnswer)
            {
                ((BitmapCell)_selectedCell).HandlePixelXYClick(input, modifierKey, x, y);

                // if now has answer, must have been a double-click of note to promote to answer, so check for dupes
                if ((input == UserInput.DoubleClick) && _selectedCell.HasAnswer)
                    CheckAndMarkDupes();

                ActionManager.AddState(CellsAsJSON());
            }
        }

        /// <summary>
        /// Load JSON version of cell data into the board's cell data
        /// </summary>
        /// <param name="cellJSON"></param>
        public void LoadCells(string cellJSON)
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            var selectedCellBeforeLoad = _selectedCell;

            _cells = JsonConvert.DeserializeObject<BitmapCell[][]>(cellJSON, settings);

            // put select on same spot to appear that nothing happened to all the cell references during the load
            SelectCellAtRowCol(selectedCellBeforeLoad.Row, selectedCellBeforeLoad.Column);
        }

        /// <summary>
        /// Render a bitmap based on the board state
        /// </summary>
        public override void Render()
        {
            using (BitmapBoard.Graphics = Graphics.FromImage(_boardImage))
            {
                int cellSize = _boardImage.Width / 9;

                // render all the cells (which will render their own notes)
                for (int r = 0; r < 9; r++)
                    for (int c = 0; c < 9; c++)
                        _cells[r][c].Render();

                // render block borders
                Pen p = new Pen(Colors.Instance.BlockBorder, 2);
                int blockSize = cellSize * 3;
                // horizontal bars
                BitmapBoard.Graphics.DrawLine(p, 0, blockSize, _boardImage.Width, blockSize);
                BitmapBoard.Graphics.DrawLine(p, 0, blockSize * 2, _boardImage.Width, blockSize * 2);
                // vertical bars
                BitmapBoard.Graphics.DrawLine(p, blockSize, 0, blockSize, _boardImage.Height);
                BitmapBoard.Graphics.DrawLine(p, blockSize * 2, 0, blockSize * 2, _boardImage.Height);
                BitmapBoard.Graphics.Flush();

                // render board border
                BitmapBoard.Graphics.DrawRectangle(new Pen(Colors.Instance.BoardBorder, 4), 0, 0, _boardImage.Width, _boardImage.Height);
            }
        }
    }
}
