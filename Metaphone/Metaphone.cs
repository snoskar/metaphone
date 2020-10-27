using System;
using System.Collections.Generic;
using System.Text;

namespace Metaphone
{
    public static class Metaphone
    {
        private static readonly string[] _vowels = { "A", "E", "I", "O", "U" };

        public static string Encode(string input)
        {
            var result = new StringBuilder();
            
            input = input.ToUpper();
            input = ProcessInitialExceptions(input);

            for (int position = 0; position < input.Length; position++)
            {
                var processedCharacter = ProcessCharacter(input, position);

                if (!string.IsNullOrEmpty(processedCharacter))
                    result.Append(processedCharacter);
            }

            return result.ToString();
        }

        private static string ProcessInitialExceptions(string input)
        {
            // Initial kn-, gn-, pn-, ac- or wr- drop first letter
            if (Match(input, 0, new[] { "KN", "GN", "PN", "AC", "WR" }))
                input = input.Substring(1);

            // Initial x- change to "s"
            if (Match(input, 0, "X"))
                input = "S" + input.Substring(1);

            // Initial wh- change to "w"
            if (Match(input, 0, "WH"))
                input = "W" + input.Substring(2);

            return input;
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
                    result = ProcessVowel(character, position);
                    break;
                case 'B':
                    result = ProcessCharacterB(input, position);
                    break;
                case 'C':
                    result = ProcessCharacterC(input, position);
                    break;
                case 'D':
                    result = ProcessCharacterD(input, position);
                    break;
                case 'F':
                    result = "F";
                    break;
                case 'G':
                    result = ProcessCharacterG(input, position);
                    break;
                case 'H':
                    result = ProcessCharacterH(input, position);
                    break;
                case 'J':
                    result = "J";
                    break;
                case 'K':
                    result = ProcessCharacterK(input, position);
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
                    result = ProcessCharacterP(input, position);
                    break;
                case 'Q':
                    result = "K";
                    break;
                case 'R':
                    result = "R";
                    break;
                case 'S':
                    result = ProcessCharacterS(input, position);
                    break;
                case 'T':
                    result = ProcessCharacterT(input, position);
                    break;
                case 'V':
                    result = "F";
                    break;
                case 'W':
                    result = ProcessCharacterW(input, position);
                    break;
                case 'X':
                    result = "KS";
                    break;
                case 'Y':
                    result = ProcessCharacterY(input, position);
                    break;
                case 'Z':
                    result = "S";
                    break;
            }

            return result;
        }

        private static string ProcessVowel(char character, int position)
        {
            // Vowels are kept only when they are the first letter.
            if (position == 0)
                return character.ToString();

            return string.Empty;
        }

        private static string ProcessCharacterB(string input, int position)
        {
            // unless at the end of a word after "m" as in "dumb"
            if (position == input.Length - 1 && Match(input, position - 1, "M"))
                return string.Empty;

            return "B";
        }

        private static string ProcessCharacterC(string input, int position)
        {
            // (sh) if -cia- or -ch
            if (Match(input, position, new[] { "CIA", "CH" }))
                return "X";

            // if -ci-, -ce- or -cy
            if (Match(input, position, new[] { "CI", "CE", "CY" }))
                return "S";

            return "K";
        }

        private static string ProcessCharacterD(string input, int position)
        {
            // if in -dge-, -dgy- or -dgi
            if (Match(input, position, new[] { "DGE", "DGY", "DGI" }))
                return "J";

            return "T";
        }

        private static string ProcessCharacterG(string input, int position)
        {
            // in -gh- and not at end or before a vowel
            if (Match(input, position, "GH") && (position < input.Length - 2) || Match(input, position + 1, _vowels))
                return string.Empty;

            // in -gn- or -gned-
            if (Match(input, position, "GN") || Match(input, position, "GNED"))
                return string.Empty;

            //if before i or e or y if not double gg
            if (Match(input, position, new[] { "GI", "GE", "GY" }) && (Match(input, position - 1, "GG") || Match(input, position, "GG")))
                return "J";

            return "K";
        }

        private static string ProcessCharacterH(string input, int position)
        {
            // if after vowel and no vowel follows
            if (Match(input, position - 1, _vowels) && Match(input, position + 1, _vowels))
                return string.Empty;

            return "H";
        }

        private static string ProcessCharacterK(string input, int position)
        {
            // if after "c"
            if (Match(input, position - 1, "CK"))
                return string.Empty;

            return "K";
        }

        private static string ProcessCharacterP(string input, int position)
        {
            // if in -ph
            if (Match(input, position, "PH"))
                return "F";

            return "P";
        }

        private static string ProcessCharacterS(string input, int position)
        {
            // if before "h" or in -sio- or -sia
            if (Match(input, position, new[] { "SH", "SIO", "SIA" }))
                return "X";

            return "S";
        }

        private static string ProcessCharacterT(string input, int position)
        {
            // if -tia- or -tio
            if (Match(input, position, new[] { "TIO", "TIA" }))
                return "X";

            // if before "h"
            if (Match(input, position, "TH"))
                return "0";

            // if in -tch-
            if (Match(input, position, "TCH"))
                return string.Empty;

            return "T";
        }

        private static string ProcessCharacterW(string input, int position)
        {
            // if followed by a vowel
            if (Match(input, position + 1, _vowels))
                return "W";

            return string.Empty;
        }

        private static string ProcessCharacterY(string input, int position)
        {
            // if followed by a vowel
            if (Match(input, position + 1, _vowels))
                return "Y";

            return string.Empty;
        }


        private static bool Match(string input, int position, string value)
        {
            return Match(input, position, new[] { value });
        }

        private static bool Match(string input, int position, string[] values)
        {
            if (position < 0 || position > input.Length)
                return false;

            foreach (var value in values)
            {
                if (string.Compare(input, position, value, 0, value.Length) == 0)
                    return true;
            }

            return false;
        }
    }
}
