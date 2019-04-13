using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public abstract class Board
    {
        private Cell _selectedCell;
        protected int _boardSize;
        protected Cell[][] _cells;

        public Cell[][] Cells { get { return _cells; } }
        public Cell SelectedCell { get { return _selectedCell; } }
        
        public void SelectCellAtRowCol(int row, int col)
        {
            // if no change, bail
            if ((_selectedCell != null) && ((_selectedCell.Row == row) && (_selectedCell.Column == col)))
                return;

            if (row < 1 || row > 9)
                throw new ArgumentException(String.Format("Invalid cell row requested for selection: {0}", row));

            if (col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid cell column requested for selection: {0}", col));

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                {
                    // if found the desired cell
                    if ((r + 1 == row) && (c + 1 == col))
                        _cells[r][c].IsSelected = true;
                    else
                        _cells[r][c].IsSelected = false;
                }

            _selectedCell = _cells[row-1][col-1];

            // cell selection changed, so house would have too
            SelectHousesOfCellAtRowCol(row, col);
        }

        public void SelectHousesOfCellAtRowCol(int row, int col)
        {
            if (row < 1 || row > 9)
                throw new ArgumentException(String.Format("Invalid cell row requested for house selection: {0}", row));

            if (col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid cell column requested for house selection: {0}", col));

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                {
                    // if in the same row, column, or block as the requested row/col
                    if ((_cells[r][c].Row == _cells[row-1][col-1].Row) ||
                        (_cells[r][c].Column == _cells[row - 1][col - 1].Column) ||
                        (_cells[r][c].Block == _cells[row - 1][col - 1].Block))
                        _cells[r][c].IsHouseSelected = true;
                    else
                        _cells[r][c].IsHouseSelected = false;
                }
        }

        public void HighlightCellsWithNoteOrNumber(int value)
        {
            if (value < 1 || value > 9)
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].HighlightHavingNoteOrNumber(value);
        }

        public void HandleKeyUserInput(UserInput input, ModifierKey modifierKey)
        {
            int currentRow = _selectedCell.Row;
            int currentColumn = _selectedCell.Column;
            int currentBlock = _selectedCell.Block;

            switch (input)
            {
                case UserInput.One:
                case UserInput.Two:
                case UserInput.Three:
                case UserInput.Four:
                case UserInput.Five:
                case UserInput.Six:
                case UserInput.Seven:
                case UserInput.Eight:
                case UserInput.Nine:
                    if (!_selectedCell.IsGiven)
                    {
                        // if Alt-num 
                        if ((modifierKey & ModifierKey.Alt) != 0)
                        {
                            // and the cell doesn't already have an answer number assigned
                            if (!_selectedCell.HasNumberSet)
                                _selectedCell.SetNote((int)input);
                        }
                        else if (modifierKey == 0) // if not shift or ctrl, etc.
                            _selectedCell.SetNumber((int)input, isGiven: false);
                    }
                    break;
                case UserInput.UpArrow:
                    if (--currentRow < 1)
                        currentRow = 9;
                    SelectCellAtRowCol(currentRow, currentColumn);
                    break;
                case UserInput.DownArrow:
                    if (++currentRow > 9)
                        currentRow = 1;
                    SelectCellAtRowCol(currentRow, currentColumn);
                    break;
                case UserInput.LeftArrow:
                    if (--currentColumn < 1)
                        currentColumn = 9;
                    SelectCellAtRowCol(currentRow, currentColumn);
                    break;
                case UserInput.RightArrow:
                    if (++currentColumn > 9)
                        currentColumn = 1;
                    SelectCellAtRowCol(currentRow, currentColumn);
                    break;
                case UserInput.Home:
                    if (currentColumn != 1)
                    {
                        currentColumn = 1;
                        SelectCellAtRowCol(currentRow, currentColumn);
                    }
                    break;
                case UserInput.End:
                    if (currentColumn != 9)
                    {
                        currentColumn = 9;
                        SelectCellAtRowCol(currentRow, currentColumn);
                    }
                    break;
                case UserInput.Delete:
                    // has number, BUT isn't a number that was given at the beginning
                    if (_selectedCell.HasNumberSet && !_selectedCell.IsGiven)
                        _selectedCell.SetNumber(0, isGiven: false);
                    break;
            }
        }

        public void HandleMouseUserInput(UserInput input, int x, int y)
        {
            // if just basic cell select
            if (input == UserInput.LeftClick)
            {
                // TODO
                SelectCellAtRowCol(1, 1);
            } 
            else
            {
                // TODO
                // convert double-clicked note (if had note) to solvedFor value
                SelectCellAtRowCol(9, 9);
            }
        }

        public abstract void Render();
    }
 }
