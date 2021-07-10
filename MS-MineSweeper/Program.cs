using MineSweeperConsole;
using System;

namespace MS_MineSweeper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**************MineSweeper Game*****************\n");

            //Sets the Board Size
            int boardSize = 11;
            GameBoard newBoard = new GameBoard(boardSize);

            //Sets the Difficulty Level which depicts how many bombs are placed
            newBoard.SetupLiveMembers(8);

            //prints the initial Board
            PrintBoard(newBoard, boardSize);

            //GamePlay
            PrintBoardDuringGame(newBoard, boardSize);

        }

        //This method drives the game play. It prints the board during the game based on the current
        //cells that have been shown.
        public static void PrintBoardDuringGame(GameBoard newBoard, int boardSize)
        {

            // declaration of game handling variables
            int selectedRow, selectedCol;
            bool playAgain = true;
            bool gameOver = false;

            // do/while loop for the game repition
            do
            {
                // try/catch for exception handling
                try
                {

                    // user input
                    Console.Write("Enter the row: ");
                    selectedRow = int.Parse(Console.ReadLine());
                    Console.Write("Enter the Column: ");
                    selectedCol = int.Parse(Console.ReadLine());


                    if (selectedRow > boardSize || selectedCol > boardSize)
                    {
                        Console.WriteLine("Your input was too large. try again");

                    }
                    else
                    {
                        newBoard.grid[selectedRow, selectedCol].ActiveState = true;
                    }

                    //Number index
                    Console.Write("+ ");
                    for (int boardBound = 0; boardBound < boardSize - 1; boardBound++)
                    {
                        if (boardBound < boardSize)
                            Console.Write(boardBound + " + ");
                        else
                            Console.Write(boardBound + "+ ");
                    }
                    Console.WriteLine("");

                    //top Boarder
                    for (int boardBound = 0; boardBound < boardSize - 1; boardBound++)
                    {

                        Console.Write("+---");

                        if (boardBound == boardSize - 1)
                        {
                            Console.WriteLine(boardBound + " +");
                        }
                    }
                    Console.Write("+");

                    //Grid
                    for (int sendRow = 0; sendRow < boardSize - 1; sendRow++)
                    {

                        Console.Write(" \n: ");

                        for (int sendCol = 0; sendCol < boardSize - 1; sendCol++)
                        {


                            if (sendCol < boardSize - 1)
                            {
                                int cell = newBoard.CalcLiveMembers(sendRow, sendCol);

                                //checks the current entered row displays apprpriate cell
                                if (selectedRow == sendRow && selectedCol == sendCol)
                                {
                                    if (cell == 9)
                                    {
                                        Console.Write("*", Console.ForegroundColor = ConsoleColor.Red);
                                        Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                                        gameOver = true;
                                    }
                                    else
                                    {
                                        OutputSwitchCase(cell);
                                    }

                                }
                                //prints the remainder of the board that is active state true
                                else
                                {
                                    if (newBoard.grid[sendRow, sendCol].ActiveState == true)
                                    {
                                        OutputSwitchCase(cell);
                                    }
                                    else
                                    {
                                        Console.Write("?" + " : ");
                                    }
                                }
                            }

                        }

                        //bottom row
                        Console.Write("\n");
                        for (int boardBound = 0; boardBound < boardSize - 1; boardBound++)
                        {

                            Console.Write("+---");

                            if (boardBound == boardSize)
                            {
                                Console.WriteLine(boardBound + "+");
                            }

                        }
                    }
                    Console.WriteLine("+");
                    Console.WriteLine("\n\n\n");
                    playAgain = GameOverCheck(playAgain, gameOver);
                    playAgain = CheckForWin(newBoard, boardSize, playAgain);
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter a correct response");

                }
            } while (playAgain);

        }

        //This method controls the display of the live members and their colors. 
        private static void OutputSwitchCase(int cell)
        {
            switch (cell)
            {
                case 0:
                    Console.Write(" " + " : ");
                    break;
                case 1:
                    Console.Write("1", Console.ForegroundColor = ConsoleColor.Green);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
                case 2:
                    Console.Write("2", Console.ForegroundColor = ConsoleColor.Blue);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
                case 3:
                    Console.Write("3", Console.ForegroundColor = ConsoleColor.Yellow);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
                case 4:
                    Console.Write("4", Console.ForegroundColor = ConsoleColor.DarkCyan);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
                case 5:
                    Console.Write("5", Console.ForegroundColor = ConsoleColor.Magenta);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
                case 6:
                    Console.Write("6", Console.ForegroundColor = ConsoleColor.DarkYellow);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
                case 7:
                    Console.Write("7", Console.ForegroundColor = ConsoleColor.DarkGreen);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
                case 8:
                    Console.Write("8", Console.ForegroundColor = ConsoleColor.DarkRed);
                    Console.Write(" : ", Console.ForegroundColor = ConsoleColor.White);
                    break;
            }
        }

        //This method checks if the the game is over.
        private static bool GameOverCheck(bool playAgain, bool gameOver)
        {
            if (gameOver)
            {
                Console.WriteLine("\n\nYou Blowed Up!!!! Game Over");
                playAgain = false;
            }

            return playAgain;
        }

        //This method checks to see if the game is won
        private static bool CheckForWin(GameBoard newBoard, int boardSize, bool playAgain)
        {
            int winCount = 0;
            for (int i = 0; i < boardSize - 1; i++)
            {
                for (int j = 0; j < boardSize - 1; j++)
                {
                    if (newBoard.grid[i, j].ActiveState == false && newBoard.grid[i, j].IsLive == true)
                    {
                        winCount++;
                    }
                }
            }
            if (winCount == 0)
            {
                playAgain = false;

                Console.WriteLine("You have wone!!! And you didn't blow up!!!");
            }

            return playAgain;
        }

        // this method prints the initial board before gameplay
        private static void PrintBoard(GameBoard newBoard, int boardSize)
        {
            int sideNums = 0;
            //Top numbered index of board
            Console.Write("+ ");
            for (int boardBound = 0; boardBound < boardSize - 1; boardBound++)
            {
                if (boardBound < boardSize)
                    Console.Write(boardBound + " + ");
                else
                    Console.Write(boardBound + "+ ");
            }
            Console.WriteLine("");

            //Start of layout
            for (int boardBound = 0; boardBound < boardSize - 1; boardBound++)
            {

                Console.Write("+---");

                if (boardBound == boardSize - 1)
                {
                    Console.WriteLine(boardBound + " +");
                }
            }

            //cells
            for (int sendRow = 0; sendRow < boardSize - 1; sendRow++)
            {

                Console.Write(" \n: ");

                for (int sendCol = 0; sendCol < boardSize - 1; sendCol++)
                {
                    int cell = newBoard.CalcLiveMembers(sendRow, sendCol);

                    if (sendCol < boardSize - 1)
                    {
                        if (cell == 9)
                            Console.Write("?" + " : ");
                        else
                            Console.Write("?" + " : ");

                    }
                    else if (sendCol == boardSize - 1)
                    {
                        if (cell == 9)
                            Console.WriteLine("?" + " : " + sideNums + "\n");
                        else
                            Console.WriteLine("?" + " : " + sideNums + "\n");
                        sideNums++;
                    }
                }
                Console.Write("\n");
                for (int boardBound = 0; boardBound < boardSize - 1; boardBound++)
                {

                    Console.Write("+---");

                    if (boardBound == boardSize)
                    {
                        Console.WriteLine(boardBound + "+" + sideNums);
                        sideNums++;
                    }

                }
            }
            Console.WriteLine("+");
            Console.WriteLine("\n");
        }
    }
}
