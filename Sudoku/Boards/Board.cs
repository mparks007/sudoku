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
        // TEMP>>>>MAKE THIS PROTECTED with accessors when done quick testing
        public Cell[][] _cells;
        public Cell SelectedCell { get { return _selectedCell; } }

        public void SelectCellAtRowCol(int row, int col, bool deselectOthers)
        {
            if (row < 1 || row > 9)
                throw new ArgumentException(String.Format("Invalid cell row requested for selection: {0}", row));

            if (col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid cell column requested for selection: {0}", col));

            // select the requested cell and maybe unselect the rest
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                {
                    // if found the desired cell
                    if ((r + 1 == row) && (c + 1 == col))
                        _cells[r][c].IsSelected = true;
                    else if (deselectOthers)
                        _cells[r][c].IsSelected = false;
                }

            _selectedCell = _cells[row-1][col-1];
        }

        public void SelectHousesOfCellAtRowCol(int row, int col)
        {
            if (row < 1 || row > 9)
                throw new ArgumentException(String.Format("Invalid cell row requested for house selection: {0}", row));

            if (col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid cell column requested for house selection: {0}", col));

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

            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].HighlightHavingNoteOrNumber(value);
        }

        public void HandleKeyUserInput(UserInput input)
        {
            int currentRow = _selectedCell.Row;
            int currentColumn = _selectedCell.Column;
            int currentBlock = _selectedCell.Block;

            switch (input)
            {
                case UserInput.UpArrow:
                    if (--currentRow < 1)
                        currentRow = 9;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.DownArrow:
                    if (++currentRow > 9)
                        currentRow = 1;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.LeftArrow:
                    if (--currentColumn < 1)
                        currentColumn = 9;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.RightArrow:
                    if (++currentColumn > 9)
                        currentColumn = 1;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.Home:
                    if (currentColumn != 1)
                        currentColumn = 1;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.End:
                    if (currentColumn != 9)
                        currentColumn = 9;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.AltHome:
                    if (currentRow != 1)
                        currentRow = 1;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.AltEnd:
                    if (currentRow != 9)
                        currentRow = 9;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.CtrlHome:
                    if ((currentRow != 1) || (currentColumn != 1))
                    {
                        currentRow = 1;
                        currentColumn = 1;
                    }
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.CtrlEnd:
                    if ((currentRow != 9) || (currentColumn != 9))
                    {
                        currentRow = 9;
                        currentColumn = 9;
                    }
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.Tab:
                    currentColumn += 3;
                    if (currentColumn > 9)
                        currentColumn = currentColumn - 9;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
                case UserInput.ShiftTab:
                    currentColumn -= 3;
                    if (currentColumn < 1) 
                        currentColumn = 10 - -currentColumn;
                    SelectCellAtRowCol(currentRow, currentColumn, deselectOthers: true);
                    break;
            }
        }

        public void HandleMouseUserInput(UserInput input, int x, int y)
        {

        }

        public abstract void Render();
    }
 }
