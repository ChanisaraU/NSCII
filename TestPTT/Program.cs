using System;
using System.Text;

class Program
{
    static void Main()
    {

        string input = "9..0A..Zz..a"; // ตัวอย่างข้อมูลที่รับเข้า
        string result = ConvertToNSCII(input);

        string natnupheCode = "9AA70957FDE5AC24D3F5C61776A0605362D3ACF0E33805D5309154E95195FEA13D5AC5D089B2A3265E292F374567EACFB8F3BE20929271801A1AE7B22221DD6BAFEFE2E98FA2EF7A5832516A09B55C4121482";
        string decodedText = DecodeNatnuphe(natnupheCode);
        Console.WriteLine(decodedText);
    }

    static string DecodeNatnuphe(string natnupheCode)
    {
        StringBuilder decodedText = new StringBuilder();

        for (int i = 0; i < natnupheCode.Length; i += 2)
        {
            if (i + 1 < natnupheCode.Length)
            {
                string hexPair = natnupheCode.Substring(i, 2);
                int decimalValue = Convert.ToInt32(hexPair, 16);

                char decodedChar = (char)((decimalValue - 97) % 27 + 97);

                decodedText.Append(decodedChar);
            }
        }

        return decodedText.ToString();
    }

    static string ConvertToNSCII(string input)
    {
        char[] characters = input.ToCharArray();
        for (int i = 0; i < characters.Length; i++)
        {
            char c = characters[i];

            if (char.IsDigit(c) || (char.IsUpper(c) && char.IsLetter(c)))
            {
                int asciiValue = (int)c;

                if (char.IsDigit(c))
                {
                    asciiValue -= 1;
                }
                else if (char.IsUpper(c) && char.IsLetter(c))
                {
                    asciiValue += 1;
                }

                characters[i] = (char)asciiValue;
            }
        }

        return new string(characters);
    }
}
