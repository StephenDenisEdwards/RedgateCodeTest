using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Redgate.Lib.Tests
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

    [TestClass]
    public class RedgateMinsweeperFunctionsTests
    {
        [TestMethod]
        public void RedgateMinsweeperFunctions_DoProcess_Success()
        {
            // Arrange
            string splitString = Environment.NewLine;
            string expectedOutput = $"*211{splitString}12*1{splitString}0111";
            string input = $"3 4{splitString}*...{splitString}..*.{splitString}....";

            // Act
            string result = RedgateMinsweeperFunctions.DoProcess(input, splitString);

            // Assert
            Assert.AreEqual(expectedOutput, result);
        }

        [TestMethod]
        [ExpectedException(
            typeof(ArgumentOutOfRangeException), 
            "Inconsistent line lengths. This could be due to an invalid seperator string.")] // Assert
        public void RedgateMinsweeperFunctions_DoProcess_Inconsistent_Line_Lengths_Failure()
        {
            // Arrange
            string extraniousCharacters = "XX";
            string splitString = Environment.NewLine;
            string input = $"3 4{splitString}*...{splitString}.{extraniousCharacters}.*.{splitString}....";

            // Act
            string result = RedgateMinsweeperFunctions.DoProcess(input, splitString);
        }

    }
}