//Write a program to convert binary numbers to their decimal representation.

using System;
class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Please, enter binary number to convert: ");
        string binaryNumber = Console.ReadLine();
        int decimalNumber = 0;
        const int binaryBase = 2;
        int binaryNumberLength = binaryNumber.Length;
        for (int index = 0; index < binaryNumberLength; index++)
        {
            int element = int.Parse(binaryNumber[index].ToString());
            decimalNumber += element * (int)(Math.Pow(binaryBase, binaryNumberLength - 1 - index));
        }
        Console.WriteLine("{0} (binary) = {1} (decimal)", binaryNumber, decimalNumber);
    }
}

