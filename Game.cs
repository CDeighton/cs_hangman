using System;
using System.Collections.Generic;

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
            guesses.Add(RequestGuess());

            lives--;
        }
    }

    private char RequestGuess() {
        Console.WriteLine("Make a guess: ");

        return Console.ReadLine()[0];
    }

    private bool IsOver() {
        return IsWon() || IsLost();
    }

    private bool IsWon() {
        return false;
    }

    private bool IsLost() {
        return lives <= 0;
    }
}