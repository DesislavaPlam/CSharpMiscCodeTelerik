//Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).
using System;
using System.Text;
class SixteenBitSignetIntegerToBinary
{
    static void Main()
    {
        Console.WriteLine("Please, enter integer number to convert [-32 768, 32 767]: ");
        short inputNumber;
        if (short.TryParse(Console.ReadLine(), out inputNumber))
        {
            if (inputNumber >= 0)
            {
                StringBuilder convertedNumber = new StringBuilder();
                convertedNumber.AppendFormat(DecimalToBinary.ConvertDecimalToBinary(inputNumber).ToString());
                Console.WriteLine("{0} (short) = {1} (binary)", inputNumber, convertedNumber.ToString().PadLeft(16, '0'));
            }
            else if (inputNumber < 0)
            {
                const int shortMaxValue = 32768;
                int numberToConvert = shortMaxValue + inputNumber;
                StringBuilder convertedNumber = new StringBuilder();
                convertedNumber.Append(1);
                convertedNumber.AppendFormat(DecimalToBinary.ConvertDecimalToBinary(numberToConvert).ToString().PadLeft(15, '0'));
                Console.WriteLine();
                Console.WriteLine("{0} (short) = {1} (binary)", inputNumber, convertedNumber);

            }
        }
        else
        {
            Console.WriteLine("Wrong input!");
            Main();
        }
    }
}
