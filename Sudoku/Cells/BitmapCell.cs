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
        public BitmapCell(int row, int column, int block) : base(row, column, block)
        {
            // making as derived class here vs. just Note
            for (int i = 0; i < 9; i++)
                _notes[i] = new BitmapNote();
        }
        
        public override void Render(int cellSize)
        {
            int top = (Row - 1) * cellSize;
            int left = (Column - 1) * cellSize;
            Rectangle rect = new Rectangle(left, top, cellSize, cellSize);

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

                Font f = new Font("Arial Black", cellSize / 2);
                SizeF fSize = BitmapBoard.Graphics.MeasureString(num, f);

                Brush br;
                if (IsGiven)
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
                    _notes[i].Render(cellSize, Row, Column);
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

            //int row = y / (_boardSize / 9);
            //int col = x / (_boardSize / 9);


            if (input == UserInput.DoubleClick)
            {
                // convert double-clicked note (if had note) to solvedFor value

            }
        }
    }
}
