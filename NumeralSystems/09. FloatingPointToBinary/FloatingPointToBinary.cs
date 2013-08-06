//* Write a program that shows the internal binary representation of given 32-bit signed floating-point number
//in IEEE 754 format (the C# type float). 
using System;
using System.Text;
class FloatingPointToBinary
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please, enter 32 bit floating-point number to convert: ");
        string input = Console.ReadLine();
        int integerInput;
        //we have to tell the program what to do, when the input is 0, because otherwise, it does nothing. (actualy it prints empty string)
        if (input == "0")
        {
            Console.WriteLine("0 (binary)");
            return;
        }
        //if the input is integer number, we convert it using DecimalToBinary (task 1)
        if (int.TryParse(input, out integerInput))
        {
            Console.WriteLine("{0} (decimal) = {1} (binary)", integerInput, DecimalToBinary.ConvertDecimalToBinary(integerInput));
            return;
        }
        float inputNumber = float.Parse(input);
        int sign = 0;
        float number;
        //If the number is negative, we make it positive and save the sign
        if (inputNumber < 0)
        {
            number = -inputNumber;
            sign = 1;
        }
        else
        {
            number = inputNumber;
        }
        //now we know the sign, so we can add it to the final result:
        StringBuilder binaryNumber = new StringBuilder();
        binaryNumber.Append(sign);
        binaryNumber.Append(" ");
        //we take the integer of the number
        int integer = (int)number;
        //we take the fraction of the number
        float fraction = number % 1;
        //we use the method from task 1 to convert the integer part to binary 
        StringBuilder binaryInteger = DecimalToBinary.ConvertDecimalToBinary(integer);
        //fraction to binary
        StringBuilder binaryFraction = new StringBuilder();
        while (fraction != 0F)
        {
            float next = fraction * 2;
            if (next >= 1)
            {
                binaryFraction.Append(1);
                fraction = next - 1;
            }
            else
            {
                binaryFraction.Append(0);
                fraction = next;
            }
        }

        StringBuilder fractionBuilder = new StringBuilder();
        int exponent = 127; //the formula for exponent is e = 127 +/- (positions we move the comma durring normalisation)
        //if the length of the binaryInteger is greater than zero, then we move the comma (binaryInteger.Length - 1) times to the right, si the sign is (+)
        if (binaryInteger.Length > 0)
        {
            exponent += binaryInteger.Length - 1;
            //now we know the exponent, so we can add it to the final result
            //but first, we have to convert to binary
            binaryNumber.AppendFormat(DecimalToBinary.ConvertDecimalToBinary(exponent).ToString().PadLeft(8, '0'));
            binaryNumber.Append(" ");
            for (int i = 1; i < binaryInteger.Length; i++)
            {
                fractionBuilder.Append(binaryInteger[i]);
            }
            fractionBuilder.AppendFormat(binaryFraction.ToString());
            //aaand now we know the fraction parth (the mantissa - 1), so we add it..
            binaryNumber.AppendFormat(fractionBuilder.ToString().PadRight(23, '0'));
        }
        //else we move the comma to the left until we find 1 and the sign is (-)
        else if (binaryInteger.Length == 0)
        {
            for (int i = 0; i < binaryFraction.Length; i++)
            {
                if (binaryFraction[i] == '1')
                {
                    exponent -= i + 1; //the counting starts from 0, that's why we add 1
                    //now we know the exponent, so we can add it to the final result
                    //but first, we have to convert to binary
                    binaryNumber.AppendFormat(DecimalToBinary.ConvertDecimalToBinary(exponent).ToString().PadLeft(8, '0'));
                    binaryNumber.Append(" ");
                    //here we calculate the fraction part. When the binaryInteger.Length is zero, we use only the binaryFraction after the first '1'
                    for (int j = i + 1; j < binaryFraction.Length; j++)
                    {
                        fractionBuilder.Append(binaryFraction[j]);
                    }
                    //aaand now we know the fraction parth (the mantissa - 1), so we add it..
                    binaryNumber.AppendFormat(fractionBuilder.ToString().PadRight(23, '0'));
                    break;
                }
            }
        }
        Console.WriteLine("{0} (float) = {1} (binary)", input, binaryNumber);
    }
}

