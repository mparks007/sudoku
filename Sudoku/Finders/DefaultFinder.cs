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
            _methods[Pattern.NakedPair] = FindNakedPairs;
            _methods[Pattern.NakedTriple] = FindNakedTriples;
            _methods[Pattern.NakedQuad] = FindNakedQuads;
            _methods[Pattern.NakedQuint] = FindNakedQuints;
            _methods[Pattern.HiddenSingle] = FindHiddenSingles;
            _methods[Pattern.HiddenPair] = FindHiddenPairs;
            _methods[Pattern.HiddenTriple] = FindHiddenTriples;
            _methods[Pattern.HiddenQuad] = FindHiddenQuads;
            _methods[Pattern.HiddenQuint] = FindHiddenQuints;
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
                List<string> combinedInfo = new List<string>();

                // build single string based on cell coords [r,c]
                foreach (KeyValuePair<Cell, CellHighlightType> candidateCell in resultToDedupe.CandidateCells)
                    combinedInfo.Add(candidateCell.Key.ToString());

                // also add in any candidate details that are associated to the result
                foreach (Note note in resultToDedupe.CandidateNotes)
                    combinedInfo.Add(note.Candidate.ToString());

                // then throw in house type to ensure some max uniqueness
                combinedInfo.Add(resultToDedupe.HouseType.Description());

                // now take all the details about cells and candidate notes and house, then sort it, then use this string later for "if seen this full detail before"
                var arr = combinedInfo.ToArray();
                Array.Sort(arr);
                resultInfo = string.Join("", arr);

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
        /// Determine if a cell has the right notes match for a candidate set
        /// </summary>
        /// <param name="cell">Cell to search its Notes</param>
        /// <param name="setCandidates">Candidate list to search for (like ALL the numbers that would make a triple, quad, quint, whatever is being searched for)</param>
        /// <param name="widthOfSet">If the subset is a single, pair, triple, quad, quint</param>
        /// <param name="doSearchForNaked">Flag if this is a naked or hidden type search</param>
        /// <returns>True if the cell has the right amount of notes and the right coverage of notes to be a part of a set type</returns>
        private bool CellContainsSuitableNotes(Cell cell, int[] setCandidates, int subsetWidth, bool doSearchForNaked)
        {
            // gather the notes that are matching the set needed
            var notesMatchingSetCandidates = cell.Notes.Where(note => setCandidates.Contains(note.Candidate));

            // singles have to have one note, but two or more set notes required for triples and above
            if ((subsetWidth == 1 && notesMatchingSetCandidates.Count() == 1) || (subsetWidth > 1 && notesMatchingSetCandidates.Count() >= 2))
            {
                // if naked search, the set notes found must be all the available notes
                if (doSearchForNaked)
                    return (notesMatchingSetCandidates.Count() == cell.NumberOfNotes());
                else // hiddens search, so the set notes found must be buried in extra notes OR the notes matched the subset exactly (which is a naked on its own but with other hiddens it should work out)
                    return (notesMatchingSetCandidates.Count() < cell.NumberOfNotes() || notesMatchingSetCandidates.Count() == subsetWidth);
            }
            return false;
        }

        /// <summary>
        /// Build out a list of all combinations of digits in a subset based on the subsets max amount of digits
        /// </summary>
        /// <param name="widthOfSet">If the subset is a single, pair, triple, quad, quint</param>
        /// <param name="position">Array position tracker for recursive logic</param>
        /// <param name="candidateSetValues">Subset candidates tracker for recursive logic</param>
        /// <param name="finalSubsetList">Final list of all the possible combinations of subset digits</param>
        private void BuildSetDigitCombinations(int widthOfSet, int position, int[] candidateSetValues, List<string> finalSubsetList)
        {
            for (int n = 1; n <= 9; n++)
            {
                // build out an array that has as many digits as the number of subset values (1 for singles, 2 for pairs, 3 for triples, etc.)
                candidateSetValues[position] = n;

                // if have option to fill in a digit further to the end of the candidateSetValues array (building numbers right to left)
                if (position < widthOfSet - 1)
                {
                    // recursive call needs to skip to next array position in candidateSetValues array
                    position++;

                    // recurse to loop and build out the latest candidateSetValues array slot
                    BuildSetDigitCombinations(widthOfSet, position, candidateSetValues, finalSubsetList);
                    
                    // unwinding once so back up one position in candidateSetValues array
                    position--;
                }
                else
                {
                    // to avoid anything where a subset digit is in the array twice (sure, allow 123 for a triple, but skip over 113 since no way would two 1s in any cell)
                    if (candidateSetValues.Distinct().Count() == widthOfSet)
                    {
                        // sort subset for easier checking if seen this combo in prior pass
                        string sortedSubset = string.Join("", candidateSetValues.OrderBy(i => i));

                        // if not already seen these triplets
                        if (finalSubsetList.Where(str => str == sortedSubset).Count() == 0)
                        {
                            // remember having seen subset for next time
                            finalSubsetList.Add(sortedSubset);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Find Naked Single occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Single locations found</returns>
        private List<FindResult> FindNakedSingles(Board board)
        {
            return FindNakedSubsets(board, 1);
        }

        /// <summary>
        /// Find Naked Pair occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Pair locations found</returns>
        private List<FindResult> FindNakedPairs(Board board)
        {
            return FindNakedSubsets(board, 2);
        }

        /// <summary>
        /// Find Naked Triple occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Triple locations found</returns>
        private List<FindResult> FindNakedTriples(Board board)
        {
            return FindNakedSubsets(board, 3);
        }

        /// <summary>
        /// Find Naked Quad occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Quad locations found</returns>
        private List<FindResult> FindNakedQuads(Board board)
        {
            return FindNakedSubsets(board, 4);
        }

        /// <summary>
        /// Find Naked Quint occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Quint locations found</returns>
        private List<FindResult> FindNakedQuints(Board board)
        {
            return FindNakedSubsets(board, 5);
        }

        /// <summary>
        /// Common method for finding Naked Subsets
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <param name="subsetWidth">Width of the subset (2=pairs, 3=triples, etc.)</param>
        /// <returns>List of Naked subset locations found</returns>
        private List<FindResult> FindNakedSubsets(Board board, int subsetWidth)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);
            int[] currentSubset = new int[subsetWidth];
            List<string> subsetCandidates = new List<string>();
            int position = 0;

            // build out a list of all combinations of digits in a subset based on the subsets max amount of digits
            BuildSetDigitCombinations(subsetWidth, position, currentSubset, subsetCandidates);

            // now go use all these collections of subset digits to see what subset patterns can be found (was strings for easier usage in BuildSetDigitCombinations but want int[] version to send to search funcs)
            foreach (string subset in subsetCandidates)
            {
                // gonna go ahead and override this variable previously used to recursively build the subsetCandidates list
                currentSubset = subset.Select(s => Int32.Parse(s.ToString())).ToArray();

                SearchHouseForNakeds(allCells, currentSubset, HouseType.Row, results);
                SearchHouseForNakeds(allCells, currentSubset, HouseType.Column, results);
                SearchHouseForNakeds(allCells, currentSubset, HouseType.Block, results);
            }

            return DedupeResults(results);
        }

        /// <summary>
        /// Get the value for the House property based on a specific house type of a cell 
        /// </summary>
        /// <param name="cell">Which cell to use</param>
        /// <param name="houseType">Which housetype to focus on</param>
        /// <returns>The 'value within a house' of a cell based on a specific house type</returns>
        private int GetHouseElementNumForCell(Cell cell, HouseType houseType)
        {
            switch (houseType)
            {
                case HouseType.Row:
                    return cell.Row;
                case HouseType.Column:
                    return cell.Column;
                case HouseType.Block:
                    return cell.Block;
                default:
                    throw new ArgumentException(String.Format("Invalid HouseType: {0}", houseType));
            }
        }

        /// <summary>
        /// Search a particular house type for a naked subset type
        /// </summary>
        /// <param name="allCells">Flattened list of all cells to check</param>
        /// <param name="currentSubset">List of all number combinations in a subset</param>
        /// <param name="houseType">Type of house being searched</param>
        /// <param name="results">Results for all the found cells that matched the subset search</param>
        private void SearchHouseForNakeds(IEnumerable<Cell> allCells, int[] currentSubset, HouseType houseType, List<FindResult> results)
        {
            // check each row, column, or block (depends on houseType)
            for (int houseElementNum = 1; houseElementNum <= 9; houseElementNum++)
            {
                FindResult result = new FindResult
                {
                    HouseType = houseType
                };

                // look for cells with correct subset usage
                var cellsWithCorrectSubset = allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseElementNum && CellContainsSuitableNotes(cell, currentSubset, currentSubset.Length, doSearchForNaked: true)).ToList<Cell>();

                // get a distinct list of candidates from every cell that has our subset 
                var uniqueCandidatesFound = cellsWithCorrectSubset.SelectMany(cell => cell.Notes).Where(note => note.IsNoted).Select(note => note.Candidate).Distinct();

                // if found correct number of cells for the subset size AND found all of the subset candidates within any combination of notes within those cells 
                if (cellsWithCorrectSubset.Count == currentSubset.Length && uniqueCandidatesFound.Count() == currentSubset.Length)
                {
                    List<Note> candidateNotes = new List<Note>();

                    foreach (Cell cellWithCorrectSubset in cellsWithCorrectSubset)
                    {
                        // put matching cells into the single results object
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(cellWithCorrectSubset, CellHighlightType.Special));

                        // since nakeds, just collect all the notes since all are a part of the subset (deduped below this loop)
                        candidateNotes.AddRange(cellWithCorrectSubset.GetNotesWithAnyCandidate());
                    }

                    // remember which notes were the candidates in the cell (dedupe what got built out when learning which cells had the subsets)
                    result.CandidateNotes.AddRange(candidateNotes.Distinct());

                    // gather cells that are not a part of the found cells (these will have notes that need eliminations within them)
                    result.EliminationCells.AddRange(allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseElementNum && cellsWithCorrectSubset.IndexOf(cell) < 0));

                    // remember which remaining notes were needing elimination (would be those notes of the found subset itself since the nakeds had all of them in some way)
                    result.EliminationNotes.AddRange(result.CandidateNotes);

                    results.Add(result);
                }
            }

        }

        /// <summary>
        /// Find Hidden Singles occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Singles locations found</returns>
        private List<FindResult> FindHiddenSingles(Board board)
        {
            return FindHiddenSubsets(board, 1);
        }

        /// <summary>
        /// Find Hidden Pairs occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Pairs locations found</returns>
        private List<FindResult> FindHiddenPairs(Board board)
        {
            return FindHiddenSubsets(board, 2);
        }

        /// <summary>
        /// Find Hidden Triples occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Triples locations found</returns>
        private List<FindResult> FindHiddenTriples(Board board)
        {
            return FindHiddenSubsets(board, 3);
        }

        /// <summary>
        /// Find Hidden Quads occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Quads locations found</returns>
        private List<FindResult> FindHiddenQuads(Board board)
        {
            return FindHiddenSubsets(board, 4);
        }

        /// <summary>
        /// Find Hidden Quints occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Quints locations found</returns>
        private List<FindResult> FindHiddenQuints(Board board)
        {
            return FindHiddenSubsets(board, 5);
        }

        /// <summary>
        /// Common method for finding Hidden Subsets
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <param name="subsetWidth">Width of the subset (2=pairs, 3=triples, etc.)</param>
        /// <returns>List of Hidden subset locations found</returns>
        private List<FindResult> FindHiddenSubsets(Board board, int subsetWidth)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);
            int[] currentSubset = new int[subsetWidth];
            List<string> subsetCandidates = new List<string>();
            int position = 0;

            // build out a list of all combinations of digits in a subset based on the subsets max amount of digits
            BuildSetDigitCombinations(subsetWidth, position, currentSubset, subsetCandidates);

            // now go use all these collections of subset digits to see what subset patterns can be found (was strings for easier usage in BuildSetDigitCombinations but want int[] version to send to search funcs)
            foreach (string subset in subsetCandidates)
            {
                // gonna go ahead and override this variable previously used to recursively build the subsetCandidates list
                currentSubset = subset.Select(s => Int32.Parse(s.ToString())).ToArray();

                SearchHouseForHiddens(allCells, currentSubset, HouseType.Row, results);
                SearchHouseForHiddens(allCells, currentSubset, HouseType.Column, results);
                SearchHouseForHiddens(allCells, currentSubset, HouseType.Block, results);
            }

            return DedupeResults(results);
        }

        /// <summary>
        /// Search a particular house type for a hidden subset type
        /// </summary>
        /// <param name="allCells">Flattened list of all cells to check</param>
        /// <param name="currentSubset">List of all number combinations in a subset</param>
        /// <param name="houseType">Type of house being searched</param>
        /// <param name="results">Results for all the found cells that matched the subset search</param>
        private void SearchHouseForHiddens(IEnumerable<Cell> allCells, int[] currentSubset, HouseType houseType, List<FindResult> results)
        {
            //hiddens are still broken
            //hiddens are still broken
            //hiddens are still broken
            //hiddens are still broken

            // check each row, column, or block (depends on houseType)
            for (int houseElementNum = 1; houseElementNum <= 9; houseElementNum++)
            {
                FindResult result = new FindResult
                {
                    HouseType = houseType
                };

                // look for cells with correct subset usage
                var cellsWithCorrectSubset = allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseElementNum && CellContainsSuitableNotes(cell, currentSubset, currentSubset.Length, doSearchForNaked:false)).ToList<Cell>();

                // get a distinct list of candidates from every note from every cell that has our subset
                var uniqueCandidatesFound = cellsWithCorrectSubset.SelectMany(cell => cell.Notes).Where(note => note.IsNoted).Select(note => note.Candidate).Distinct();

                List<Cell> invalidatingCells = new List<Cell>();

                // if cells found didn't cover all the notes in the subset being searched for
                if (cellsWithCorrectSubset.SelectMany(cell => cell.Notes.Where(note => currentSubset.Contains(note.Candidate))).Count() != currentSubset.Length)
                    continue;

                // find all the cells that are not in the found subset sets but do have any of the notes of the subset (which would invalidate the hidden aspect)
                invalidatingCells = allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseElementNum && cellsWithCorrectSubset.IndexOf(cell) < 0 && cell.HasAnyNotesOf(currentSubset)).ToList<Cell>();

                // if found correct number of cells for the subset size AND no other cells ruin the find AND either hidden search or found all of the subset candidates within any combination of notes within those cells 
