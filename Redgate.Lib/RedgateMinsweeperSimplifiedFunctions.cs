using System.Runtime.CompilerServices;

namespace Redgate.Lib
{
    public static class RedgateMinsweeperSimplifiedFunctions
    {
        public static string DoProcess(string input, string splitString)
        {
            var il = input.Length;
            var s = splitString.Length;
            var p = input.IndexOf(splitString) + s;
            var l = input.IndexOf(splitString, p + 1) - p;

            var result = new char[il - p];

            var fc = 0;

            for (var outIdx = 0; outIdx < il - p; outIdx++)
            {
                if (fc > 3)
                {
                    for (var j = 0; j < s; j++) result[outIdx + j] = splitString[j];
                    outIdx += s - 1;
                    fc = 0;
                    continue;
                }

                fc++;

                var inIdx = p + outIdx;

                if (input[inIdx] == '*')
                {
                    result[outIdx] = '*';
                    continue;
                }

                var a = inIdx - s - l - 1;
                var b = inIdx - s - l;
                var c = inIdx - s - l + 1;

                var d = inIdx - 1;
                var e = inIdx + 1;

                var f = inIdx + s + l - 1;
                var g = inIdx + s + l;
                var h = inIdx + s + l + 1;

                var countChr = '0';

                if (a > p - 1 && IsMine(input, a)) countChr++;
                if (b > p - 1 && IsMine(input, b)) countChr++;
                if (c > p - 1 && IsMine(input, c)) countChr++;

                if (IsMine(input, d)) countChr++;
                if (IsMine(input, e)) countChr++;
                
                if (f < il && IsMine(input, f)) countChr++;
                if (g < il && IsMine(input, g)) countChr++;
                if (h < il && IsMine(input, h)) countChr++;

                result[outIdx] = countChr;
            }
            
            return new string(result);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool IsMine(string input, int index)
        {
            if (index < 0 || index > input.Length - 1)
                return false;
            return input[index] == '*';
        }
    }
}