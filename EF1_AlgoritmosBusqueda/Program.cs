using System;

namespace BusquedaAltoRendimiento
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int[] matriculas = new int[10000];
            for (int i = 0; i < matriculas.Length; i++)
            {
                matriculas[i] = i + 1;
            }

            Console.Write("\nIn gresa la matrícula a buscar:    ");
            if (!int.TryParse(Console.ReadLine(), out int objetivo))
            {
                Console.WriteLine("Error");
                return;
            }

            int iterLineal, iterBinaria;

            // +++++++++++++++++ O(n) ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            int idxLineal = BusquedaLineal(matriculas, objetivo, out iterLineal);

            //  **************** O(log n) *******************************************
            int idxBinaria = BusquedaBinaria(matriculas, objetivo, out iterBinaria);

            Console.WriteLine("\n=== REPORTE DE BUSQUEDA ===");
            Console.WriteLine($"Tamaño del arreglo: {matriculas.Length}");
            Console.WriteLine($"Matricula objetivo: {objetivo}");
            // LINEAL BUSQUEDA LINEAL ´ÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑ
            if (idxLineal != -1)
                Console.WriteLine($"[Lineal] Encontrado en Indice: {idxLineal}");
            else
                Console.WriteLine("[Lineal] No encontrado");
            Console.WriteLine($"[Lineal] Iteraciones realizadas: {iterLineal}");

           
           //Binario Log ON ÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑÑ
            if (idxBinaria != -1)
                Console.WriteLine($"[Binaria] Encontrado en Indice: {idxBinaria}");
            else
                Console.WriteLine("[Binaria] No encontrado");
            Console.WriteLine($"[Binaria] Iteraciones realizadas: {iterBinaria}");

            Console.WriteLine("\nObservacion:");
            Console.WriteLine("La busqueda lineal recorre elemento por elemento ");
            Console.WriteLine("La busqueda binaria aprovecha que los datos estan ordenados");
        }

        static int BusquedaLineal(int[] arr, int objetivo, out int iteraciones)
        {
            iteraciones = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                iteraciones++;
                if (arr[i] == objetivo) return i;
            }
            return -1;
        }

        static int BusquedaBinaria(int[] arr, int objetivo, out int iteraciones)
        {
            iteraciones = 0;
            int izquierda = 0;
            int derecha = arr.Length - 1;

            while (izquierda <= derecha)
            {
                iteraciones++;
                int centro = izquierda + (derecha - izquierda) / 2;

                if (arr[centro] == objetivo) return centro;

                if (arr[centro] < objetivo)
                    izquierda = centro + 1;
                else
                    derecha = centro - 1;
            }
            return -1;
        }
    }
}