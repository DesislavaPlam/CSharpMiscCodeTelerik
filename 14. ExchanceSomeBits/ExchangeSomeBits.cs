//Write a program that exchanges bits {p, p+1, …, p+k-1) with bits {q, q+1, …, q+k-1} 
//of given 32-bit unsigned integer.

using System;

class ExchangeSomeBits
{
    static void Main()
    {
        byte p, q, k;
        uint number;
        Console.WriteLine("Please, enter a number: ");
        bool isNumber = uint.TryParse(Console.ReadLine(), out number);
        Console.WriteLine("Please enter first bit position p:");
        bool isNumberP = byte.TryParse(Console.ReadLine(), out p);
        Console.WriteLine("Please enter first bit position q:");
        bool isNumberQ = byte.TryParse(Console.ReadLine(), out q);
        Console.WriteLine("Please enter count of bits to exchange (k):");
        bool isNumberK = byte.TryParse(Console.ReadLine(), out k);
        bool isValidK = (k + Math.Max(p, q) <= 32);
        bool isValidP = (p >= 0 && p < 32);
        bool isValidQ = (q >= 0 && q < 32);
        bool isValidInput = isNumber && isNumberK && isNumberP && isNumberQ && isValidP && isValidQ && isValidK;
        if (isValidInput)
        {
            Console.WriteLine("The number is:\n{0}", Convert.ToString(number, 2).PadLeft(32, '0'));
            uint mask = (uint)(Math.Pow(2, k) - 1);
            Console.WriteLine("The mask is:\n{0}", Convert.ToString(mask, 2).PadLeft(32, '0'));
            mask = mask << Math.Min(p, q);
            Console.WriteLine("We move the mask to position we need:\n{0}", Convert.ToString(mask, 2).PadLeft(32, '0'));
            uint resultRight = number & mask;
            Console.WriteLine("We take the bits, we're going to move:\n{0}", Convert.ToString(resultRight, 2).PadLeft(32, '0'));
            mask = ~mask;
            Console.WriteLine("~mask\n{0}", Convert.ToString(mask, 2).PadLeft(32, '0'));
            number = number & mask;
            Console.WriteLine("Clear the bits we're going to change:\n{0}", Convert.ToString(number, 2).PadLeft(32, '0'));
            resultRight = resultRight << Math.Abs(p - q);
            Console.WriteLine("Move the right bits to position we need:\n{0}", Convert.ToString(resultRight, 2).PadLeft(32, '0'));
            Console.WriteLine();

            uint maskLeft = (uint)(Math.Pow(2, k) - 1);
            maskLeft = maskLeft << Math.Max(p, q);
            Console.WriteLine("We move the mask to position we need:\n{0}", Convert.ToString(maskLeft, 2).PadLeft(32, '0'));
            uint resultLeft = number & maskLeft;
            Console.WriteLine("We take the bits, we're going to move:\n{0}", Convert.ToString(resultLeft, 2).PadLeft(32, '0'));
            maskLeft = ~maskLeft;
            Console.WriteLine("~mask\n{0}", Convert.ToString(maskLeft, 2).PadLeft(32, '0'));
            number = number & maskLeft;
            Console.WriteLine("Clear the bits we're going to change:\n{0}", Convert.ToString(number, 2).PadLeft(32, '0'));
            resultLeft = resultLeft >> Math.Abs(p - q);
            Console.WriteLine("Move the lrft bits to position we need:\n{0}", Convert.ToString(resultLeft, 2).PadLeft(32, '0'));

            uint result = number | resultLeft | resultRight;
            Console.WriteLine("The new number in binary representatio n:\n{0}", Convert.ToString(result, 2).PadLeft(32, '0'));
            Console.WriteLine("The new number is {0}", result);
        }
        else
        {
            Console.WriteLine("Wrong input!");
        }
    }
}

