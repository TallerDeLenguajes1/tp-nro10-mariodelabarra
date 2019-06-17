using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Helper;

namespace TP10
{
    enum TipoDeOperacion { Venta = 1, Alquiler};
    enum TipoDePropiedad { Departamento = 1, Casa, Duplex, Penthouse, Terreno};
    class Program
    {
        static void Main(string[] args)
        {
            string lecturaCSV = ManejoArchivo.extraerCSV();
            char[] delimitadores = { ';', '\n'};
            string[] separarInfo = lecturaCSV.Split(delimitadores);
            TipoDeOperacion tipoOP;
            int i = 0, id = 0;

            ManejoArchivo.crearCSV();//Creo el nuevo archivo CSV donde iran las propiedades

            while (i<(separarInfo.Length - 1))
            {
                Propiedad propiedad = new Propiedad();
                if(separarInfo[i + 1] == "Venta") { tipoOP = (TipoDeOperacion)1; } else { tipoOP = (TipoDeOperacion)2; }//Para poder identificar el tipo de Operacion
                propiedad = CargarPropiedades(id, separarInfo[i], tipoOP);//Creo la propiedad
                Console.WriteLine("\n|======== Propiedad {0} ========|", id);
                Propiedad.mostrarPropiedad(propiedad);//Muestro la propiedad por consola
                ManejoArchivo.escribirCSV(propiedad);//Cargo la propiedad al archivo CSV
                i += 2; id++;
                Console.ReadKey();
            }

            Console.WriteLine("\n|========== Creando copia del archivo ==========|");
            ManejoArchivo.crearCopia();

            Console.WriteLine("\nPresione una tecla para finalizar el programa...");
            Console.ReadKey();
        }

        private static Propiedad CargarPropiedades(int id, string direccion, TipoDeOperacion tipoOperacion)
        {
            Propiedad propiedadAux = new Propiedad();
            Random rand = new Random();
            int varAux;

            propiedadAux.id = id;//El ID de acuerdo al for
            propiedadAux.direccion = direccion;//Tipo de direccion
            propiedadAux.tipoOperacion = tipoOperacion;//Tipo de operacion
            propiedadAux.tipoPropiedad =(TipoDePropiedad) rand.Next(1,5);//Tipo de Propiedad
            propiedadAux.tamanio = rand.Next(30, 400);//Metros cuadrados
            if (propiedadAux.tamanio <= 100)
            {
                propiedadAux.cantBanios = 1; //Cantidad de baños
                propiedadAux.cantHabit = rand.Next(1, 3); //Cantidad de habitaciones
            }
            else
            {
                propiedadAux.cantBanios = rand.Next(1, 4);
                propiedadAux.cantHabit = rand.Next(1, 6);
            }

            if(propiedadAux.tipoPropiedad == TipoDePropiedad.Terreno)
            {
                propiedadAux.precio = rand.Next(50000, 10000);//Precio de propiedad si es un Terreno
            }
            else
            {
                propiedadAux.precio = rand.Next(100000, 900000);//Precio de propiedad si no es Terreno
            }

            varAux = rand.Next(1, 2);
            if (varAux == 1) propiedadAux.estado = true; else propiedadAux.estado = false; //Estado: 1- activo | 0 - inactivo

            return propiedadAux;

        }

    }
}
