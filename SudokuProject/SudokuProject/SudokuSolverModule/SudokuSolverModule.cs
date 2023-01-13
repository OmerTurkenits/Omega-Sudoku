using SudokuProj.Exceptions;
using SudokuProj.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProj
{
    //The Sudoku Solver Module:
    public class SudokuSolverModule
    {
        /// <summary>
        /// 
        /// </summary>
        public static void start()
        {
            //The user's choice.
            int input;
            //The Reader object.
            Reader r;
            //The Sudoku board.
            byte[,] board;

            //Get input from user.
            int.TryParse(Console.ReadLine(), out input);

            Console.ForegroundColor = Config.CONSOLE_WHITE;
            Console.WriteLine();

            //Selects the Reader type according to the user's choice.
            switch (input)
            {
                //input from keyboard
                case 1:
                    r = new CLIReader();
                    break;
                //input from file
                case 2:
                    r = new FileReader();
                    break;
                //Defult: input from keyboard
                default:
                    r = new CLIReader();
                    break;
            }

            try {
                //Reads the string and converts it to a matrix.
                board = r.read();
                //Creates a new sudoku object.
                Sudoku sudoku = new Sudoku(board);
                //Calls the solve function.
                sudoku.solve();
            }
            catch (NullReferenceException){
                Console.WriteLine("Wrong Input!");
            }
            catch (FileNotFoundException){
                Console.WriteLine("File Not Found!");
            }
            catch (InvalidSudokuSizeException){
                Console.WriteLine("Incorrect Input Size!");
            }
            catch(UnsolvableSudokuException){
                Console.WriteLine("Unsolvable Sudoku!");
            } 


        }
    }
}
