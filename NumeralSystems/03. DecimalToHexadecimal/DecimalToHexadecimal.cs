//Write a program to convert decimal numbers to their hexadecimal representation
using System;
using System.Text;
class DecimalToHexadecimal
{
    static void Main()
    {
        Console.WriteLine("Please, enter decimal number to convert: ");
        int decimalNumber = int.Parse(Console.ReadLine());
        StringBuilder hexadecimalNumberReversed = new StringBuilder();
        Console.Write("{0} (decimal) = ", decimalNumber);
        while (decimalNumber != 0)
        {
            int next = decimalNumber % 16;
            if (next < 10)
            {
                hexadecimalNumberReversed.Append(next);
            }
            else if (next == 10)
            {
                hexadecimalNumberReversed.Append("A");
            }
            else if (next == 11)
            {
                hexadecimalNumberReversed.Append("B");
            }
            else if (next == 12)
            {
                hexadecimalNumberReversed.Append("C");
            }
            else if (next == 13)
            {
                hexadecimalNumberReversed.Append("D");
            }
            else if (next == 14)
            {
                hexadecimalNumberReversed.Append("E");
            }
            else if (next == 15)
            {
                hexadecimalNumberReversed.Append("F");
            }

            decimalNumber /= 16;
        }
        for (int i = hexadecimalNumberReversed.Length - 1; i >= 0; i--)
        {
            Console.Write(hexadecimalNumberReversed[i]);
        }
        Console.WriteLine(" (hexadecimal)");
    }
}


