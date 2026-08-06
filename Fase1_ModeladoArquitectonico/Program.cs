using System;

namespace DataCoreEngine
{
    public readonly struct RegistroDatos
    {
        public int Id { get; }
        public long HashValidacion { get; }
        public int PesoBytes { get; }

        public RegistroDatos(int id, long hashValidacion, int pesoBytes)
        {
            // Validación obligatoria del contrato
            if (pesoBytes <= 0)
            {
                throw new ArgumentException("El peso en bytes debe ser mayor a cero.", nameof(pesoBytes));
            }

            Id = id;
            HashValidacion = hashValidacion;
            PesoBytes = pesoBytes;
        }

        public override string ToString() => $"[ID: {Id} | Hash: {HashValidacion} | Peso: {PesoBytes} bytes]";
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****** FASE 1 ******");

            int totalRegistros = 40;
            RegistroDatos[] registros = new RegistroDatos[totalRegistros];
            Random rand = new Random();
            try
            {
                for (int i = 0; i < totalRegistros; i++)
                {
                    int idTemp = rand.Next(100, 1000);
                    long hashTemp = rand.NextInt64(100000, 999999);
                    int pesoTemp = rand.Next(10, 5000); 

                    registros[i] = new RegistroDatos(idTemp, hashTemp, pesoTemp);
                }
                Console.WriteLine("\n[++ Exito ++] Se inicializaron los 40 registros correctamente bajo el contrato de integridad");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[Error de contrato]: {ex.Message}");
                return;
            }
            Console.WriteLine("\n+ --- + Estado Inicial + --- +");
            ImprimirMuestra(registros, 5);
            int comparaciones = 0;
            int intercambiosReales = 0;

            int n = registros.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int indiceMinimo = i;
                for (int j = i + 1; j < n; j++)
                {
                    comparaciones++;
                    if (registros[j].Id < registros[indiceMinimo].Id)
                    {
                        indiceMinimo = j;
                    }
                }

                if (indiceMinimo != i)
                {
                    (registros[i], registros[indiceMinimo]) = (registros[indiceMinimo], registros[i]);
                    intercambiosReales++;
                }
            }
            Console.WriteLine("\n+ --- + Estado final ordenado por id + --- +");
            ImprimirMuestra(registros, 5);
            Console.WriteLine("\n+ --- + Metricas del algoritmo + --- +");
            Console.WriteLine($"Total de elementos: {n}");
            Console.WriteLine($"Comparaciones realizadas: {comparaciones}");
            Console.WriteLine($"Intercambios reales : {intercambiosReales}");
        }

        static void ImprimirMuestra(RegistroDatos[] arr, int cantidad)
        {
            for (int i = 0; i < Math.Min(cantidad, arr.Length); i++)
            {
                Console.WriteLine($"Indice {i}: {arr[i]}");
            }
            Console.WriteLine("...");
        }
    }
}