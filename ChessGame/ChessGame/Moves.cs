using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGame
{
    internal class Moves
    {
        private static List<int> moves = new List<int>();
        private static char piece;
        private static int finalVerticalAxis;
        private static int finalHorizontalAxis;
        private static int initialVerticalAxis;
        private static int initialHorizontalAxis;
        private static List<char> alphabets = new List<char>();
        private static char firstLetter = 'a';
        private static char lastLetter = 'h';


        private static void alphabetsPopulator()
        {
            for(char i = firstLetter; i <= lastLetter; i++)
            {
                alphabets.Add(i);
            }
        }
        private static void dictionaryPopulator(Dictionary<char, int> map)  //method that populates the reference dictionary that matches the horizontal characters on the grid with their respective integer values.
        {
            map.Add(alphabets[(int)numberRef.z], (int)numberRef.a);
            map.Add(alphabets[(int)numberRef.a], (int)numberRef.b);
            map.Add(alphabets[(int)numberRef.b], (int)numberRef.c);
            map.Add(alphabets[(int)numberRef.c], (int)numberRef.d);
            map.Add(alphabets[(int)numberRef.d], (int)numberRef.e);
            map.Add(alphabets[(int)numberRef.e], (int)numberRef.f);
            map.Add(alphabets[(int)numberRef.f], (int)numberRef.g);
            map.Add(alphabets[(int)numberRef.g], (int)numberRef.h);
        }
        private static int horizontalValue() //method that converts the letter chosen on the horizontal axis of the board to a number
        {
            alphabetsPopulator();
            Dictionary<char, int> horizontalAxisReferenceContainer = new Dictionary<char, int>();
            dictionaryPopulator(horizontalAxisReferenceContainer);
            alphabets.Clear();
            char chosenHorizontalAxisLetter;
            bool charTester;
            do
            {
                Console.Write("horizontal: ");
                charTester = char.TryParse(Console.ReadLine().ToLower(), out chosenHorizontalAxisLetter);
            }
            while (!horizontalAxisReferenceContainer.ContainsKey(chosenHorizontalAxisLetter) || charTester == false);
            return horizontalAxisReferenceContainer[chosenHorizontalAxisLetter];
        }
        private static int extractor() //method to collect the user's choice of number on the vertical axis of the board
        {
            int number = (int)numberRef.z;
            do
            {
                Console.Write("vertical: "); 
                int.TryParse(Console.ReadLine(), out number);
            }
            while (number == (int)numberRef.z || number > Board.returnGridSize());
            return number;
        }
        private static void moveToMessage()
        {
            Console.WriteLine("which player position do you want to move player from? ");
        }
        private static void moveFromMessage()
        {
            Console.WriteLine("which player position do you want to move player from? ");
        }
        public static void moveCollector()
        {
            moveFromMessage();
            initialHorizontalAxis = horizontalValue();
            initialHorizontalAxis--;
            initialVerticalAxis = extractor();
            initialVerticalAxis--;
            moveToMessage();
            finalHorizontalAxis = horizontalValue();
            finalHorizontalAxis--;
            finalVerticalAxis = extractor();
            finalVerticalAxis--;

            moves.Add(initialHorizontalAxis);
            moves.Add(initialVerticalAxis);
            moves.Add(finalHorizontalAxis);
            moves.Add(finalVerticalAxis);
        }
        public static List<int> returnMoves()
        {
            return moves;
        }
        public static void movePlayer()
        {
            Board.returnGrid()[moves[(int)numberRef.b], moves.Last()] = Board.returnGrid()[moves.First(), moves[(int)numberRef.a]];
            Board.returnGrid()[moves.First(), moves[(int)numberRef.a]] = Board.returnSpacing();
            moves.Clear();
        }
        public static char movedPiece()
        {
            piece = Board.returnGrid()[moves.First(), moves[(int)numberRef.a]];
            return piece;
        }
    }
}
