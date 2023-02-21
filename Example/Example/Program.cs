

namespace NumberGuessingGame
{
    class Program
    {
        static void Main()
        {
            var random = new Random();

            // Define the play game function using lambda notation
            Action playGame = null;
            playGame = () =>
            {
                int randomNumber = random.Next(1, 101);

                // Initialize variables for user's guess and number of attempts
                int guess = 0;
                int attempts = 0;

                Console.WriteLine("I'm thinking of a number between 1 and 100. Can you guess it?");
                Console.WriteLine("To end the game at any time, enter 'quit'.");

                while (guess != randomNumber)
                {
                    // Prompt user to input their guess
                    Console.Write("Enter your guess: ");
                    string? input = Console.ReadLine();

                    // Check if user wants to end the game
                    if (input == "quit")
                    {
                        Console.WriteLine("Ending the game. Thanks for playing!");
                        return;
                    }

                    // Validate user's input
                    if (!int.TryParse(input, out guess))
                    {
                        Console.WriteLine("Invalid input. Please enter a whole number between 1 and 100.");
                        continue;
                    }
                    else if (guess < 1 || guess > 100)
                    {
                        Console.WriteLine("Invalid input. Please enter a whole number between 1 and 100.");
                        continue;
                    }

                    // Increment number of attempts
                    attempts++;

                    // Check if user's guess is correct, too high, or too low
                    if (guess == randomNumber)
                    {
                        Console.WriteLine($"Congratulations! You guessed the number in {attempts} attempts.");

                        // Ask if user wants to play again
                        Console.Write("Play again? (y/n): ");
                        string? playAgainInput = Console.ReadLine();

                        if (playAgainInput == "y")
                        {
                            playGame(); // Call the play game function again
                        }
                        else
                        {
                            Console.WriteLine("Ending the game. Thanks for playing!");
                            return;
                        }
                    }
                    else if (guess < randomNumber)
                    {
                        Console.WriteLine("Too low. Try again.");
                    }
                    else
                    {
                        Console.WriteLine("Too high. Try again.");
                    }
                }
            };

            // Call the play game function to start the game
            playGame();
        }
    }
}

