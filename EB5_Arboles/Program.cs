using System;

namespace ArbolesApp
{
    public class Nodo
    {
        public int Valor { get; set; }
        public Nodo? Izquierdo { get; set; }
        public Nodo? Derecho { get; set; }

        public Nodo(int valor) => Valor = valor;
    }

    public class ArbolBinario
    {
        public Nodo? Raiz { get; set; }

        public void Insertar(int valor)
        {
            Raiz = InsertarRec(Raiz, valor);
        }

        private Nodo InsertarRec(Nodo? nodo, int valor)
        {
            if (nodo == null) return new Nodo(valor);

            if (valor < nodo.Valor)
                nodo.Izquierdo = InsertarRec(nodo.Izquierdo, valor);
            else if (valor > nodo.Valor)
                nodo.Derecho = InsertarRec(nodo.Derecho, valor);

            return nodo;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ArbolBinario arbol = new ArbolBinario();
            int[] valores = { 10, 5, 15, 3, 7, 12, 20 };

            foreach (var v in valores) arbol.Insertar(v);
            Console.WriteLine("Árbol construido exitosamente con valores: 10, 5, 15, 3, 7, 12, 20");
        }
    }
}
