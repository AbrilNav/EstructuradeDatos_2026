using System;

namespace RecursividadApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Ingresa un numero para calcular su factorial: ");
                int num = int.Parse(Console.ReadLine()!);

                if (num < 0) throw new ArgumentException("El numero debe ser positivo.");

                Console.WriteLine($"Factorial de {num} es: {CalcularFactorial(num)}");
                Console.WriteLine($"Fibonacci en la posición {num} es: {GenerarFibonacci(num)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        // FACTORIAL 
        static long CalcularFactorial(int n)
        {
            // Caso base: el factorial de 0 o 1 es 1
            if (n <= 1) return 1;
            // Caso recursivo: n * factorial(n-1)
            return n * CalcularFactorial(n - 1);
        }

        // FIBONACCI
        static long GenerarFibonacci(int n)
        {
            // Caso base
            if (n <= 1) return n;
            // Caso recursivo
            return GenerarFibonacci(n - 1) + GenerarFibonacci(n - 2);
        }
    }
}