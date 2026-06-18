using System;
using System.Collections.Generic;
using System.Linq; // Necesario para LINQ (.ToDictionary, .OrderBy, .Where)

namespace InventarioApp
{
    public class Producto
    {
        public int ID { get; set; }
        // Inicializamos con string.Empty para evitar advertencias de nulos
        public string Nombre { get; set; } = string.Empty; 
        public double Precio { get; set; }
        public bool EstaAgotado { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //PRODUCTOS
            List<Producto> inventario = new List<Producto>
            {
                new Producto { ID = 1, Nombre = "Laptop Huawei", Precio = 16911, EstaAgotado = false },
                new Producto { ID = 2, Nombre = "Mouse", Precio = 340, EstaAgotado = true },
                new Producto { ID = 3, Nombre = "Teclado logitech", Precio = 910, EstaAgotado = false },
                new Producto { ID = 4, Nombre = "Monitor LG", Precio = 12300, EstaAgotado = false },
                new Producto { ID = 5, Nombre = "Cables", Precio = 160, EstaAgotado = true }
            };

            //DICCIONARIO
            Dictionary<int, Producto> catalogo = inventario.ToDictionary(p => p.ID, p => p);
            BuscarPorID(catalogo);
        }

        // BUSQUEDA
        static void BuscarPorID(Dictionary<int, Producto> catalogo)
        {
            Console.WriteLine("--- Sistema de Inventario ---");
            Console.Write("Ingresa el ID del producto a buscar: ");

            if (int.TryParse(Console.ReadLine(), out int idBuscado))
            {
                
                if (catalogo.TryGetValue(idBuscado, out Producto encontrado))
                {
                    Console.WriteLine($"\n[ÉXITO] Producto encontrado:");
                    Console.WriteLine($"Nombre: {encontrado.Nombre} | Precio: ${encontrado.Precio}");
                }
                else
                {
                    Console.WriteLine($"\n[ERROR] No existe ningún producto con el ID {idBuscado}.");
                }
            }
            else
            {
                Console.WriteLine("\n[ERROR] Entrada inválida. Por favor ingresa un número entero.");
            }
        }
    }
}