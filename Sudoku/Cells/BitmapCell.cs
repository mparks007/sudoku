﻿using Newtonsoft.Json;
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
        [JsonProperty]
        private readonly int _cellSize;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="cellSize">Size of each cell (used for render calculations)</param>
        /// <param name="row">Row of the cell in the overall board (used for render calculations)</param>
        /// <param name="column">Column of the cell in the overall board (used for render calculations)</param>
        /// <param name="block">Block of the cell in the overall board (used for render calculations)</param>
        public BitmapCell(int cellSize, int row, int column, int block) : base(row, column, block)
        {
            _cellSize = cellSize;
            _notes = new BitmapNote[9];

            // making as derived class here vs. just Note
            for (int i = 0; i < 9; i++)
                _notes[i] = new BitmapNote(_cellSize);
        }
        
        /// <summary>
        /// Render the cell
        /// </summary>
        public override void Render()
        {   
            // calc the top/left of the cells location in the overall board image
            int top = (Row - 1) * _cellSize;
            int left = (Column - 1) * _cellSize;
            Rectangle rect = new Rectangle(left, top, _cellSize, _cellSize);

            if (HighlightType == CellHighlightType.Pivot)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Colors.Instance.CellHighlightPivot), rect);
            else if (HighlightType == CellHighlightType.Pincer)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Colors.Instance.CellHighlightPincer), rect);
            else if (HighlightType == CellHighlightType.Special)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Colors.Instance.CellHighlightSpecial), rect);
            else if (HighlightType == CellHighlightType.Value)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Colors.Instance.CellHighlightValue), rect);
            else if (IsHouseSelected)
                BitmapBoard.Graphics.FillRectangle(new SolidBrush(Colors.Instance.CellHouseSelect), rect);
            else
            {
                // make a subtle checkerboard pattern on the blocks
                if (Block % 2 == 0)
                    BitmapBoard.Graphics.FillRectangle(new SolidBrush(Colors.Instance.CellBlockAlternate), rect);
                else
                    BitmapBoard.Graphics.FillRectangle(new SolidBrush(Colors.Instance.CellBlank), rect);
            }

            // if solved, render solved number
            if (_answer != 0)
            {
                string num = _answer.ToString();

                Font f = new Font(Fonts.Instance.Answer, _cellSize / 2);
                SizeF fSize = BitmapBoard.Graphics.MeasureString(num, f);

                Brush br;
                // only turn red when invalid if....validating full number option and that number isn't a given
                if (IsInvalid && (Board.ValidationMode == ValidationMode.Numbers) && (IsGiven.HasValue && !IsGiven.Value))
                    br = new SolidBrush(Colors.Instance.AnswerInvalid);
                else if (IsGiven.HasValue && IsGiven.Value)
                    br = new SolidBrush(Colors.Instance.AnswerGiven);
                else
                    br = new SolidBrush(Colors.Instance.AnswerGuess);

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
                BitmapBoard.Graphics.DrawRectangle(new Pen(Colors.Instance.CellSelectFrame, 3), rect.X+2, rect.Y+2, rect.Width-4, rect.Height-4);

            // render cell border
            BitmapBoard.Graphics.DrawRectangle(new Pen(Colors.Instance.CellBorder, 1), rect);
        }

        /// <summary>
        /// Take the X and Y pixel coordinate where clicked in the main board and determine what action to take a the note level
        /// </summary>
        /// <param name="input">Type of click (right, left, double)</param>
        /// <param name="modifierKey">Key modifier (shift, alt, control)</param>
        /// <param name="x">X pixel location clicked in the main board</param>
        /// <param name="y">Y pixel location clicked in the main board</param>
        public void HandlePixelXYClick(UserInput input, ModifierKey modifierKey, int x, int y)
        {
            if (x < 0 || x > (_cellSize * 9 - 1) || y < 0 || y > (_cellSize * 9 - 1))
                throw new ArgumentException(String.Format("Invalid point requested (x:{0}, y:{1})", x, y));

            int noteRowInBoard = y / (_cellSize / 3);
            int noteColInBoard = x / (_cellSize / 3);

            int noteRowInCell = noteRowInBoard % 3; // zero-based
            int noteColInCell = noteColInBoard % 3; // zero-based

            int noteNum = (3 * noteRowInCell) + noteColInCell; // zero-based

            _selectedNote = null;
            if (_notes[noteNum].IsNoted)
            {
                _selectedNote = _notes[noteNum];

                if ((modifierKey & ModifierKey.Control) != 0)
                {
                    if (input == UserInput.LeftClick)
                    {
                        // if notes visible
                        if (!HasAnswer)
                            HighlightNote(noteNum+1, NoteHighlightType.Strong);
                    }
                    else if (input == UserInput.RightClick)
                    {
                        // if notes visible
                        if (!HasAnswer)
                            HighlightNote(noteNum+1, NoteHighlightType.Weak);
                    }
                }
                else
                {
                    // if double-clicked note convert to guess
                    if (input == UserInput.DoubleClick)
                    {
                        // if notes visible
                        if (!HasAnswer)
                            SetGuess(noteNum+1);
                    }
                }
            }
        }
    }
}
