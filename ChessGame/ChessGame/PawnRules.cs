using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class PawnRules
    {
        
        private static bool capitalPawnExtraMovement() //method to restrict capital pawn movement to one step forward only and displace opponent diagonally
        { 
            if ((Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First() - (int)numberRef.a && Moves.returnMoves()[(int)numberRef.a] 
                == Moves.returnMoves().Last() &&!char.IsLetter(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()])) || 
                (Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First() - (int)numberRef.a && (Moves.returnMoves()[(int)numberRef.a] 
                == Moves.returnMoves().Last() - (int)numberRef.a || Moves.returnMoves()[(int)numberRef.a] - (int)numberRef.a == 
                Moves.returnMoves().Last()) && char.IsLower(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()])))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool lowerPawnMovement() //method to restrict lower pawn movement to one step forward only and displace opponent diagonally
        {
            if ((Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First() + (int)numberRef.a && Moves.returnMoves()[(int)numberRef.a]
                ==  Moves.returnMoves().Last() && !char.IsLetter(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()])) || 
                (Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First() + (int)numberRef.a && (Moves.returnMoves()[(int)numberRef.a]
                == Moves.returnMoves().Last() + (int)numberRef.a || Moves.returnMoves()[(int)numberRef.a] + (int)numberRef.a ==
                Moves.returnMoves().Last()) && char.IsUpper(Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()])))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool capitalPawnDoubleMovementCondition()
        {
            if (Moves.returnMoves()[(int)numberRef.a] == Moves.returnMoves().Last() && Moves.returnMoves().First() == (int)numberRef.f && 
                Moves.returnMoves()[(int)numberRef.b] ==(int)numberRef.d && Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()]
                == Board.returnSpacing() && Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b] + (int)numberRef.a, Moves.returnMoves().Last()] == Board.returnSpacing())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private static bool lowerPawnDoubleMovementCondition()
        {
            if (Moves.returnMoves()[(int)numberRef.a] == Moves.returnMoves().Last() && Moves.returnMoves()[(int)numberRef.z] == (int)numberRef.a && 
                Moves.returnMoves()[(int)numberRef.b] == (int)numberRef.c && Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()] 
                == Board.returnSpacing() && Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b] - (int)numberRef.a, Moves.returnMoves().Last()] == Board.returnSpacing())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool generalPawnRules()
        {
            if (Moves.movedPiece() == ChessPieceDifferentiator.upperPawn() && (capitalPawnDoubleMovementCondition() || 
                (((Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First() - (int)numberRef.a) && Moves.returnMoves().Last() ==
                Moves.returnMoves()[(int)numberRef.a] && Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()] == Board.returnSpacing())
                || capitalPawnExtraMovement()) && Player.returnPlayer() == Player.returnPlayerAvatar().First() && ChessRules.preventMoveOver()))
            {
                return true;
            }
            else if (Moves.movedPiece() == ChessPieceDifferentiator.lowerPawn() && (lowerPawnDoubleMovementCondition() || 
                (((Moves.returnMoves()[(int)numberRef.b] == Moves.returnMoves().First() + (int)numberRef.a) && Moves.returnMoves().Last() == 
                Moves.returnMoves()[(int)numberRef.a] && Board.returnGrid()[Moves.returnMoves()[(int)numberRef.b], Moves.returnMoves().Last()] == Board.returnSpacing())
                || lowerPawnMovement()) && Player.returnPlayer() == Player.returnPlayerAvatar().Last() && ChessRules.preventMoveOver()))
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
