using SudokuProject.Exceptions;
using SudokuProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject.Readers
{
    public static class InputProcessor
    {
        /// <summary>
        /// A function that that validates the input.
        /// </summary>
        /// <param name="input"> The input string </param>
        public static void validate(String input)
        {
            //Calculates the size of the sudoku board.
            double size = Math.Sqrt(input.Length);

            //Checks if the size of the sudoku isn't in the ALLOWED_SIZES list.
            if (!Config.ALLOWED_SIZES.Contains((int)size))
                throw new InvalidSudokuSizeException();

            //Checks if the charachars in the input are valid.
            for(int i = 0; i < input.Length; i++)
                if(input[i] < '0' || input[i] > '0' + size)
                    throw new InvalidInputException();
        } 

        /// <summary>
        /// A function that converts a string to a sudoku board.
        /// </summary>
        /// <param name="input"> The input string </param>
        /// <returns> The sudoku board representing the input </returns>
        public static byte[,] convertStringToBoard(String input)
        {
            //Calls the function that validates the input.
            validate(input);

            //Calculates the size of the sudoku board.
            double size = Math.Sqrt(input.Length);

            //Creates the matrix.
            byte[,] board = new byte[(int)size, (int)size];

            //Sets the sudoku's values.
            Config.SIZE = (int)size;
            Config.SQUARE = (int)Math.Sqrt((int)size);

            //Inputs the values from the string to the matrix.
            for (int i = 0; i < (int)size; i++)
                for (int j = 0; j < (int)size; j++)
                    board[i, j] = (byte)(input[i * (int)size + j] - '0');

            return board;
        }

        /// <summary>
        /// A function that converts a sudoku board solution to a string.
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static string convertBoardToString(byte[,] board)
        {
            string solution = "";

            for (int i = 0; i < board.GetLength(0); i++)
                for (int j = 0; j < board.GetLength(1); j++)
                    solution += (char)(board[i, j] + '0');

            return solution;
        }

    }
}
