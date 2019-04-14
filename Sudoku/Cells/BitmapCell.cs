using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public class BitmapCell : Cell
    {
        private int _cellSize;

        public BitmapCell(int cellSize, int row, int column, int block) : base(row, column, block)
        {
            _cellSize = cellSize;

            // making as derived class here vs. just Note
            for (int i = 0; i < 9; i++)
                _notes[i] = new BitmapNote(_cellSize);
        }
        
        public override void Render()
        {
            int top = (Row - 1) * _cellSize;
            int left = (Column - 1) * _cellSize;
            Rectangle rect = new Rectangle(left, top, _cellSize, _cellSize);

            if (_isHighlighted)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.Lime), rect);
            else if (IsHouseSelected)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), rect);
            else
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.White), rect);

            // if solved, render solved candidate
            if (_bigNumber != 0)
            {
                string num = _bigNumber.ToString();

                Font f = new Font("Arial Black", _cellSize / 2);
                SizeF fSize = BitmapBoard.Graphics.MeasureString(num, f);

                Brush br;
                if (IsGiven.HasValue && IsGiven.Value)
                    br = Brushes.Black;
                else if (IsInvalid)
                    br = Brushes.Red;
                else
                    br =Brushes.Blue;

                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                BitmapBoard.Graphics.DrawString(num, f, br, rect, format);
            }
            else
            {
                // render notes
                for (int i = 0; i < 9; i++)
                    _notes[i].Render(Row, Column);
            }
            
            // maybe render selection box
            if (IsSelected)
                BitmapBoard.Graphics.DrawRectangle(new Pen(Color.Coral, 3), rect.X+2, rect.Y+2, rect.Width-4, rect.Height-4);

            // render cell border
            BitmapBoard.Graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);
        }

        public void HandleXYClick(UserInput input, ModifierKey modifierKey, int x, int y)
        {

            //if (x < 0 || x > _boardImage.Height || y < 0 || y > _boardImage.Width)
            //    throw new ArgumentException(String.Format("Invalid point requested (x:{0}, y:{1})", x, y));

            int row = y / _cellSize + 1;
            int col = x / _cellSize + 1;

            int noteRow = y / (_cellSize / 3) + 1;
            int noteCol = x / (_cellSize / 3) + 1;

            int v = (noteRow / 3);
            int h = (noteCol / 3);
            int block = (3 * v) + h;
            int b2 = noteRow * noteCol;

//            int noteNum = (noteRow - 1) % 3 + 1;
            //int noteCol = (noteCol - 1) % 3 + 1;

            if (input == UserInput.DoubleClick)
            {
                // convert double-clicked note (if had note) to solvedFor value (dummy code for now)
                if (!HasNumberSet &&  _notes[1].IsNoted)
                    SetGuess(2);

            }
        }
    }
}
