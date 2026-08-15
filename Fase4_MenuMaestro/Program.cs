using System;

namespace DataCore.Fase4
{
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

    // + + +  FASE 2 CLASE NODO + + + +
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

    // 3333333333333 FASE 3 333333333333333333333333333
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
        public bool EliminarPorId(int idTarget)
        {
            if (cabeza == null) return false;

            if (cabeza.Dato.id == idTarget)
            {
                cabeza = cabeza.Siguiente;
                contadorRegistros--;
                return true;
            }

            NodoRegistro anterior = cabeza;
            NodoRegistro? actual = cabeza.Siguiente;

            while (actual != null)
            {
                if (actual.Dato.id == idTarget)
                {
                    anterior.Siguiente = actual.Siguiente;
                    contadorRegistros--;
                    return true;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }

            return false;
        }

        public void MostrarRegistros()
        {
            if (cabeza == null)
            {
                Console.WriteLine("La tabla de datos está vacía.");
                return;
            }

            NodoRegistro? actual = cabeza;
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine(string.Format("{0,-10} | {1,-25} | {2,-15}", "ID", "Nombre", "Monto"));
            Console.WriteLine("---------------------------------------------------------");
            
            while (actual != null)
            {
                Console.WriteLine(string.Format("{0,-10} | {1,-25} | {2,-15:C}", actual.Dato.id, actual.Dato.Nombre, actual.Dato.Monto));
                actual = actual.Siguiente;
            }
            Console.WriteLine("---------------------------------------------------------");
        }
        public RegistroDatos[] ObtenerComoArreglo()
        {
            RegistroDatos[] resultado = new RegistroDatos[contadorRegistros];
            NodoRegistro? actual = cabeza;
            int i = 0;

            while (actual != null && i < contadorRegistros)
            {
                resultado[i] = actual.Dato;
                actual = actual.Siguiente;
                i++;
            }
            return resultado;
        }
    }

    //  + + ++ +  FASE 4 MENU MAESTRO ++ + + +  
    class Program
    {
        private static RegistroDatos[]? indiceOrdenado = null;

        static void Main(string[] args)
        {
            TablaDinamica dataCore = new TablaDinamica();
            bool salir = false;

            do
            {
                Console.Clear();
                Console.WriteLine("=========================================================");
                Console.WriteLine("                DataCore v4.0 - Menu Maestro            ");
                Console.WriteLine("=========================================================");
                Console.WriteLine($" Estado actual: {dataCore.ContadorRegistros} registro(s) en memoria");
                Console.WriteLine($" Estado del indice: {(indiceOrdenado != null ? $"Listo ({indiceOrdenado.Length} registros)" : "No generado")}");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("1. Insertar Registro");
                Console.WriteLine("2. Eliminar por ID");
                Console.WriteLine("3. Mostrar Todos los Registros");
                Console.WriteLine("4. Indexar y Ordenar (QuickSort)");
                Console.WriteLine("5. Busqueda Binaria Indexada");
                Console.WriteLine("6. Salir del Sistema");
                Console.WriteLine("=========================================================");
                Console.Write("Selecciona una opcion (1-6): ");

                string? entrada = Console.ReadLine();

                if (!int.TryParse(entrada, out int opcion))
                {
                    Console.WriteLine("\n[ERROR] Entrada invalida. Debes ingresar un numero.");
                    Pausar();
                    continue;
                }

                Console.WriteLine();

                switch (opcion)
                {
                    case 1:
                        EjecutarInsertar(dataCore);
                        break;
                    case 2:
                        EjecutarEliminar(dataCore);
                        break;
                    case 3:
                        EjecutarMostrar(dataCore);
                        break;
                    case 4:
                        EjecutarIndexar(dataCore);
                        break;
                    case 5:
                        EjecutarBusquedaIndexada();
                        break;
                    case 6:
                        salir = ConfirmarSalida();
                        break;
                    default:
                        Console.WriteLine("[ERROR] Opcion fuera de rango (elige del 1 al 6).");
                        break;
                }

                if (!salir) Pausar();

            } while (!salir);

            Console.WriteLine("\n¡Gracias por utilizar DataCore v4.0!");
        }

