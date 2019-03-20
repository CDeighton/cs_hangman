using System;
using System.Text;
using System.IO;

namespace cs_hangman {
    class Program {
        static void Main(string[] args) {
            string[] words = File.ReadAllLines(@"dictionary.txt", Encoding.UTF8);
            Random random = new Random();

            Word word = new Word(words[random.Next(words.Length)]);
            Game game = new Game(word);

            while (game.InProgress()) {
                Console.WriteLine(word.Mask(game.guesses));
                Console.WriteLine(String.Join(", ", game.guesses));

                game.MakeGuess(RequestGuess());
            }

            if (game.IsWon()) {
                Console.WriteLine("You won");
            }
            else {
                Console.WriteLine("The word was {0}. Loser.", word.ToString());
            }
        }

        public static char RequestGuess() {
            string guess;

            do {
                Console.WriteLine("Make a guess (one character only): ");
                guess = Console.ReadLine();
            } while(guess.Length != 1);

            return guess[0];
        }
    }
}
