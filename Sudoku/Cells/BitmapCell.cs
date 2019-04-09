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

            // render cell color
            if (IsSelected)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.LightBlue), rect);
            else if (IsHighlighted)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.LightGreen), rect);
            else if (IsHouseSelected)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.LightGray), rect);
            else
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Color.White), rect);

            // if solved, render solved candidate
            if (_solvedFor != 0)
            {
                // Draw the text onto the image
                Font f = new Font("Arial Black", cellSize / 2);
                SizeF fSize = BitmapBoard.Graphics.MeasureString(SolvedFor.ToString(), f);

                Brush br;
                if (IsGiven)
                    br = Brushes.Black;
                else
                    br = Brushes.Blue;

                StringFormat format = new StringFormat()
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                BitmapBoard.Graphics.DrawString(SolvedFor.ToString(), f, br, rect, format);
            }
            else
            {
                // render notes
                for (int i = 0; i < 9; i++)
                    _notes[i].Render(cellSize, Row, Column);
            }

            // render cell border
            BitmapBoard.Graphics.DrawRectangle(new Pen(Color.DarkGray, 1), rect);
        }
    }
}