//                    if (cellsWithCorrectSubset.Count == subsetWidth && invalidatingCells.Count() == 0 && (!doSearchForNaked || uniqueCandidatesFound.Count() == subsetWidth))
                {
                    List<Note> candidateNotes = new List<Note>();

                    // put cells involved into the single results object
                    foreach (Cell cellWithCorrectSubset in cellsWithCorrectSubset)
                    {
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(cellWithCorrectSubset, CellHighlightType.Special));

                        // candidates must be all notes in the cell that are in the subset being searched
                        candidateNotes.AddRange(cellsWithCorrectSubset.SelectMany(cell => cell.Notes.Where(note => currentSubset.Contains(note.Candidate))));
                    }

                    // remember which notes were the candidates in the cell (dedupe what got built out when learning which cells had the subsets)
                    result.CandidateNotes.AddRange(candidateNotes.Distinct());

                    List<Cell> cellsWithEliminations = new List<Cell>();
                    List<Note> candidateNotesToEliminate = new List<Note>();

                    // for hiddens, the cell with the subset found is also where the eliminations would be necessary
                    cellsWithEliminations.AddRange(cellsWithCorrectSubset);

                    // the notes to eliminate in the cells not in the subset match would be those notes of the subset
                    candidateNotesToEliminate.AddRange(cellsWithEliminations.SelectMany(cell => cell.Notes.Where(note => note.IsNoted && !currentSubset.Contains(note.Candidate))));

                    // cell with eliminations (is the same cell as the hidden single already found above)
                    result.EliminationCells.AddRange(cellsWithEliminations);

                    // remember which remaining notes were needing elimination
                    result.EliminationNotes.AddRange(candidateNotesToEliminate);

                    results.Add(result);
                }
            }
        }

        /// <summary>
        /// Find Hidden Single patterns
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Single patterns found</returns>
        private List<FindResult> FindHiddenSinglesX(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);

            // do rows

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan rows from top to bottom
                for (int r = 1; r <= 9; r++)
                {
                    FindResult result = new FindResult();
                    result.HouseType = HouseType.Row;

                    // look for notes of n on this row
                    var cellsWithNote = allCells.Where(cell => (cell.Row == r) && cell.HasNoteOf(n)).ToList<Cell>();

                    // if found a single cell in the house with the note and that note is hidden in a pack of notes
                    if ((cellsWithNote.Count() == 1) && cellsWithNote[0].HasMultipleNotes())
                    {
                        // load in all the cells involved in the pattern
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(cellsWithNote[0].Row, cellsWithNote[0].Column), CellHighlightType.Special));

                        // remember which naked single note was found 
                        result.CandidateNotes.Add(cellsWithNote[0].GetNoteForCandidate(n));

                        // cell with eliminations (is the same cell as the hidden single already found above)
                        result.EliminationCells.Add(cellsWithNote[0]);

                        // remember which remaining notes were needing elimination
                        result.EliminationNotes.AddRange(cellsWithNote[0].Notes.Where(note => (note.Candidate != n) && (note.Candidate != 0)));

                        results.Add(result);
                    }
                }
            }

            // do columns

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan columns left to right
                for (int c = 1; c <= 9; c++)
                {
                    FindResult result = new FindResult();
                    result.HouseType = HouseType.Column;

                    // look for notes of n in this column
                    var cellsWithNote = allCells.Where(cell => (cell.Column == c) && cell.HasNoteOf(n)).ToList<Cell>();

                    // if found a single cell in the house with the note and that note is hidden in a pack of notes
                    if ((cellsWithNote.Count() == 1) && cellsWithNote[0].HasMultipleNotes())
                    {
                        // load in all the cells involved in the pattern
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(cellsWithNote[0].Row, cellsWithNote[0].Column), CellHighlightType.Special));

                        // remember which naked single note was found 
                        result.CandidateNotes.Add(cellsWithNote[0].GetNoteForCandidate(n));

                        // cell with eliminations (is the same cell as the hidden single already found above)
                        result.EliminationCells.Add(cellsWithNote[0]);

                        // remember which remaining notes were needing elimination
                        result.EliminationNotes.AddRange(cellsWithNote[0].Notes.Where(note => (note.Candidate != n) && (note.Candidate != 0)));

                        results.Add(result);
                    }
                }
            }

            // do blocks

            // pick one number at a time
            for (int n = 1; n <= 9; n++)
            {
                // scan blocks
                for (int b = 1; b <= 9; b++)
                {
                    FindResult result = new FindResult();
                    result.HouseType = HouseType.Block;

                    // look for notes of n in this block
                    var cellsWithNote = allCells.Where(cell => (cell.Block == b) && cell.HasNoteOf(n)).ToList<Cell>();

                    // if found a single cell in the house with the note and that note is hidden in a pack of notes
                    if ((cellsWithNote.Count() == 1) && cellsWithNote[0].HasMultipleNotes())
                    {
                        // load in all the cells involved in the pattern
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(cellsWithNote[0].Row, cellsWithNote[0].Column), CellHighlightType.Special));

                        // remember which naked single note was found 
                        result.CandidateNotes.Add(cellsWithNote[0].GetNoteForCandidate(n));

                        // cell with eliminations (is the same cell as the hidden single already found above)
                        result.EliminationCells.Add(cellsWithNote[0]);

                        // remember which remaining notes were needing elimination
                        result.EliminationNotes.AddRange(cellsWithNote[0].Notes.Where(note => (note.Candidate != n) && (note.Candidate != 0)));

                        results.Add(result);
                    }
                }
            }

            return DedupeResults(results);
        }

        /// <summary>
        /// Find Hidden Pair occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Pair locations found</returns>
        private List<FindResult> FindHiddenPairsX(Board board)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);
            List<KeyValuePair<int, int>> reverseCheckList = new List<KeyValuePair<int, int>>();

            // pick one number at a time for the first part of the pair
            for (int n1 = 1; n1 <= 9; n1++)
            {
                // pick one number at a time for the second part of the pair
                for (int n2 = 1; n2 <= 9; n2++)
                {
                    // if about to compare the same two numbers, skip it
                    if (n1 == n2)
                    {
                        n2++;

                        // sanity check to avoid using a 10
                        if (n2 > 9)
                            continue;
                    }

                    // keep track of each pair already seen
                    reverseCheckList.Add(new KeyValuePair<int, int>(n1, n2));

                    // if already seen the reverse of a seen pair, skip the check (have seen 1,2 so skip 2,1)
                    if (reverseCheckList.Where(kvp => kvp.Key == n2 && kvp.Value == n1).Count() != 0)
                        continue;

                    // check each row
                    for (int r = 1; r <= 9; r++)
                    {
                        FindResult result = new FindResult();
                        result.HouseType = HouseType.Row;

                        // find cells that have the two notes in the search
                        var cellsWithCorrectHiddens = allCells.Where(cell => !cell.HasAnswer && cell.Row == r && cell.HasNoteOf(n1) && cell.HasNoteOf(n2)).ToList<Cell>();
                        // find any cells that have either/both of those notes but are not in the cells just found with BOTH notes
                        var invalidatingCells = allCells.Where(cell => !cell.HasAnswer && cell.Row == r && (cell.HasNoteOf(n1) || cell.HasNoteOf(n2)) && cellsWithCorrectHiddens.IndexOf(cell) < 0).ToList<Cell>();
                       // need invalidating cells concept in common findsubset method to find the other cells not in the subset matches
                        // if found two sets of notes and no other cells with those notes and the two found are not just naked pairs (either have more than two notes)
                        if ((cellsWithCorrectHiddens.Count() == 2) && invalidatingCells.Count() == 0 && (cellsWithCorrectHiddens[0].NumberOfNotes() > 2 || cellsWithCorrectHiddens[1].NumberOfNotes() > 2))
                        {
                            // put cells involved into the single results object
                            foreach (Cell cellWithCorrectHiddens in cellsWithCorrectHiddens)
                                result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(cellWithCorrectHiddens, CellHighlightType.Special));

                            // remember which note was the candidate in the cell
                            result.CandidateNotes.AddRange(cellsWithCorrectHiddens[0].Notes.Where(note => note.Candidate == n1 || note.Candidate == n2));
                            result.CandidateNotes.AddRange(cellsWithCorrectHiddens[1].Notes.Where(note => note.Candidate == n1 || note.Candidate == n2));

                            // cell with eliminations (are the same cells as the hidden pairs already found above)
                            result.EliminationCells.AddRange(cellsWithCorrectHiddens);

                            // remember which remaining notes were needing elimination
                            result.EliminationNotes.AddRange(cellsWithCorrectHiddens[0].Notes.Where(note => note.IsNoted && note.Candidate != n1 && note.Candidate != n2));
                            result.EliminationNotes.AddRange(cellsWithCorrectHiddens[1].Notes.Where(note => note.IsNoted && note.Candidate != n1 && note.Candidate != n2));

                            results.Add(result);
                        }
                    }

                    // check each column
                    for (int c = 1; c <= 9; c++)
                    {
                        FindResult result = new FindResult();
                        result.HouseType = HouseType.Column;

                        // find cells that have the two notes in the search
                        var cellsWithCorrectHiddens = allCells.Where(cell => !cell.HasAnswer && cell.Column == c && cell.HasNoteOf(n1) && cell.HasNoteOf(n2)).ToList<Cell>();
                        // find any cells that have either/both of those notes but are not in the cells just found with BOTH notes
                        var invalidatingCells = allCells.Where(cell => !cell.HasAnswer && cell.Column == c && (cell.HasNoteOf(n1) || cell.HasNoteOf(n2)) && cellsWithCorrectHiddens.IndexOf(cell) < 0).ToList<Cell>();

                        // if found two sets of notes and no other cells with those notes and the two found are not just naked pairs (either have more than two notes)
                        if ((cellsWithCorrectHiddens.Count() == 2) && invalidatingCells.Count() == 0 && (cellsWithCorrectHiddens[0].NumberOfNotes() > 2 || cellsWithCorrectHiddens[1].NumberOfNotes() > 2))
                        {
                            // put cells involved into the single results object
                            foreach (Cell cellWithCorrectHiddens in cellsWithCorrectHiddens)
                                result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(cellWithCorrectHiddens, CellHighlightType.Special));

                            // remember which note was the candidate in the cell
                            result.CandidateNotes.AddRange(cellsWithCorrectHiddens[0].Notes.Where(note => note.Candidate == n1 || note.Candidate == n2));
                            result.CandidateNotes.AddRange(cellsWithCorrectHiddens[1].Notes.Where(note => note.Candidate == n1 || note.Candidate == n2));

                            // cell with eliminations (are the same cells as the hidden pairs already found above)
                            result.EliminationCells.AddRange(cellsWithCorrectHiddens);

                            // remember which remaining notes were needing elimination
                            result.EliminationNotes.AddRange(cellsWithCorrectHiddens[0].Notes.Where(note => note.IsNoted && note.Candidate != n1 && note.Candidate != n2));
                            result.EliminationNotes.AddRange(cellsWithCorrectHiddens[1].Notes.Where(note => note.IsNoted && note.Candidate != n1 && note.Candidate != n2));

                            results.Add(result);
                        }
                    }

                    // check each block
                    for (int b = 1; b <= 9; b++)
                    {
                        FindResult result = new FindResult();
                        result.HouseType = HouseType.Block;

                        // find cells that have the two notes in the search
                        var cellsWithCorrectHiddens = allCells.Where(cell => !cell.HasAnswer && cell.Block == b && cell.HasNoteOf(n1) && cell.HasNoteOf(n2)).ToList<Cell>();
                        // find any cells that have either/both of those notes but are not in the cells just found with BOTH notes
                        var invalidatingCells = allCells.Where(cell => !cell.HasAnswer && cell.Block == b && (cell.HasNoteOf(n1) || cell.HasNoteOf(n2)) && cellsWithCorrectHiddens.IndexOf(cell) < 0).ToList<Cell>();

                        // if found two sets of notes and no other cells with those notes and the two found are not just naked pairs (either have more than two notes)
                        if ((cellsWithCorrectHiddens.Count() == 2) && invalidatingCells.Count() == 0 && (cellsWithCorrectHiddens[0].NumberOfNotes() > 2 || cellsWithCorrectHiddens[1].NumberOfNotes() > 2))
                        {
                            // put cells involved into the single results object
                            foreach (Cell cellWithCorrectHiddens in cellsWithCorrectHiddens)
                                result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(cellWithCorrectHiddens, CellHighlightType.Special));

                            // remember which note was the candidate in the cell
                            result.CandidateNotes.AddRange(cellsWithCorrectHiddens[0].Notes.Where(note => note.Candidate == n1 || note.Candidate == n2));
                            result.CandidateNotes.AddRange(cellsWithCorrectHiddens[1].Notes.Where(note => note.Candidate == n1 || note.Candidate == n2));

                            // cell with eliminations (are the same cells as the hidden pairs already found above)
                            result.EliminationCells.AddRange(cellsWithCorrectHiddens);

                            // remember which remaining notes were needing elimination
                            result.EliminationNotes.AddRange(cellsWithCorrectHiddens[0].Notes.Where(note => note.IsNoted && note.Candidate != n1 && note.Candidate != n2));
                            result.EliminationNotes.AddRange(cellsWithCorrectHiddens[1].Notes.Where(note => note.IsNoted && note.Candidate != n1 && note.Candidate != n2));

                            results.Add(result);
                        }
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
                    result.HouseType = HouseType.Row;

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
                    result.HouseType = HouseType.Column;

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
                    result.HouseType = HouseType.Row;

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
                    result.HouseType = HouseType.Column;

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
