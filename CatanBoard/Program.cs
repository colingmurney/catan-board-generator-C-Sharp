using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CatanBoard
{
    class Program
    {
        static void Main(string[] args)
        {

            Board board = new Board();
            //input shouldn't be less than 9. Even 9 will take many iterations to find board that meets constraints
            board.generateNumbers(10);
            //lowest input should be 1. Should make a default min=0 and make method so user could enter a min and max (ex: min 3, max 4)
            board.GenerateTerrain(3);
            board.printBoard();
            
        }
    }
}
