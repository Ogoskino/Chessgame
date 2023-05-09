using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class KnightRules
    {

        public static bool generalKnightRules()
        {
            if (((Moves.movedPiece() == ChessPieceDifferentiator.lowerKnight() && Player.returnPlayer() == Player.returnPlayerAvatar().Last()) 
                || (Moves.movedPiece() == ChessPieceDifferentiator.upperKnight() && Player.returnPlayer() == Player.returnPlayerAvatar().First()))
                && ChessRules.preventMoveOver() && (((Moves.returnMoves()[(int)numberRef.b] + (int)numberRef.b== Moves.returnMoves().First() ||
                Moves.returnMoves()[(int)numberRef.b] - (int)numberRef.b == Moves.returnMoves().First()) && (Moves.returnMoves().Last() ==
                Moves.returnMoves()[(int)numberRef.a] - (int)numberRef.a ||Moves.returnMoves().Last() == Moves.returnMoves()[(int)numberRef.a] + 
                (int)numberRef.a)) || ((Moves.returnMoves()[(int)numberRef.b] + (int)numberRef.a == Moves.returnMoves().First() || 
                Moves.returnMoves()[(int)numberRef.b] - (int)numberRef.a== Moves.returnMoves().First()) && (Moves.returnMoves()[(int)numberRef.a] == 
                Moves.returnMoves().Last() - (int)numberRef.b || Moves.returnMoves()[(int)numberRef.a] == Moves.returnMoves().Last() + (int)numberRef.b))))
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
