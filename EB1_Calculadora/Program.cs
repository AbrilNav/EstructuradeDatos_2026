using System;

namespace CalculadoraPoligonos
{
    struct Poligono
    {
        public string Nombre;
        public double Lado;
        public double Apotema;
    }

    class Program
    {
        static void Main(string[] args)
        {
            int numLados = SeleccionarPoligono();
            Poligono miFigura = PedirDatos(numLados);
            double area = CalcularArea(miFigura, numLados);

            Console.WriteLine($"\nEl área del {miFigura.Nombre} es: {area}");
        }

        static int SeleccionarPoligono()
        {
            int lados = 0;
           
            while (lados < 3)
            {
                Console.WriteLine("--- Menú de Polígonos Regulares ---");
                Console.WriteLine("3. Triángulo equilátero");
                Console.WriteLine("4. Cuadrado");
                Console.WriteLine("5. Pentágono");
                Console.WriteLine("6. Hexágono");
                Console.WriteLine("7. Heptágono");
                Console.Write("Selecciona el número de lados (mínimo 3): ");
                
                
                if (!int.TryParse(Console.ReadLine(), out lados) || lados < 3)
                {
                    Console.WriteLine("Error: Por favor ingresa un número entero válido mayor o igual a 3.\n");
                    lados = 0; // Reiniciamos para que el ciclo continúe
                }
            }
            return lados;
        }

        static Poligono PedirDatos(int lados)
        {
            Poligono p = new Poligono();
            
            // Evaluamos el número de lados para asignar el nombre correcto
            switch (lados)
            {
                case 3:
                    p.Nombre = "Triángulo equilátero";
                    break;
                case 4:
                    p.Nombre = "Cuadrado";
                    break;
                case 5:
                    p.Nombre = "Pentágono";
                    break;
                case 6:
                    p.Nombre = "Hexágono";
                    break;
                case 7:
                    p.Nombre = "Heptágono";
                    break;
                default:
                    p.Nombre = "Polígono Regular";
                    break;
            }

            // Pedimos las medidas usando la validación de números positivos
            p.Lado = ValidarDato($"Ingresa la medida del lado del {p.Nombre}: ");
            p.Apotema = ValidarDato($"Ingresa la medida de la apotema: ");
            
            return p;
        }

        // Esta era la función que faltaba para validar los números
        static double ValidarDato(string mensaje)
        {
            double valor = -1;
            while (valor <= 0)
            {
                Console.Write(mensaje);
                if (!double.TryParse(Console.ReadLine(), out valor) || valor <= 0)
                {
                    Console.WriteLine("Error: El valor debe ser un número decimal positivo mayor a cero.\n");
                    valor = -1;
                }
            }
            return valor;
        }

        static double CalcularArea(Poligono p, int nLados)
        {
            double perimetro = p.Lado * nLados;
            return (perimetro * p.Apotema) / 2;
        }
    }
}