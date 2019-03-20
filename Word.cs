using System;
using System.Collections.Generic;
using System.Linq;

class Word {
    public Word(string value) {
        Value = value;
    }

    public string Value { get; set; }

    public bool IsGuessed(List<char> guesses) {
        return Value.All((c) => guesses.Contains(c));
    }

    public bool CorrectGuess(char c) {
        return Value.Contains(c);
    }

    public string Mask(List<char> guesses) {
        return String.Join("", Value.Select((c) => guesses.Contains(c) ? c : '_'));
    }

    public override string ToString() { return Value; }
}