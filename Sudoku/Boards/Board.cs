using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public abstract class Board
    {
        protected int _boardSize;
        protected Cell[][] _cells;
        protected Cell _selectedCell;

        public Cell SelectedCell { get { return _selectedCell; } }
        public int BoardSize { get { return _boardSize; } }

        public static YesNo RemoveOldNotes { get; set; }
        public static ValidationMode ValidationMode { get; set; }

        public Board()
        {
            Board.RemoveOldNotes = YesNo.No;
            Board.ValidationMode = ValidationMode.Off;
        }

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
        /// Return the cell at the specified row/col
        /// </summary>
        /// <param name="row">Row of the target cell</param>
        /// <param name="col">Column of the target cell</param>
        /// <returns>Cell at the specified row/col</returns>
        public Cell CellAt(int row, int col)
        {
            return _cells[row - 1][col - 1];
        }

        /// <summary>
        /// Select the cell at the row/col coordinates passed in
        /// </summary>
        /// <param name="row">Row of the cell to select</param>
        /// <param name="col">Column of the cell to select</param>
        public void SelectCellAtRowCol(int row, int col)
        {
            if (row < 1 || row > 9)
                throw new ArgumentException(String.Format("Invalid row requested for selection: {0}", row));

            if (col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid column requested for selection: {0}", col));

            // first maybe clear current selection
            if (_selectedCell != null)
                _selectedCell.IsSelected = false;
            
            // select and remember new selection
            _selectedCell = _cells[row - 1][col - 1];
            _selectedCell.IsSelected = true;

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
                throw new ArgumentException(String.Format("Invalid row requested for house selection: {0}", row));

            if (col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid column requested for house selection: {0}", col));

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
                throw new ArgumentException(String.Format("No cell is selected for setting guess number: {0}", num));

            if (num < 0 || num > 9)
                throw new ArgumentException(String.Format("Invalid guess number being set: {0}", num));

            _selectedCell.SetGuess(num);

            if ((Board.RemoveOldNotes == YesNo.Yes) && (num != 0))
                RemoveNotes(num);

            CheckAndMarkDupes();
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

            if (Board.RemoveOldNotes == YesNo.Yes)
                RemoveNotes(num);

            CheckAndMarkDupes();
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

            if (Board.RemoveOldNotes == YesNo.Yes)
                RemoveNotes(num);

            CheckAndMarkDupes();
        }

        /// <summary>
        /// For all cells in the board, highlight cells that have either an answer number or a note based on the passed in value
        /// </summary>
        /// <param name="value">Number or note to check against and highlight</param>
        public void HighlightCellsWithNoteOrNumber(int value)
        {
            if (value < -1 || value > 9)
                throw new ArgumentException(String.Format("Invalid value requested for cell highlight by note or number: {0}", value));

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                {
                    // if special (unhighlight no matter what)...OR not a special highlight
                    if ((value == -1) || ((_cells[r][c].HighlightType == CellHighlightType.Value)) || (_cells[r][c].HighlightType == CellHighlightType.None))
                        _cells[r][c].HighlightHavingNoteOrNumber(value);
                }
        }

        /// <summary>
        /// Highlight the cell at row/col with the specified type of highlight
        /// </summary>
        /// <param name="row">Row to highlight</param>
        /// <param name="col">Column to highlight</param>
        /// <param name="highlightType">Type of cell highlight</param>
        public void HighlightCell(int row, int col, CellHighlightType highlightType)
        {
            if (row < 1 || row > 9 || col < 1 || col > 9)
                throw new ArgumentException(String.Format("Invalid value row/column requested for cell highlight: {0}/{1}", row, col));

            _cells[row-1][col-1].HighlightType = highlightType;
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
            CheckAndMarkDupes();
        }

        /// <summary>
        /// Set the selected note to the specified hightlight level for the selected cell
        /// </summary>
        /// <param name="highlightType">How to highlight it</param>
        public void HighlightSelectedNote(NoteHighlightType highlightType)
        {
            if (_selectedCell == null)
                throw new ArgumentException("No cell is selected for note highlight update");

            _selectedCell.HighlightSelectedNote(highlightType);
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
        /// Clear every note in the cell of its highlight
        /// </summary>
        public void ClearNoteHighlights()
        {
            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    _cells[r][c].ClearNoteHighlights();
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
                        // if shift-num and the cell doesn't already have an answer number assigned 
                        if (((modifierKey & ModifierKey.Shift) != 0) && !_selectedCell.HasAnswer)
                            ToggleNote((int)input);
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
                    // allowing both Givens and Guesses to be deleted this way
                    if (_selectedCell.HasAnswer)
                        SetGuess(0);
                    break;
                case UserInput.Space:
                    // tbd
                    break;
            }
        }

        /// <summary>
        /// Remove ALL old notes for all guess/given values
        /// </summary>
        public void RemoveNotes()
        {
            RemoveNotes(0);
        }

        /// <summary>
        /// Remove all notes of the given note value
        /// Ugly waste of time to do all the cells when only might need to do selected cell houses
        /// </summary>
        /// <param name="note">Note to remove, if has it (0 means check all note values)</param>
        public void RemoveNotes(int note)
        {
            // assume clearing every single old note
            int min = 1;
            int max = 9;

            // but use really desired note if passed in
            if (note != 0)
            {
                min = note;
                max = note;
            }

            // flatten the cells multidimmensional array
            IEnumerable<Cell> allCells = _cells.SelectMany(list => list);

            // do rows
            for (int r = 1; r <= 9; r++)
                for (int n = min; n <= max; n++) // while on a column, pick each number (or ONE specific note if one was passed in)
                {
                    IEnumerable<Cell> filteredCells = allCells.Where(cell => (cell.Row == r) && (cell.HasNote(n) || (cell.Answer == n)));
                    if (filteredCells.Where(cell => (cell.Answer == n)).Count() > 0)
                        filteredCells.OfType<Cell>().ToList().ForEach(cell => cell.RemoveNote(n));
                }

            // do columns
            for (int c = 1; c <= 9; c++)
                for (int n = min; n <= max; n++) // while on a column, pick each number (or ONE specific note if one was passed in)
                {
                    IEnumerable<Cell> filteredCells = allCells.Where(cell => (cell.Column == c) && (cell.HasNote(n) || (cell.Answer == n)));
                    if (filteredCells.Where(cell => (cell.Answer == n)).Count() > 0)
                        filteredCells.OfType<Cell>().ToList().ForEach(cell => cell.RemoveNote(n));
                }

            // do blocks
            for (int b = 1; b <= 9; b++)
                for (int n = min; n <= max; n++) // while on a block, pick each number (or ONE specific note if one was passed in)
                {
                    IEnumerable<Cell> filteredCells = allCells.Where(cell => (cell.Block == b) && (cell.HasNote(n) || (cell.Answer == n)));
                    if (filteredCells.Where(cell => (cell.Answer == n)).Count() > 0)
                        filteredCells.OfType<Cell>().ToList().ForEach(cell => cell.RemoveNote(n));
                }
        }

        /// <summary>
        /// Scan the whole board, rows then columns then blocks, tagging all invalid stuff so it renders as 'Invalid' (if that options is on)
        /// Ugly, brute force approach atm.  But it works....
        /// </summary>
        public bool CheckAndMarkDupes()
        {
            bool hasDupes = false;

            // flatten the cells multidimmensional array
            IEnumerable<Cell> allCells = _cells.SelectMany(list => list);
            
            // reset all to valid
            allCells.ToList().ForEach(c => c.IsInvalid = false);

            // do rows
            for (int r = 1; r <= 9; r++)
                for (int n = 1; n <= 9; n++) // while on a row, pick each number
                {
                    IEnumerable<Cell> filteredCells = allCells.Where(cell => (cell.Row == r) && (cell.Answer == n));
                    if (filteredCells.Count() > 1)
                    {
                        filteredCells.OfType<Cell>().ToList().ForEach(cell => cell.IsInvalid = true);
                        hasDupes = true;
                    }
                }

            // do columns
            for (int c = 1; c <= 9; c++)
                for (int n = 1; n <= 9; n++) // while on a column, pick each number
                {
                    IEnumerable<Cell> filteredCells = allCells.Where(cell => (cell.Column == c) && (cell.Answer == n));
                    if (filteredCells.Count() > 1)
                    {
                        filteredCells.OfType<Cell>().ToList().ForEach(cell => cell.IsInvalid = true);
                        hasDupes = true;
                    }
                }

            // do blocks
            for (int b = 1; b <= 9; b++)
                for (int n = 1; n <= 9; n++) // while on a block, pick each number
                {
                    IEnumerable<Cell> filteredCells = allCells.Where(cell => (cell.Block == b) && (cell.Answer == n));
                    if (filteredCells.Count() > 1)
                    {
                        filteredCells.OfType<Cell>().ToList().ForEach(cell => cell.IsInvalid = true);
                        hasDupes = true;
                    }
                }

            return hasDupes;
        }

        /// <summary>
        /// Determine if board is solved.  Until I can do any board create with unique solve awareness, just doing a sloppy "If nothing is duped and all cells filled, must be 'valid'"
        /// </summary>
        /// <returns></returns>
        public bool IsBoardSolved()
        {
            if (!CheckAndMarkDupes())
                return false;

            // paw through all cells
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    if (!_cells[r][c].HasAnswer) // if no number decided (given or guess)
                        return false;

           return true;
        }

        /// <summary>
        /// Return JSON of the current cells
        /// </summary>
        /// <returns>JSON string of current cell data</returns>
        public string CellsAsJSON()
        {
            var settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

            return JsonConvert.SerializeObject(_cells, Newtonsoft.Json.Formatting.None, settings);
        }

        /// <summary>
        /// Render (work done in derived classes)
        /// </summary>
        public abstract void Render();
    }
 }
