//Write a program to convert binary numbers to hexadecimal numbers (directly).
using System;
using System.Text;
class BinaryToHexadecimal
{
    static void Main()
    {
        Console.WriteLine("Please, enter binary number to convert: ");
        string binaryNumberInput = Console.ReadLine();
        string binaryNumber = string.Empty;
        if (binaryNumberInput.Length % 4 == 1)
        {
            binaryNumber = "000" + binaryNumberInput;
        }
        if (binaryNumberInput.Length % 4 == 2)
        {
            binaryNumber = "00" + binaryNumberInput;
        }
        if (binaryNumberInput.Length % 4 == 3)
        {
            binaryNumber = "0" + binaryNumberInput;
        }
        if (binaryNumberInput.Length % 4 == 0)
        {
            binaryNumber = binaryNumberInput;
        }
        StringBuilder hexadecimalNumber = new StringBuilder(); 

        for (int index = 0; index < binaryNumber.Length - 3; index += 4)
        {
            switch (binaryNumber.Substring(index, 4))
            {
                case "0000":
                    hexadecimalNumber.Append(0);
                    break;
                case "1000":
                    hexadecimalNumber.Append(8);
                    break;
                case "0001":
                    hexadecimalNumber.Append(1);
                    break;
                case "1001":
                    hexadecimalNumber.Append(9);
                    break;
                case "0010":
                    hexadecimalNumber.Append(2);
                    break;
                case "1010":
                    hexadecimalNumber.Append("A");
                    break;
                case "0011":
                    hexadecimalNumber.Append(3);
                    break;
                case "1011":
                    hexadecimalNumber.Append("B");
                    break;
                case "0100":
                    hexadecimalNumber.Append(4);
                    break;
                case "1100":
                    hexadecimalNumber.Append("C");
                    break;
                case "0101":
                    hexadecimalNumber.Append(5);
                    break;
                case "1101":
                    hexadecimalNumber.Append("D");
                    break;
                case "0110":
                    hexadecimalNumber.Append(6);
                    break;
                case "1110":
                    hexadecimalNumber.Append("E");
                    break;
                case "0111":
                    hexadecimalNumber.Append(7);
                    break;
                case "1111":
                    hexadecimalNumber.Append("F");
                    break;
                default:
                    break;
            }
        }
        Console.WriteLine("{0} (binary) = {1} (hexadecimal)", binaryNumberInput, hexadecimalNumber);
    }
}
