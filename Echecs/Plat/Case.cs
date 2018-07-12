using System;
using System.Collections.Generic;
using System.Text;
using Echecs.Pieces;

namespace Echecs.Plat
{
    class Case
    {
        private Position pos;
        private Pawn content;

        public Position Pos { get => pos; set => pos = value; }
        public Pawn Content { get => content; set => content = value; }

        public bool IsEmpty() => content == null;
    }
}
