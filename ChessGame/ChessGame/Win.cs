using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Win
    {
        private static List<char> list = new List<char>();
        private static char[,] WinClassplayers = new char[Board.returnGridSize(), Board.returnGridSize()];


        private static void keyExtractor() //stores the elements of the latest saved grid in the 2D-char array WinClassPlayers
        {
            foreach (char[,] key in Files.loadPiecesAndPlayers().Keys)
            {
                WinClassplayers = key;
            }
        }
        private static void populator() //populates the list with elements of the 2D-char array WinClassPlayars
        {
            for (int i = (int)numberRef.z; i < Board.returnGridSize(); i++)
            {
                for (int j = (int)numberRef.z; j < Board.returnGridSize(); j++)
                {
                    list.Add(WinClassplayers[i, j]);
                }
            }
        }
        public static bool hasWon()
        {
            if (Files.loadPiecesAndPlayers().Count != (int)numberRef.z)
            {
                list.Clear();
                keyExtractor();
                populator();    
                if (list.Contains(ChessPieceDifferentiator.upperKing()) && list.Contains(ChessPieceDifferentiator.lowerKing()))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }
        public static bool winMessage()
        {
            if (hasWon())
            {
                Console.WriteLine("player {0} has won", Player.returnPlayer());
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
