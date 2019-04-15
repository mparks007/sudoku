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

        public Cell SelectedCell { get { return _selectedCell; } }
        public int BoardSize {  get { return _boardSize; } }
        
        /// <summary>
        /// Select the cell at the row/col coordinates passed in
        /// </summary>
        /// <param name="row">Row of the cell to select</param>
        /// <param name="col">Column of the cell to select</param>
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

        /// <summary>
        /// Highlight all cells in the same house (row, column, block) of the cell at row/col
        /// </summary>
        /// <param name="row">Row of the source cell</param>
        /// <param name="col">Columm of the source cell</param>
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

        /// <summary>
        /// Places an answer/guess/solve main number in the selected cell
        /// </summary>
        /// <param name="num">Number to try and set</param>
        public void SetGuess(int num)
        {
            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            _selectedCell.SetGuess(num);
        }

        /// <summary>
        /// Places a starter/given main number in the selected cell
        /// </summary>
        /// <param name="num">Number to try and set</param>
        public void SetGiven(int num)
        {
            if (num < 1 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            _selectedCell.SetGiven(num);
        }
        /// <summary>
        /// For all cells in the board, highlight cells that have either an answer number or a note based on the passed in value
        /// </summary>
        /// <param name="value">Number or note to check against and highlight</param>
        public void HighlightCellsWithNoteOrNumber(int value)
        {
            if (value < 1 || value > 9)
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].HighlightHavingNoteOrNumber(value);
        }

        /// <summary>
        /// Toggle a note on/off for the selected cell
        /// </summary>
        /// <param name="row">Row of cell to toggle note</param>
        /// <param name="col">Column of cell to toggle note</param>
        /// <param name="note">Note number to toggle</param>
        public void ToggleNote(int note)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note being set/unset: {0}", note));

            if (_selectedCell == null)
                throw new ArgumentException(String.Format("No cell is selected for note toggle", note));

            _selectedCell.ToggleNote(note);
        }

        /// <summary>
        /// Set the specific note to the specified hightlight level for the selected cell
        /// </summary>
        /// <param name="note">Which note to hightlight</param>
        /// <param name="highlightType">How to highlight it</param>
        public void HighlightNote(int note, NoteHighlightType highlightType)
        {
            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note being set/unset: {0}", note));

            if (_selectedCell == null)
                throw new ArgumentException(String.Format("No cell is selected for note toggle", note));

            _selectedCell.HighlightNote(note, highlightType);
        }

        /// <summary>
        /// Deal with the supported key presses and modifiers select when key was pressed
        /// </summary>
        /// <param name="input">Which key was pressed</param>
        /// <param name="modifierKey">Which modifier was active (shift, alt, control)</param>
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
                    // if no main number present OR there is but it isn't a given number (then we are allowed assignment of a guess number)
                    if (!_selectedCell.IsGiven.HasValue || (_selectedCell.IsGiven.HasValue && !_selectedCell.IsGiven.Value))
                    {
                        // if shift-num 
                        if ((modifierKey & ModifierKey.Shift) != 0)
                        {
                            // and the cell doesn't already have an answer number assigned
                            if (!_selectedCell.HasNumberSet)
                                _selectedCell.ToggleNote((int)input);
                        }
                        else if (modifierKey == 0) // if not shift or ctrl, etc.
                            SetGuess((int)input);
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
                    // has number, BUT isn't a number that was given at the beginning (NOTE: For now, allowing Delete of Givens)
                    if (_selectedCell.HasNumberSet)// && _selectedCell.IsGiven.HasValue && !_selectedCell.IsGiven.Value)
                        SetGuess(0);
                    break;
                case UserInput.Space:
                    // tbd
                    break;
            }
        }

        /// <summary>
        /// Render (work done in derived classes)
        /// </summary>
        public abstract void Render();
    }
 }
