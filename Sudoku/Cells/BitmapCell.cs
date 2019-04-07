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

        public override void Render(Bitmap boardImage)
        {
            using (Graphics gr = Graphics.FromImage(boardImage))
            {
                int cellSize = boardImage.Width / 9;
                int top = (Row - 1) * cellSize;
                int left = (Column - 1) * cellSize;
                Rectangle rect = new Rectangle(top, left, left + cellSize, top + cellSize);

                // render cell color
                if (IsSelected)
                    gr.FillRectangle(new SolidBrush(Color.LightBlue), rect);
                else if (IsHighlighted)
                    gr.FillRectangle(new SolidBrush(Color.LightGreen), rect);
                else if (IsHouseSelected)
                    gr.FillRectangle(new SolidBrush(Color.LightGray), rect);
                else
                    gr.FillRectangle(new SolidBrush(Color.White), rect);

                // if solved, render solved candidate
                if (_solvedFor != 0)
                {
                    // Draw the text onto the image
                    Font f = new Font("Tahoma", cellSize / 2);
                    SizeF fSize = gr.MeasureString(SolvedFor.ToString(), f);
                    Brush br;
                    if (IsGiven)
                        br = Brushes.Black;
                    else
                        br = Brushes.Blue;
                    gr.DrawString(SolvedFor.ToString(), f, br, top+(cellSize / 2)-(f.Height / 2), left+(cellSize / 2)-(fSize.Width / 2));

                    // HOW TO CENTER TEXT??????
                    //StringFormat format = new StringFormat()
                    //{
                    //    Alignment = StringAlignment.Center,
                    //    LineAlignment = StringAlignment.Center
                    //};
                    // this doesn't render the text at all.  why??
                    //gr.DrawString(SolvedFor.ToString(), f, br, rect, format);
                }
                else
                {
                    // render notes
                    for (int i = 0; i < 9; i++)
                        _notes[i].Render(Row, Column, boardImage);
                }

                // render cell border
                gr.DrawRectangle(new Pen(Color.DarkGray, 1), top, left, left+cellSize, top+cellSize);
            }
        }
    }
}
