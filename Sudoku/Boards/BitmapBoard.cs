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

        private static class DefaultColors
        {
            public static Color BoardBorder = Color.Black;
            public static Color BlockBorder = Color.Black;
            public static Color BlockAltShade = Color.GhostWhite;
            public static Color CellBorder = Color.DarkGray;
            public static Color CellBlank = Color.White;
            public static Color CellHouseSelect = Color.LavenderBlush;
            public static Color CellSelectFrame = Color.Coral;
            public static Color CellHighlightNone = SystemColors.GradientInactiveCaption;
            public static Color CellHighlightValue = Color.Lime;
            public static Color CellHighlightSpecial = Color.MediumSeaGreen;
            public static Color CellHighlightPivot = Color.LightSeaGreen;
            public static Color CellHighlightPincer = Color.Aquamarine;
            public static Color CellTextOnHighlightNone = Color.DimGray;
            public static Color CellTextOnHighlightValue = Color.DarkSlateGray;
            public static Color CellTextOnHighlightSpecial = Color.DarkSlateGray;
            public static Color CellTextOnHighlightPivot = Color.DarkSlateGray;
            public static Color CellTextOnHighlightPincer = Color.DarkSlateGray;
            public static Brush AnswerGiven = Brushes.Black;
            public static Brush AnswerGuess = Brushes.Blue;
            public static Brush AnswerInvalid = Brushes.Red;
            public static Color NoteHighlightNone = Color.Transparent;
            public static Color NoteHighlightInfo = Color.Plum;
            public static Color NoteHighlightBad = Color.Red;
            public static Color NoteHighlightStrong = Color.RoyalBlue;
            public static Color NoteHighlightWeak = Color.Yellow;
            public static Color NoteTextOnHighlightNone = Color.DimGray;
            public static Color NoteTextOnHighlightInfo = Color.DarkSlateGray;
            public static Color NoteTextOnHighlightBad = Color.LightGray;
            public static Color NoteTextOnHighlightStrong = Color.LightGray;
            public static Color NoteTextOnHighlightWeak = Color.DarkSlateGray;
        }

        public static class Colors
        {
            public static Color BoardBorder = DefaultColors.BoardBorder;
            public static Color BlockBorder = DefaultColors.BlockBorder;
            public static Color BlockAltShade = DefaultColors.BlockAltShade;
            public static Color CellBorder = DefaultColors.CellBorder;
            public static Color CellBlank = DefaultColors.CellBlank;
            public static Color CellHouseSelect = DefaultColors.CellHouseSelect;
            public static Color CellSelectFrame = DefaultColors.CellSelectFrame;
            public static Color CellHighlightNone = DefaultColors.CellHighlightNone;
            public static Color CellHighlightValue = DefaultColors.CellHighlightValue;
            public static Color CellHighlightSpecial = DefaultColors.CellHighlightSpecial;
            public static Color CellHighlightPivot = DefaultColors.CellHighlightPivot;
            public static Color CellHighlightPincer = DefaultColors.CellHighlightPincer;
            public static Color CellTextOnHighlightNone = DefaultColors.CellTextOnHighlightNone;
            public static Color CellTextOnHighlightValue = DefaultColors.CellTextOnHighlightValue;
            public static Color CellTextOnHighlightSpecial = DefaultColors.CellTextOnHighlightSpecial;
            public static Color CellTextOnHighlightPivot = DefaultColors.CellTextOnHighlightPivot;
            public static Color CellTextOnHighlightPincer = DefaultColors.CellTextOnHighlightPincer;
            public static Brush AnswerGiven = DefaultColors.AnswerGiven;
            public static Brush AnswerGuess = DefaultColors.AnswerGuess;
            public static Brush AnswerInvalid = DefaultColors.AnswerInvalid;
            public static Color NoteHighlightNone = DefaultColors.NoteHighlightNone;
            public static Color NoteHighlightInfo = DefaultColors.NoteHighlightInfo;
            public static Color NoteHighlightBad = DefaultColors.NoteHighlightBad;
            public static Color NoteHighlightStrong = DefaultColors.NoteHighlightStrong;
            public static Color NoteHighlightWeak = DefaultColors.NoteHighlightWeak;
            public static Color NoteTextOnHighlightNone = DefaultColors.NoteTextOnHighlightNone;
            public static Color NoteTextOnHighlightInfo = DefaultColors.NoteTextOnHighlightInfo;
            public static Color NoteTextOnHighlightBad = DefaultColors.NoteTextOnHighlightBad;
            public static Color NoteTextOnHighlightStrong = DefaultColors.NoteTextOnHighlightStrong;
            public static Color NoteTextOnHighlightWeak = DefaultColors.NoteTextOnHighlightWeak;
        }

        private static class DefaultFonts
        {
            public static string Answer = "Century Gothic";
            public static string Note = "Arial";
        }

        public static class Fonts
        {
            public static string Answer = DefaultFonts.Answer;
            public static string Note = DefaultFonts.Note;
        }

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
        /// Ctor
        /// </summary>
        /// <param name="cellSize">Pixel size of each cell (used in render calculations)</param>
        public BitmapBoard(int cellSize) : base()
        {
            _boardSize = cellSize * 9;
            _boardImage = new Bitmap(_boardSize, _boardSize);

            // create all the child cells as two-dimensional array
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
            if (x < 0 || x > _boardImage.Height || y < 0 || y > _boardImage.Width)
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
                if (input == UserInput.DoubleClick && _selectedCell.HasAnswer)
                    CheckAndMarkDupes();
            }
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

                // render board border
                BitmapBoard.Graphics.DrawRectangle(new Pen(BitmapBoard.Colors.BoardBorder, 4), 0, 0, _boardImage.Width, _boardImage.Height);

                // render block borders
                Pen p = new Pen(BitmapBoard.Colors.BlockBorder, 2);
                int blockSize = cellSize * 3;
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
