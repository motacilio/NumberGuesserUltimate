using System;

class Program
{
    static void Main(string[] args)
    {
        string option;

        do
        {
            NumberGuesser ng = new NumberGuesser();
            Console.WriteLine("Press 1 to play again or any key to leave");
            option = Console.ReadLine();
        } while (option.Equals("1"));


        
    }
}
