﻿using System;
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

        //public static Game GetInstance(BoardType type, int cellSize)
        public static void CreateInstance(BoardType type, int cellSize)
        {
            if (cellSize % 3 != 0)
                throw new ArgumentException(String.Format("Invalid cell size specified: {0} (must be a multiple of three)", cellSize));

            if (cellSize < 30)
                throw new ArgumentException(String.Format("Invalid cell size specified: {0} (must be a >= 30)", cellSize));

            if (_instance == null)
                _instance = new Game(type, cellSize);
            
            //return _instance;
        }

        private Game(BoardType type, int cellSize)
        {
            switch (type)
            {
                case BoardType.Bitmap:
                    _board = new BitmapBoard(cellSize);
                    break;
                case BoardType.Html:
                    throw new ArgumentException("Html Board not supported at this time");
            }
        }
    }
}
