//Write a program to convert hexadecimal numbers to their decimal representation.
using System;
class HexadecimalToDecimal
{
    static void Main()
    {
        Console.WriteLine("Please, enter hexadecimal number to convert: ");
        string hexadecimalNumber = Console.ReadLine();
        int decimalNumber = 0;
        const int hexadecimalBase = 16;
        int hexadecimalNumberLength = hexadecimalNumber.Length;
        for (int index = 0; index < hexadecimalNumberLength; index++)
        {
            int element;
            if (int.TryParse(hexadecimalNumber[index].ToString(), out element))
            {
                decimalNumber += element * (int)(Math.Pow(hexadecimalBase, hexadecimalNumberLength - 1 - index));
            }
            else if (hexadecimalNumber[index].ToString().ToUpper() == "A")
            {
                decimalNumber += 10 * (int)(Math.Pow(hexadecimalBase, hexadecimalNumberLength - 1 - index));
            }
            else if (hexadecimalNumber[index].ToString().ToUpper() == "B")
            {
                decimalNumber += 11 * (int)(Math.Pow(hexadecimalBase, hexadecimalNumberLength - 1 - index));
            }
            else if (hexadecimalNumber[index].ToString().ToUpper() == "C")
            {
                decimalNumber += 12 * (int)(Math.Pow(hexadecimalBase, hexadecimalNumberLength - 1 - index));
            }
            else if (hexadecimalNumber[index].ToString().ToUpper() == "D")
            {
                decimalNumber += 13 * (int)(Math.Pow(hexadecimalBase, hexadecimalNumberLength - 1 - index));
            }
            else if (hexadecimalNumber[index].ToString().ToUpper() == "E")
            {
                decimalNumber += 14 * (int)(Math.Pow(hexadecimalBase, hexadecimalNumberLength - 1 - index));
            }
            else if (hexadecimalNumber[index].ToString().ToUpper() == "F")
            {
                decimalNumber += 15 * (int)(Math.Pow(hexadecimalBase, hexadecimalNumberLength - 1 - index));
            }
        }
        Console.WriteLine("{0} (hexadecimal) = {1} (decimal)", hexadecimalNumber, decimalNumber);
    }
}

