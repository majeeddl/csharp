using System;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            byte number = 2;

            int count = 10;

            float totalPrice = 20.25f;

            char character = 'H';

            string firstName = "Majeed";

            bool isWorking = true;

            
            Console.WriteLine(number);

            Console.WriteLine(firstName);

            Console.WriteLine(isWorking);

            Console.WriteLine("{0} , {1}" ,byte.MinValue , byte.MaxValue);

            Console.WriteLine("{0} {1}",float.MinValue , float.MaxValue);

        }
    }
}
