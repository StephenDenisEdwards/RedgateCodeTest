using System;

namespace Redgate.Lib
{
    public static class RedgateMinsweeperFunctions
    {
        public static string MinefieldParse(this string input, string splitString)
        {
            return DoProcess(input, splitString);
        }

        public static string DoProcess(string input, string splitString)
        {
            var secondLineStartIndex = input.IndexOf(splitString) + splitString.Length;
            var stringWithoutFirstLine = input.Substring(secondLineStartIndex);
            var minefield = ConvertToMultiDimensionalArray(stringWithoutFirstLine, splitString);
            var resultArray = DoProcess(minefield);
            var stringResult = ConvertMultiDimensionalArrayToString(resultArray, splitString);
            return stringResult;
        }

        private static string ConvertMultiDimensionalArrayToString(char[,] inputArray, string lineSplitString)
        {
            var stringResult = string.Empty;

            var maxX = inputArray.GetLength(0);
            var maxY = inputArray.GetLength(1);

            for (var x = 0; x < maxX; x += 1)
            {
                for (var y = 0; y < maxY; y += 1) stringResult = string.Concat(stringResult, inputArray[x, y]);
                stringResult = string.Concat(stringResult, x != maxX - 1 ? lineSplitString : string.Empty);
            }

            return stringResult;
        }

        private static char[,] ConvertToMultiDimensionalArray(string inputString, string splitString)
        {
            var lines = inputString.Split(splitString);

            var lineLength = lines[0].Length;

            var md = new char[lines.Length, lineLength];

            for (var lineIndex = 0; lineIndex < lines.Length; lineIndex++)
            {
                if (lines[lineIndex].Length != lineLength)
                    throw new ArgumentOutOfRangeException(
                        "Inconsistent line lengths. This could be due to an invalid seperator string.",
                        nameof(inputString));

                for (var character = 0; character < lineLength; character++)
                    md[lineIndex, character] = lines[lineIndex][character];
            }

            return md;
        }

        private static char[,] DoProcess(char[,] minefield)
        {
            var xMax = minefield.GetLength(0);
            var yMax = minefield.GetLength(1);

            var result = new char[xMax, yMax];

            for (var x = 0; x < xMax; x++)
            for (var y = 0; y < yMax; y++)
                if (minefield[x, y] == '*')
                {
                    result[x, y] = '*';
                }
                else
                {
                    var count = '0';

                    if (IsMine(minefield, x - 1, y - 1)) count++;
                    if (IsMine(minefield, x - 1, y)) count++;
                    if (IsMine(minefield, x - +1, y + 1)) count++;

                    if (IsMine(minefield, x, y - 1)) count++;
                    if (IsMine(minefield, x, y + 1)) count++;

                    if (IsMine(minefield, x + 1, y - 1)) count++;
                    if (IsMine(minefield, x + 1, y)) count++;
                    if (IsMine(minefield, x + 1, y + 1)) count++;

                    result[x, y] = count;
                }

            return result;
        }

        private static bool IsMine(char[,] minefield, int x, int y)
        {
            var xMax = minefield.GetLength(0) - 1;
            var yMax = minefield.GetLength(1) - 1;

            if (x < 0 || x > xMax || y < 0 || y > yMax) return false;

            var cell = minefield[x, y];
            return cell == '*';
        }
    }
}