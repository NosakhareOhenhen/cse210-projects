using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        bool playAgain = true;
        
        while (playAgain)
        {
            int magicNumber = randomGenerator.Next(1, 101);
            int guess = -1;
            int guessCount = 0;
            
            Console.WriteLine("I've picked a magic number between 1 and 100!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (magicNumber > guess)
                {
                    Console.WriteLine("Higher");
                }
                else if (magicNumber < guess)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} tries!");
                }
            }

            Console.Write("Would you like to play again? (yes/no) ");
            string response = Console.ReadLine().ToLower();
            playAgain = (response == "yes");
        }
    }
}