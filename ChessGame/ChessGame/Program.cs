using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net;
using System.Threading;

namespace ChessGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Files.constructFile();
            int tries = Player.numberOfTries();
            Board.welcomeMessage();
            Board.displayOptions();
            do
            {
                Board.displayBoard();
                Player.playerToMove();
                Moves.moveCollector();
                if (ChessRules.combinedChessRules())
                {
                    Moves.movePlayer();
                    tries++;
                    Files.saveNumberOfTries(tries);
                    Files.savePiecesAndPlayers();
                }
                else
                {
                    Board.invalidMoveMessage();
                }
                Win.winMessage();
            }
            while (!Win.hasWon());
            tries--;
            Files.saveNumberOfTries(tries);

        }
    }
}
