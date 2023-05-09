using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Player
    {
        private static List<char> playerAvatar = new List<char>();
        private static bool playerA; 
        private static char player1;
        private static bool playerB; 
        private static char player2;
        private static char player;


        private static void choiceMessage()
        {
            Console.Write("choice: ");
        }
        private static void chooseCharacterAvatarMessagePrompter(int playerNumber)
        {
            Console.WriteLine("Player {0} Choose your character avatar (alphabets only)", playerNumber);
        }
        private static char player1Avatar() //method to set player 1 avatar
        {
            do
            {
                choiceMessage();
                playerA = char.TryParse(Console.ReadLine().ToUpper(), out player1);
            }
            while (!playerA || !char.IsLetter(player1));
            return player1;
        }
        private static char player2Avatar() //method to set player 2 avatar
        {
            do
            {
                choiceMessage();
                playerB = char.TryParse(Console.ReadLine().ToUpper(), out player2);
            }
            while (!playerB || !char.IsLetter(player2));
            return player2;
        }
        public static void choosePlayerAvatarMessage()
        {
            chooseCharacterAvatarMessagePrompter((int)numberRef.a);
            char choice = player1Avatar();
            playerAvatar.Add(choice);
            chooseCharacterAvatarMessagePrompter((int)numberRef.b);
            char choice2 = player2Avatar();
            playerAvatar.Add(choice2);
        }
        public static void replacementForPlayers(Dictionary<char[,], List<char>> nameOfDictionary) //method to populate the playerAvatars when the user selects "load last game" option on display tab
        {
            foreach (List<char> value in nameOfDictionary.Values)
            {
                playerAvatar = value;
            }
        }
        public static int numberOfTries()
        { 
            int tries = Files.loadNumberOfTries();
            if (tries % (int)numberRef.b == (int)numberRef.z)
            {
                return (int)numberRef.z;
            }
            else
            {
                return (int)numberRef.a;
            }
        }
        public static char currentPlayer()
        {
            int number = numberOfTries();
            if (number == (int)numberRef.z)
            {
                player = playerAvatar.First();
            }
            else if (number == (int)numberRef.a)
            {
                player = playerAvatar.Last();
            }
            return player;
        }
        public static void playerToMove()
        {
            currentPlayer();
            Console.WriteLine("player {0} to move", player);
        }

        public static List<char> returnPlayerAvatar()
        {
            return playerAvatar;
        }
        public static char returnPlayer()
        {
            return player;
        }
    }
}
