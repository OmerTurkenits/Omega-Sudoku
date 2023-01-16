using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SudokuProject;
using SudokuProject.Exceptions;
using System.Security.Principal;
using System.IO;
using SudokuProject.Readers;

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
                Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("000000"));
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
        //Incorrect input sudoku
        public void TestIncorrectInputSudoku()
        {
            try
            {
                Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("400000805030000A00000700000020000060L00080400000010000000603070500200000104000000"));
                sudoku.solve();
                Assert.Fail();

            }
            //Expected to throw the 'InvalidSudokuSizeException' exception.
            catch (InvalidInputException)
            {
                Console.WriteLine("Incorrect Char Input!");
            }
        }

        [TestMethod]
        //Empty 1x1 Sudoku
        public void TestEmpty1x1Sudoku()
        {
            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("0"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Empty 4x4 Sudoku
        public void TestEmpty4x4Sudoku()
        {
            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("0000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Solvable 4x4 Sudoku
        public void TestSolvable4x4Sudoku()
        {
            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("1000020000300004"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Unsolvable 4x4 Sudoku
        public void TestUnsolvable4x4Sudoku()
        {
            try
            {
                Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("1000020030300004"));
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
        //Empty 9x9 Sudoku
        public void TestEmpty9x9Sudoku()
        {
            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));

        }

        [TestMethod]
        //Solvable 9x9 Sudoku
        public void TestSolvable9x9Sudoku()
        {

            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("900800000000000500000000000020010003010000060000400070708600000000030100400000200"));
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
                Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("000005080000601043000000000010500000000106000300000005530000061000000004000000000"));
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
        //Solved 9x9 Sudoku
        public void TestSolved9x9Sudoku()
        {

                Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("378496215659132478214758639745619382123584967896273154481325796532967841967841523"));
                sudoku.solve();

                //Expected to solve the sudoku.
                Assert.IsTrue(isSolved(sudoku.solvedBoard));

        }

        [TestMethod]
        //Empty 16x16 Sudoku
        public void TestEmpty16x16Sudoku()
        {
            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Solvable 16x16 Sudoku - given example
        public void TestSolvable16x16Sudoku()
        {

            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("10023400<06000700080007003009:6;0<00:0010=0;00>0300?200>000900<0=000800:0<201?000;76000@000?005=000:05?0040800;0@0059<00100000800200000=00<580030=00?0300>80@000580010002000=9?000<406@0=00700050300<0006004;00@0700@050>0010020;1?900=002000>000>000;0200=3500<"));
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
                Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("800000040000000250000000000000013000000<00000002400000000000000350000000000000066000000000000005700000000000000900000000000000009000000000000007;00000000000000::00000000000000;>00000000000000<<00000000000000>=00000000000000@@00000000000000=?0000000000000001"));
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
        //Solved 16x16 Sudoku
        public void TestSolved16x16Sudoku()
        {

            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("15:2349;<@6>?=78>@8=5?7<43129:6;9<47:@618=?;35>236;?2=8>75:94@<1=4>387;:5<261?@98;76412@9:>?<35=<91:=5?634@8>2;7@?259<>31;7=:68462@>;94=?1<587:37=91?235;>8:@<46583;1:<7264@=9?>?:<4>6@8=9372;152358<>:?6794;1=@:7=<@359>8;1642?;1?968=4@25<7>3:4>6@7;12:?=3589<"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));

        }

        [TestMethod]
        //Empty 25x25 Sudoku
        public void TestEmpty25x25Sudoku()
        {
            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Solvable 25x25 Sudoku
        public void TestSolvable25x25Sudoku()
        {

            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("4000008050300000000007000000200000600000804000000100000000030705002000000000000000000000000000000000000000000000100000000009000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));
        }

        [TestMethod]
        //Unsolvable 25x25 Sudoku
        public void TestUnsolvable25x25Sudoku()
        {
            try
            {
                Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("400000805030000000000700000020000060000080400000010000000003070500200000000000000000050000000000000000000000000010000000000900000000000000007000000000000000000000090000400000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000002000000000000000000000300000000000000000004000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000003000000000000000000000000B000000000000000000000<000000000000A00000000000000000000000>0000000"));
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
        //Solved 25x25 Sudoku
        public void TestSolved25x25Sudoku()
        {
            Sudoku sudoku = new Sudoku(InputProcessor.convertStringToBoard("41:;<28=5>36?@A9BCDEF7GHI35729FGHI6=>CDE8<4?@:;AB1BDEFG19:;34785<>2AHI6=?@C6=>?@7ABCE9:;HI135FG248<D8ACHI4<?@D2B1FG76:;=35>9E1:2G3B45<IC8H;6EA?79>FD=@?<FC=>196GB3DA:I@25;8E47H;H6D>=27E@14FI9<CG8:A?53B@78ABH3;?F<5GE=41>6DI29C:549IE8:CDA@27?>3HF=B1<6;GF3192G54:?EC=68AID@7<BH>;>E@4;IB1=HF<53?G:928DAC67IG?8ACD279H1>4;B=<36E@F:5CB<=7E63>;DGA:@HF1459I2?8H65:DA@8F<I927B;>EC?G134=29;1?<CD356H:84F7IBA@G=E><@H34?FE1:GIB=5C86>27D;A9ECDB:;>A27?F<13=9@G45HI86AFG78@I64=;E9>CD5H13?:B2<=>I569HG8BAD@27?E;:<C31F4923@15?<H48=6CD:;7IFB>EGA:;B>C3EIA15@4<F2G89H=67D?GIAEHD7>92:;3B16?=<C48@5F7846F:=@BC>?EGH5D3A1;9<I2D?=<56;FG87AI92@4BE>HC:13"));
            sudoku.solve();

            //Expected to solve the sudoku.
            Assert.IsTrue(isSolved(sudoku.solvedBoard));

        }
    }
}
