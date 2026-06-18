using System;

namespace RecursividadClase7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nEJERCICIO A");
            ImprimirCuentaRegresiva(3, 1);
            Console.WriteLine("\nEJERCICIO B");
            EjecutarSumatoria();
        }




        //+++++++++ +EJERCICIO A: CUENTA REGRESIVA DE MEMORIA +++++++
        static void ImprimirCuentaRegresiva(int numero, int profundidad)
        {
          
            if (numero < 1)
            {
                Console.WriteLine($"[Nivel {profundidad}] -> CASO BASE ALCANZADO");
                return;
            }
            Console.WriteLine($"[Nivel {profundidad}] APILANDO: numero={numero}");
            ImprimirCuentaRegresiva(numero - 1, profundidad + 1);
            Console.WriteLine($"[Nivel {profundidad}] LIBERANDO: numero={numero}");
        }





        // +++++++ EJERICICO B: SUMATORIA RECURSIVA CON VALIDACION PROFESIONAL +++++++++++++
        static void EjecutarSumatoria()
        {
            Console.Write("Introduce un nmero positivo para sumar: ");
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int numero) && numero > 0)
            {
                int resultado = SumarHasta(numero);
                Console.WriteLine($"La suma de 1 hasta {numero} es: {resultado}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Solo se aceptan enteros positivos.");
                Console.ResetColor();
            }
        }
        static int SumarHasta(int n)
        {
            if (n == 1) return 1;
            return n + SumarHasta(n - 1);
        }
    }
}