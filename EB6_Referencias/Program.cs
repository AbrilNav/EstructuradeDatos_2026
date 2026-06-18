using System;

namespace MemoriaApp
{
    public class Alumno
    {
        public string Nombre { get; set; } = string.Empty;
    }

    class Program
    {
        static void Main(string[] args)
        {
            EjecutarModulo1();
            EjecutarModulo2();
            EjecutarModulo3();
        }

        //  +++++++++++++++++  MODULO 1: Intercambiar(ref int a, ref int b) ++++++++++++++++++
        static void EjecutarModulo1()
        {
            Console.WriteLine("\n[Módulo 1: Intercambio con 'ref']");
            int x = 10, y = 25;
            Console.WriteLine($"Antes: x={x}, y={y}");
            
            Intercambiar(ref x, ref y);
            
            Console.WriteLine($"Después: x={x}, y={y}");
        }
        static void Intercambiar(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }






        //  +++++++++++++++ MODULO 2:CalcularYValidar(int dividendo, int divisor, out int residuo) ++++++++++++++
        static void EjecutarModulo2()
        {
            Console.WriteLine("\n[Módulo 2: Validación con 'out']");
            int cociente = CalcularYValidar(17, 5, out int resto);
            
            Console.WriteLine($"Cociente: {cociente}");
            Console.WriteLine($"Residuo: {resto}");
        }

        static int CalcularYValidar(int dividendo, int divisor, out int residuo)
        {
            residuo = dividendo % divisor;
            return dividendo / divisor;
        }





        // ++++++++++++++++++ MODULO 3: Demostración de Referencias de Objetos ++++++++++++++++++
        static void EjecutarModulo3()
        {
            Console.WriteLine("\n[Módulo 3: Referencias de Objetos]");
            
            Alumno alumno1 = new Alumno { Nombre = "Dany" };
            Alumno alumno2 = alumno1; 

            alumno2.Nombre = "3Treum";

            Console.WriteLine($"Nombre en alumno1: {alumno1.Nombre}");
            Console.WriteLine($"Nombre en alumno2: {alumno2.Nombre}");
        }
    }
}