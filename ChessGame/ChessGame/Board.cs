using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace ChessGame
{
    enum numberRef
    {
        z, a, b, c, d, e, f, g, h
    }


    internal class Board
    {
        private static int gridSize = (int)numberRef.h;
        private static char[,] grid = new char[gridSize, gridSize];
        private static char spacing = ' ';
        private static string spacingForGrid = " ";
        private static string verticalDivider = "|";
        private static string horizontalElipsis = "-";

        public static int returnGridSize()
        {
            return gridSize;
        }
        public static char[,] returnGrid()
        {
            return grid;
        }
        public static char returnSpacing()
        {
            return spacing;
        }
        private static void replacementForGrid(Dictionary<char[,], List<char>> nameOfDictionary) //procedure to populate grid when user chooses to load last game
        {
            foreach (char[,] key in nameOfDictionary.Keys)
            {
                grid = key;
            }
        }
        private static int choiceExtractor() //procedure to collect number chosen by user from the display option
        {
            int choice;
            int.TryParse(Console.ReadLine(), out choice);
            return choice;
        }
        private static void displayMessage()
        {
            Console.WriteLine("1. Play new game.\n2. Load last game.");
            Console.Write("option: ");
        }
        public static Dictionary<char[,], List<char>> playersAndPiecesStorage()
        {
            Dictionary<char[,], List<char>> playersPiecesContainer = Files.loadPiecesAndPlayers();
            return playersPiecesContainer;
        }
        public static void welcomeMessage()
        {
            Console.WriteLine("Welcome to the Chess game\nChoose an option");
        }
        public static void displayOptions()
        {
            int choice;
            string nameOfFile = Files.returnSavedPlayersAndPieces();
            do
            { 
                do
                {     
                    displayMessage();
                    choice = choiceExtractor();
                }
                while (choice != (int)numberRef.a && choice != (int)numberRef.b);

                if (choice == (int)numberRef.a)
                {
                    Player.choosePlayerAvatarMessage();
                    addPieces();
                    break;
                }
                else if ((File.Exists(nameOfFile) && playersAndPiecesStorage().Count != (int)numberRef.z) && (!Win.hasWon() && choice == (int)numberRef.b))
                {
                    if (playersAndPiecesStorage().Count != (int)numberRef.z)
                    {
                        replacementForGrid(playersAndPiecesStorage());
                        Player.replacementForPlayers(playersAndPiecesStorage());
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (((File.Exists(nameOfFile) && playersAndPiecesStorage().Count != (int)numberRef.z)) && (Win.hasWon() && choice == (int)numberRef.b))
                {
                    replacementForGrid(playersAndPiecesStorage());
                    Player.replacementForPlayers(playersAndPiecesStorage());
                    displayBoard();
                    Console.WriteLine("player {0} has already won this game.", Player.currentPlayer());
                    playersAndPiecesStorage().Clear();
                }
                Console.WriteLine("choose option 1 to play a new game.");
            }
            while (((File.Exists(nameOfFile) || playersAndPiecesStorage().Count == (int)numberRef.z)) && choice == (int)numberRef.b && Win.hasWon());
        }
        public static char configPieces(int number) //method to extract the last letter of selected row in the configuration file
        {
            char filePieces;
            string[] configPieces = Files.configPieceFileExtractor();
            filePieces = configPieces[number].ToCharArray().Last();
            return filePieces;
        }
        private static void horizontalLayout()
        {
            Console.Write(spacingForGrid + spacingForGrid + spacingForGrid);
            for (int i = (int)numberRef.z; i < gridSize; i++)
            {
                Console.Write((i + (int)numberRef.a) + spacingForGrid + spacingForGrid + spacingForGrid);
            }
        }
        private static void horizontalDivider()
        {
            Console.Write("\n{0}", horizontalElipsis);
            for(int i = 0; i < (gridSize * (int)numberRef.d) + (int)numberRef.a; i++)
            {
                Console.Write(horizontalElipsis);
            }
            Console.WriteLine();
        }
        public static void displayBoard()
        {
            char horizontalGridAlphabet = 'a';
            horizontalLayout();
            for (int i = (int)numberRef.z; i < gridSize; i++)
            {
                horizontalDivider();
                Console.Write((horizontalGridAlphabet++) + verticalDivider + spacingForGrid);
                for (int j = (int)numberRef.z; j < gridSize; j++)
                {
                    Console.Write(grid[i, j]);
                    Console.Write(spacingForGrid + verticalDivider + spacingForGrid);
                }
            }
            horizontalDivider();
        }
        private static void addPieces()
        {
            string[] chessPieces = Files.pieceFileExtractor();
            for (int i = (int)numberRef.z; i < gridSize; i++)
            {
                for (int j = (int)numberRef.z; j < gridSize; j++)
                {
                    grid[i, j] = chessPieces[i].ToCharArray()[j];
                }
            }
        }
        public static void invalidMoveMessage()
        {
            Console.WriteLine("invalid move, try again");
        }
        
    }

}
