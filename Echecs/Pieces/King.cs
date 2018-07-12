using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Plat;

namespace Echecs.Pieces
{
    class King : Pawn
    {
        public King(Plateau.Sides s, Position p) : base(s, p) { }
        public override String GetRepr() => "K";

        public new bool IsMovementValid(Plateau board, Position destination)
        {
            return King.IsMovementValid(board, Pos, destination, Side);
        }

        public static new bool IsMovementValid(Plateau board, Position origin, Position destination, Plateau.Sides side)
        {
            int deltaX = origin.X - destination.X;
            int deltaY = origin.Y - destination.Y;

            bool InRange = deltaX >= -1 && deltaX <= 1
                && deltaY >= -1 && deltaY <= 1;

            Pawn dest = board.GetPawn(destination);

            bool CanMove = dest == null || dest.Side != side;

            return InRange && CanMove;
        }
    }
}
