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

        DisplayEndGame();
    }

    private void DisplayMaskedWord() {
        // TODO mask word
        Console.WriteLine(word);
    }

    private void DisplayGuesses() {
        Console.WriteLine(String.Join(", ", guesses));
    }

    private void DisplayEndGame() {
        if (IsWon()) Console.WriteLine("You won");
        else Console.WriteLine("Loser");
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
        return word.All((c) => guesses.IndexOf(c) != -1);
    }

    private bool IsLost() {
        return lives <= 0;
    }

    private bool IsCorrect(char guess) {
        return word.Contains(guess);
    }
}