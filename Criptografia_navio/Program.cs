using System;
using System.Collections.Generic;
// See https://aka.ms/new-console-template for more information
namespace Criptografia_navio
{

class Program
{
    static void Main()
    {

        string message = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        List<string> eightBitStrings = new List<string>(message.Split(" "));
        List<string> newStrings = new List<string>();

        foreach (string s in eightBitStrings)
        {
            
            string firstPart = s[0..4];
            string twoDigits = s[4..6];
            string threeDigits;
            string secondPart;

            if(s[6] == '0')
            {
                threeDigits = twoDigits + '1';
            }
            else
            {
                threeDigits = twoDigits + '0';
            }

            if(s[7] == '0')
            {
                secondPart = threeDigits + '1';
            }
            else
            {
                secondPart = threeDigits + '0';
            }

            newStrings.Add(secondPart + firstPart);

        }

        List<char> asciiCharacters = new List<char>();

        foreach (string bitString in newStrings)
        {
            int asciiValue = Convert.ToInt32(bitString, 2);
            char character = (char)asciiValue;
            asciiCharacters.Add(character);
        }

        string decryptedMessage = new string(asciiCharacters.ToArray());

        Console.WriteLine(decryptedMessage);

    }
    
}
}



