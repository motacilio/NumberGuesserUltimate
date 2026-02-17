public class NumberGuesser
{
    int attempts;
    int numberToGuess;
    int currentAttempt;
    int hintsLeft;

    Random random;

    public NumberGuesser()
    {
        Play();
    }

    private void Play()
    {
        random = new Random();
        numberToGuess = random.Next(1, 100);

        Console.WriteLine("Welcome to the NumberGuesser!");
        Console.WriteLine("Im thinking of a number between 1 and 100.");

        attempts = DifficultySelection();
        hintsLeft = 3;
        int i = 1;
        string option;
        while (i <= attempts)
        {
            Console.WriteLine("Enter your guess (press 'h/H' for a hint - {0} hints remaining): ", hintsLeft);
            option = Console.ReadLine();

            if (option.Equals("h", StringComparison.OrdinalIgnoreCase))
            {
                if (hintsLeft > 0)
                {
                    Hint(numberToGuess);
                    hintsLeft--;
                    continue;
                }
                else
                {
                    Console.WriteLine("No more hints remaining!");
                }
            }
            else if (int.TryParse(option, out currentAttempt))
            {
                if (currentAttempt == numberToGuess)
                {
                    Console.WriteLine(
                        "Congratulations! You guessed the correct number in {0} attempts.",
                        i
                    );
                    break;
                }
                else if (currentAttempt > 100 || currentAttempt < 0)
                {
                    Console.WriteLine("Digite um número entre 0 e 100");
                }
                else if (currentAttempt > numberToGuess)
                {
                    Console.WriteLine("Incorrect! The number is less than {0}", currentAttempt);
                }
                else
                {
                    Console.WriteLine("Incorrect! The number is greater than {0}", currentAttempt);
                }
                i++;
            }
            else
            {
                Console.WriteLine("Digite um opção válida.");
                continue;
            }

            if (i > attempts)
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
            if (int.TryParse(Console.ReadLine(), out difficulty))
            {
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
            }
            else
            {
                Console.WriteLine("Write a valid difficulty");
            }
        } while (difficulty < 1 || difficulty > 3);

        return attempts;
    }

    private void Hint(int numberToGuess)
    {
        Random rdn = new Random();
        int option = rdn.Next(0, 2);
        int number;

        if (option == 0)
        {
            Console.WriteLine(
                "The number is between {0} and {1}",
                numberToGuess - rdn.Next(1, 15),
                numberToGuess + rdn.Next(1, 15)
            );
        }
        else if (option == 1)
        {
            number = rdn.Next(0, 100);
            if (number == numberToGuess)
            {
                number++;
            }
            Console.WriteLine("The number is NOT {0}", number);
        }
        else if (option == 2)
        {
            number = rdn.Next(0, 100);
            if (numberToGuess > number)
            {
                Console.WriteLine("The number is less than {0}", number);
            }
            else
            {
                Console.WriteLine("The number is greater than {0}", number);
            }
        }
    }
}
