using System;

namespace GestionMemoria
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeroOriginal = 5;
            int[] arregloOriginal = { 1, 2, 3 };
            Console.WriteLine($"Variable entera (numeroOriginal): {numeroOriginal}");
            Console.WriteLine($"Primer elemento del arreglo (arregloOriginal[0]): {arregloOriginal[0]}");
            
            CambiarValor(numeroOriginal);
            CambiarReferencia(arregloOriginal);
            Console.WriteLine($"Variable entera (numeroOriginal): {numeroOriginal}");
            Console.WriteLine($"Primer elemento del arreglo (arregloOriginal[0]): {arregloOriginal[0]}");
        }
        static void CambiarValor(int x)
        {
            x = 100;
        }
        static void CambiarReferencia(int[] arr)
        {
            if (arr.Length > 0)
            {
                arr[0] = 100;
            }
        }
    }
}
