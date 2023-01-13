using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    //A Dancing Node implementation: CHECK
    public class DancingNode
    {
        //The Dancing Node connections. 
        public DancingNode left, right, top, bottom;
        //The Dancing Node column.
        public ColumnNode column;

        //Dancing Node Constractor.
        public DancingNode(){
            left = right = top = bottom = this;
        }

        //A Dancing Node Constractor that gets a Column Node and adds it to the column.
        public DancingNode(ColumnNode c){
            left = right = top = bottom = this;
            column = c;
        }

        //A function that gets a node and links it under this node.
        public DancingNode linkDown(DancingNode node){
            node.bottom = bottom;
            node.bottom.top = node;
            node.top = this;
            bottom = node;
            return node;
        }

        //A function that gets a node and links it to the right of this node.
        public DancingNode linkRight(DancingNode node) {
            node.right = right;
            node.right.left = node;
            node.left = this;
            right = node;
            return node;
        }

        //A function that removes this node from the list horizontally.
        public void removeLeftRight() {
            left.right = right;
            right.left = left;
        }

        //A function that reinsert this node to the list horizontally.
        public void reinsertLeftRight(){
            left.right = this;
            right.left = this;
        }

        //A function that removes this node from the list verticaly.
        public void removeTopBottom(){
            top.bottom = bottom;
            bottom.top = top;
        }

        //A function that reinsert this node to the list verticaly.
        public void reinsertTopBottom(){
            top.bottom = this;
            bottom.top = this;
        }
    }

}
