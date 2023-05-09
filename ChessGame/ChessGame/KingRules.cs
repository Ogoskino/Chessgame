using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class KingRules
    {

        public static bool generalCrownRules()
        {
            if (((Moves.movedPiece() == ChessPieceDifferentiator.upperKing() && Player.returnPlayer() == Player.returnPlayerAvatar().First()) 
                || (Moves.movedPiece() == ChessPieceDifferentiator.lowerKing() && Player.returnPlayer() == Player.returnPlayerAvatar().Last())) 
                && (Math.Abs(Moves.returnMoves()[(int)numberRef.b] - Moves.returnMoves().First()) == (int)numberRef.a && Math.Abs(Moves.returnMoves().Last()
                - Moves.returnMoves()[(int)numberRef.a]) == (int)numberRef.a || (Moves.returnMoves().Last() == Moves.returnMoves()[(int)numberRef.a] && 
                Math.Abs(Moves.returnMoves()[(int)numberRef.b] - Moves.returnMoves().First())== (int)numberRef.a) || Math.Abs(Moves.returnMoves().Last()
                - Moves.returnMoves()[(int)numberRef.a]) == (int)numberRef.a && Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First()) &&
                ChessRules.preventMoveOver())
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
