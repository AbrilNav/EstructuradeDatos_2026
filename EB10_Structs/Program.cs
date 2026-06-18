using System;

namespace CoordenaGPS
{
    // ++++++++++++ MODULO A: El Struct CoordenadaGPS ++++++++++++++++++++++
    public readonly struct CoordenadaGPS
    {
        public double Latitud { get; }
        public double Longitud { get; }
        public CoordenadaGPS(double lat, double lon)
        {
            if (lat < -90 || lat > 90)
                throw new ArgumentOutOfRangeException(nameof(lat), "Latitud fuera de rango [-90, 90]");
            
            if (lon < -180 || lon > 180)
                throw new ArgumentOutOfRangeException(nameof(lon), "Longitud fuera de rango [-180, 180]");
            Latitud = lat;
            Longitud = lon;
        }
        public void ImprimirUbicacion()
        {
            Console.WriteLine($"Lat: {Latitud}, Lon: {Longitud}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            

            // ++++++++++++ MÓDULO B ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            CoordenadaGPS c1 = new CoordenadaGPS(19.4326, -99.1332); 
            CoordenadaGPS c2 = c1; 
            c2 = new CoordenadaGPS(52.5200, 13.4050); //otro pais
            
            Console.Write("c1 (CDMX): "); c1.ImprimirUbicacion();
            Console.Write("c2 (Berlin): "); c2.ImprimirUbicacion();

            // ++++MÓDULO C: Control de Excepciones y robustez ++++++++++++++++++++++++++++++++++++++++++
            Console.WriteLine("\nEntrada de datos");
            try
            {
                Console.Write("Ingresa Latitud: ");
                double lat = double.Parse(Console.ReadLine());
                Console.Write("Ingresa Longitud: ");
                double lon = double.Parse(Console.ReadLine());
                var coord = new CoordenadaGPS(lat, lon);
                coord.ImprimirUbicacion();
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error de rango: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Entrada no valida");
            }
        }
    }
}