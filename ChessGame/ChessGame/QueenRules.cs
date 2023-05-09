using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class QueenRules
    {
        public static bool generalQueenRules()
        {
            if (((Moves.movedPiece() == ChessPieceDifferentiator.upperQueen() && Player.returnPlayer() == 
                Player.returnPlayerAvatar().First()) || (Moves.movedPiece() == ChessPieceDifferentiator.lowerQueen()
                && Player.returnPlayer() == Player.returnPlayerAvatar().Last())) && ChessRules.preventMoveOver() && 
                ((Math.Abs(Moves.returnMoves()[(int)numberRef.b] - Moves.returnMoves().First()) == Math.Abs(Moves.returnMoves().Last() 
                - Moves.returnMoves()[(int)numberRef.a]) && BishopRules.getOverBishop()) || ((Moves.returnMoves().Last() == 
                Moves.returnMoves()[(int)numberRef.a] || Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First()) &&
               (RookRules.goOverForRookHorizontal() || RookRules.goOverRookVertical()))))
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
