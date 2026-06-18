using System;
using System.Numerics; 

namespace FactorialApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            //+++++++++++++++++++  PARTE A  IMPLMENTACION TRADCIONAL Y EL PUNTO DE QUIEBRE+++++++++++++++++++++++++++
            for (int i = 1; i <= 20; i++)
            {
                Console.WriteLine($"n={i:D2} | Resultado (int): {FactorialInt(i),12}");
            }
            Console.WriteLine("\n[Documentación]: A partir de n=13, el valor excede el límite del 'int' (32 bits), causando desbordamiento.");






            // +++++++++++++++++ PARTE B EL  BIGINTEGRE +++++++++++++++++++
            BigInteger n = 100;
            Console.WriteLine($"Factorial de {n} es:");
            Console.WriteLine(FactorialProfesional(n));
        }
        static int FactorialInt(int n)
        {
            if (n == 0 || n == 1) return 1;
            return n * FactorialInt(n - 1);
        }
        static BigInteger FactorialProfesional(BigInteger n)
        {
            if (n == 0 || n == 1) return BigInteger.One;
            return n * FactorialProfesional(n - 1);
        }
    }
}