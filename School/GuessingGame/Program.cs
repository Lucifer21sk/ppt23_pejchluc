class Program
{
    static readonly Random Random = new();
    static void Main()
    {
        Console.WriteLine("Welcome to the Number Guessing Game!");
        while (true)
        {
            Console.WriteLine("I'm thinking of number between 1 and 100. Can you guess it?");
            int randomNumber = Random.Next(1,101);
            while(true)
            {
                Console.Write("Enter your guess(type 'quit' to end the game): ");
                string? input = Console.ReadLine()?.Trim();

                if (input?.Equals("quit", StringComparison.OrdinalIgnoreCase) == true)
                {
                    Console.WriteLine("Ending the game...Thanks for playing!");
                    return;
                }
                if (!int.TryParse(input, out int guess) || guess < 1 || guess > 100)
                {
                    Console.WriteLine("Invalid inout. Please enter a whole number between 1 and 100.");
                    continue;
                }
                if (guess == randomNumber)
                {
                    Console.WriteLine($"Congratulations! You guessed the number {randomNumber}.");
                    break;
                }

                Console.WriteLine(guess < randomNumber ? "Too low. Try again." : "Too high. Try again");

            }

            Console.Write("Do you want to play again? (y/n): ");
            string? playAgainInput = Console.ReadLine()?.Trim().ToLower();
            
            if (playAgainInput == "n" || playAgainInput == "no")
            {
                Console.WriteLine("Thanks for playing. Bye");
                return;
            }
        }
    }
}