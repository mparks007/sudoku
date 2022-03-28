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
            _methods[Pattern.Swordfish] = FindSwordfishes;
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

            // singles have to have one note, but two is minimum number of notes required for pairs and above (the max is not considered here)
            if ((subsetWidth == 1 && notesMatchingSetCandidates.Count() == 1) || (subsetWidth > 1 && notesMatchingSetCandidates.Count() >= 2))
            {
                // if naked search, the set notes found must be all the available notes
                if (doSearchForNaked)
                    return (notesMatchingSetCandidates.Count() == cell.NumberOfNotes());
                else // hiddens search, so the set notes found must be all notes or buried in extra notes OR the notes matched the subset exactly (which is a naked on its own but with other hiddens it should work out)
                    return (notesMatchingSetCandidates.Count() <= cell.NumberOfNotes() || notesMatchingSetCandidates.Count() == subsetWidth);
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
        /// Find Naked Single occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Single locations found</returns>
        private List<FindResult> FindNakedSingles(Board board)
        {
            return FindNakedSubsets(board, subsetWidth:1);
        }

        /// <summary>
        /// Find Naked Pair occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Pair locations found</returns>
        private List<FindResult> FindNakedPairs(Board board)
        {
            return FindNakedSubsets(board, subsetWidth:2);
        }

        /// <summary>
        /// Find Naked Triple occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Triple locations found</returns>
        private List<FindResult> FindNakedTriples(Board board)
        {
            return FindNakedSubsets(board, subsetWidth:3);
        }

        /// <summary>
        /// Find Naked Quad occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Quad locations found</returns>
        private List<FindResult> FindNakedQuads(Board board)
        {
            return FindNakedSubsets(board, subsetWidth:4);
        }

        /// <summary>
        /// Find Naked Quint occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Naked Quint locations found</returns>
        private List<FindResult> FindNakedQuints(Board board)
        {
            return FindNakedSubsets(board, subsetWidth:5);
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

                SearchHousesForNakeds(allCells, currentSubset, HouseType.Row, results);
                SearchHousesForNakeds(allCells, currentSubset, HouseType.Column, results);
                SearchHousesForNakeds(allCells, currentSubset, HouseType.Block, results);
            }

            return DedupeResults(results);
        }

        /// <summary>
        /// Search a particular house type for a naked subset type
        /// </summary>
        /// <param name="allCells">Flattened list of all cells to check</param>
        /// <param name="currentSubset">List of all number combinations in a subset</param>
        /// <param name="houseType">Type of house being searched</param>
        /// <param name="results">Results for all the found cells that matched the subset search</param>
        private void SearchHousesForNakeds(IEnumerable<Cell> allCells, int[] currentSubset, HouseType houseType, List<FindResult> results)
        {
            // check each row, column, or block (depends on houseType)
            for (int houseIndex = 1; houseIndex <= 9; houseIndex++)
            {
                FindResult result = new FindResult
                {
                    HouseType = houseType
                };

                // look for cells with correct subset usage
                var cellsWithCorrectSubset = allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseIndex && CellContainsSuitableNotes(cell, currentSubset, currentSubset.Length, doSearchForNaked: true)).ToList<Cell>();

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
                    result.EliminationCells.AddRange(allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseIndex && cellsWithCorrectSubset.IndexOf(cell) < 0));

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
            return FindHiddenSubsets(board, subsetWidth:1);
        }

        /// <summary>
        /// Find Hidden Pairs occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Pairs locations found</returns>
        private List<FindResult> FindHiddenPairs(Board board)
        {
            return FindHiddenSubsets(board, subsetWidth:2);
        }

        /// <summary>
        /// Find Hidden Triples occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Triples locations found</returns>
        private List<FindResult> FindHiddenTriples(Board board)
        {
            return FindHiddenSubsets(board, subsetWidth:3);
        }

        /// <summary>
        /// Find Hidden Quads occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Quads locations found</returns>
        private List<FindResult> FindHiddenQuads(Board board)
        {
            return FindHiddenSubsets(board, subsetWidth:4);
        }

        /// <summary>
        /// Find Hidden Quints occurrences 
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <returns>List of Hidden Quints locations found</returns>
        private List<FindResult> FindHiddenQuints(Board board)
        {
            return FindHiddenSubsets(board, subsetWidth:5);
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

                SearchHousesForHiddens(allCells, currentSubset, HouseType.Row, results);
                SearchHousesForHiddens(allCells, currentSubset, HouseType.Column, results);
                SearchHousesForHiddens(allCells, currentSubset, HouseType.Block, results);
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
        private void SearchHousesForHiddens(IEnumerable<Cell> allCells, int[] currentSubset, HouseType houseType, List<FindResult> results)
        {
            // check each row, column, or block (depends on houseType)
            for (int houseIndex = 1; houseIndex <= 9; houseIndex++)
            {
                FindResult result = new FindResult
                {
                    HouseType = houseType
                };

                // look for cells with correct subset usage
                var cellsWithCorrectSubset = allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseIndex && CellContainsSuitableNotes(cell, currentSubset, currentSubset.Length, doSearchForNaked:false)).ToList<Cell>();

                // get a distinct list of candidates from every note from every cell that has our subset THEN skip this pass if we don't have enough notes to be actually have a hiddens situation
                var uniqueCandidatesFound = cellsWithCorrectSubset.SelectMany(cell => cell.Notes).Where(note => note.IsNoted).Select(note => note.Candidate).Distinct();
                if (uniqueCandidatesFound.Count() == currentSubset.Length)
                    continue;

                // if cells found didn't cover all the notes in the subset being searched for, skip this pass
                var allSubsetNoteFromSuspectedCells = cellsWithCorrectSubset.SelectMany(cell => cell.Notes.Where(note => currentSubset.Contains(note.Candidate)).Select(note => note.Candidate)).Distinct();
                if (allSubsetNoteFromSuspectedCells.Count() != currentSubset.Length)
                    continue;

                // find all the cells that are NOT in the found subset sets but do have any of the notes of the subset (which would invalidate the max subset cell count aspect)
                List<Cell> invalidatingCells = new List<Cell>(allCells.Where(cell => !cell.HasAnswer && GetHouseElementNumForCell(cell, houseType) == houseIndex && cellsWithCorrectSubset.IndexOf(cell) < 0 && cell.HasAnyNotesOf(currentSubset)).ToList<Cell>());

                // if found correct number of cells for the subset size AND no other cells ruin the find
                if (cellsWithCorrectSubset.Count == currentSubset.Length && invalidatingCells.Count() == 0)
                {
                    List<Note> candidateNotes = new List<Note>();

                    foreach (Cell cellWithCorrectSubset in cellsWithCorrectSubset)
                    {
                        // put matching cells into the single results object
                        result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(cellWithCorrectSubset, CellHighlightType.Special));

                        // candidates must be all notes in the cell that are in the subset being searched
                        candidateNotes.AddRange(cellsWithCorrectSubset.SelectMany(cell => cell.Notes.Where(note => currentSubset.Contains(note.Candidate))));
                    }

                    // remember which notes were the candidates in the cell (dedupe what got built out when learning which cells had the subsets)
                    result.CandidateNotes.AddRange(candidateNotes.Distinct());

                    // for hiddens, the cells with the subset found are also where the eliminations would be necessary
                    result.EliminationCells.AddRange(cellsWithCorrectSubset);

                    // notes to eliminate are those in the found subset cells but that are also not in the subset notes being searched for
                    result.EliminationNotes.AddRange(cellsWithCorrectSubset.SelectMany(cell => cell.Notes.Where(note => note.IsNoted && !currentSubset.Contains(note.Candidate))));

                    results.Add(result);
                }
            }
        }

        /// <summary>
        /// Return Column for a cell if housetype is Row, and vice versa
        /// </summary>
        /// <param name="cell">Cell in use</param>
        /// <param name="houseType">Housetype in a search to determine the OTHER housetype to return data for</param>
        /// <returns>Number of a cell's Row or Column, using the oposite of the housetype (row/column)</returns>
        private int GetCoverPointForHouseType(Cell cell, HouseType houseType)
        {
            switch (houseType)
            {
                case HouseType.Row:
                    return cell.Column;
                case HouseType.Column:
                    return cell.Row;
                default:
                    throw new ArgumentException(String.Format("Invalid HouseType: {0}", houseType));
            }
        }

        /// <summary>
        /// Find X-Wing patterns
        /// </summary>
        /// <param name="board"></param>
        /// <returns>Results containing the X-Wing discoveries</returns>
        private List<FindResult> FindXWings(Board board)
        {
            // search with rows as base then columns as base
            List<FindResult> results = new List<FindResult>(FindFishes(board, HouseType.Row, baseCountTarget:2));
            results.AddRange(FindFishes(board, HouseType.Column, baseCountTarget:2));
            return results;
        }

        /// <summary>
        /// Find Swordfish patterns
        /// </summary>
        /// <param name="board"></param>
        /// <returns>Results containing the Swordfish discoveries</returns>
        private List<FindResult> FindSwordfishes(Board board)
        {
            // search with rows as base then columns as base
            List<FindResult> results = new List<FindResult>(FindFishes(board, HouseType.Row, baseCountTarget:3));
            results.AddRange(FindFishes(board, HouseType.Column, baseCountTarget:3));
            return results;
        }

        private bool FindFishForCandidate(IEnumerable<Cell> allCells, HouseType houseType, int candidate, ref int houseIndex1, int baseCountTarget, List<List<Cell>> basesWithMatchedCells, int[] coverLocations)
        {
            //// if there is no more room to fit a fish after this point (like if searching for xwings (baseCountTarget of 2) in rows and you are starting search on row nine, makes no sense)
            //if (houseIndex1 > 9 - baseCountTarget + 1)
            //    return false;
            
            //// if found enough matching bases to be a full fish of size baseCountTarget
            //if (basesWithMatchedCells.Count() == baseCountTarget)
            //    return true;
            //int[] coverTrack = new int[baseCountTarget]

            // check each row or column (which axis depends on houseType)
            for (int i = houseIndex1; i <= 9; i++)
            {
                // if there is no more room to fit a fish after this point (like if searching for xwings (baseCountTarget of 2) in rows and you are starting search on row nine, makes no sense)
                if (i > 9 - baseCountTarget + 1)
                    return false;

                // look for any cells with the target candidate (this could be a base)
                List<Cell> baseCells = new List<Cell>(allCells.Where(cell => GetHouseElementNumForCell(cell, houseType) == i && cell.HasNoteOf(candidate)));

                // if found right candidate cell counts based on fish type (aka baseCountTarget) (must be two for xwing, but can be from two to baseCountTarget for larger fish) 
                if (((baseCountTarget == 2 && baseCells.Count() == 2) || (baseCountTarget > 2 && baseCells.Count() >= 2 && baseCells.Count() <= baseCountTarget)))
                {
                    // remember all the cells involved that were in that base
                    basesWithMatchedCells.Add(baseCells.ToList<Cell>());

                    foreach (Cell cell in baseCells)
                    {
                        coverLocations[GetCoverPointForHouseType(cell, houseType) - 1]++;
                    }
                    // keep a list of the list of cover points (row or column number) that were found in the base cells
                    //coverLocations.Add(new List<int>(baseCells.Select(cell => )));

                    if (coverLocations.Where(c => c != 0).Count() == baseCountTarget && coverLocations.All(c => c == 0 || (c >= 2 && c <= baseCountTarget)))
                        return true;


//                    houseIndex1++;


  //                  FindFishForCandidate(allCells, houseType, candidate, ref houseIndex1, baseCountTarget, basesWithMatchedCells, coverLocations);
                }
            }
            // any point in returning true/false at all yet?  will see
            return false;
        }

        /// <summary>
        /// Find Fish pattern based on base size (which is also cover size)
        /// </summary>
        /// <param name="board">Board to search</param>
        /// <param name="baseCountTarget">Type of fish (2:xwing, 3:swordfish, 4:jellyfish, etc.</param>
        /// <returns>List of patterns found</returns>
        private List<FindResult> FindFishes(Board board, HouseType houseType, int baseCountTarget)
        {
            List<FindResult> results = new List<FindResult>();
            IEnumerable<Cell> allCells = board.Cells.SelectMany(list => list);

            // 1 plan to search for y number of base rows (like 2 for xwing, 3 for swordfish, 4 for jellyfish, etc.)
            // 2 pick a candidate number (start with 1)
            // 3 pick initial row (start from 1)
            // 4 on that row, find exactly y number of columns (if xwing) or from 2 to y number (for above xwing) which contain the target candidate (this is the first base row)
            // 5 if number of base rows found is less than y (need to find another base row)
            //   5a scoot down a row (to start search for another base row)
            //   5b on that row, find exactly y number of columns (if xwing) or from 2 to y number (for above xwing) which contain the target candidate (this is another base row)
            //   5c loop back to step 5
            // 6 verify that the number columns found for each candidate found in the bases are the same columns in every base involved (these are the cover columns)
            // 7 verify that each cover column has the target candidate in y number of base rows (if xwing) or from 2 two y number (for above xwing)
            // 8 build/return result
            //   8a candidate cell is each base/cover intersection
            //   8b candidate note is the number in the search (from step 2)
            //   8c elimination cells are all cells in the cover column that are not in the base rows
            //   8d elimnation note is the number in the search (from step 2)
            // loop back to 4 to re-search but starting at one row below the prior search each time, do this repeat until on out or rows to have bases below it (i.e. row 9 - y + 1) (i.e. xwing could be in row 8 and 9)
            // loop back to 2 to pick the next candidate (candidate++) and do this all over again

            // pick one target candidate at a time
            for (int candidate = 1; candidate <= 9; candidate++)
            {
                //int houseIndex1 = 1;

                for (int houseIndex1 = 1; houseIndex1 <= 9; houseIndex1++)
                {
                    List<List<Cell>> basesWithMatchedCells = new List<List<Cell>>();
                    int[] coverLocations = new int[9];

                    // if found a fish for a patricular candidate (recursive to keep looking for the appropriate number of bases/covers, BUT will not find multiple fishes for the same candidate atm)
                    if (FindFishForCandidate(allCells, houseType, candidate, ref houseIndex1, baseCountTarget, basesWithMatchedCells, coverLocations))
                    {
                        FindResult result = new FindResult()
                        {
                            HouseType = houseType
                        };

                        // build out results 
                        List<Note> candidateNotes = new List<Note>();

                        foreach (Cell cellWithCorrectSubset in basesWithMatchedCells.SelectMany(cell => cell))
                        {
                            // put matching cells into the single results object
                            result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(cellWithCorrectSubset, CellHighlightType.Special));

                            // since nakeds, just collect all the notes since all are a part of the subset (deduped below this loop)
                            candidateNotes.Add(cellWithCorrectSubset.GetNoteForCandidate(candidate));
                        }

                        // remember which notes were the candidates in the cell (dedupe what got built out when learning which cells had the subsets)
                        result.CandidateNotes.AddRange(candidateNotes.Distinct());

                        // for hiddens, the cells with the subset found are also where the eliminations would be necessary
                        result.EliminationCells.AddRange(allCells.Where(cell => cell.Row == houseIndex1));//  GetHouseElementNumForCell(cell, houseType) == );

                        // notes to eliminate are those in the found subset cells but that are also not in the subset notes being searched for
                        result.EliminationNotes.Add(basesWithMatchedCells.First().First().GetNoteForCandidate(candidate));

                        results.Add(result);
                    }
                }

                // check each row or column (which axis depends on houseType)
                //   for (int houseIndex1 = 1; houseIndex1 <= 9; houseIndex1++)
                {
                    //// if there is no more room to fit a fish after this point (like if searching for xwings (baseCountTarget of 2) in rows and you are starting search on row nine, makes no sense)
                    //if (houseIndex1 > 9 - baseCountTarget + 1)
                    //    break;

                    //FindResult result = new FindResult()
                    //{
                    //    HouseType = houseType
                    //};

                    //// look for any cells with the target candidate (this could be a base)
                    //List<Cell> baseCells = new List<Cell>(allCells.Where(cell => GetHouseElementNumForCell(cell, houseType) == houseIndex1 && cell.HasNoteOf(n)));

                    //// if found right candidate cell counts based on fish type (aka baseCountTarget) (must be two for xwing, but can be from two to baseCountTarget for larger fish) 
                    //if (((baseCountTarget == 2 && baseCells.Count() == 2) || (baseCountTarget > 2 && baseCells.Count() >= 2 && baseCells.Count() <= baseCountTarget)))
                    //{
                    //    // remember all the cells involved that were in that base
                    //    basesWithMatchedCells.Add(baseCells.ToList<Cell>());

                    //    // keep a list of the list of cover points (row or column number) that were found in the base cells
                    //    coverLocations.Add(new List<int>(baseCells.Select(cell => GetCoverPointForHouseType(cell, houseType))));

                    //    if (coverLocations.Count() > 1)
                    //    {

                    //    }
                        
                    //    // check if cover houses cover correctly enough to be a fish of size baseCountTarget


                    //    //// if found enough matching bases to be a full fish of size baseCountTarget
                    //    //if (basesWithMatchedCells.Count() == baseCount)
                    //    //    break;

                    //    //start here to figure out the rest
                    //    //start here to figure out the rest
                    //    //start here to figure out the rest
                    //    //start here to figure out the rest
                    //    //start here to figure out the rest

                    //    //// now scoot down a row (or over a column if doing column mode) and try to find another base from there down/over
                    //    //for (int houseIndex2 = houseIndex1 + 1; houseIndex2 <= 9; houseIndex2++)
                    //    //{
                    //    //    // again, look for notes of n
                    //    //    IEnumerable<Cell> secondPair = allCells.Where(cell => (cell.Row == houseIndex2) && cell.HasNoteOf(n));
                        //    // again, if found two
                        //    if (secondPair.Count() == 2)
                        //    {
                        //        var firstPairAsList = basesWithMatchedCells.First().ToList();
                        //        var secondPairAsList = secondPair.OfType<Cell>().ToList();

                        //        // if the sets of pairs found are of the same column, but not in the same block, we have an xwing
                        //        if (((firstPairAsList[0].Column == secondPairAsList[0].Column) &&
                        //             (firstPairAsList[1].Column == secondPairAsList[1].Column)) &&
                        //            ((firstPairAsList[0].Block != firstPairAsList[1].Block) ||
                        //             (firstPairAsList[0].Block != secondPairAsList[0].Block)))
                        //        {
                        //            // put all four cells involved in the single results object
                        //            result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[0].Row, firstPairAsList[0].Column), CellHighlightType.Special));
                        //            result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(firstPairAsList[1].Row, firstPairAsList[1].Column), CellHighlightType.Special));
                        //            result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[0].Row, secondPairAsList[0].Column), CellHighlightType.Special));
                        //            result.CandidateCells.Add(new KeyValuePair<Cell, CellHighlightType>(board.CellAt(secondPairAsList[1].Row, secondPairAsList[1].Column), CellHighlightType.Special));

                        //            // remember which note was the candidate in the cell
                        //            result.CandidateNotes.Add(basesWithMatchedCells.First().First().GetNoteForCandidate(n));

                        //            // find all the cells with notes that should be eliminated (same columns but not in same rows as the candidate cells above)
                        //            var eliminationCells = allCells.Where(cell => ((cell.Column == firstPairAsList[0].Column) || (cell.Column == firstPairAsList[1].Column)) && (cell.Row != houseIndex1) && (cell.Row != houseIndex2) && cell.HasNoteOf(n));
                        //            result.EliminationCells.AddRange(eliminationCells);

                        //            // remember which note was needing elimination
                        //            result.EliminationNotes.Add(basesWithMatchedCells.First().First().GetNoteForCandidate(n));

                        //            results.Add(result);
                        //            break;
                        //        }
                        //    }
                        //}
                    //}
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
