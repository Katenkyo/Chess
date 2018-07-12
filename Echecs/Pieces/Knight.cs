using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Plat;

namespace Echecs.Pieces
{
    class Knight : Pawn
    {
        public Knight(Plateau.Sides s, Position p) : base(s, p) { }
        public override String GetRepr() => "N";

        public new bool IsMovementValid(Plateau board, Position destination)
        {
            return Knight.IsMovementValid(board, Pos, destination, Side);
        }

        public static new bool IsMovementValid(Plateau board, Position origin, Position destination, Plateau.Sides side)
        {
            return false;
        }
    }
}
