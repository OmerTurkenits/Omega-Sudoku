using SudokuProject.Readers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    //A File Reader implementation:
    public class FileReader : Reader
    {
        public string filePath;

        public override string read()
        {  
            Console.Write("Enter a file path: ");

            //Enter a file path.
            string filePath = Console.ReadLine();
            this.filePath = filePath;

            //Read from file.
            string input = System.IO.File.ReadAllText($@"{filePath}");

            //Calls the convert function on the input.
            return input;
        }

        public void writeSolution(Sudoku sudoku)
        {
            string solution = InputProcessor.convertBoardToString(sudoku.solvedBoard);
            System.IO.File.WriteAllText(this.filePath, solution);
        }
    }
}
