using System;
using System.Text;
using System.IO;

namespace cs_hangman {
    class Program {
        static void Main(string[] args) {
            string[] words = File.ReadAllLines(@"dictionary.txt", Encoding.UTF8);
            Random random = new Random();

            string word = words[random.Next(words.Length)];

            new Game(word);
        }
    }
}
