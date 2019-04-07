using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;

namespace Sudoku
{
    public sealed class Game
    {
        private static Game _instance = null;
        private static Board _board;

        public static Board Board 
        {
            get
            {
                if (_board == null)
                    throw new InvalidOperationException("Call GetInstance first to create board");

                return _board;
            }
        }

        public static Game GetInstance(BoardType type)
        {
            if (_instance == null)
            {
                _instance = new Game(type);
            }

            return _instance;
        }

        private Game(BoardType type)
        {
            switch (type)
            {
                case BoardType.Bitmap:
                    _board = new BitmapBoard(540);
                    break;
                case BoardType.Html:
                    throw new ArgumentException("Html Board not supported at this time");
            }
        }

        //public static void SelectCellByXY(int x, int y)
        //{
        //    if (_board is BitmapBoard)
        //    {

        //    }
                
        //}

    }
}
