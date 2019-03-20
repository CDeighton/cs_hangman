using System;
using System.Collections.Generic;
using System.Linq;

class Game {
    public List<char> guesses = new List<char>();
    private int lives = 5;

    public Game(string word) {
        Word = word;
    }

    private string Word { get; set; }

    public void MakeGuess(char guess) {
        guesses.Add(guess);

        if (!CorrectGuess(guess)) {
            lives--;
        }
    }

    public bool InProgress() {
        return !IsWon() && !IsLost();
    }

    public bool IsWon() {
        return Word.All((c) => guesses.Contains(c));
    }

    private bool IsLost() {
        return lives <= 0;
    }

    public bool CorrectGuess(char c) {
        return Word.Contains(c);
    }
}