using System;
using System.Runtime.CompilerServices;

namespace Redgate.Lib
{
    public static class RedgateMinsweeperSimplifiedFunctions
    {
        public static string DoProcess(string input, string splitString)
        {
            const char mineCharacter = '*';
            var splitStringLength = splitString.Length;
            var startIndex = input.IndexOf(splitString, StringComparison.Ordinal) + splitStringLength;
            var segmentLength = input.IndexOf(splitString, startIndex + 1, StringComparison.Ordinal) - startIndex;

            var result = new char[input.Length - startIndex];

            var segmentIndex = 0;

            for (var outputIndex = 0; outputIndex < input.Length - startIndex; outputIndex++)
            {
                if (segmentIndex > segmentLength - 1)
                {
                    for (var j = 0; j < splitStringLength; j++) result[outputIndex + j] = splitString[j];
                    outputIndex += splitStringLength - 1;
                    segmentIndex = 0;
                    continue;
                }

                segmentIndex++;

                var inIdx = startIndex + outputIndex;

                if (input[inIdx] == mineCharacter)
                {
                    result[outputIndex] = mineCharacter;
                    continue;
                }

                int scanOffset = splitStringLength + segmentLength;
                
                var countChr = '0';

                IsMine(mineCharacter, startIndex, input, inIdx - scanOffset - 1, ref countChr);
                IsMine(mineCharacter, startIndex, input, inIdx - scanOffset, ref countChr);
                IsMine(mineCharacter, startIndex, input, inIdx - scanOffset + 1, ref countChr);

                IsMine(mineCharacter, startIndex, input, inIdx - 1, ref countChr);
                IsMine(mineCharacter, startIndex, input, inIdx + 1, ref countChr);
                
                IsMine(mineCharacter, startIndex, input, inIdx + scanOffset - 1, ref countChr);
                IsMine(mineCharacter, startIndex, input, inIdx + scanOffset, ref countChr);
                IsMine(mineCharacter, startIndex, input, inIdx + scanOffset + 1, ref countChr);

                result[outputIndex] = countChr;
            }
            
            return new string(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void IsMine(char mineCharacter, int startIndex, string input, int index, ref char counterChr)
        {
            if (index > startIndex - 1 && index < input.Length && input[index] == '*')
                counterChr++;
        }
    }
}