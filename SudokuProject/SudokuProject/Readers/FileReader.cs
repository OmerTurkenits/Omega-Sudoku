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
        public override byte[,] read()
        {
            
            Console.WriteLine("1. C:\\Users\\Asus\\Desktop\\Omega-Sudoku\\SudokuProject\\SudokuProject\\sudoku.txt\n");
            Console.Write("Enter a file path: ");

            //Enter a file path.
            string filePath = Console.ReadLine();

            //Read from file.
            string input = System.IO.File.ReadAllText($@"{filePath}");

            //Calls the convert function on the input.
            return convert(input);
        }
    }
}
