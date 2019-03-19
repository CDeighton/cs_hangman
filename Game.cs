using System;
using System.Collections.Generic;
using System.Linq;

class Game {
    private List<char> guesses = new List<char>();
    private int lives = 5;
    private string word;

    public Game(string word) {
        this.word = word;

        Run();
    }

    private void Run() {
        while (!IsOver()) {
            DisplayMaskedWord();
            DisplayGuesses();

            char guess = RequestGuess();
            guesses.Add(guess);

            if (!IsCorrect(guess)) lives--;
        }

        if (IsWon()) DisplayWin();
        else DisplayLoss();
    }

    private void DisplayMaskedWord() {
        Console.WriteLine(MaskedWord());
    }

    private void DisplayGuesses() {
        Console.WriteLine(String.Join(", ", guesses));
    }

    private void DisplayWin() {
        Console.WriteLine("You won");
    }

    private void DisplayLoss() {
        Console.WriteLine("The word was {0}. Loser.", word);
    }

    private string MaskedWord() {
        return String.Join("", word.Select((c) => IsGuessed(c) ? c : '_'));
    }

    private char RequestGuess() {
        string guess;

        do {
            Console.WriteLine("Make a guess (one character only): ");
            guess = Console.ReadLine();
        } while(guess.Length != 1);

        return guess[0];
    }

    private bool IsOver() {
        return IsWon() || IsLost();
    }

    private bool IsWon() {
        return word.All((c) => IsGuessed(c));
    }

    private bool IsLost() {
        return lives <= 0;
    }

    private bool IsCorrect(char guess) {
        return word.Contains(guess);
    }

    private bool IsGuessed(char c) {
        return guesses.IndexOf(c) != -1;
    }
}