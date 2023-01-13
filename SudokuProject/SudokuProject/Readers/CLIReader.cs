using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{ 
    //A Command Line Reader implementation:
    public class CLIReader : Reader
    {
        public override byte[,] read()
        {
            String input;
            Console.WriteLine("Input From Keyboard:");
            input = Console.ReadLine();

            //Calls the convert function on the input.
            return convert(input);
        }
    }
}
