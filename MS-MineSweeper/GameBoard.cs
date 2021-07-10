using System;
using System.Collections.Generic;
using System.Text;
using static MineSweeperConsole.GameCell;


/*
 * This is the GameBoard class for the MineSweeper Game. In this class, there are 3 properties,
 * the board size, the difficulty level, and a two-dimentional array that contains GameCell class objects.
 */
namespace MineSweeperConsole
{
    class GameBoard
    {

        /*
         * The constructor initializes the two dimentional array with gameCell objects based on the size of the board
         * given by the driver program.
        */

        public GameBoard(int boardSize)
        {
            this.BoardSize = boardSize;

            grid = new GameCell[boardSize, boardSize];

            for(int row = 0; row < boardSize; row++)
            {
                for(int col = 0; col < boardSize; col++)
                {
                    grid[row, col] = new GameCell(-1,-1,false,false,0);
                }
            }
        }

        //Properties
        private int BoardSize { get; set; }
        private int GameDifficulty { get; set; }
        public GameCell[,] grid;


        /*
         * The SetupLiveMembers method is responsible for setting the live bombs on the gameboard. This is done by random
         * numbers for the rows and columns in the two-dimentional array. To prevent from not placeing the proper number 
         * of mines on the field, an if statment surrounded by a do/while will check the IsLive property of each randomly 
         * selected GameCell in the array. If it is false, the mine will be planted and the loop ends. 
         */
        public void SetupLiveMembers(int difficulty)
        {
            int numMines = (BoardSize * BoardSize) / difficulty;

            Random row = new Random();
            Random col = new Random();
                
            for(int bombCount = 0; bombCount < numMines; bombCount++)
            {
                bool checker = false;
                do
                {
                    int plantRow = row.Next(0, BoardSize);
                    int plantCol = col.Next(0, BoardSize);

                    if (grid[plantRow, plantCol].IsLive == false)
                    {
                        grid[plantRow, plantCol].IsLive = true;
                        checker = true;
                    }
                } while (checker == false);
            }

        }
        /*
         * The purpose of the CalcLiveMembers method is to set the number of mines that neighbor each cell. This will be used
         * in the displaying of the board.
         */
        public int CalcLiveMembers(int focusRow, int focusCol)
        {
            int liveMemberCounter = 0;

            //if the cell has a mine on it
            if(grid[focusRow, focusCol].IsLive)
            {
                liveMemberCounter = 9;
            }
            // case of top right corner
            else if(focusRow == 0 && focusCol == 0)
            {

                if (grid[focusRow, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                
            }
            //case of botom right corner
            else if(focusRow == BoardSize - 1 && focusCol == 0)
            {
                if (grid[focusRow - 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
            }
            //case of bottom left corner
            else if(focusRow == BoardSize - 1 && focusCol == BoardSize - 1)
            {
                if (grid[focusRow, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow  - 1, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }

            }
            //case of top left corner
            else if (focusRow == 0 && focusCol == BoardSize - 1)
            {
                if (grid[focusRow, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }

            }
            // case Top Edge
            else if(focusRow == 0 && focusCol != 0)
            {
                if(grid[focusRow, focusCol-1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                
            }
            // case left Edge
            
            else if (focusRow != 0 && focusCol == 0)
            {
                if (grid[focusRow - 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }

            }
            // case right Edge
            else if (focusRow == 0 && focusCol != 0)
            {
                if (grid[focusRow - 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol -1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }

            }
            // case Bottom Edge
            else if (focusRow == (BoardSize - 1) && focusCol != (BoardSize - 1))
            {
                if (grid[focusRow, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }

            }
            // case not corner or edge
            else
            {
                if (grid[focusRow, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow - 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol + 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol - 1].IsLive)
                {
                    liveMemberCounter++;
                }
                if (grid[focusRow + 1, focusCol].IsLive)
                {
                    liveMemberCounter++;
                }
            }

            return liveMemberCounter;
        }

    }
}
