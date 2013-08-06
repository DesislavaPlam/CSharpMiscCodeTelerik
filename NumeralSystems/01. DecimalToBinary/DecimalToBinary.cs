//Write a program to convert decimal numbers to their binary representation. 
using System;
using System.Text;
public class DecimalToBinary
{
    public static void Main()
    {
        Console.WriteLine("Please, enter decimal number to convert: ");
        long decimalNumber = long.Parse(Console.ReadLine());
        Console.WriteLine("{0} (decimal) = {1} (binary)", decimalNumber, ConvertDecimalToBinary(decimalNumber).ToString().PadLeft(32, '0'));
    }
    // I make method, so I can use it in 08. SixteenBitSignetIntegerToBinary
    public static StringBuilder ConvertDecimalToBinary(long decimalNumber)
    {
        StringBuilder binaryNumberReversed = new StringBuilder();
        while (decimalNumber != 0)
        {
            long next = decimalNumber % 2;
            binaryNumberReversed.Append(next);
            decimalNumber /= 2;
        }
        StringBuilder binaryNumber = new StringBuilder();
        for (int i = binaryNumberReversed.Length - 1; i >= 0; i--)
        {
            binaryNumber.Append(binaryNumberReversed[i]);
        }
        return binaryNumber;
    }
}

