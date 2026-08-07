using System;

namespace DataCore.Fase3
{
    // ********** FASE 1 ***********
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

    // 33333333333333333333 FASE 3 333333333333333333333333
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
                // Recorre hasta el último nodo
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
            contadorRegistros++;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Probando compilacion de Fase 3...");
        }
    }
}
    
