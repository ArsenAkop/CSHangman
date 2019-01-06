using System;

namespace HangMan
{
    class Program
    {
        static void Main(string[] args)
        {
            HangmanGame game = new HangmanGame();
            game.play();

            Console.ReadLine();
        }
    }
}
