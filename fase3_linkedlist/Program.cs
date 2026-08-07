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
}