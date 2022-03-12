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
            _methods[Pattern.NakedSingle] = FindNakedSingles;
            _methods[Pattern.HiddenSingle] = FindHiddenSingles;
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
            if (_methods[pattern] != null)
                return _methods[pattern](board);
            else
                return new List<FindResult>();
        }

        /// <summary>
        /// Return unique list of results from passed in results list
        /// </summary>
        /// <param name="resultsToDedupe">List of results that might have dupes to dedupe</param>
        /// <returns>List of unique results</returns>
        private List<FindResult> DedupeResults(List<FindResult> resultsToDedupe)
        {
            List<FindResult> dedupedResults = new List<FindResult>();
            List<String> priorResultsInfo = new List<string>();

            foreach (FindResult resultToDedupe in resultsToDedupe)
            {
                string resultInfo = "";

                // if just a single cell in the results, easy to just ensure that "[r,c]" isn't in the final results more than once
                if (resultToDedupe.CandidateCells.Count == 1)
                {
                    resultInfo = resultToDedupe.ToString();

                    // also add in any candidate details that are associated to the result
                    foreach (Note note in resultToDedupe.CandidateNotes)
                        resultInfo += note.Candidate.ToString();
                }
                else // need to do crazy stuff to ensure the same list of cells wasn't found in a different find order
                {
                    List<string> combinedInfo = new List<string>();

                    // build single string based on cell coords
                    foreach (KeyValuePair<Cell, CellHighlightType> candidateCell in resultToDedupe.CandidateCells)
                        combinedInfo.Add(candidateCell.Key.ToString());

                    // also add in any candidate details that are associated to the result
                    foreach (Note note in resultToDedupe.CandidateNotes)
                        combinedInfo.Add(note.Candidate.ToString());

                    // now take all the details about cells and candidate notes, sort it, then use this string later for "if seen this full detail before"
                    var arr = combinedInfo.ToArray();
                    Array.Sort(arr);
                    resultInfo = string.Join("", arr);
                }

                // if not already seen this cell coords and candidate info
                if (!priorResultsInfo.Contains(resultInfo))
                {
                    dedupedResults.Add(resultToDedupe);
                        
                    // remember already seen this cell coords and candidate info
                    priorResultsInfo.Add(resultInfo);
                }
            }

            return dedupedResults;
        }

        #region Finders

        /// <summary>
        /// Find Naked Single occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of locations found</returns>
        private List<FindResult> FindNakedSingles(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);

            // look for cells with naked singles
            var cellsWithNakedSingle = allCells.Where(cell => !cell.HasAnswer && cell.HasSingleNote()).ToList<Cell>();
            
            // build results list for all found
            foreach (Cell cellWithNakedSingle in cellsWithNakedSingle)
            {
                FindResult result = new FindResult();

                result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(cellWithNakedSingle.Row, cellWithNakedSingle.Column), CellHighlightType.Special));

                // assuming the cell will have a SINGLE visible note due to the HasSingleNote call when building the nakeds list above
                result.CandidateNotes.Add(cellWithNakedSingle.GetOnlyNote());
                results.Add(result);
            }

            return DedupeResults(results);
        }

        /// <summary>
        /// Find Hidden Single patterns
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindHiddenSingles(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);

            // row-based

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan rows from top to bottom
                for (int r1 = 1; r1 <= 9; r1++)
                {
                    FindResult result = new FindResult();

                    // look for notes of n on this row
                    var cellsWithNote = allCells.Where(cell => (cell.Row == r1) && cell.HasNoteOf(n)).ToList<Cell>();

                    // if found a single note hidden in a pack of notes
                    if ((cellsWithNote.Count() == 1) && cellsWithNote[0].HasMultipleNotes())
                    {
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(cellsWithNote[0].Row, cellsWithNote[0].Column), CellHighlightType.Special));

                        result.CandidateNotes.Add(cellsWithNote[0].GetNoteForCandidate(n));

                        // cell with eliminations is the same cell as the hidden single
                        result.EliminationCells.Add(cellsWithNote[0]);

                        // remember which note was needing elimination
                        result.EliminationNotes.AddRange(cellsWithNote[0].Notes.Where(note => (note.Candidate != n) && (note.Candidate != 0)));

                        results.Add(result);
                    }
                }
            }

            // column-based

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan columns left to right
                for (int c1 = 1; c1 <= 9; c1++)
                {
                    FindResult result = new FindResult();

                    // look for notes of n in this column
                    var cellsWithNote = allCells.Where(cell => (cell.Column == c1) && cell.HasNoteOf(n)).ToList<Cell>();

                    // if found a single note hidden in a pack of notes
                    if ((cellsWithNote.Count() == 1) && cellsWithNote[0].HasMultipleNotes())
                    {
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(cellsWithNote[0].Row, cellsWithNote[0].Column), CellHighlightType.Special));

                        result.CandidateNotes.Add(cellsWithNote[0].GetNoteForCandidate(n));

                        // cell with eliminations is the same cell as the hidden single
                        result.EliminationCells.Add(cellsWithNote[0]);

                        // remember which note was needing elimination
                        result.EliminationNotes.AddRange(cellsWithNote[0].Notes.Where(note => (note.Candidate != n) && (note.Candidate != 0)));

                        results.Add(result);
                    }
                }
            }

            // block-based

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan blocks
                for (int b1 = 1; b1 <= 9; b1++)
                {
                    FindResult result = new FindResult();

                    // look for notes of n in this block
                    var cellsWithNote = allCells.Where(cell => (cell.Block == b1) && cell.HasNoteOf(n)).ToList<Cell>();

                    // if found a single note hidden in a pack of notes
                    if ((cellsWithNote.Count() == 1) && cellsWithNote[0].HasMultipleNotes())
                    {
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(cellsWithNote[0].Row, cellsWithNote[0].Column), CellHighlightType.Special));

                        result.CandidateNotes.Add(cellsWithNote[0].GetNoteForCandidate(n));

                        // cell with eliminations is the same cell as the hidden single
                        result.EliminationCells.Add(cellsWithNote[0]);

                        // remember which note was needing elimination
                        result.EliminationNotes.AddRange(cellsWithNote[0].Notes.Where(note => (note.Candidate != n) && (note.Candidate != 0)));

                        results.Add(result);
                    }
                }
            }

            return DedupeResults(results);
        }

        /// <summary>
        /// Find XWing patterns
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
                // scan rows from top to bottom
                for (int r1 = 1; r1 <= 9; r1++)
                {
                    FindResult result = new FindResult();

                    // look for notes of n
                    IEnumerable<Cell> firstPair = allCells.Where(cell => (cell.Row == r1) && cell.HasNoteOf(n));
                    // if found two
                    if (firstPair.Count() == 2)
                    {
                        // now scoot down a row and try to find another pair from there to bottom
                        for (int r2 = r1 + 1; r2 <= 9; r2++)
                        {
                            // again, look for notes of n
                            IEnumerable<Cell> secondPair = allCells.Where(cell => (cell.Row == r2) && cell.HasNoteOf(n));
                            // again, if found two
                            if (secondPair.Count() == 2)
                            {
                                var firstPairAsList = firstPair.OfType<Cell>().ToList();
                                var secondPairAsList = secondPair.OfType<Cell>().ToList();

                                // if the sets of pairs found are of the same column, but not in the same block, we have an xwing
                                if (((firstPairAsList[0].Column == secondPairAsList[0].Column) &&
                                     (firstPairAsList[1].Column == secondPairAsList[1].Column)) &&
                                    ((firstPairAsList[0].Block != firstPairAsList[1].Block) ||
                                     (firstPairAsList[0].Block != secondPairAsList[0].Block)))
                                {
                                    // put all four cells involved in the single results object
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[0].Row, firstPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[1].Row, firstPairAsList[1].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[0].Row, secondPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[1].Row, secondPairAsList[1].Column), CellHighlightType.Special));

                                    // remember which note was the candidate in the cell
                                    result.CandidateNotes.Add(firstPair.First().GetNoteForCandidate(n));

                                    // find all the cells with notes that should be eliminated (same columns but not in same rows as the candidate cells above)
                                    var eliminationCells = allCells.Where(cell => ((cell.Column == firstPairAsList[0].Column) || (cell.Column == firstPairAsList[1].Column)) && (cell.Row != r1) && (cell.Row != r2) && cell.HasNoteOf(n));
                                    result.EliminationCells.AddRange(eliminationCells);

                                    // remember which note was needing elimination
                                    result.EliminationNotes.Add(firstPair.First().GetNoteForCandidate(n));

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
                // scan columns left to right
                for (int c1 = 1; c1 <= 9; c1++)
                {
                    FindResult result = new FindResult();

                    // look for notes of n
                    IEnumerable<Cell> firstPair = allCells.Where(cell => (cell.Column == c1) && cell.HasNoteOf(n));
                    // if found two
                    if (firstPair.Count() == 2)
                    {
                        // now scoot over a column and try to find another pair from there to the right
                        for (int c2 = c1 + 1; c2 <= 9; c2++)
                        {
                            // again, look for notes of n
                            IEnumerable<Cell> secondPair = allCells.Where(cell => (cell.Column == c2) && cell.HasNoteOf(n));
                            // again, if found two
                            if (secondPair.Count() == 2)
                            {
                                var firstPairAsList = firstPair.OfType<Cell>().ToList();
                                var secondPairAsList = secondPair.OfType<Cell>().ToList();

                                // if the sets of pairs found are of the same row, but not in the same block, we have an xwing
                                if (((firstPairAsList[0].Row == secondPairAsList[0].Row) &&
                                    (firstPairAsList[1].Row == secondPairAsList[1].Row)) &&
                                    ((firstPairAsList[0].Block != firstPairAsList[1].Block) ||
                                     (firstPairAsList[0].Block != secondPairAsList[0].Block)))
                                {
                                    // put all four cells involved in the single results object
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[0].Row, firstPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[1].Row, firstPairAsList[1].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[0].Row, secondPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[1].Row, secondPairAsList[1].Column), CellHighlightType.Special));

                                    // remember which note was the candidate in the cell
                                    result.CandidateNotes.Add(firstPair.First().GetNoteForCandidate(n));

                                    // find all the cells with notes that should be eliminated (same rows but not in same columns as the candidate cells above)
                                    var eliminationCells = allCells.Where(cell => ((cell.Row == firstPairAsList[0].Row) || (cell.Row == firstPairAsList[1].Row)) && (cell.Column != c1) && (cell.Column != c2) && cell.HasNoteOf(n));
                                    result.EliminationCells.AddRange(eliminationCells);

                                    // remember which note was needing elimination
                                    result.EliminationNotes.Add(firstPair.First().GetNoteForCandidate(n));
                                    
                                    results.Add(result);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return DedupeResults(results);
        }

        /// <summary>
        /// Find Skyscraper patterns
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindSkyscrapers(Board board)
        {
            // THIS IS BROKEN
            // THIS IS BROKEN
            // THIS IS BROKEN
            //
            // It doesn't consider needing to have tops in differing blocks and it doesn't ensure the tower directions are actually legit
            //
            // THIS IS BROKEN
            // THIS IS BROKEN
            // THIS IS BROKEN
            // THIS IS BROKEN


            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);

            // row-based skyscrapers

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan rows from top to bottom
                for (int r1 = 1; r1 <= 9; r1++)
                {
                    FindResult result = new FindResult();

                    // look for notes of n
                    IEnumerable<Cell> firstPair = allCells.Where(cell => (cell.Row == r1) && cell.HasNoteOf(n));
                    // if found two
                    if (firstPair.Count() == 2)
                    {
                        // now scoot down a row and try to find another pair from there to bottom
                        for (int r2 = r1 + 1; r2 <= 9; r2++)
                        {
                            // again, look for notes of n
                            IEnumerable<Cell> secondPair = allCells.Where(cell => (cell.Row == r2) && cell.HasNoteOf(n));
                            // again, if found two
                            if (secondPair.Count() == 2)
                            {
                                var firstPairAsList = firstPair.OfType<Cell>().ToList();
                                var secondPairAsList = secondPair.OfType<Cell>().ToList();

                                // if the sets of pairs found line up on one side but are offset on the other, and both offset ends are outside the lined up pair's block, we have a skyscraper
                                if ((((firstPairAsList[0].Column == secondPairAsList[0].Column) && 
                                      (firstPairAsList[1].Column != secondPairAsList[1].Column)) ||
                                     ((firstPairAsList[0].Column != secondPairAsList[0].Column) && 
                                      (firstPairAsList[1].Column == secondPairAsList[1].Column))) &&
                                    ((firstPairAsList[0].Block != firstPairAsList[1].Block) ||
                                     (firstPairAsList[0].Block != secondPairAsList[0].Block)))
                                {
                                    // put all four cells involved in the single results object
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[0].Row, firstPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[1].Row, firstPairAsList[1].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[0].Row, secondPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[1].Row, secondPairAsList[1].Column), CellHighlightType.Special));

                                    result.CandidateNotes.Add(firstPair.First().GetNoteForCandidate(n));
                                    results.Add(result);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            // column-based skyscrapers

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan columns left to right
                for (int c1 = 1; c1 <= 9; c1++)
                {
                    FindResult result = new FindResult();

                    // look for notes of n
                    IEnumerable<Cell> firstPair = allCells.Where(cell => (cell.Column == c1) && cell.HasNoteOf(n));
                    // if found two
                    if (firstPair.Count() == 2)
                    {
                        // now scoot over a column and try to find another pair from there to the right
                        for (int c2 = c1 + 1; c2 <= 9; c2++)
                        {
                            // again, look for notes of n
                            IEnumerable<Cell> secondPair = allCells.Where(cell => (cell.Column == c2) && cell.HasNoteOf(n));
                            // again, if found two
                            if (secondPair.Count() == 2)
                            {
                                var firstPairAsList = firstPair.OfType<Cell>().ToList();
                                var secondPairAsList = secondPair.OfType<Cell>().ToList();

                                // if the sets of pairs found line up on one side but are offset on the other, and both offset ends are outside the lined up pair's block, we have a skyscraper
                                if ((((firstPairAsList[0].Row == secondPairAsList[0].Row) &&
                                      (firstPairAsList[1].Row != secondPairAsList[1].Row)) ||
                                     ((firstPairAsList[0].Row != secondPairAsList[0].Row) &&
                                      (firstPairAsList[1].Row == secondPairAsList[1].Row))) &&
                                    ((firstPairAsList[0].Block != firstPairAsList[1].Block) ||
                                     (firstPairAsList[0].Block != secondPairAsList[0].Block)))
                                {
                                    // put all four cells involved in the single results object
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[0].Row, firstPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[1].Row, firstPairAsList[1].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[0].Row, secondPairAsList[0].Column), CellHighlightType.Special));
                                    result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[1].Row, secondPairAsList[1].Column), CellHighlightType.Special));

                                    result.CandidateNotes.Add(firstPair.First().GetNoteForCandidate(n));
                                    results.Add(result);
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return DedupeResults(results);
        }
        #endregion
    }
}
