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
            for (int i = 0; i < 9; i++)
                _notes[i] = new BitmapNote();
        }
        
        public override void Render(int cellSize)
        {
            int top = (Row - 1) * cellSize;
            int left = (Column - 1) * cellSize;
            Rectangle rect = new Rectangle(left, top, cellSize, cellSize);

            if (_isHighlighted)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), rect);
            else if (IsHouseSelected)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.WhiteSmoke), rect);
            else
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.White), rect);

            // if solved, render solved candidate
            if (_number != 0)
            {
                string num = _number.ToString();

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

            if (IsSelected)
                BitmapBoard.Graphics.DrawRectangle(new Pen(Color.Coral, 3), rect.X+2, rect.Y+2, rect.Width-4, rect.Height-4);

            // render cell border
            BitmapBoard.Graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);
        }
    }
}
