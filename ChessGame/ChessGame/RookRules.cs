using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class RookRules
    {
        private static List<char> listing1 = new List<char>();
        private static List<char> listing2 = new List<char>();


        private static void horizontalLeftChecker() //horizontal left-direction check that populates the list starting from the first non-space character
        {
            for (int i = (int)numberRef.a; (Moves.returnMoves().First() - i) >= Moves.returnMoves()[(int)numberRef.b]; i++) 
            {
                listing1.Add(Board.returnGrid()[Moves.returnMoves().First() - i, Moves.returnMoves()[(int)numberRef.a]]);
                if (listing1[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing1.Clear();
                }
            }
        }
        private static void horizontalRightChecker()  //horizontal right-direction check that populates the list starting from the first non-space character
        {
            for (int i = (int)numberRef.a; (Moves.returnMoves().First() + i) <= Moves.returnMoves()[(int)numberRef.b]; i++) 
            {
                listing2.Add(Board.returnGrid()[Moves.returnMoves().First() + i, Moves.returnMoves()[(int)numberRef.a]]);
                if (listing2[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing2.Clear();
                }
            }
        }
        public static bool goOverForRookHorizontal() //method that returns true when no pieces exist along the possible horizontal path of the selected rook piece
        {
            listing1.Clear();
            listing2.Clear();
            horizontalLeftChecker();
            horizontalRightChecker();

            if ((listing1.Count <= (int)numberRef.a && Moves.returnMoves().First() > Moves.returnMoves()[(int)numberRef.b]) 
                || (listing2.Count <= (int)numberRef.a && Moves.returnMoves().First() < Moves.returnMoves()[(int)numberRef.b]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static void verticalUpwardChecker() //vertical upward-direction check that populates the list starting from the first non-space character
        {
            for (int j = (int)numberRef.a; (Moves.returnMoves()[(int)numberRef.a] - j) >= Moves.returnMoves().Last(); j++)
            {
                listing1.Add(Board.returnGrid()[Moves.returnMoves().First(), Moves.returnMoves()[(int)numberRef.a] - j]);
                if (listing1[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing1.Clear();
                }
            }
        }
        private static void verticalDownwardChecker() //vertical down-direction check method that populates the list starting from the first non-space character
        {
            for (int j = (int)numberRef.a; (Moves.returnMoves()[(int)numberRef.a] + j) <= Moves.returnMoves().Last(); j++)
            {
                listing2.Add(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves()[(int)numberRef.a] + j]);
                if (listing2[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing2.Clear();
                }
            }
        }
        public static bool goOverRookVertical() //method that returns true when no pieces exist along the possible vertical path of the selected rook piece
        {
            listing1.Clear();
            listing2.Clear();
            verticalUpwardChecker();
            verticalDownwardChecker();

            if ((listing1.Count <= (int)numberRef.a && Moves.returnMoves()[(int)numberRef.a] > Moves.returnMoves().Last()) ||
                (listing2.Count <= (int)numberRef.a && Moves.returnMoves()[(int)numberRef.a] < Moves.returnMoves().Last()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool generalRookRules() //combines all rook rules
        {
            if (((Moves.movedPiece() == ChessPieceDifferentiator.lowerRook() && Player.returnPlayer() == 
                Player.returnPlayerAvatar().Last()) || (Moves.movedPiece() == ChessPieceDifferentiator.upperRook() && 
                Player.returnPlayer() == Player.returnPlayerAvatar().First())) && (Moves.returnMoves().Last() == Moves.returnMoves()[(int)numberRef.a] 
                || Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First()) && ChessRules.preventMoveOver() && 
                (goOverForRookHorizontal() || goOverRookVertical()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
