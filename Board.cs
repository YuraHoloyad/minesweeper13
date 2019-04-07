using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Minesweeper
{
    public class Board
    {
        public int Mines { get; private set; }
        public int Rows { get; private set; }
        public int Cols { get; private set; }
        public Tile[,] Grid { get; private set; }

        public Board(int rows, int cols, int mines)
        {
            Rows = rows;
            Cols = cols;
            Mines = mines;
            SetDimensions(rows, cols);
            SetNumberOfMines(mines);
        }

        private void SetDimensions(int rows, int cols)
        {
            Grid = new Tile[rows, cols];
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < cols; ++c)
                {
                    Grid[r, c] = new Tile();
                }
            }
        }

        private void SetNumberOfMines(int count)
        {
            var random = new Random();

            var placed = 0;
            while (placed < count)
            {
                var row = random.Next() % Rows;
                var col = random.Next() % Cols;
                if (!Grid[row, col].Mine)
                {
                    Grid[row, col].Mine = true;
                    placed++;
                }
            }
        }
 
        public bool Open(int row, int col)
        {
            var open = Grid[row, col].Open();
            if (!open)
            {
                return false;
            }

           if (NumberOfSurroundingMines(row, col) == 0)
            {
                for (int r = row - 1; r <= row + 1; ++r)
                {
                    for (int c = col - 1; c <= col + 1; ++c)
                    {
                        if (IsInside(r, c))
                            Grid[r, c].Open();
                    }
                }
            }
            return true;
        }

       public void Flag(int row, int col)
       {
            Grid[row, col].SetFlag();
       }

        private bool IsInside(int r, int c)
        {
            return r >= 0 && c >= 0 && r < Rows && c < Cols;
        }



        public string GetStatus(int row, int col)
        {
            switch (Grid[row, col].Status)
            {
                case TileStatus.CLOSED:
                    return "CLOSE";
                case TileStatus.FLAGGED:
                    return "FLAG";
                case TileStatus.OPEN:
                    return NumberOfSurroundingMines(row, col).ToString();
            }
            return "E";//error
        }

        public int NumberOfSurroundingMines(int row, int col)
        {
            int count = 0;
            for (int r = row - 1; r <= row + 1; ++r)
            {
                for (int c = col - 1; c <= col + 1; ++c)
                {
                    if (IsInside(r, c) && Grid[r, c].Mine)
                        count++;
                }
            }
            return count;
        }
    }
}
