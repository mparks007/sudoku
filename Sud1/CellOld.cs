using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public class CellOld
    {
        public Panel pnl;
        private bool isNoteMode;
        private Panel[] pnlNotes = new Panel[9];
        private Label[] lblNotes = new Label[9];
        private Color cellBackColor;
        private Color cellSelectColor;
        private Color cellHiColor;
        private Color noteTextColor;
        private Color noteCtrlColor;
        private Color noteAltColor;
        private Color noteShiftColor;


        //// A read-write instance property:
        public bool IsNoteMode
        {
            set { isNoteMode = value; }
        }

        public CellOld()
        {
        }

        public CellOld(object owner, int top, int left, int height, int width, Color cellBackColor, Color cellSelectColor, Color cellHiColor, Color noteTextColor, Color noteCtrlColor, Color noteAltColor, Color noteShiftColor)
        {
            this.cellBackColor = cellBackColor;
            this.cellSelectColor = cellSelectColor;
            this.cellHiColor = cellHiColor;
            this.noteTextColor = noteTextColor;
            this.noteCtrlColor = noteCtrlColor;
            this.noteAltColor = noteAltColor;
            this.noteShiftColor = noteShiftColor;

            pnl = new Panel
            {
                Parent = (Control)owner,
                Top = top,
                Left = left,
                Height = height,
                Width = width,
                BackColor = cellBackColor
            };
            
            int leftOffset = 0;
            for (int i = 0; i < 9; i++)
            {
                // every third note, reset back to far right of the cell to prepare for the next row of notes
                leftOffset++;
                if (i % 3 == 0)
                    leftOffset = 0;

                pnlNotes[i] = new Panel();
                pnlNotes[i].Parent = pnl;
                pnlNotes[i].Width = 30;
                pnlNotes[i].Height = 30;
                pnlNotes[i].Top = i / 3 * pnlNotes[i].Height; // every exact multiple of 3 will allow scooting down by "height" number of pixels
                pnlNotes[i].Left = leftOffset * pnlNotes[i].Width; // offset should allow scooting over "width" pixels at a time
                pnlNotes[i].BackColor = Color.Transparent;

                lblNotes[i] = new Label();
                lblNotes[i].Parent = pnlNotes[i];
                lblNotes[i].Top = 0;
                lblNotes[i].Left = 0;
                lblNotes[i].Width = lblNotes[i].Parent.Width;
                lblNotes[i].Height = lblNotes[i].Parent.Height;
                lblNotes[i].AutoSize = false;
                lblNotes[i].TextAlign = ContentAlignment.MiddleCenter;
                lblNotes[i].Font = new Font(lblNotes[i].Font.Name, (int)(lblNotes[i].Width * .35));
                lblNotes[i].ForeColor = noteTextColor;

                int iVal = i;
                int noteNumber = i + 1;
                lblNotes[i].Click += (s, args) =>
                {
                    if (isNoteMode)
                    {
                        if (Control.ModifierKeys == Keys.Control)
                        {
                            ToggleCtrl(iVal + 1);
                        }
                        else if (Control.ModifierKeys == Keys.Shift)
                        {
                            ToggleShift(iVal + 1);
                        }
                        else if (Control.ModifierKeys == Keys.Alt)
                        {
                            ToggleAlt(iVal + 1);
                        }
                        else
                        {
                            ToggleNote(iVal + 1);
                        }
                    }
                    else
                    {
                        if (pnlNotes[iVal].Parent.BackColor == cellSelectColor)
                            pnlNotes[iVal].Parent.BackColor = cellBackColor;
                        else
                            pnlNotes[iVal].Parent.BackColor = cellSelectColor;
                    }
                };
            }
        }

        public void ToggleCtrl(int number)
        {
            if (number > 0 && number < 10)
            {
                if (pnlNotes[number - 1].BackColor == noteCtrlColor)
                    pnlNotes[number - 1].BackColor = Color.Transparent;
                else
                    pnlNotes[number - 1].BackColor = noteCtrlColor;
            }
        }

        public void ToggleShift(int number)
        {
            if (number > 0 && number < 10)
            {
                if (pnlNotes[number - 1].BackColor == noteShiftColor)
                    pnlNotes[number - 1].BackColor = Color.Transparent;
                else
                    pnlNotes[number - 1].BackColor = noteShiftColor;
            }
        }

        public void ToggleAlt(int number)
        {
            if (number > 0 && number < 10)
            {
                if (pnlNotes[number - 1].BackColor == noteAltColor)
                    pnlNotes[number - 1].BackColor = Color.Transparent;
                else
                    pnlNotes[number - 1].BackColor = noteAltColor;
            }
        }

        public void ToggleNote(int number)
        {
            if (number > 0 && number < 10)
            {
                if (lblNotes[number - 1].Text == "")
                    lblNotes[number - 1].Text = number.ToString();
                else
                    lblNotes[number - 1].Text = "";
            }
        }
        public void ToggleHighlight()
        {
            if (pnl != null)
            {
                if (pnl.BackColor == cellHiColor)
                    pnl.BackColor = cellBackColor;
                else
                    pnl.BackColor = cellHiColor;
            }
        }
    }
}
