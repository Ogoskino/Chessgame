using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    struct ChessPieceDifferentiator
    {
        public static char lowerRook()
        {
            char lowerCaseRook = Board.configPieces((int)numberRef.z);
            return lowerCaseRook;
        }
        public static char lowerKnight()
        {
            char lowerCaseKnight = Board.configPieces((int)numberRef.a);
            return lowerCaseKnight;
        }
        public static char lowerBishop()
        {
            char lowerCaseBishop = Board.configPieces((int)numberRef.b);
            return lowerCaseBishop;
        }
        public static char lowerQueen()
        {
            char lowerCaseQueen = Board.configPieces((int)numberRef.c);
            return lowerCaseQueen;
        }
        public static char lowerKing()
        {
            char lowerCaseKing = Board.configPieces((int)numberRef.d);
            return lowerCaseKing;
        }
        public static char lowerPawn()
        {
            char lowerCasePawn = Board.configPieces((int)numberRef.e);
            return lowerCasePawn;
        }
        public static char upperPawn()
        {
            char upperCasePawn = Board.configPieces((int)numberRef.f);
            return upperCasePawn;
        }
        public static char upperRook()
        {
            char upperCaseRook = Board.configPieces((int)numberRef.g);
            return upperCaseRook;
        }
        public static char upperKnight()
        {
            char upperCaseKnight = Board.configPieces((int)numberRef.h);
            return upperCaseKnight;
        }
        public static char upperBishop()
        {
            char upperCaseBishop = Board.configPieces((int)numberRef.h + (int)numberRef.a);
            return upperCaseBishop;
        }
        public static char upperQueen()
        {
            char upperCaseQueen = Board.configPieces((int)numberRef.h + (int)numberRef.b);
            return upperCaseQueen;
        }
        public static char upperKing()
        {
            char upperCaseKing = Board.configPieces((int)numberRef.h + (int)numberRef.c);
            return upperCaseKing;
        }
    }
}
