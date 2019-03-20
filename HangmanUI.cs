using System;
using System.Linq;
using System.Collections.Generic;

class HangmanUI : IHangmanUI {
    void IHangmanUI.ShowMaskedWord(string word, List<char> guesses) {
        string masked_word = String.Join("", word.Select((c) => guesses.Contains(c) ? c : '_'));

        Console.WriteLine(masked_word);
    }

    void IHangmanUI.ShowGuesses(List<char> guesses) {
        Console.WriteLine(String.Join(", ", guesses));
    }

    void IHangmanUI.ShowGameWon() {
        Console.WriteLine("You won");
    }

    void IHangmanUI.ShowGameLost(string word) {
        Console.WriteLine("The word was {0}. Loser.", word);
    }

    char IHangmanUI.RequestGuess() {
        string guess;

        do {
            Console.WriteLine("Make a guess (one character only): ");
            guess = Console.ReadLine();
        } while(guess.Length != 1);

        return guess[0];
    }
}