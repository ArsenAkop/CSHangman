using System;
using System.Linq;

namespace HangMan
{
    public class HangmanGame
    {

        private bool _keepPlaying; //control variable while game is in session
        private int _guessesLeft; //control variable holding number of guesses left
        private string _answer; //variable holding the the answer 
        private int _lettersFound; //variable holding number of letters found within answer

        private string[] _guessedLetters; //string array that holds all of the guessed letters
        private int _guessedLettersIndex; //pointer for guessedLetters array

        private string[] _wordDisplay; //variable for empty (blank) dislay of the answer
        public void play()
        {

            SetUp(); //set up boundaries for new game

            while(_keepPlaying)
            {
                DisplayPuzzle();
                Console.ReadLine();
                PromptUser();
            }

            DisplayResult();
        }

        //input function for letter or word
        private void PromptUser()
        {
            bool validInput = false;
            while(!validInput)
            {
                Console.Write("Guess a letter or the whole word:  ");
                validInput = ParseInput(Console.ReadLine().ToUpper());
            }

            Console.WriteLine("\nPress enter to continue...");
            Console.ReadLine();
        }

        //function to check the validity of the input
        private bool ParseInput(string input)
        {
            if (input.Length > 1)
            {
                if(input == _answer)
                {
                    _keepPlaying = false;
                    return true;
                }
                Console.WriteLine("Wrong Anwer!");
                _guessesLeft--;
            }
            else
            {

                //if the user inputs the same guessed letter twice or more times
                if(_guessedLetters.Contains(input))
                {
                    Console.WriteLine("You already guessed {0}", input);
                    return false;
                }

                bool foundLetterAtLeastOnce = false;
                for (int i = 0; i < _answer.Length; i++)
                {
                    if(input == _answer[i].ToString())
                    {
                        foundLetterAtLeastOnce = true;
                        _lettersFound++;
                        _wordDisplay[i] = input;

                    }
                }
                if (foundLetterAtLeastOnce)
                {
                    Console.WriteLine("That was a good guess!");
                    if(_lettersFound == _answer.Length)
                    {
                        _keepPlaying = false;
                    }

                }

                else
                {
                    Console.WriteLine("No, that letter was not found!");
                    _guessesLeft--;
                }

                _guessedLetters[_guessedLettersIndex] = input;
                _guessedLettersIndex++;

                if(_guessesLeft == 0 )
                {
                    _keepPlaying = false;
                }
            }

            return true;
        }

        private void DisplayResult()
        {
            if(_guessesLeft > 0)
            {
              Console.WriteLine("You guessed the word!");
            }
            else
            {
                Console.WriteLine("You lose! The word was: {0}", _answer);
            }
        }

        private void DisplayPuzzle()
        {
            Console.WriteLine("\nPuzzle:  ");
            for (int i = 0; i < _wordDisplay.Length; i++)
            {
                // write as many underscores as characters in the answer
                Console.Write("{0} ", _wordDisplay[i]);
            }
            Console.WriteLine("\nYou have {0} guesses left.\n", _guessesLeft);
        }

        private void SetUp() //sets up boundaries for new game
        {
            _guessesLeft = 5;
            _keepPlaying = true;
            _guessedLetters = new string[26];
            _guessedLettersIndex = 0;
            GetWordFromPlayer();
            CreateWordDisplay();
        }

        
        {
            _wordDisplay = new string[_answer.Length];
            for (int i = 0; i < _wordDisplay.Length; i++)
            {
                _wordDisplay[i] = "_";
            }

        }

        private void GetWordFromPlayer() //user input for the 'answer'
        {
            Console.Write("Enter the word to guess (have the other person look away!): ");
            _answer = Console.ReadLine().ToUpper();
            Console.Clear();
        }
    }

}