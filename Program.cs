using System;
using System.Text;
using System.IO;

namespace cs_hangman {
    class Program {
        static void Main(string[] args) {
            string[] words = File.ReadAllLines(@"dictionary.txt", Encoding.UTF8);
            Random random = new Random();

            string word = words[random.Next(words.Length)];
            IHangmanUI ui = new HangmanUI();
            Game game = new Game(word);

            while (game.InProgress()) {
                ui.ShowMaskedWord(word, game.guesses);
                ui.ShowGuesses(game.guesses);

                game.MakeGuess(ui.RequestGuess());
            }

            if (game.IsWon()) {
                ui.ShowGameWon();
            }
            else {
                ui.ShowGameLost(word);
            }
        }
    }
}
