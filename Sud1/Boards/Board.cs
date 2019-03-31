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
    public class Board
    {
        private Cell[][] cells;
        private HouseType houseSelectionType = HouseType.None;
        private Cell selectedCell;

        public Board()
        {
            cells = new Cell[9][];

            for (int i = 0; i < 9; i++)
            {
                cells[i] = new Cell[9];
                for (int j = 0; j < 9; j++)
                    cells[i][j] = new Cell();
            }
        }

        public void SelectCell(Cell cell)
        {
            if (cell != selectedCell)
            {
                selectedCell = cell;
                cell.ToggleSelect(true);
            }
        }

        public void SelectHouse(Cell cell, HouseType house)
        {
            if (selectedCell != null && cell != selectedCell && house != houseSelectionType)
            {
                houseSelectionType = house;
                // update all cell highlight states to hightlight only the house of the selected cell
            }
        }

        public void HighlightCellsWithNote(int note)
        {
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    cells[i][j].HighlightHavingNote(note);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public virtual void Render()
        {

        }
    }
 }
