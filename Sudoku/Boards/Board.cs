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
        public int BoardSize { get { return _boardSize; } }
        public static ValidationMode ValidationMode { get; set; }

        /// <summary>
        /// Default board setup for testing
        /// </summary>
        public void SetDefaultState()
        {
            Game.Board.SetGiven(1, 1, 9);
            Game.Board.SetGiven(1, 2, 1);
            Game.Board.SetGiven(1, 4, 7);
            Game.Board.SetGiven(2, 2, 3);
            Game.Board.SetGiven(2, 3, 2);
            Game.Board.SetGiven(2, 4, 6);
            Game.Board.SetGiven(2, 6, 9);
            Game.Board.SetGiven(2, 8, 8);
            Game.Board.SetGiven(3, 3, 7);
            Game.Board.SetGiven(3, 5, 8);
            Game.Board.SetGiven(3, 7, 9);
            Game.Board.SetGiven(4, 2, 8);
            Game.Board.SetGiven(4, 3, 6);
            Game.Board.SetGiven(4, 5, 3);
            Game.Board.SetGiven(4, 7, 1);
            Game.Board.SetGiven(4, 8, 7);
            Game.Board.SetGiven(5, 1, 3);
            Game.Board.SetGiven(5, 9, 6);
            Game.Board.SetGiven(6, 2, 5);
            Game.Board.SetGiven(6, 3, 1);
            Game.Board.SetGiven(6, 5, 2);
            Game.Board.SetGiven(6, 7, 8);
            Game.Board.SetGiven(6, 8, 4);
            Game.Board.SetGiven(7, 3, 9);
            Game.Board.SetGiven(7, 5, 5);
            Game.Board.SetGiven(7, 7, 3);
            Game.Board.SetGiven(8, 2, 2);
            Game.Board.SetGiven(8, 4, 3);
            Game.Board.SetGiven(8, 6, 1);
            Game.Board.SetGiven(8, 7, 4);
            Game.Board.SetGiven(8, 8, 9);
            Game.Board.SetGiven(9, 6, 2);
            Game.Board.SetGiven(9, 8, 6);
            Game.Board.SetGiven(9, 9, 1);
        }

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

            _selectedCell = _cells[row - 1][col - 1];

            // cell selection changed, so house would have too
            SelectHousesOfCellAtRowCol(row, col);
        }

        /// <summary>
        /// Highlight all cells in the same house (row, column, block) of the cell at row/col
        /// </summary>
        /// <param name="row">Row of the source cell</param>
        /// <param name="col">Columm of the source cell</param>
        private void SelectHousesOfCellAtRowCol(int row, int col)
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
                    if ((_cells[r][c].Row == _cells[row - 1][col - 1].Row) ||
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
            if (_selectedCell == null)
                throw new ArgumentException(String.Format("No cell is selected for setting guess: {0}", num));

            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid guess number being set: {0}", num));

            _selectedCell.SetGuess(num);

            ActionManager.Add(new BoardAction
            {
                Row = _selectedCell.Row,
                Column = _selectedCell.Column,
                ActionType = ActionType.SetGuess,
                Number = num
            });

            Validate();
        }

        /// <summary>
        /// Places an answer/guess/solve main number in the cell at row/col
        /// </summary>
        /// <param name="row">Row to update</param>
        /// <param name="col">Column to update</param>
        /// <param name="num">Number to try and set</param>
        private void SetGuess(int row, int col, int num)
        {
            if (row < 1 || row > 9 || col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid value row/column requested for setting Guess: {0}/{1}", row, col));

            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid solution number being set: {0}", num));

            _cells[row - 1][col - 1].SetGuess(num);
            Validate();
        }

        /// <summary>
        /// Places a starter/given main number in the selected cell
        /// </summary>
        /// <param name="num">Number to try and set</param>
        public void SetGiven(int num)
        {
            if (_selectedCell == null)
                throw new ArgumentException(String.Format("No cell is selected for setting given: {0}", num));

            if (num < 1 || num > 9)
                throw new ArgumentException(String.Format("Invalid given number being set: {0}", num));

            _selectedCell.SetGiven(num);
            Validate();
        }

        /// <summary>
        /// Places a starter/given main number in the cell at row/col
        /// </summary>
        /// <param name="row">Row to update</param>
        /// <param name="col">Column to update</param>
        /// <param name="num">Number to try and set</param>
        private void SetGiven(int row, int col, int num)
        {
            if (row < 1 || row > 9 || col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid value row/column requested for setting given: {0}/{1}", row, col));

            if (num < 1 || num > 9)
                throw new ArgumentException(String.Format("Invalid given number being set: {0}", num));

            _cells[row - 1][col - 1].SetGiven(num);
            Validate();
        }

        /// <summary>
        /// For all cells in the board, highlight cells that have either an answer number or a note based on the passed in value
        /// </summary>
        /// <param name="value">Number or note to check against and highlight</param>
        public void HighlightCellsWithNoteOrNumber(int value)
        {
            if (value < 0 || value > 9)
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].HighlightHavingNoteOrNumber(value);
        }

        /// <summary>
        /// Highlight the selected cell with the specified type of highlight
        /// </summary>
        /// <param name="highlightType">Type of cell highlight</param>
        public void HighlightCell(CellHighlightType highlightType)
        {
            if (_selectedCell == null)
                throw new ArgumentException(String.Format("No cell is selected for highlight: {0}", highlightType.Description()));

            _selectedCell.HighlightType = highlightType;
        }

        /// <summary>
        /// Toggle a note on/off for the selected cell
        /// </summary>
        /// <param name="note">Note number to toggle</param>
        public void ToggleNote(int note)
        {
            if (_selectedCell == null)
                throw new ArgumentException(String.Format("No cell is selected for note toggle: {0}", note));

            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note requested for note toggle: {0}", note));

            _selectedCell.ToggleNote(note);
            Validate();
        }

        /// <summary>
        /// Set the specific note to the specified hightlight level for the selected cell
        /// </summary>
        /// <param name="note">Which note to hightlight</param>
        /// <param name="highlightType">How to highlight it</param>
        public void HighlightNote(int note, NoteHighlightType highlightType)
        {
            if (_selectedCell == null)
                throw new ArgumentException(String.Format("No cell is selected for note highlight update: {0}", note));

            if (note < 1 || note > 9)
                throw new ArgumentException(String.Format("Invalid note having highlight updated: {0}", note));

            _selectedCell.HighlightNote(note, highlightType);
        }

        /// <summary>
        /// Clear every note in the cell of highlight
        /// </summary>
        public void ClearNoteHighlights(NoteHighlightType type)
        {
            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].ClearNoteHighlights(type);
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
                            if (!_selectedCell.HasAnswer)
                                ToggleNote((int)input);
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
                    if (_selectedCell.HasAnswer)// && _selectedCell.IsGiven.HasValue && !_selectedCell.IsGiven.Value)
                        SetGuess(0);
                    break;
                case UserInput.Space:
                    // tbd
                    break;
            }
        }

        /// <summary>
        /// Scan the whole board and tag all invalid stuff so it renders as 'Invalid' (if that options is on)
        /// Ugly, brute force approach atm.  But it works....
        /// </summary>
        public bool Validate()
        {
            bool valid = true;

            int rowFirstFind = -1;
            int columnFirstFind = -1;

            // Need to scan stuff and set the IsInvalid flag to true on cells that are violating the rules.
            switch (ValidationMode)
            {
                // for now, just super obvious dupes, not yet based on the setup not aligning with the final solve values
                case ValidationMode.Numbers:
                    
                    // do row at a time
                    for (int r = 0; r < 9; r++)
                    {
                        rowFirstFind = -1;
                        columnFirstFind = -1;

                        // while on this row, pick each number
                        for (int n = 1; n <= 9; n++)
                        {
                            // back to the next number to scan, so reset that the number has been found already
                            columnFirstFind = -1;

                            // then scan across the columns on this focus row
                            for (int c = 0; c < 9; c++)
                            {
                                // if the cell has this number
                                if (_cells[r][c].Answer == n)
                                {
                                    // if this was the first time finding this number, remember its row/col (in case we find a dupe and need to come back and mark this first find as Invalid)
                                    if (columnFirstFind == -1)
                                    {
                                        rowFirstFind = r;
                                        columnFirstFind = c;

                                        // clearing first occurance as we go as it can clear all before deciding invalids (this is NOT to be done in the subsqeuent scans for Column and Block
                                        _cells[r][c].IsInvalid = false;
                                    }
                                    else // wasn't the first find, so mark original find as Invalid and this one
                                    {
                                        _cells[rowFirstFind][columnFirstFind].IsInvalid = true;
                                        _cells[r][c].IsInvalid = true;
                                    }
                                }
                            }
                        }
                    }

                    // do column at a time
                    for (int c = 0; c < 9; c++)
                    {
                        rowFirstFind = -1;
                        columnFirstFind = -1;

                        // while on this column, pick each number
                        for (int n = 1; n <= 9; n++)
                        {
                            // back to the next number to scan, so reset that the number has been found already
                            rowFirstFind = -1;

                            // then scan down the rows on this focus column
                            for (int r = 0; r < 9; r++)
                            {
                                // if the cell has this number
                                if (_cells[r][c].Answer == n)
                                {
                                    // if this was the first time finding this number, remember its row/col (in case we find a dupe and need to come back and mark this first find as Invalid)
                                    if (rowFirstFind == -1)
                                    {
                                        rowFirstFind = r;
                                        columnFirstFind = c;
                                    }
                                    else // wasn't the first find, so mark original find as Invalid and this one
                                    {
                                        _cells[rowFirstFind][columnFirstFind].IsInvalid = true;
                                        _cells[r][c].IsInvalid = true;
                                    }
                                }
                            }
                        }
                    }

                    // do blocks
                    List<Cell> cellsForBlock;
                    int blockFirstFind = -1;
                    for (int b = 1; b <= 9; b++)
                    {
                        // convert two dimenstional array to single, but based on the focused block number
                        cellsForBlock = _cells.SelectMany(list => list).Where(c => c.Block == b).ToList<Cell>();

                        // while on a block, pick each number
                        for (int n = 1; n <= 9; n++)
                        {
                            // back to the next number to scan, so reset that the number has been found already
                            blockFirstFind = -1;

                            // now scan through the rows in the focused block
                            for (int c = 0; c < 9; c++)
                            {
                                // if the cell has this number
                                if (cellsForBlock[c].Answer == n)
                                {
                                    // if this was the first time finding this number, remember its index (in case we find a dupe and need to come back and mark this first find as Invalid)
                                    if (blockFirstFind == -1)
                                    {
                                        blockFirstFind = c;
                                    }
                                    else // wasn't the first find, so mark original find as Invalid and this one
                                    {
                                        _cells[cellsForBlock[blockFirstFind].Row - 1][cellsForBlock[blockFirstFind].Column - 1].IsInvalid = true;
                                        _cells[cellsForBlock[c].Row - 1][cellsForBlock[c].Column - 1].IsInvalid = true;
                                    }
                                }
                            }
                        }
                    }

                    Render();
                    break;
                // Notes don't have an IsValid checked at render time.  I may use NoteHighlightType.Bad  
                case ValidationMode.Notes:
                    
                    //Game.Board.HighlightNote(r, c, note, NoteHighlightType.Bad);

                    Render();
                    break;
            }

            return valid;
        }

        /// <summary>
        /// Determine if board is solved
        /// </summary>
        /// <returns></returns>
        public bool IsBoardSolved()
        {
            if (!Validate())
                return false;

            bool solved = true;

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                {
                    if (!_cells[r][c].HasAnswer || (_cells[r][c].HasAnswer && _cells[r][c].IsInvalid))
                    {
                        solved = false;
                        break;
                    }
                }

           return solved;
        }

        /// <summary>
        /// Render (work done in derived classes)
        /// </summary>
        public abstract void Render();
    }
 }
