using SudokuProject.Exceptions;
using SudokuProject.Readers;
using SudokuProject.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    //The Sudoku Solver Module: 
    public class SudokuSolverModule
    {
        /// <summary>
        /// A function that start the sudoku solving process.
        /// </summary>
        public static void startProcess()
        {
            //The Reader object.
            Reader r = SelectUserInput();
            
            //The user's input string.
            string input;

            //The sudoku board.
            byte[,] board;

            try {
                //Reads the user's input.
                input = r.read();
                //converts the input to a matrix.
                board = InputProcessor.convertStringToBoard(input);
                //Creates a new sudoku object.
                Sudoku sudoku = new Sudoku(board);
                //Calls the solve function.
                sudoku.solve();

                //if the input came from a file, write the solution back to the same file.
                if (r is FileReader)
                    ((FileReader)r).writeSolution(sudoku);

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
            catch (InvalidInputException)
            {
                Console.WriteLine("Incorrect Char Input!");
            }

        }

        public static Reader SelectUserInput()
        {
            //The user's choice.
            int input;

            //Get choice from user.
            int.TryParse(Console.ReadLine(), out input);

            Console.ForegroundColor = Config.CONSOLE_WHITE;
            Console.WriteLine();

            //Selects the Reader type according to the user's choice.
            switch (input)
            {
                //input from keyboard
                case 1:
                    return new CLIReader();
                //input from file
                case 2:
                    return new FileReader();
                //Defult: input from keyboard
                default:
                    return null;
            }
            
        }
    }
}
