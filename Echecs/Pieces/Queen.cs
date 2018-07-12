using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Plat;

namespace Echecs.Pieces
{
    class Queen : Pawn
    {
        public Queen(Plateau.Sides s, Position p) : base(s, p) { }
        public override String GetRepr() => "Q";

        public new bool IsMovementValid(Plateau board, Position destination)
        {
            return Queen.IsMovementValid(board, Pos, destination, Side);
        }

        public static new bool IsMovementValid(Plateau board, Position origin, Position destination, Plateau.Sides side)
        {
            return Bishop.IsMovementValid(board, origin, destination, side) 
                ^ Rook.IsMovementValid(board, origin, destination, side);
        }
    }
}
