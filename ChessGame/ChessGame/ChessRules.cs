using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class ChessRules
    {
        public static bool preventMoveOver() //method to prevent like piece from displacing teammates
        {
            if ((char.IsLower(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()]) && 
                char.IsUpper(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.z],Moves.returnMoves()[(int)numberRef.a]])) ||
                (char.IsLower(Board.returnGrid()[Moves.returnMoves().First(), Moves.returnMoves()[(int)numberRef.a]]) && 
                char.IsUpper(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()])) ||
                Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()] == Board.returnSpacing())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool combinedChessRules()
        {
            if (PawnRules.generalPawnRules() || RookRules.generalRookRules() || BishopRules.generalBishopRules()
                || KnightRules.generalKnightRules() || QueenRules.generalQueenRules() || KingRules.generalCrownRules())
            {
                return true;
            }
            else
            {
                Moves.returnMoves().Clear();
                return false;
            }
        }
    }
}
