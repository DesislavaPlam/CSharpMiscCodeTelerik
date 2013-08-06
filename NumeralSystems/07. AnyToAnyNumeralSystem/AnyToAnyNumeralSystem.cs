//Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).
using System;
using System.Text;
class AnyToAnyNumeralSystem
{
    static void Main()
    {
        int firstBase, secondBase;
        do
        {
            Console.WriteLine("Enter base to convert from (not less than 2, not bigger than 16): ");
            firstBase = int.Parse(Console.ReadLine());
        } while (firstBase < 2 || firstBase > 16);
        do
        {
            Console.WriteLine("Enter base to convert to (not less than 2, not bigger than 16): ");
            secondBase = int.Parse(Console.ReadLine());
        } while (secondBase < 2 || secondBase > 16);
        Console.WriteLine("Enter number in base {0} to convert: ", firstBase);
        string numberToConvert = Console.ReadLine();
        
        //First we convert to decimal
        int decimalNumber = 0;
        int numberToConvertLength = numberToConvert.Length;
        for (int index = 0; index < numberToConvertLength; index++)
        {
            int element;
            if (int.TryParse(numberToConvert[index].ToString(), out element))
            {
                decimalNumber += element * (int)(Math.Pow(firstBase, numberToConvertLength - 1 - index));
            }
            else if (numberToConvert[index].ToString().ToUpper() == "A")
            {
                decimalNumber += 10 * (int)(Math.Pow(firstBase, numberToConvertLength - 1 - index));
            }
            else if (numberToConvert[index].ToString().ToUpper() == "B")
            {
                decimalNumber += 11 * (int)(Math.Pow(firstBase, numberToConvertLength - 1 - index));
            }
            else if (numberToConvert[index].ToString().ToUpper() == "C")
            {
                decimalNumber += 12 * (int)(Math.Pow(firstBase, numberToConvertLength - 1 - index));
            }
            else if (numberToConvert[index].ToString().ToUpper() == "D")
            {
                decimalNumber += 13 * (int)(Math.Pow(firstBase, numberToConvertLength - 1 - index));
            }
            else if (numberToConvert[index].ToString().ToUpper() == "E")
            {
                decimalNumber += 14 * (int)(Math.Pow(firstBase, numberToConvertLength - 1 - index));
            }
            else if (numberToConvert[index].ToString().ToUpper() == "F")
            {
                decimalNumber += 15 * (int)(Math.Pow(firstBase, numberToConvertLength - 1 - index));
            }
        }
        Console.WriteLine(decimalNumber);

        //And after that, we convert to secondBase
        StringBuilder secondBaseNumberReversed = new StringBuilder();
        while (decimalNumber != 0)
        {
            int next = decimalNumber % secondBase;
            if (next < 10)
            {
                secondBaseNumberReversed.Append(next);
            }
            else if (next == 10)
            {
                secondBaseNumberReversed.Append("A");
            }
            else if (next == 11)
            {
                secondBaseNumberReversed.Append("B");
            }
            else if (next == 12)
            {
                secondBaseNumberReversed.Append("C");
            }
            else if (next == 13)
            {
                secondBaseNumberReversed.Append("D");
            }
            else if (next == 14)
            {
                secondBaseNumberReversed.Append("E");
            }
            else if (next == 15)
            {
                secondBaseNumberReversed.Append("F");
            }

            decimalNumber /= secondBase;
        }
        //and we print it reversed: 
        Console.Write("{0} ({1}) = ", numberToConvert.ToUpper(), firstBase);
        for (int i = secondBaseNumberReversed.Length - 1; i >= 0; i--)
        {
            Console.Write(secondBaseNumberReversed[i]);
        }
        Console.WriteLine(" ({0})", secondBase);
    }
}

