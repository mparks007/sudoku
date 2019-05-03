using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class DefaultFinder : IFinder
    {
        private Dictionary<Pattern, Func<Board, List<FindResult>>> _methods = new Dictionary<Pattern, Func<Board, List<FindResult>>>();

        /// <summary>
        /// Ctor to load up all the supported finders
        /// </summary>
        public DefaultFinder()
        {
            // add in the supported find methods
            _methods[Pattern.XWing] = FindXWings;
            _methods[Pattern.Skyscraper] = FindSkyscrapers;
            _methods[Pattern.XYWing] = FindXYWings;
            _methods[Pattern.TwoStringKite] = FindTwoStringKites;
        }

        /// <summary>
        /// Find the specified pattern on the specified board
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <param name="pattern">Pattern to search for</param>
        /// <returns>List of found patterns</returns>
        public List<FindResult> Find(Board board, Pattern pattern)
        {
            if (_methods[pattern] != null)
                return _methods[pattern](board);
            else
                return new List<FindResult>();
        }

        #region Finders

        /// <summary>
        /// Find XWing patterns
        ///   Very raw way to search atm (sort of searched as I search with brain)
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindXWings(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);

            // row-based xwings

            // pick one number at a time
            for (int n = 1; n <=9; n++)
            {
                // from top, scan rows from top to bottom
                for (int r1 = 1; r1 <= 9; r1++)
                {
                    FindResult result = new FindResult();

                    // look for two numbers (but for this query, have to also find answer matches too, which is skipped if using brain)
                    IEnumerable<Cell> firstPair = allCells.Where(cell => (cell.Row == r1) && (!cell.HasAnswer && cell.HasNote(n) || (cell.HasAnswer && (cell.Answer == n))));
                    // if found two, but they are JUST notes found (we found our note pairs)
                    if ((firstPair.Count() == 2) && firstPair.Where(cell => cell.HasAnswer).Count() == 0)
                    {
                        // now scan scoot down a row and try to find another pair
                        for (int r2 = r1 + 1; r2 <= 9; r2++)
                        {
                            // again, look for two numbers (but for this query, have to also find answer matches too, which is skipped if using brain)
                            IEnumerable<Cell> secondPair = allCells.Where(cell => (cell.Row == r2) && (!cell.HasAnswer && cell.HasNote(n) || (cell.HasAnswer && (cell.Answer == n))));
                            // again, if found two, but they are JUST notes found (we found our note pairs)
                            if ((secondPair.Count() == 2) && secondPair.Where(cell => cell.HasAnswer).Count() == 0)
                            {
                                // if the sets of pairs found are of the same column, they are lined up as xwing
                                if ((firstPair.OfType<Cell>().ToList()[0].Column == secondPair.OfType<Cell>().ToList()[0].Column) &&
                                    (firstPair.OfType<Cell>().ToList()[1].Column == secondPair.OfType<Cell>().ToList()[1].Column))
                                {
                                    // put all four cells involved in the single results object
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPair.OfType<Cell>().ToList()[0].Row, firstPair.OfType<Cell>().ToList()[0].Column), CellHighlightType.Special));
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPair.OfType<Cell>().ToList()[1].Row, firstPair.OfType<Cell>().ToList()[1].Column), CellHighlightType.Special));
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPair.OfType<Cell>().ToList()[0].Row, secondPair.OfType<Cell>().ToList()[0].Column), CellHighlightType.Special));
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPair.OfType<Cell>().ToList()[1].Row, secondPair.OfType<Cell>().ToList()[1].Column), CellHighlightType.Special));

                                    results.Add(result);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            // column-based xwings

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // from left, scan columns left to right
                for (int c1 = 1; c1 <= 9; c1++)
                {
                    FindResult result = new FindResult();

                    // look for two numbers (but for this query, have to also find answer matches too, which is skipped if using brain)
                    IEnumerable<Cell> firstPair = allCells.Where(cell => (cell.Column == c1) && (!cell.HasAnswer && cell.HasNote(n) || (cell.HasAnswer && (cell.Answer == n))));
                    // if found two, but they are JUST notes found (we found our note pairs)
                    if ((firstPair.Count() == 2) && firstPair.Where(cell => cell.HasAnswer).Count() == 0)
                    {
                        // now scan scoot over a column and try to find another pair
                        for (int c2 = c1 + 1; c2 <= 9; c2++)
                        {
                            // again, look for two numbers (but for this query, have to also find answer matches too, which is skipped if using brain)
                            IEnumerable<Cell> secondPair = allCells.Where(cell => (cell.Column == c2) && (!cell.HasAnswer && cell.HasNote(n) || (cell.HasAnswer && (cell.Answer == n))));
                            // again, if found two, but they are JUST notes found (we found our note pairs)
                            if ((secondPair.Count() == 2) && secondPair.Where(cell => cell.HasAnswer).Count() == 0)
                            {
                                // if the sets of pairs found are of the same row, they are lined up as xwing
                                if ((firstPair.OfType<Cell>().ToList()[0].Row == secondPair.OfType<Cell>().ToList()[0].Row) &&
                                    (firstPair.OfType<Cell>().ToList()[1].Row == secondPair.OfType<Cell>().ToList()[1].Row))
                                {
                                    // put all four cells involved in the single results object
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPair.OfType<Cell>().ToList()[0].Row, firstPair.OfType<Cell>().ToList()[0].Column), CellHighlightType.Special));
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPair.OfType<Cell>().ToList()[1].Row, firstPair.OfType<Cell>().ToList()[1].Column), CellHighlightType.Special));
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPair.OfType<Cell>().ToList()[0].Row, secondPair.OfType<Cell>().ToList()[0].Column), CellHighlightType.Special));
                                    result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPair.OfType<Cell>().ToList()[1].Row, secondPair.OfType<Cell>().ToList()[1].Column), CellHighlightType.Special));

                                    results.Add(result);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return results;
        }

        /// <summary>
        /// Find Skyscraper patterns
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindSkyscrapers(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            FindResult result = new FindResult();

            // TODO...make it actually find all skyscrapers
            result = new FindResult();
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(1, 1), CellHighlightType.Special));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(6, 1), CellHighlightType.Special));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(1, 7), CellHighlightType.Special));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(6, 8), CellHighlightType.Special));
            results.Add(result);

            return results;
        }

        /// <summary>
        /// Find XYWing patterns
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindXYWings(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            FindResult result = new FindResult();

            // TODO...make it actually find all xywings
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(2, 2), CellHighlightType.Pivot));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(2, 7), CellHighlightType.Pincer));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(7, 2), CellHighlightType.Pincer));
            results.Add(result);

            return results;
        }

        /// <summary>
        /// Find Two-String kite patterns
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindTwoStringKites(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            FindResult result = new FindResult();

            // TODO...make it actually find all two-string kites

            return results;
        }
        #endregion
    }
}
