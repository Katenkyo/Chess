using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Pieces;

namespace Echecs.Plat
{
    class Plateau
    {
        // The board positions are 1-indexed
        private const int BOARD_SIZE = 8;

        public enum Sides : int { BLACK = -1, WHITE = 1 };
        public List<Pawn> pieces;

        public Plateau()
        {
            pieces = new List<Pawn>();

            // Génération des pions (Pawns)
            for(int i=1; i <= BOARD_SIZE; i++)
            {
                pieces.Add(new Pawn(Sides.WHITE, new Position(2, i)));
                pieces.Add(new Pawn(Sides.BLACK, new Position(BOARD_SIZE - 1, i)));
            }

            // Génération des tours (Rooks)
            pieces.Add(new Rook(Sides.WHITE, new Position(1, 1)));
            pieces.Add(new Rook(Sides.WHITE, new Position(1, BOARD_SIZE)));
            pieces.Add(new Rook(Sides.BLACK, new Position(BOARD_SIZE, 1)));
            pieces.Add(new Rook(Sides.BLACK, new Position(BOARD_SIZE, BOARD_SIZE)));

            // Génération des Cavaliers (Knights)
            pieces.Add(new Knight(Sides.WHITE, new Position(1, 2)));
            pieces.Add(new Knight(Sides.WHITE, new Position(1, BOARD_SIZE - 1)));
            pieces.Add(new Knight(Sides.BLACK, new Position(BOARD_SIZE, 2)));
            pieces.Add(new Knight(Sides.BLACK, new Position(BOARD_SIZE, BOARD_SIZE - 1)));

            // Génération des fous (Bishops)
            pieces.Add(new Bishop(Sides.WHITE, new Position(1, 3)));
            pieces.Add(new Bishop(Sides.WHITE, new Position(1, BOARD_SIZE -2 )));
            pieces.Add(new Bishop(Sides.BLACK, new Position(BOARD_SIZE, 3)));
            pieces.Add(new Bishop(Sides.BLACK, new Position(BOARD_SIZE, BOARD_SIZE - 2)));

            // Génération des Reines/Rois
            pieces.Add(new Queen(Sides.WHITE, new Position(1, 4)));
            pieces.Add(new Queen(Sides.BLACK, new Position(BOARD_SIZE, 4)));
            pieces.Add(new King(Sides.WHITE, new Position(1, 5)));
            pieces.Add(new King(Sides.BLACK, new Position(BOARD_SIZE, 5)));
        }

        public bool IsPawnStartingRow(Position pos, Sides s) => IsPawnStartingRow(pos.X, s);
        public bool IsPawnStartingRow(int row, Sides s)
        {
            if(!Sides.IsDefined(typeof(Sides), s))
            {
                return false;
            }
            return row == (s >= 0 ? 2 : BOARD_SIZE - 1);
        }

        public Pawn GetPawn(Position pos)
        {
            foreach (Pawn p in pieces)
            {
                if (p.Pos == pos)
                {
                    return p;
                }
            }
            return null;
        }

        public bool IsEmpty(Position pos)
        {
            return GetPawn(pos) == null;
        }


        // Returns the position corresponding to the first pawn encountered
        // When moving from origin to destination
        // Returns null if there's none
        public Pawn FirstPawnOnPath(Position origin, Position destination)
        {
            int deltaX = origin.X - destination.X;
            int deltaY = origin.Y - destination.Y;

            // Only act on lines/diags, otherwise throw error because that pathway is impossible
            bool isLine = deltaX == 0 ^ deltaY == 0;
            bool isDiag = Math.Abs(deltaX) == Math.Abs(deltaY) && deltaX != 0;

            // Equivalent to !(isLine||isDiag)
            if (!isLine && !isDiag)
            {
                throw new Exception();
            }

            int incX = Math.Sign(deltaX);
            int incY = Math.Sign(deltaY);
            Position currPos = new Position(origin);
            while(!currPos.Equals(destination))
            {
                currPos.X += incX;
                currPos.Y += incY;
                Pawn temp = GetPawn(currPos);
                if(temp != null)
                {
                    return temp;
                }
            }
            return null;
        }

        public override string ToString()
        {
            String[][] repr = new String[BOARD_SIZE + 2][];
            String concat = "";

            for (int i = 0; i < repr.Length; i++)
            {
                String[] temp = new String[BOARD_SIZE + 2];
                for(int j = 0; j < temp.Length; j++)
                {

                    if (j == 0 
                        ^ j == temp.Length - 1
                        ^ i == 0
                        ^ i == temp.Length - 1)
                    {
                        temp[j] = i == 0 || i == temp.Length - 1 ? j.ToString() : i.ToString();
                    }
                    else
                    {
                        temp[j] = "_";
                    }
                    
                }

                repr[i] = temp;
            }

            foreach(Pawn p in pieces)
            {
                String pRep = p.GetRepr();
                repr[p.Pos.X][p.Pos.Y] = p.Side == Sides.BLACK ? pRep.ToLower() : pRep;
            }

            for (int i = repr.Length - 1; i >= 0; i--)
            {
                concat += String.Join(" ", repr[i]) + "\n";
            }

            return concat;
        }
    }
}
