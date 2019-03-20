using System.Collections.Generic;

public interface IHangmanUI {
    void ShowMaskedWord(string word, List<char> guesses);
    void ShowGuesses(List<char> guesses);
    void ShowGameWon();
    void ShowGameLost(string word);
    char RequestGuess();
}