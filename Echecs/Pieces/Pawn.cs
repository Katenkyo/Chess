using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Plat;

namespace Echecs.Pieces
{
    class Pawn
    {
        private Plateau.Sides side;
        private Position pos;

        public Pawn()
        {
            Pos = null;
        }

        public Pawn(Plateau.Sides s)
        {
            Side = s;
            Pos = null;
        }
        public Pawn(Plateau.Sides s, Position p)
        {
            Side = s;
            Pos = p;
        }

        public virtual String GetRepr() => "P";
        public Plateau.Sides Side
        {
            get => side;
            set
            {
                if (!Enum.IsDefined(typeof(Plateau.Sides), value))
                {
                    throw new Exception();
                }
                side = value;
            }
        }

        public Position Pos { get => pos; set => pos = value; }

        public virtual bool IsMovementValid(Plateau board, Position destination)
        {
            return Pawn.IsMovementValid(board, Pos, destination, Side);
        }

        // TODO: Il faudra rajouter les 'en passant'
        public static bool IsMovementValid(Plateau board, Position origin, Position destination, Plateau.Sides side)
        {
            int deltaX = origin.X - destination.X;
            int deltaY = origin.Y - destination.Y;
            bool isValid = false;

            if(Math.Sign(deltaX) != Math.Sign((int)side))
            {
                // Moving in a direction the pawn isn't allowed to
                return false;
            }

            deltaX = Math.Abs(deltaX);
            deltaY = Math.Abs(deltaY);

            if(deltaY == 0)
            {
                switch (deltaX)
                {                
                    case 1:
                        isValid = board.IsEmpty(destination);
                        break;
                    case 2:
                        
                        if(board.IsPawnStartingRow(origin,side) 
                            && board.FirstPawnOnPath(origin, destination) == null)
                        {
                            isValid = true;
                        }
                        break;
                    default:break;
                }
            }
            // Case: on mange une pièce, mouvement de 1 en diagonale
            else if(deltaY == 1 && deltaY == deltaX)
            {
                isValid = !board.IsEmpty(destination);
            }
            

            return isValid;
        }

        public List<Position> PossibleMovements(Plateau board, Position origin)
        {
            throw new NotImplementedException();
        }
    }
}
