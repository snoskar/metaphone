using System;
using System.Collections.Generic;
using System.Text;

namespace Metaphone
{
    public static class Metaphone
    {
        public static string Encode(string input)
        {
            var result = new StringBuilder();
            input = input.ToUpper();

            for (int position = 0; position < input.Length; position++)
            {
                var ProcessedCharacter = ProcessCharacter(input, position);

                if (!string.IsNullOrEmpty(ProcessedCharacter))
                    result.Append(ProcessedCharacter);
            }

            return result.ToString();
        }

        private static string ProcessCharacter(string input, int position)
        {
            var character = input[position];
            var result = string.Empty;

            switch (character)
            {
                case 'A':
                case 'E':
                case 'I':
                case 'O':
                case 'U':
                    result = position == 0 ? character.ToString() : string.Empty;
                    break;
                case 'B':
                    result = ProcessB(input, position);
                    break;
                case 'C':
                    result = ProcessC(input, position);
                    break;
                case 'D':
                    result = ProcessD(input, position);
                    break;
                case 'F':
                    result = "F";
                    break;
                case 'G':
                    result = ProcessG(input, position);
                    break;
                case 'H':
                    result = ProcessH(input, position);
                    break;
                case 'J':
                    result = "J";
                    break;
                case 'K':
                    result = ProcessK(input, position);
                    break;
                case 'L':
                    result = "L";
                    break;
                case 'M':
                    result = "M";
                    break;
                case 'N':
                    result = "N";
                    break;
                case 'P':
                    result = ProcessP(input, position);
                    break;
                case 'Q':
                    result = "K";
                    break;
                case 'R':
                    result = "R";
                    break;
                case 'S':
                    result = ProcessS(input, position);
                    break;
                case 'T':
                    result = ProcessT(input, position);
                    break;
                case 'V':
                    result = "F";
                    break;
                case 'W':
                    result = ProcessW(input, position);
                    break;
                case 'X':
                    result = "KS";
                    break;
                case 'Y':
                    result = ProcessY(input, position);
                    break;
                case 'Z':
                    result = "S";
                    break;
            }

            return result;
        }

        private static string ProcessB(string input, int position)
        {
            // unless at the end of a word after "m" as in "dumb"
            if (position == input.Length - 1 && Match(input, position - 1, "M"))
                return string.Empty;

            return "B";
        }

        private static string ProcessC(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessD(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessG(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessH(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessK(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessP(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessS(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessT(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessW(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static string ProcessY(string input, int position)
        {
            throw new NotImplementedException();
        }

        private static bool Match(string input, int position, string value)
        {
            if (position < 0 || position > input.Length)
                return false;

            return string.Compare(input, position, value, 0, value.Length) == 0;
        }
    }
}
