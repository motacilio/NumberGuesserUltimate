public class NumberGuesser
{
    
    int attempts;
    int attemptsLeft;
    int numberToGuess;

    Random random;


    NumberGuesser()
    {
        random = new Random();
        numberToGuess = random.Next(1, 100);
        
        Console.WriteLine("Welcome to the NumberGuesser!");
        int attempts = DifficultySelection();
        int attemptsLeft = attempts;
        
        Console.WriteLine("Im thinking of a number between 1 and 100.");
        
    }

    
    private int DifficultySelection()
    {
        int difficulty = -1;
        int attempts = 0;

        Console.WriteLine("Please select the difficulty level:");
        Console.WriteLine("1. Easy (10 chances)");
        Console.WriteLine("2. Medium (10 chances)");
        Console.WriteLine("3. Hard (3 chances)");

        do
        {
            difficulty = Convert.ToInt32(Console.ReadLine());
            if(difficulty == 1)
            {
                attempts = 10;
            } else if (difficulty == 2)
            {
                attempts = 5;
            } else if(difficulty == 3)
            {
                attempts = 3;
            } else
            {
                Console.WriteLine("Write a valid difficulty");
            }
        } while(difficulty < 1 || difficulty > 3);

        return attempts;

    }

}