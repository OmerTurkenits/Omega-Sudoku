using SudokuProj.Exceptions;
using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj
{
    //The Sudoku class implementation:
    public class Sudoku
    {
        //The board entered.
        public byte[,] board;
        //The solved board.
        public byte[,] solvedBoard;

        //Sudoku Constractor
        public Sudoku(byte[,] board)
        {
            this.board = board;
        }

        /// <summary>
        /// A function that runs through the steps of the algorithm and solves the sudoku.
        /// </summary>
        /// <exception cref="UnsolvableSudokuException"> If the sudoku is unsolvable, Throws this exception</exception>
        public void solve()
        {
            //Creating a Stopwatch object in order to time the sudoku solving.
            var watch = new Stopwatch();
            
            Console.WriteLine();
            Console.WriteLine("Your Sudoku Board:");
            this.displayBoard();

            //The Solving Algorithm:
            watch.Start();

            //1. Creating a cover matrix from the given board:
            CoverMatrix cover = new CoverMatrix(this);

            //2. Converting the cover matrix into DLX:
            DLX dlx = new DLX(cover.coverData);

            //3. Running algorithm X on the DLX:
            if (!dlx.solveProcess())
                throw new UnsolvableSudokuException();

            //4. Convert the result DLX back to a regular matrix:
            this.solvedBoard = dlx.convertDLXListToGrid();

            watch.Stop();

            //Printing the time took to solve the board and the solved board.
            Console.WriteLine();
            Console.WriteLine($"Your Sudoku Board Solved in {watch.ElapsedMilliseconds} ms!");
            this.displaySolvedBoard();
        }

        /// <summary>
        /// A function that displays the initial board.
        /// </summary>
        public void displayBoard()
        {
            for (int i = 0; i < Config.SIZE; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < Config.SIZE; j++)
                {
                    if (this.board[i,j] == 0)
                        Console.Write("0 ");
                   
                    else
                        //Converts byte to char.
                        Console.Write(Convert.ToChar(this.board[i, j]+'0') + " ");
                   
                    if (j % Config.SQUARE == Config.SQUARE - 1)
                        Console.Write("|");
                }

                if (i % Config.SQUARE == Config.SQUARE - 1)
                    Console.Write($"\n{String.Concat(Enumerable.Repeat(new String('-', Config.SQUARE * 2)+'|', Config.SQUARE))}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// A function that displays the solved board.
        /// </summary>
        public void displaySolvedBoard()
        {
            for (int i = 0; i < Config.SIZE; i++)
            {
                Console.WriteLine();

                for (int j = 0; j < Config.SIZE; j++)
                { 
                    //Shows what cells the algoritm has completed.
                    //Colors them in cyan.
                    if(this.board[i,j] == 0)
                        Console.ForegroundColor = Config.CONSOLE_CYAN;
                    else
                        Console.ForegroundColor = Config.CONSOLE_WHITE;

                    //Converts byte to char.
                    Console.Write(Convert.ToChar(this.solvedBoard[i, j] + '0') + " ");

                    Console.ForegroundColor = Config.CONSOLE_WHITE;

                    if (j % Config.SQUARE == Config.SQUARE - 1)
                        Console.Write("|");
                }

                if (i % Config.SQUARE == Config.SQUARE - 1)
                    Console.Write($"\n{String.Concat(Enumerable.Repeat(new String('-', Config.SQUARE * 2) + '|', Config.SQUARE))}");
            }

            Console.WriteLine();
        }

    }
}
