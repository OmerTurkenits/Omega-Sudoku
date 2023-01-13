using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.InteropServices;

namespace SudokuProj
{
    //The Dancing Links List implementation.
    public class DLX
    {
        //The header of the DLX list.
        private ColumnNode header;

        //The algorithm x temp list.
        private List<DancingNode> temp =  new List<DancingNode>();
        //The algorithm x result list.
        public List<DancingNode> result = new List<DancingNode>();

        //A DLX constractor that gets a cover matrix
        public DLX(byte[,] cover)
        {
            header = covertCoverToDLX(cover);
        }

        //
        /// <summary>
        /// A function that converts a cover matrix to a DLX list
        /// </summary>
        /// <param name="cover"> The Cover Matrix </param>
        /// <returns> The DLX Matrix </returns>
        private ColumnNode covertCoverToDLX(byte[,] cover)
        {
            //The head of the DLX
            ColumnNode headerNode = new ColumnNode("header");
            //The DLX columns.
            ArrayList columnNodes = new ArrayList();

            //Create each of the DLX columns.
            for (int i = 0; i < cover.GetLength(1); i++)
            {
                ColumnNode n = new ColumnNode(i + "");
                columnNodes.Add(n);
                headerNode = (ColumnNode)headerNode.linkRight(n);
            }

            //Move the headerNode to the start.
            headerNode = headerNode.right.column;

            //Create the Dancing links according to the cover matrix values.
            for (int i = 0; i < cover.GetLength(0); i++)
            {
                DancingNode prev = null;
                for (int j = 0; j < cover.GetLength(1); j++)
                {
                    //If = 1, Create a link and link it.
                    if (cover[i,j] == 1)
                    {
                        ColumnNode col = (ColumnNode)columnNodes[j] ;
                        DancingNode newNode = new DancingNode(col);

                        if (prev == null)
                            prev = newNode;

                        col.top.linkDown(newNode);
                        prev = prev.linkRight(newNode);
                        col.size++;
                    }
                }
            }

            headerNode.size = cover.GetLength(1);

            //Return the DLX
            return headerNode;
        }

        /// <summary>
        /// A function that implements Algorithm X.
        /// </summary>
        /// <returns> True if the sudoku has been solved, else returns false. </returns>
        public Boolean solveProcess()
        {
            //The end of the algorithm.
            if (header.right == header)
            {
                //Copy the temp list to the final result list
                result = new List<DancingNode>(temp);
                return true;
            }
            else
            {
                //Choose a column and cover it.
                ColumnNode c = selectMinColumn();
                c.cover();

                for (DancingNode r = c.bottom; r != c; r = r.bottom)
                {
                    //Add a line to the solution.
                    temp.Add(r);

                    //Cover the columns.
                    DancingNode j = r.right;
                    for (j = r.right; j != r; j = j.right)
                        j.column.cover();
                    
                    //If the sudoku has been solved:
                    if(solveProcess())
                        return true;

                    //If not:
                    //Remove the node from the list.
                    r = temp[temp.Count() - 1];
                    temp.RemoveAt((int)(temp.Count() - 1));
                    c = r.column;

                    //Uncover the columns.
                    for (j = r.left; j != r; j = j.left)
                        j.column.uncover();
                }

                c.uncover();
                return false;
            }
        }

        /// <summary>
        /// A Heuristic function that selects the minimum size column node in the DLX
        /// </summary>
        /// <returns> The minimum size column node </returns>
        public ColumnNode selectMinColumn()
        {
            //The minimum size column node.
            ColumnNode minColumn = (ColumnNode)header.right;
            ColumnNode c = (ColumnNode)header.right;

            while (c != header)
            {
                //If the current column is smaller replace the min column
                if (c.size < minColumn.size)
                    minColumn = c;

                //Go to the next column
                c = (ColumnNode)c.right;
            }

            //Return the minimum size column
            return minColumn;
        }

        //A function that converts DLX list to a regular matrix
        public byte[,] convertDLXListToGrid()
        {
            //The solved sudoku matrix
            byte[,] result = new byte[Config.SIZE, Config.SIZE];

            foreach (DancingNode n in this.result)
            {
                DancingNode rcNode = n;
                int min = int.Parse(rcNode.column.name);

                for (DancingNode tmp = n.right; tmp != n; tmp = tmp.right)
                {
                    int val = int.Parse(tmp.column.name);

                    if (val < min)
                    {
                        min = val;
                        rcNode = tmp;
                    }
                }

                int ans1 = int.Parse(rcNode.column.name);
                int ans2 = int.Parse(rcNode.right.column.name);
                int r = ans1 / Config.SIZE;
                int c = ans1 % Config.SIZE;
                byte num = (byte)((ans2 % Config.SIZE) + 1);
                result[r, c] = num;
            }
            return result;
        }
    }

}
