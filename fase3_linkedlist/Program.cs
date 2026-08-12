using System;

namespace DataCore.Fase3
{
    // ++++ FASE 1++++
    public struct RegistroDatos
    {
        public int id;
        public string Nombre;
        public double Monto;

        public RegistroDatos(int id, string nombre, double monto)
        {
            this.id = id;
            Nombre = nombre;
            Monto = monto;
        }
    }

    // ********* FASE 3 ****************
    public class NodoRegistro
    {
        public RegistroDatos Dato { get; set; }
        public NodoRegistro? Siguiente { get; set; }

        public NodoRegistro(RegistroDatos dato)
        {
            Dato = dato;
            Siguiente = null;
        }
    }
    public class TablaDinamica
    {
        private NodoRegistro? cabeza;
        private int contadorRegistros;

        public TablaDinamica()
        {
            cabeza = null;
            contadorRegistros = 0;
        }

        public int ContadorRegistros => contadorRegistros;

        public void InsertarInicio(RegistroDatos nuevoRegistro)
        {
            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);
            nuevoNodo.Siguiente = cabeza;
            cabeza = nuevoNodo;
            contadorRegistros++;
        }

        public void InsertarFinal(RegistroDatos nuevoRegistro)
        {
            NodoRegistro nuevoNodo = new NodoRegistro(nuevoRegistro);

            if (cabeza == null)
            {
                cabeza = nuevoNodo;
            }
            else
            {
                NodoRegistro actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            contadorRegistros++;
        }
        public void EliminarPorId(int idTarget)
        {
            if (cabeza == null) return;
            if (cabeza.Dato.id == idTarget)
            {
                cabeza = cabeza.Siguiente;
                contadorRegistros--;
                return;
            }

            NodoRegistro anterior = cabeza;
            NodoRegistro? actual = cabeza.Siguiente;

            while (actual != null)
            {
                if (actual.Dato.id == idTarget)
                {
                    anterior.Siguiente = actual.Siguiente;
                    contadorRegistros--;
                    return;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
        }
        public RegistroDatos[] ObtenerComoArreglo()
        {
            RegistroDatos[] resultado = new RegistroDatos[contadorRegistros];
            NodoRegistro? actual = cabeza;
            int i = 0;

            while (actual != null)
            {
                resultado[i] = actual.Dato;
                actual = actual.Siguiente;
                i++;
            }
            return resultado;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TablaDinamica dataCore = new TablaDinamica();
            for (int i = 1; i <= 15; i++)
            {
                RegistroDatos reg = new RegistroDatos(i, $"Transacción-{i}", i * 100.0);
                dataCore.InsertarFinal(reg);
                Console.WriteLine($"[INSERT] Registro {i} añadido a la cadena.");
            }
            Console.WriteLine("\n--- Eliminando registros con Id 5 y Id 11 ---");
            dataCore.EliminarPorId(5);
            dataCore.EliminarPorId(11);
            Console.WriteLine("Cadena reestructurada exitosamente - Sin NullReferenceException");

            RegistroDatos[] arreglo = dataCore.ObtenerComoArreglo();
            Console.WriteLine($"\nRegistros en arreglo: {arreglo.Length} (esperado: 13)");

            QuickSort(arreglo, 0, arreglo.Length - 1);

            Console.WriteLine("\n+ + + Arreglo ordenado por id + + +");
            foreach (var r in arreglo)
            {
                Console.WriteLine($"Id: {r.id} | Nombre: {r.Nombre} | Monto: {r.Monto:C}");
            }
        }
        static void QuickSort(RegistroDatos[] arr, int izq, int der)
        {
            int i = izq, j = der;
            int pivote = arr[(izq + der) / 2].id;

            while (i <= j)
            {
                while (arr[i].id < pivote) i++;
                while (arr[j].id > pivote) j--;

                if (i <= j)
                {
                    RegistroDatos temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }

            if (izq < j) QuickSort(arr, izq, j);
            if (i < der) QuickSort(arr, i, der);
        }
    }
}
    
