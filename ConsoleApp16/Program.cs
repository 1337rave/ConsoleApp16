using System;
using System.Collections.Generic;

namespace ArrayOperations
{
    class Program
    {
        // Делегат для функцій, які приймають масив цілих чисел і повертають масив цілих чисел
        delegate int[] IntArrayOperation(int[] array);

        static void Main(string[] args)
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            // Метод для отримання усіх парних чисел у масиві
            IntArrayOperation getEvenNumbers = delegate (int[] arr)
            {
                List<int> evenNumbers = new List<int>();
                foreach (int num in arr)
                {
                    if (num % 2 == 0)
                    {
                        evenNumbers.Add(num);
                    }
                }
                return evenNumbers.ToArray();
            };

            // Метод для отримання усіх непарних чисел у масиві
            IntArrayOperation getOddNumbers = delegate (int[] arr)
            {
                List<int> oddNumbers = new List<int>();
                foreach (int num in arr)
                {
                    if (num % 2 != 0)
                    {
                        oddNumbers.Add(num);
                    }
                }
                return oddNumbers.ToArray();
            };

            // Метод для перевірки простого числа
            bool IsPrime(int number)
            {
                if (number <= 1) return false;
                if (number == 2) return true;
                if (number % 2 == 0) return false;
                int boundary = (int)Math.Floor(Math.Sqrt(number));
                for (int i = 3; i <= boundary; i += 2)
                {
                    if (number % i == 0) return false;
                }
                return true;
            }

            // Метод для отримання усіх простих чисел у масиві
            IntArrayOperation getPrimeNumbers = delegate (int[] arr)
            {
                List<int> primeNumbers = new List<int>();
                foreach (int num in arr)
                {
                    if (IsPrime(num))
                    {
                        primeNumbers.Add(num);
                    }
                }
                return primeNumbers.ToArray();
            };

            // Метод для отримання усіх чисел Фібоначчі в масиві
            IntArrayOperation getFibonacciNumbers = delegate (int[] arr)
            {
                List<int> fibonacciNumbers = new List<int>();
                foreach (int num in arr)
                {
                    if (IsFibonacci(num))
                    {
                        fibonacciNumbers.Add(num);
                    }
                }
                return fibonacciNumbers.ToArray();
            };

            Console.WriteLine("Even Numbers:");
            PrintArray(getEvenNumbers(numbers));

            Console.WriteLine("Odd Numbers:");
            PrintArray(getOddNumbers(numbers));

            Console.WriteLine("Prime Numbers:");
            PrintArray(getPrimeNumbers(numbers));

            Console.WriteLine("Fibonacci Numbers:");
            PrintArray(getFibonacciNumbers(numbers));
        }

        static void PrintArray(int[] arr)
        {
            foreach (int num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }

        static bool IsFibonacci(int number)
        {
            return IsPerfectSquare(5 * number * number + 4) || IsPerfectSquare(5 * number * number - 4);
        }

        static bool IsPerfectSquare(int number)
        {
            int sqrt = (int)Math.Sqrt(number);
            return sqrt * sqrt == number;
        }
    }
}
