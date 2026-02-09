public class NumberGuesser
{
    int attempts;
    int numberToGuess;
    int currentAttempt;

    Random random;

    public NumberGuesser()
    {
        random = new Random();
        numberToGuess = random.Next(1, 100);

        Console.WriteLine("Welcome to the NumberGuesser!");
        Console.WriteLine("Im thinking of a number between 1 and 100.");

        int attempts = DifficultySelection();

        for (int i = 1; i <= attempts; i++)
        {
            Console.WriteLine("Enter your guess: ");
            currentAttempt = Convert.ToInt32(Console.ReadLine());

            if (currentAttempt == numberToGuess)
            {
                Console.WriteLine(
                    "Congratulations! You guessed the correct number in {0} attempts.",
                    i
                );
                break;
            }
            else if (currentAttempt > numberToGuess)
            {
                Console.WriteLine("Incorrect! The number is less than {0}", currentAttempt);
            }
            else
            {
                Console.WriteLine("Incorrect! The number is greater than {0}", currentAttempt);
            }

            if (i == attempts)
            {
                Console.WriteLine("Game Over! \nThe number is {0}", numberToGuess);
            }
        }
    }

    private int DifficultySelection()
    {
        int difficulty = -1;
        int attempts = 0;

        Console.WriteLine("Please select the difficulty level:");
        Console.WriteLine("1. Easy (10 chances)");
        Console.WriteLine("2. Medium (5 chances)");
        Console.WriteLine("3. Hard (3 chances)");

        do
        {
            difficulty = Convert.ToInt32(Console.ReadLine());
            if (difficulty == 1)
            {
                attempts = 10;
            }
            else if (difficulty == 2)
            {
                attempts = 5;
            }
            else if (difficulty == 3)
            {
                attempts = 3;
            }
            else
            {
                Console.WriteLine("Write a valid difficulty");
            }
        } while (difficulty < 1 || difficulty > 3);

        return attempts;
    }
}
