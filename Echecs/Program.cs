using System;
using Echecs.Pieces;
using Echecs.Plat;

namespace Echecs
{
    class Program
    {
        private enum sides : int {WHITE = 1, BLACK = 0 };
        static void Main(string[] args)
        {
            Plateau board = new Plateau();
            foreach(Pawn p in board.pieces)
            {
                Console.WriteLine(p.GetType() + "\t |" + p.Side + "\t : \t" + p.Pos + " | " + p.GetRepr());
            }

            Console.WriteLine(board);

            // Prevent console from closing
            Console.ReadKey();
        }
    }
}
