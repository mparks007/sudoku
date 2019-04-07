using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class BitmapNote : Note
    {
        public override void Render(int row, int col, Bitmap boardImage)
        {
            using (Graphics gr = Graphics.FromImage(boardImage))
            {
                int cellSize = boardImage.Width / 9;
                int top = (row - 1) * cellSize;
                int left = (col - 1) * cellSize;
                Rectangle rect = new Rectangle(top, left, left + cellSize, top + cellSize);

                // render cell color
                if (IsSelected)
                    gr.FillRectangle(new SolidBrush(Color.LightBlue), rect);
                else if (IsHighlighted)
                    gr.FillRectangle(new SolidBrush(Color.LightGreen), rect);
                //else
                //    gr.FillRectangle(new SolidBrush(Color.White), rect);

                // if solved, render solved candidate
                if (_candidate != 0)
                {
                    // Draw the text onto the image
                    Font f = new Font("Tahoma", cellSize / 3 / 2);

                    // try to calculate the right spot in the 1 through 9 note array in the cell for this note value
                    SizeF fSize = gr.MeasureString(_candidate.ToString(), f);
                    gr.DrawString(_candidate.ToString(), f, Brushes.DarkGray, top + (cellSize / 2) - (f.Height / 2), left + (cellSize / 2) - (fSize.Width / 2));
                }
            }
        }
    }
}
