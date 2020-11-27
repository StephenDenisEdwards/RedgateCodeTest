using System.Runtime.CompilerServices;

namespace Redgate.Lib
{
    public static class RedgateMinsweeperSimplifiedFunctions
    {
        public static string DoProcess(string input, string splitString)
        {
            var inputLength = input.Length;
            var splitStringLength = splitString.Length;
            var startIdx = input.IndexOf(splitString) + splitStringLength;
            var segmentLength = input.IndexOf(splitString, startIdx + 1) - startIdx;

            var result = new char[inputLength - startIdx];

            var segmentIdx = 0;

            for (var outIdx = 0; outIdx < inputLength - startIdx; outIdx++)
            {
                if (segmentIdx > segmentLength - 1)
                {
                    for (var j = 0; j < splitStringLength; j++) result[outIdx + j] = splitString[j];
                    outIdx += splitStringLength - 1;
                    segmentIdx = 0;
                    continue;
                }

                segmentIdx++;

                var inIdx = startIdx + outIdx;

                if (input[inIdx] == '*')
                {
                    result[outIdx] = '*';
                    continue;
                }

                int scanOffset = splitStringLength + segmentLength;
                
                var a = inIdx - scanOffset - 1;
                var b = inIdx - scanOffset;
                var c = inIdx - scanOffset + 1;

                var d = inIdx - 1;
                var e = inIdx + 1;

                var f = inIdx + scanOffset - 1;
                var g = inIdx + scanOffset;
                var h = inIdx + scanOffset + 1;

                var countChr = '0';

                if (a > startIdx - 1 && a < inputLength && IsMine(input, a)) countChr++;
                if (b > startIdx - 1 && b < inputLength && IsMine(input, b)) countChr++;
                if (c > startIdx - 1 && c < inputLength && IsMine(input, c)) countChr++;

                if (d < inputLength && IsMine(input, d)) countChr++;
                if (e < inputLength && IsMine(input, e)) countChr++;
                
                if (f < inputLength && IsMine(input, f)) countChr++;
                if (g < inputLength && IsMine(input, g)) countChr++;
                if (h < inputLength && IsMine(input, h)) countChr++;

                result[outIdx] = countChr;
            }
            
            return new string(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsMine(string input, int index)
        {
            //if (index < 0 || index > input.Length - 1)
            //    return false;
            return input[index] == '*';
        }
    }
}