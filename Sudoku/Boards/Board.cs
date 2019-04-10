using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Newtonsoft.Json;

namespace Sudoku
{
    public abstract class Board
    {
        // TEMP>>>>MAKE THIS PROTECTED with accessors when done quick testing
        public Cell[][] _cells;
        //private Cell _selectedCell;
        //private bool _isSolved;

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

            // maybe will use this field later
            //_selectedCell = _cells[row-1][col-1];
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
            // maybe use this field later
            // _houseSelectionType = house;
            // update all cell highlight states to hightlight only the house of the selected cell
        }

        public void HighlightCellsWithNoteOrNumber(int value)
        {
            if (value < 1 || value > 9)
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].HighlightHavingNoteOrNumber(value);
        }

        //public string ToJson()
        //{
        //    how to deserialize the base class?
        //    return JsonConvert.SerializeObject(this);
        //}

        public abstract void Render();
    }
 }
