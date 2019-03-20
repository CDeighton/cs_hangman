using System;
using System.Collections.Generic;
using System.Linq;

class Game {
    public List<char> guesses = new List<char>();
    private int lives = 5;

    public Game(Word word) {
        this.word = word;
    }

    private Word word { get; set; }

    public void MakeGuess(char guess) {
        guesses.Add(guess);

        if (!word.CorrectGuess(guess)) {
            lives--;
        }
    }

    public bool InProgress() {
        return !IsWon() && !IsLost();
    }

    public bool IsWon() {
        return word.IsGuessed(guesses);
    }

    private bool IsLost() {
        return lives <= 0;
    }
}