        private static void EjecutarInsertar(TablaDinamica tabla)
        {
            try
            {
                Console.WriteLine("* + * +  INSERTAR REGISTRO + * + *");
                Console.Write("Ingresa el ID (entero positivo): ");
                if (!int.TryParse(Console.ReadLine(), out int id) || id <= 0)
                {
                    Console.WriteLine("[ERROR] ID invalido debe ser un entero positivo");
                    return;
                }

                Console.Write("Ingresa el Nombre/Descripcion: ");
                string nombre = Console.ReadLine() ?? "Sin Nombre";
                if (string.IsNullOrWhiteSpace(nombre)) nombre = "Sin Nombre";

                Console.Write("Ingresa el Monto: ");
                if (!double.TryParse(Console.ReadLine(), out double monto))
                {
                    Console.WriteLine("[ERROR] Monto inválido.");
                    return;
                }

                tabla.InsertarFinal(new RegistroDatos(id, nombre, monto));
                indiceOrdenado = null; 
                Console.WriteLine($"\n[ÉXITO] Registro con ID {id} insertado correctamente.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"[ERROR DE FORMATO] {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR INESPERADO] {ex.Message}");
            }
        }

        private static void EjecutarEliminar(TablaDinamica tabla)
        {
            try
            {
                Console.WriteLine("+ * + * ELIMINAR REGISTRO POR ID * + * +");
                if (tabla.ContadorRegistros == 0)
                {
                    Console.WriteLine("[AVISO] La tabla está vacia. No hay elementos para eliminar.");
                    return;
                }

                Console.Write("Ingresa el ID del registro a eliminar: ");
                if (!int.TryParse(Console.ReadLine(), out int id))
                {
                    Console.WriteLine("[ERROR] ID inválido.");
                    return;
                }

                bool eliminado = tabla.EliminarPorId(id);
                if (eliminado)
                {
                    indiceOrdenado = null; 
                    Console.WriteLine($"\n[ÉXITO] El registro con ID {id} fue eliminado de la cadena.");
                }
                else
                {
                    Console.WriteLine($"\n[AVISO] No se encontro ningún registro con ID {id}.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR INESPERADO] {ex.Message}");
            }
        }

        private static void EjecutarMostrar(TablaDinamica tabla)
        {
            try
            {
                Console.WriteLine("* + * + REGISTROS EN LA TABLA DINÁMICA + * + *");
                tabla.MostrarRegistros();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR INESPERADO] {ex.Message}");
            }
        }

        private static void EjecutarIndexar(TablaDinamica tabla)
        {
            try
            {
                Console.WriteLine("--- 4. INDEXAR Y ORDENAR CON QUICKSORT ---");
                if (tabla.ContadorRegistros == 0)
                {
                    Console.WriteLine("[AVISO] La tabla está vacía. Inserta registros antes de indexar.");
                    indiceOrdenado = null;
                    return;
                }

                RegistroDatos[] arregloAuxiliar = tabla.ObtenerComoArreglo();

                QuickSort(arregloAuxiliar, 0, arregloAuxiliar.Length - 1);

                indiceOrdenado = arregloAuxiliar;

                Console.WriteLine($"\n[EXITO] Se han extrado y ordenado {indiceOrdenado.Length} registros.");
                Console.WriteLine("El indice auxiliar ya está disponible para Búsqueda Binaria O(log n).");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR AL INDEXAR] {ex.Message}");
            }
        }

        private static void EjecutarBusquedaIndexada()
        {
            try
            {
                Console.WriteLine("* + * + BÚSQUEDA BINARIA INDEXADA O(log n) * + * +");

                if (indiceOrdenado == null || indiceOrdenado.Length == 0)
                {
                    Console.WriteLine("[AVISO] El índice no ha sido generado o está vacío.");
                    Console.WriteLine("Por favor ejecuta primero la opción 4 (Indexar y Ordenar).");
                    return;
                }

                Console.Write("Ingresa el ID a buscar: ");
                if (!int.TryParse(Console.ReadLine(), out int idBuscado))
                {
                    Console.WriteLine("[ERROR] ID inválido.");
                    return;
                }

                var (registro, comparaciones) = BuscarRegistroIndexado(indiceOrdenado, idBuscado);

                Console.WriteLine("\n+ * + *RESULTADOS DE LA BUSQUEDA + * + *");
                Console.WriteLine($"Comparaciones realizadas: {comparaciones}");

                if (registro.HasValue)
                {
                    Console.WriteLine("[ESTADO] Registro Encontrado:");
                    Console.WriteLine($" - ID: {registro.Value.id}");
                    Console.WriteLine($" - Nombre: {registro.Value.Nombre}");
                    Console.WriteLine($" - Monto: {registro.Value.Monto:C}");
                }
                else
                {
                    Console.WriteLine($"[ESTADO] El ID {idBuscado} NO existe en la base de datos.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR EN BÚSQUEDA] {ex.Message}");
            }
        }

        public static (RegistroDatos? registro, int comparaciones) BuscarRegistroIndexado(RegistroDatos[] arr, int idBuscado)
        {
            int comparaciones = 0;

            if (arr == null || arr.Length == 0)
            {
                return (null, comparaciones);
            }

            int izquierda = 0;
            int derecha = arr.Length - 1;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                comparaciones++;

                if (arr[medio].id == idBuscado)
                {
                    return (arr[medio], comparaciones);
                }

                if (arr[medio].id < idBuscado)
                {
                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }

            return (null, comparaciones);
        }

        private static void QuickSort(RegistroDatos[] arr, int izq, int der)
        {
            if (izq >= der) return;

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
       private static bool ConfirmarSalida()
        {
            Console.Write("¿Estás seguro de que deseas salir del sistema? (S/N): ");
            string? resp = Console.ReadLine()?.Trim().ToUpper();
            return resp == "si";
        }

       private static void Pausar()
        {
            Console.WriteLine("\nPresiona 'Enter' para regresar al menú principal...");
            Console.ReadLine(); 
        }
    }
}

