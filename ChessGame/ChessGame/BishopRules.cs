using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class BishopRules
    {
        private static List<char> listing1 = new List<char>();
        private static List<char> listing2 = new List<char>();
        private static List<char> listing3 = new List<char>();
        private static List<char> listing4 = new List<char>();

        private static void listing1Evaluator() //up-right diagonal check that populates the list starting from the first non-space character
        {
            for (int j = (int)numberRef.a; (Moves.returnMoves().First() - j >= Moves.returnMoves()[(int)numberRef.b] && Moves.returnMoves()[(int)numberRef.a] + j <= Moves.returnMoves().Last()); j++)
            {
                listing1.Add(Board.returnGrid()[Moves.returnMoves().First() - j, Moves.returnMoves()[(int)numberRef.a] + j]);
                if (listing1[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing1.Clear();
                }
            }
        }
        private static void listing2Evaluator() //down-left diagonal check that populates the list starting from the first non-space character
        {
            for (int j = (int)numberRef.a; (Moves.returnMoves().First() + j <= Moves.returnMoves()[(int)numberRef.b] && Moves.returnMoves()[(int)numberRef.a] - j >= Moves.returnMoves().Last()); j++)
            {
                listing2.Add(Board.returnGrid()[Moves.returnMoves().First() + j, Moves.returnMoves()[(int)numberRef.a] - j]);

                if (listing2[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing2.Clear();
                }
            }
        }
        private static void listing3Evaluator() //up-left diagonal check that populates the list starting from the first non-space character
        {
            for (int j = (int)numberRef.a; (Moves.returnMoves().First() - j >= Moves.returnMoves()[(int)numberRef.b] && Moves.returnMoves()[(int)numberRef.a] - j >= Moves.returnMoves().Last()); j++)
            {
                listing3.Add(Board.returnGrid()[Moves.returnMoves().First() - j, Moves.returnMoves()[(int)numberRef.a] - j]);

                if (listing3[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing3.Clear();
                }
            }
        }
        private static void listing4Evaluator() //down-right diagonal check that populates the list starting from the first non-space character
        {
            for (int j = (int)numberRef.a; (Moves.returnMoves().First() + j <= Moves.returnMoves()[(int)numberRef.b] && Moves.returnMoves()[(int)numberRef.a] + j <= Moves.returnMoves().Last()); j++)
            {
                listing4.Add(Board.returnGrid()[Moves.returnMoves().First() + j, Moves.returnMoves()[(int)numberRef.a] + j]);

                if (listing4[(int)numberRef.z] == Board.returnSpacing())
                {
                    listing4.Clear();
                }
            }
        }
        private static void clearListings()
        {
            listing1.Clear();
            listing2.Clear();
            listing3.Clear();
            listing4.Clear();
            
        }
        private static void listingEvaluator()
        {
            listing1Evaluator();
            listing2Evaluator();
            listing3Evaluator();
            listing4Evaluator();
        }
        public static bool getOverBishop() //method that returns true when no piece exist along the possible path of the selected bishop piece. 
        {
            clearListings();
            listingEvaluator();
            
            if ((listing4.Count <= (int)numberRef.a && Moves.returnMoves().First() - Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves()[(int)numberRef.a] - Moves.returnMoves().Last()) &&
                listing3.Count == (int)numberRef.z || (listing1.Count <= (int)numberRef.a && Moves.returnMoves().Last() - Moves.returnMoves()[(int)numberRef.a] == Moves.returnMoves().First() 
                - Moves.returnMoves()[(int)numberRef.b] && listing2.Count == (int)numberRef.z) || (listing3.Count <= (int)numberRef.a &&Moves.returnMoves().First() - 
                Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves()[(int)numberRef.a] - Moves.returnMoves().Last() && listing4.Count == (int)numberRef.z) ||(listing2.Count <= (int)numberRef.a
                && Moves.returnMoves().First() - Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().Last() - Moves.returnMoves()[(int)numberRef.a] && listing1.Count == (int)numberRef.z))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool generalBishopRules()  //combines all bishop rules
        {
            if (((Moves.movedPiece() == ChessPieceDifferentiator.lowerBishop() && Player.returnPlayer() == Player.returnPlayerAvatar().Last()) || (Moves.movedPiece() == 
                ChessPieceDifferentiator.upperBishop() &&  Player.returnPlayer() == Player.returnPlayerAvatar().First())) && ChessRules.preventMoveOver() && (Math.Abs(Moves.returnMoves()[(int)numberRef.b]
                - Moves.returnMoves().First()) == Math.Abs(Moves.returnMoves().Last() - Moves.returnMoves()[(int)numberRef.a]) && getOverBishop()))
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
