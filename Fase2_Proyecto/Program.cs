using System.Diagnostics;

namespace ProyectoFase2QuickSort
{
    public struct RegistroDatos
    {
        public int id;
        public string HashValidacion;
        public double PesoBytes;

        public RegistroDatos(int id, string hash, double peso)
        {
            this.id = id;
            HashValidacion = hash;
            PesoBytes = peso;
        }
    }

    class Program
    {
        private static long contadorComparaciones = 0;
        private static long contadorIntercambios = 0;
        private static long contadorLlamadasRecursivas = 0;

        static void Main(string[] args)
        {
            Console.WriteLine(" + + + FASE 2 + + + + ");

            int n = 10000; 
            RegistroDatos[] datosOriginales = GenerarDatosAleatorios(n, 42);
            RegistroDatos[] datosSeleccion = (RegistroDatos[])datosOriginales.Clone();
            
            Console.WriteLine($"[1] Ejecutando Selección Directa O(n^2) con {n} registros...");
            Stopwatch sw = Stopwatch.StartNew();
            long opsSeleccion = EjecutarSeleccionDirecta(datosSeleccion);
            sw.Stop();
            long tiempoSeleccionMs = sw.ElapsedMilliseconds;
            
            Console.WriteLine($" -> Tiempo: {tiempoSeleccionMs} ms | Operaciones estimadas: {opsSeleccion}\n");

            RegistroDatos[] datosQuickSort = (RegistroDatos[])datosOriginales.Clone();
            Console.WriteLine($"[2] Ejecutando QuickSort O(n log n) con {n} registros...");
            
            ReiniciarContadores();
            sw.Restart();
            QuickSort(datosQuickSort, 0, datosQuickSort.Length - 1);
            sw.Stop();
            long tiempoQuickSortMs = sw.ElapsedMilliseconds;

            Console.WriteLine($" -> Tiempo: {tiempoQuickSortMs} ms");
            Console.WriteLine($" -> Llamadas recursivas: {contadorLlamadasRecursivas}");
            Console.WriteLine($" -> Comparaciones: {contadorComparaciones}");
            Console.WriteLine($" -> Intercambios: {contadorIntercambios}\n");

            Console.WriteLine($"Seleccion Directa: {tiempoSeleccionMs} ms");
            Console.WriteLine($"QuickSort:         {tiempoQuickSortMs} ms");
            
            if (tiempoQuickSortMs > 0)
            {
                double mejora = (double)tiempoSeleccionMs / tiempoQuickSortMs;
                Console.WriteLine($"Factor de mejora:  QuickSort fue ~{mejora:F1}x más rápido.");
            }
            else
            {
                Console.WriteLine("Factor de mejora:  QuickSort se ejecutó en 0 ms (demasiado rápido para medir).");
            }
        }

        private static RegistroDatos[] GenerarDatosAleatorios(int cantidad, int semilla)
        {
            Random rnd = new Random(semilla);
            RegistroDatos[] arreglo = new RegistroDatos[cantidad];
            for (int i = 0; i < cantidad; i++)
            {
                int idAleatorio = rnd.Next(1, 100000);
                arreglo[i] = new RegistroDatos(idAleatorio, $"hash_{i:D5}", rnd.NextDouble() * 1024);
            }
            return arreglo;
        }

        private static long EjecutarSeleccionDirecta(RegistroDatos[] arr)
        {
            long operaciones = 0;
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    operaciones++;
                    if (arr[j].id < arr[minIndex].id)
                    {
                        minIndex = j;
                    }
                }
                if (minIndex != i)
                {
                    RegistroDatos temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                    operaciones += 3;
                }
            }
            return operaciones;
        }

        public static void QuickSort(RegistroDatos[] arr, int bajo, int alto)
        {
            contadorLlamadasRecursivas++;
            if (bajo < alto)
            {
                int indicePivote = Particionar(arr, bajo, alto);
                QuickSort(arr, bajo, indicePivote - 1);
                QuickSort(arr, indicePivote + 1, alto);
            }
        }

        private static int Particionar(RegistroDatos[] arr, int bajo, int alto)
        {
            RegistroDatos pivote = arr[alto]; 
            int i = bajo - 1;

            for (int j = bajo; j < alto; j++)
            {
                contadorComparaciones++;
                if (arr[j].id <= pivote.id)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                    contadorIntercambios++;
                }
            }
            (arr[i + 1], arr[alto]) = (arr[alto], arr[i + 1]);
            contadorIntercambios++;
            return i + 1;
        }

        private static void ReiniciarContadores()
        {
            contadorComparaciones = 0;
            contadorIntercambios = 0;
            contadorLlamadasRecursivas = 0;
        }
    }
}