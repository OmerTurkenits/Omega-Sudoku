using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SudokuProject;
using SudokuProject.Exceptions;
using System.Security.Principal;
using System.IO;

namespace SudokuTesting
{
    [TestClass]
    public class SudokuTest
    {
        /// <summary>
        /// A function that checks if a sudoku board is solved.
        /// </summary>
        /// <param name="board"> The sudoku board </param>
        /// <returns> True if the board is solved correctly else returns false. </returns>
        public static Boolean isSolved(byte[,] board)
        {
            int sum = 0;
            int currSum = 0;
            for (int i = 1; i <= board.GetLength(0); i++)
                sum += i;

            //Run on the rows
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                    currSum += board[i, j];

                if (currSum != sum)
                    return false;

                currSum = 0;
            }

            //Run on the columns
            for (int i = 0; i < board.GetLength(1); i++)
            {
                for (int j = 0; j < board.GetLength(0); j++)
                    currSum += board[i, j];  

                if (currSum != sum)
                    return false;

                currSum = 0;
            }

            return true;

        }

        [TestMethod]
        //Wrong input size Sudoku
        public void TestWrongInputSizeSudoku()
        {
            try
            {
                Sudoku sudoku = new Sudoku(Reader.convert("000000"));
                sudoku.solve();
                Assert.Fail();

            }
            //Expected to throw the 'InvalidSudokuSizeException' exception.
            catch (InvalidSudokuSizeException)
            {
                Console.WriteLine("Incorrect Input Size!");
            }
        }

        [TestMethod]
        //Empty 9x9 Sudoku
        public void TestEmpty9x9Sudoku()
        {
            Sudoku sudoku = new Sudoku(Reader.convert("000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Simple 9x9 Sudoku
        public void TestSimple9x9Sudoku()
        {

            Sudoku sudoku = new Sudoku(Reader.convert("900800000000000500000000000020010003010000060000400070708600000000030100400000200"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Unsolvable 9x9 Sudoku
        public void TestUnsolvable9x9Sudoku()
        {
            try
            {
                Sudoku sudoku = new Sudoku(Reader.convert("000005080000601043000000000010500000000106000300000005530000061000000004000000000"));
                sudoku.solve();
                Assert.Fail();

            }
            //Expected to throw the 'UnsolvableSudokuException' exception.
            catch (UnsolvableSudokuException) 
            {
                Console.WriteLine("Unsolvable Sudoku!");
            }
        }

        [TestMethod]
        //Empty 16x16 Sudoku
        public void TestEmpty16x16Sudoku()
        {
            Sudoku sudoku = new Sudoku(Reader.convert("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Simple 16x16 Sudoku - given example
        public void TestSimple16x16Sudoku()
        {

            Sudoku sudoku = new Sudoku(Reader.convert("10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Unsolvable 16x16 Sudoku
        public void TestUnsolvable16x16Sudoku()
        {
            try
            {
                Sudoku sudoku = new Sudoku(Reader.convert("000005080000601043000000000010500000000106000300000005530000061000000004000000000"));
                sudoku.solve();
                Assert.Fail();

            }
            //Expected to throw the 'UnsolvableSudokuException' exception.
            catch (UnsolvableSudokuException)
            {
                Console.WriteLine("Unsolvable Sudoku!");
            }
        }

        [TestMethod]
        //Empty 25x25 Sudoku
        public void TestEmpty25x25Sudoku()
        {
            Sudoku sudoku = new Sudoku(Reader.convert("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Simple 9x9 Sudoku
        public void TestSimple25x25Sudoku()
        {

            Sudoku sudoku = new Sudoku(Reader.convert("4000008050300000000007000000200000600000804000000100000006030705002000001040000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Unsolvable 9x9 Sudoku
        public void TestUnsolvable25x25Sudoku()
        {
            try
            {
                Sudoku sudoku = new Sudoku(Reader.convert("000005080000601043000000000010500000000106000300000005530000061000000004000000000"));
                sudoku.solve();
                Assert.Fail();

            }
            //Expected to throw the 'UnsolvableSudokuException' exception.
            catch (UnsolvableSudokuException)
            {
                Console.WriteLine("Unsolvable Sudoku!");
            }
        }
    }
}
