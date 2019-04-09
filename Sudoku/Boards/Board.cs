using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

//9x9 cells
// border (normal, highlighted)
// color (normal, selected, highlighted)
// 9x9 notes
// font, number (or blank), color (n states? or just use outer color-picker?), 
// border
// blocks border

namespace Sudoku
{
    public abstract class Board
    {
        // TEMP>>>>MAKE THIS PROTECTED
        public Cell[][] _cells;
        //private HouseType _houseSelectionType = HouseType.None;
        private Cell _selectedCell;
        private bool _isSolved;

        public Board()
        {
            // not sure how to instantiate the right Cell type if doing this in base clase (moved to derived Boards) :/
            //_cells = new Cell[9][];
            //for (int r = 0; r < 9; r++)
            //{
            //    _cells[r] = new Cell[9];
            //    for (int c = 0; c < 9; c++)
            //    {
            //        int v = (r / 3);
            //        int h = (c / 3);
            //        int block = (3 * v) + h;

            //        _cells[r][c] = new Cell(r + 1, c + 1, block + 1);
            //    }
            //}
        }

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
            _selectedCell = _cells[row-1][col-1];
        }

        public void SelectHouseOfCellAtRowCol(int row, int col, HouseType house, bool deselectOthers)
        {
            if (row < 1 || row > 9)
                throw new ArgumentException(String.Format("Invalid cell row requested for house selection: {0}", row));

            if (col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid cell column requested for house selection: {0}", col));

            switch (house)
            {
                case HouseType.Row:
                    for (int r = 0; r < 9; r++)
                        for (int c = 0; c < 9; c++)
                        {
                            // if on the desired row
                            if (r + 1 == row)
                                _cells[r][c].IsHouseSelected = true;
                            else if (deselectOthers)
                                _cells[r][c].IsHouseSelected = false;
                        }
                    break;
                case HouseType.Column:
                    for (int r = 0; r < 9; r++)
                        for (int c = 0; c < 9; c++)
                        {
                            // if on the desired column
                            if (c + 1 == col)
                                _cells[r][c].IsHouseSelected = true;
                            else if (deselectOthers)
                                _cells[r][c].IsHouseSelected = false;
                        }
                    break;
                case HouseType.Block:
                    for (int r = 0; r < 9; r++)
                        for (int c = 0; c < 9; c++)
                        {
                            // if in the same block as the requested row/col
                            if (_cells[r][c].Block == _cells[row-1][col-1].Block)
                                _cells[r][c].IsHouseSelected = true;
                            else if (deselectOthers)
                                _cells[r][c].IsHouseSelected = false;
                        }
                    break;
            }
            // maybe use this field later
            // _houseSelectionType = house;
            // update all cell highlight states to hightlight only the house of the selected cell
        }

        public void HighlightCellsWithNote(int note)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note requested for cell highlight: {0}", note));

            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].HighlightHavingNote(note);
        }

        public string ToJson()
        {
            // how to deserialize the base class?
            return JsonConvert.SerializeObject(this);
        }

        public abstract void Render();
    }
 }
