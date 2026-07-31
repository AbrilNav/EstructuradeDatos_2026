using System;

namespace EF2_BubbleSort
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                //++++++++++++++ MODULO 1: INICIALIZACION ALEATORIA ++++++++++++++++++++++++++++++++++++++++
                int[] calificaciones = new int[100];
                Random rng = new Random();

                for (int i = 0; i < calificaciones.Length; i++)
                {
                    calificaciones[i] = rng.Next(0, 101); // 0 a 100 inclusive
                }

                Console.WriteLine("\n=== Estado inicial: calificaciones desordenadas ===");
                ImprimirArreglo(calificaciones);

                
                OrdenarPorBurbuja(calificaciones);

                Console.WriteLine("\n=== Estado final: calificaciones ordenadas (menor a mayor) ===");
                ImprimirArreglo(calificaciones);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"\n[ERROR] Índice fuera de rango detectado: {ex.Message}");
                Console.WriteLine("Revisa los límites de tus ciclos for anidados.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n[ERROR inesperado]: {ex.Message}");
            }
        }
        static void ImprimirArreglo(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static void OrdenarPorBurbuja(int[] arr)
        {
            int n = arr.Length;
            int contadorIntercambios = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        contadorIntercambios++;
                    }
                }
            }

            Console.WriteLine($"\nTotal de intercambios realizados: {contadorIntercambios}");
        }
    }
}