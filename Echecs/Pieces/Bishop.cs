using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Plat;

namespace Echecs.Pieces
{
    class Bishop : Pawn
    {
        public Bishop(Plateau.Sides s, Position p) : base(s, p) { }
        public override String GetRepr() => "B";

        public new bool IsMovementValid(Plateau board, Position destination)
        {
            return Bishop.IsMovementValid(board, Pos, destination, Side);
        }

        public static new bool IsMovementValid(Plateau board, Position origin, Position destination, Plateau.Sides side)
        {
            if (!origin.IsDiag(destination))
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
