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
        }

        /// <summary>
        /// Find the specified pattern on the specified board
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <param name="pattern">Pattern to search for</param>
        /// <returns>List of found patterns</returns>
        public List<FindResult> Find(Board board, Pattern pattern)
        {
            return _methods[pattern](board);
        }

        #region Finders

        /// <summary>
        /// Find XWing patterns
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindXWings(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            FindResult result = new FindResult();

            // TODO...make it actually find all xwings
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(2, 2), CellHighlightType.Pivot));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(2, 7), CellHighlightType.Pincer));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(7, 2), CellHighlightType.Pincer));
            results.Add(result);

            result = new FindResult();
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(3, 3), CellHighlightType.Special));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(3, 9), CellHighlightType.Special));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(9, 3), CellHighlightType.Special));
            result.CellsFound.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(9, 9), CellHighlightType.Special));
            results.Add(result);

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

            // TODO

            return results;
        }
        #endregion
    }
}
