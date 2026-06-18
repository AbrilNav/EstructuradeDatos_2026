using System;

namespace GestionMemoria
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Valores iniciales
            int numeroOriginal = 5;
            int[] arregloOriginal = { 1, 2, 3 };

            // Imprimir valores ANTES de llamar a las funciones
            Console.WriteLine("=== ANTES DE LAS FUNCIONES ===");
            Console.WriteLine($"Variable entera (numeroOriginal): {numeroOriginal}");
            Console.WriteLine($"Primer elemento del arreglo (arregloOriginal[0]): {arregloOriginal[0]}");
            Console.WriteLine("---------------------------------------------\n");

            // 2. Llamada a las funciones
            CambiarValor(numeroOriginal);
            CambiarReferencia(arregloOriginal);

            // Imprimir valores DESPUÉS de llamar a las funciones
            Console.WriteLine("=== DESPUÉS DE LAS FUNCIONES ===");
            Console.WriteLine($"Variable entera (numeroOriginal): {numeroOriginal}");
            Console.WriteLine($"Primer elemento del arreglo (arregloOriginal[0]): {arregloOriginal[0]}");
            Console.WriteLine("---------------------------------------------");
        }

        // 1. Intenta cambiar el valor de un entero a 100 (Tipo por Valor -> Vive en el Stack)
        static void CambiarValor(int x)
        {
            x = 100;
        }

        // 2. Intenta cambiar el primer elemento de un arreglo a 100 (Tipo por Referencia -> Vive en el Heap)
        static void CambiarReferencia(int[] arr)
        {
            if (arr.Length > 0)
            {
                arr[0] = 100;
            }
        }
    }
}