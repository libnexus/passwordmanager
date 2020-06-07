/*

 Author: Quentin 'Q' James Thomas
 Email: libnexus.theprogrammer@gmail.com
 
 Project Start Date: 05/06/2020
 Language/s: C#
 License: MIT
 Made In: Visual Studio 2019

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager
{
    class PasswordStrength
    {
        public class CharArrays
        {
            public static char[] Lower = { 'z', 'x', 'c', 'v', 'b', 'n', 'm', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p' };
            public static char[] Upper = { 'Z', 'X', 'C', 'V', 'B', 'N', 'M', 'A', 'S', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'Q', 'W', 'E', 'R', 'T', 'Y', 'U', 'I', 'O', 'P' };
            public static char[] Special = { '¬', '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '_', '+', '¬', '-', '=', '[', ']', '{', '}', ';', '#', ':', '@', '~', ',', '.', '/', '<', '>', '?', '|' };
            public static char[] Number = { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
        }
        public bool Check(string Password)
        {
            bool Result;

            char[] Lower = CharArrays.Lower;
            char[] Upper = CharArrays.Upper;
            char[] Special = CharArrays.Special;
            char[] Number = CharArrays.Number;

            int LowerCase, UpperCase, SpecialChars, Numbers;
            LowerCase = UpperCase = SpecialChars = Numbers = 0;

            for (int i = 0; i < Password.Length; i++)
            {
                for (int y = 0; y < Lower.Length; y++) { if (Password[i] == Lower[y]) { LowerCase += 1; } }
                for (int y = 0; y < Upper.Length; y++) { if (Password[i] == Upper[y]) { UpperCase += 1; } }
                for (int y = 0; y < Special.Length; y++) { if (Password[i] == Special[y]) { SpecialChars += 1; } }
                for (int y = 0; y < Number.Length; y++) { if (Password[i] == Number[y]) { Numbers += 1; } }
            }

            if (LowerCase >= 2 && UpperCase >= 2 && SpecialChars >= 2 && Numbers >= 2 && Password.Length >= 12) { Result = true; } else { Result = false; }

            return Result;
        }

        public string Create(bool LowerCase, bool UpperCase, bool SpecialChars, bool Numbers, int Length)
        {
            string Result = "";

            char[] Possibilties = { };

            Random Random = new Random();

            if (LowerCase) { foreach ( char Symbol in CharArrays.Lower ) { Possibilties = Possibilties.ToString().Insert(-1, Symbol.ToString()).ToCharArray(); } }
            if (UpperCase) { foreach (char Symbol in CharArrays.Upper) { Possibilties = Possibilties.ToString().Insert(-1, Symbol.ToString()).ToCharArray(); } }
            if (SpecialChars) { foreach (char Symbol in CharArrays.Special) { Possibilties = Possibilties.ToString().Insert(-1, Symbol.ToString()).ToCharArray(); } }
            if (Numbers) { foreach (char Symbol in CharArrays.Number) { Possibilties = Possibilties.ToString().Insert(-1, Symbol.ToString()).ToCharArray(); } }

            for (int i = 0; i < Length; i++) { Result += Random.Next(0, Possibilties.Length); }
            if (!(LowerCase && UpperCase && SpecialChars && Numbers) | Length <= 5) { return "<Error> Tag:1:monkaS"; }

            return Result;
        }
    }
}
