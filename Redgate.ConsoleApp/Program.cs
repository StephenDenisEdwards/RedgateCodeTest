using System;
using Redgate.Lib;

namespace Redgate.ConsoleApp
{
/*
    Mine Sweeper code writing exercise
    A field of N x M squares is represented by N lines of 
    exactly M characters each. The character '*' represents 
    a mine and the character '.' represents no-mine. 

    Example input (a 3 x 4 mine-field of 12 squares, 2 of
    which are mines)

        3 4
        *...
        ..*.
        ....

    Your task is to write a program to accept this input and
    produce as output a hint-field of identical dimensions 
    where each square is a * for a mine or the number of 
    adjacent mine-squares if the square does not contain a mine. 

    Example output (for the above input)

        *211
        12*1
        0111
*/
    class Program
    {
        static void Main(string[] args)
        {
            string splitString = Environment.NewLine;
            string expectedOutput = $"*211{splitString}12*1{splitString}0111";

            Console.WriteLine("Expected Output");
            Console.WriteLine(expectedOutput);
            Console.WriteLine();

            string input = $"3 4{splitString}*...{splitString}..*.{splitString}....";

            Console.WriteLine("Input");
            Console.WriteLine(input);
            Console.WriteLine();

            var result = RedgateMinsweeperFunctions.DoProcess(input, splitString);

            Console.WriteLine("Output");
            Console.WriteLine(result);
            Console.WriteLine();

            Console.WriteLine("Output (Using Extension method)");
            Console.WriteLine(input.MinefieldParse(splitString));
        }
    }
}
