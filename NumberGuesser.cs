using System.Diagnostics;

public class NumberGuesser
{
    Difficulty difficulty;
    int attempts;
    int numberToGuess;
    int currentAttempt;
    int hintsLeft;
    Stopwatch? stopwatch;
    Random? random;

    SortedSet<int> easyRank = new SortedSet<int>();
    SortedSet<int> mediumRank = new SortedSet<int>();
    SortedSet<int> hardRank = new SortedSet<int>();

    public NumberGuesser()
    {
        string? option;

        do
        {
            Play();
            Console.WriteLine("Press 1 to play again or any key to leave");
            option = Console.ReadLine() ?? string.Empty;
        } while (option.Equals("1"));
    }

    private void Play()
    {
        random = new Random();
        numberToGuess = random.Next(1, 100);

        Console.WriteLine("Welcome to the NumberGuesser!");
        Console.WriteLine("Im thinking of a number between 1 and 100.");

        DifficultySelection();
        hintsLeft = 3;
        int i = 1;

        string option;
        stopwatch = Stopwatch.StartNew();
        while (i <= attempts)
        {
            // for test
            Console.WriteLine($"The number is {numberToGuess}");
            Console.WriteLine(
                "Enter your guess (press 'h/H' for a hint - {0} hints remaining): ",
                hintsLeft
            );
            option = Console.ReadLine() ?? string.Empty;

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
                    stopwatch.Stop();

                    Console.WriteLine(
                        $"Congratulations! You guessed the correct number in {i} attempts."
                    );
                    Console.WriteLine($"Time taken: {stopwatch.Elapsed.TotalSeconds} seconds");

                    AddRank(difficulty, i);

                    PrintRank();

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
                stopwatch.Stop();
                Console.WriteLine("Time taken: {0} seconds", stopwatch.Elapsed.TotalSeconds);
            }
        }
    }

    private void DifficultySelection()
    {
        int option = -1;

        Console.WriteLine("Please select the difficulty level:");
        Console.WriteLine("1. Easy (10 chances)");
        Console.WriteLine("2. Medium (5 chances)");
        Console.WriteLine("3. Hard (3 chances)");

        do
        {
            if (int.TryParse(Console.ReadLine(), out option))
            {
                if (option == 1)
                {
                    attempts = 10;
                    this.difficulty = Difficulty.Easy;
                }
                else if (option == 2)
                {
                    attempts = 5;
                    this.difficulty = Difficulty.Medium;
                }
                else if (option == 3)
                {
                    attempts = 3;
                    this.difficulty = Difficulty.Hard;
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
        } while (option < 1 || option > 3);
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

    private void AddRank(Difficulty difficulty, int attempts)
    {
        switch (difficulty)
        {
            case Difficulty.Easy:
                easyRank.Add(attempts);
                break;
            case Difficulty.Medium:
                mediumRank.Add(attempts);
                break;
            case Difficulty.Hard:
                hardRank.Add(attempts);
                break;
        }
    }

    public void PrintRank()
    {
        Console.WriteLine("Easy Rank");
        foreach (int rank in easyRank)
        {
            Console.WriteLine($"{rank}");
        }
        Console.WriteLine("Medium Rank");
        foreach (int rank in mediumRank)
        {
            Console.WriteLine($"{rank}");
        }
        Console.WriteLine("Hard Rank");
        foreach (int rank in hardRank)
        {
            Console.WriteLine($"{rank}");
        }
    }

    enum Difficulty
    {
        Easy = 1,
        Medium = 2,
        Hard = 3,
    }
}
