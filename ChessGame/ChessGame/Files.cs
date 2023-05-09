using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace ChessGame
{
    internal class Files
    {
        private static string pieceFile = "pieceFile.txt";
        private static string configFileForPieces = "configFileForPieces.txt";
        private static string savedPlayersAndPieces = "savedPlayersAndPieces.bin";
        private static string numberOfTriesFile = "numberOfTries.bin";
        private static char[,] Lines = new char[Board.returnGridSize(), Board.returnGridSize()];


        private static void rowOneFirstFive(char[,] nameOf2DArray) //method to populate the first-five elements of the first row
        {
            for (int i = (int)numberRef.z; i < (int)numberRef.a; i++)
            {
                for (int j = (int)numberRef.z; j < (int)numberRef.e; j++)
                {
                    nameOf2DArray[i, j] = Board.configPieces(j);
                }
            }
        }
        private static void rowOneLastThree(char[,] nameOf2DArray) //method to poulate the last-three elements of the first row
        {
            nameOf2DArray[(int)numberRef.z, (int)numberRef.e] = Board.configPieces((int)numberRef.b);
            nameOf2DArray[(int)numberRef.z, (int)numberRef.f] = Board.configPieces((int)numberRef.a);
            nameOf2DArray[(int)numberRef.z, (int)numberRef.g] = Board.configPieces((int)numberRef.z);
        }
        private static void rowOne(char[,] nameOf2DArray)
        {
            rowOneFirstFive(nameOf2DArray);
            rowOneLastThree(nameOf2DArray);
        }
        private static void rowTwo(char[,] nameOf2DArray) //method to populate row two
        {
            for (int i = (int)numberRef.a; i < (int)numberRef.b; i++)
            {
                for (int j = (int)numberRef.z; j < Board.returnGridSize(); j++)
                {
                    nameOf2DArray[i, j] = ChessPieceDifferentiator.lowerPawn();
                }
            }
        }
        private static void rowThreeToSix(char[,] nameOf2DArray) //method to poulate rows three to six
        {
            for (int i = (int)numberRef.b; i < (int)numberRef.f; i++)
            {
                for (int j = (int)numberRef.z; j < Board.returnGridSize(); j++)
                {
                    nameOf2DArray[i, j] = Board.returnSpacing();
                }
            }
        }
        private static void rowSeven(char[,] nameOf2DArray)
        {
            for (int i = (int)numberRef.f; i < (int)numberRef.g; i++)
            {
                for (int j = (int)numberRef.z; j < Board.returnGridSize(); j++)
                {
                    nameOf2DArray[i, j] = ChessPieceDifferentiator.upperPawn();
                }
            }
        }
        private static void rowEightFirstFive(char[,] nameOf2DArray)
        {
            for (int i = (int)numberRef.g; i < Board.returnGridSize(); i++)
            {
                for (int j = (int)numberRef.z; j < (int)numberRef.e; j++)
                {
                    nameOf2DArray[i, j] = Board.configPieces(j + (int)numberRef.g);
                }
            }
        }
        private static void rowEightLastThree(char[,] nameOf2DArray)
        {
            nameOf2DArray[(int)numberRef.g, (int)numberRef.e] = Board.configPieces((int)numberRef.h + (int)numberRef.a);
            nameOf2DArray[(int)numberRef.g, (int)numberRef.f] = Board.configPieces((int)numberRef.h);
            nameOf2DArray[(int)numberRef.g, (int)numberRef.g] = Board.configPieces((int)numberRef.g);
        }
        private static void rowEight(char[,] nameOf2DArray)
        {
            rowEightFirstFive(nameOf2DArray);
            rowEightLastThree(nameOf2DArray);
        }
        private static void rowsAndColumns()
        {
            rowOne(Lines);
            rowTwo(Lines);
            rowThreeToSix(Lines);
            rowSeven(Lines);
            rowEight(Lines);
        }
        public static void constructFile() //method to construct piece file from the configuration file
        {
            rowsAndColumns();
            StreamWriter name = new StreamWriter(pieceFile);

            for (int i = (int)numberRef.z; i < Board.returnGridSize(); i++)
            {
                for (int j = (int)numberRef.z; j < Board.returnGridSize(); j++)
                {
                    name.Write(Lines[i, j]);
                }
                name.WriteLine();
            }
            name.Close();
        }
        public static string[] pieceFileExtractor() //method that extracts the information from the file created by the constructFile() method
        {
            string[] chessPieces;
            chessPieces = File.ReadAllLines(pieceFile);
            return chessPieces;
        }

        private static void doesFileExist(string nameOfFile)
        {
            while (!File.Exists(nameOfFile))
            {
                Console.WriteLine("Add the configuration file into the debug folder and rerun the program");
                Console.ReadLine();
            }
        }
        private static void isFileEmpty(string configFile)
        {
            string [] pieceInFile = File.ReadAllLines(configFile);
            while (pieceInFile.Count() == 0)
            {
                Console.WriteLine("Add the contents of the configuration file in the debug folder and rerun the program");
                Console.ReadLine();
            }
        }
        public static string[] configPieceFileExtractor()
        {
            try
            {
                string[] configPieces;
                configPieces = File.ReadAllLines(configFileForPieces);
                isFileEmpty(configFileForPieces);
                return configPieces;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                doesFileExist(configFileForPieces);
                return null;
            }
        }
        public static void savePiecesAndPlayers()
        {
            Dictionary<char[,], List<char>> piecesAndPlayers = new Dictionary<char[,], List<char>>();
            piecesAndPlayers.Add(Board.returnGrid(), Player.returnPlayerAvatar());
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file1 = File.Create(savedPlayersAndPieces);
            bf.Serialize(file1, piecesAndPlayers);
            file1.Close();
        }
        public static Dictionary<char[,], List<char>> loadPiecesAndPlayers()
        {
            Dictionary<char[,], List<char>> piecesAndPlayers = new Dictionary<char[,], List<char>>();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file2;
            if (File.Exists(savedPlayersAndPieces))
            {
                file2 = File.OpenRead(savedPlayersAndPieces);
                if (file2.Length == (int)numberRef.z)
                {
                    Console.WriteLine("\"{0}\" file is empty", savedPlayersAndPieces);
                }
                else
                {
                    piecesAndPlayers = (Dictionary<char[,], List<char>>)bf.Deserialize(file2);
                }
                file2.Close();
            }
            else
            {
                Console.WriteLine("\"{0}\" file doesn't exist", savedPlayersAndPieces);
            }
            return piecesAndPlayers;
        }
        public static string returnSavedPlayersAndPieces()
        {
            return savedPlayersAndPieces;
        }
        public static void saveNumberOfTries(int tries)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(numberOfTriesFile);
            bf.Serialize(file, tries);
            file.Close();
        }
        public static int loadNumberOfTries()
        {
            int number;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file;
            if (File.Exists(numberOfTriesFile))
            {
                file = File.OpenRead(numberOfTriesFile);
                if (file.Length == (int)numberRef.z)
                {
                    number = (int)numberRef.z;
                }
                else
                {
                    number = (int)bf.Deserialize(file);
                }
                file.Close();
            }
            else
            {
                number = (int)numberRef.z;
            }

            return number;
        }
    }
}
