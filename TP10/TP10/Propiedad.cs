using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP10
{
    class Propiedad
    {
        public int id;
        public TipoDePropiedad tipoPropiedad;
        public TipoDeOperacion tipoOperacion;
        public double tamanio;
        public int cantBanios, cantHabit, precio;
        public string direccion;
        public bool estado;
        

        //===================Constructores================================
        public int Id { get => id; set => id = value; }
        public double Tamanio { get => tamanio; set => tamanio = value; }
        public int CantBanios { get => cantBanios; set => cantBanios = value; }
        public int CantHabit { get => cantHabit; set => cantHabit = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public bool Estado { get => estado; set => estado = value; }
        internal TipoDePropiedad TipoPropiedad { get => tipoPropiedad; set => tipoPropiedad = value; }
        internal TipoDeOperacion TipoOperacion { get => tipoOperacion; set => tipoOperacion = value; }

        public static double ValorDelInmueble(TipoDeOperacion tipoOperacion, int precio)
        {
            double valorTot = 0;

            if (tipoOperacion == TipoDeOperacion.Venta)//Si la propiedad esta para venta
            {
                valorTot = precio + (precio * 0.21);
                valorTot = valorTot + (valorTot * 0.10) + 10000;
            }
            else if (tipoOperacion == TipoDeOperacion.Alquiler)//Si la propiedad esta para alquiler
            {
                valorTot = (precio * 0.2);
                valorTot = valorTot + (valorTot * 0.5);
            }

            return valorTot;
        }

        public static void mostrarPropiedad(Propiedad propiedad)
        {
            Console.WriteLine("ID: {0}", propiedad.id);
            Console.WriteLine("Tipo de propiedad: {0}", propiedad.tipoPropiedad);
            Console.WriteLine("Tipo de Operacion: {0}.", propiedad.tipoOperacion);
            Console.WriteLine("Tamanio de casa: {0} m2.", propiedad.tamanio);
            Console.WriteLine("Cantidad de banios: {0}.", propiedad.cantBanios);
            Console.WriteLine("Cantidad de habitaciones: {0}", propiedad.cantHabit);
            Console.WriteLine("Precio: {0}.", propiedad.precio);
            Console.WriteLine("Direccion: {0}.", propiedad.direccion);
            if (propiedad.estado == true) { Console.WriteLine("Estado: Activa."); } else { Console.WriteLine("Estado: Inactiva."); }
        }

    }
}
