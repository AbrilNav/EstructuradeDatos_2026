using System;

namespace EF3_InsertionSort
{
    struct Transaccion
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public double Monto { get; set; }
        public Transaccion(int id, string cliente, double monto)
        {
            Id = id;
            Cliente = cliente;
            Monto = monto;
        }
        public override string ToString()
        {
            return $"[ID: {Id:D2} | Cliente: {Cliente,-8} | Monto: ${Monto,7:F2}]";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Transaccion[] bitacora = new Transaccion[]
            {
                new Transaccion(45, "Carlos",  1500.50),
                new Transaccion(12, "Ana",     2300.00),
                new Transaccion(89, "Elizabeth",  450.75),
                new Transaccion(23, "Adrian",   3100.20),
                new Transaccion(05, "Elena",    890.00)
            };

            Console.WriteLine("++++ ESTADO INICIAL DE LA BITACORA  ++++");
            ImprimirArreglo(bitacora);
            Console.WriteLine();

            //*******************************************
            InsertionSort(bitacora);

            Console.WriteLine("\n+++++++ ESTADO FINAL +++++++");
            ImprimirArreglo(bitacora);
        }
        static void InsertionSort(Transaccion[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; i++)
            {
                Transaccion clave = arr[i]; 
                int j = i - 1;

                Console.WriteLine($"\n>> Pasada {i}: Evaluando clave con ID {clave.Id} ({clave.Cliente})");
                while (j >= 0 && arr[j].Id > clave.Id)
                {
                    Console.WriteLine($"   Desplazando ID {arr[j].Id} a la derecha...");
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = clave;
                Console.WriteLine($"   -> Clave ID {clave.Id} insertada en la posición [{j + 1}]");
                Console.Write("   Estado actual: ");
                ImprimirArregloResumido(arr);
            }
        }
        static void ImprimirArreglo(Transaccion[] arr)
        {
            foreach (var t in arr)
            {
                Console.WriteLine($"  {t}");
            }
        }
        static void ImprimirArregloResumido(Transaccion[] arr)
        {
            Console.Write("[ ");
            for (int k = 0; k < arr.Length; k++)
            {
                Console.Write($"{arr[k].Id:D2}" + (k < arr.Length - 1 ? ", " : " "));
            }
            Console.WriteLine("]");
        }
    }
}