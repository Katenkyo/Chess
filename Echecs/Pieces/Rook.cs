using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Plat;

namespace Echecs.Pieces
{
    class Rook : Pawn
    {
        public Rook(Plateau.Sides s, Position p) : base(s, p){  }
        public override String GetRepr() => "R";

        public new bool IsMovementValid(Plateau board, Position destination)
        {
            return Rook.IsMovementValid(board, Pos, destination, Side);
        }

        public static new bool IsMovementValid(Plateau board, Position origin, Position destination, Plateau.Sides side)
        {
            if (!origin.IsLine(destination))
            {
                return false;
            }
            int deltaX = origin.X - destination.X;
            int deltaY = origin.Y - destination.Y;

            Pawn dest = board.FirstPawnOnPath(origin, destination);
            
            return dest == null || dest.Side != side && dest.Pos == destination;
        }
    }
}
