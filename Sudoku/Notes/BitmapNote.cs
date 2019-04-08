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
                // if has a note, render it
                if (_candidate != 0)
                {
                    int cellSize = boardImage.Width / 9;

                    // calculate offset of each note to find right rect by note position
                    //   top: (row depth) + (inner-cell depth)
                    //   left: (col offset) + (inner-cell offset)
                    int top = ((row - 1) * cellSize) + ((Candidate - 1) / 3 * 20);
                    int left = ((col - 1) * cellSize) + (0);
                    Rectangle rect = new Rectangle(left, top, cellSize / 3, cellSize / 3);

                    // render note area color
                    if (IsSelected)
                        gr.FillRectangle(new SolidBrush(Color.LightBlue), rect);
                    else if (IsHighlighted)
                        gr.FillRectangle(new SolidBrush(Color.LightBlue), rect);
                    else
                    {
                        Color c = Color.Transparent;

                        switch (HighlightType)
                        {
                            case NoteHighlightType.Info:
                                c = Color.Lime;
                                break;
                            case NoteHighlightType.Bad:
                                c = Color.Red;
                                break;
                            case NoteHighlightType.Strong:
                                c = Color.DeepSkyBlue;
                                break;
                            case NoteHighlightType.Weak:
                                c = Color.Yellow;
                                break;
                        }
                        gr.FillRectangle(new SolidBrush(c), rect);
                    }

                    // Draw the text onto the image
                    Font f = new Font("Arial", cellSize / 3 / 2);
                    SizeF fSize = gr.MeasureString(_candidate.ToString(), f);

                    StringFormat format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Center
                    };
                    gr.DrawString(_candidate.ToString(), f, Brushes.Black, rect, format);
                    gr.Flush();
                }
            }
        }
    }
}
