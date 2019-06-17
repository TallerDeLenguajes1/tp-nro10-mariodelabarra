using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TP10;

namespace Helper
{
    static class ManejoArchivo
    {
        public static void crearCSV()//Creo el archivo CSV
        {
            string archivo = "empleadosFinal.csv";
            using (FileStream file = new FileStream(archivo, FileMode.Create))
            {
                file.Close();
            }
                
            using(StreamWriter file = new StreamWriter(archivo))
            {
                file.Write("ID;Tipo de Propiedad;Tipo de Operacion;Tamanio;Cantidad de Banios;Cantidad de Habitacion;Precio;Direccion;Estado\n");
                file.Close();
            }
        }

        public static string extraerCSV()//Lectura del archivo CSV
        {
            string archivo = "empleadoAux.csv";
            string lectura;

            using(StreamReader file = new StreamReader(archivo))
            {
                lectura = file.ReadToEnd();
                file.Close();
            }

            return lectura;
        }

        public static void escribirCSV(Propiedad propiedad)//Cargo las propiedades
        {
            string archivo = "empleadosFinal.csv";

            using (StreamWriter file = new StreamWriter(archivo, true))
            {
                file.Write(propiedad.id + ";");
                file.Write(propiedad.tipoPropiedad + ";");
                file.Write(propiedad.tipoOperacion + ";");
                file.Write(propiedad.tamanio + ";");
                file.Write(propiedad.cantBanios + ";");
                file.Write(propiedad.cantHabit+ ";");
                file.Write(propiedad.precio + ";");
                file.Write(propiedad.direccion + ";");
                file.Write(propiedad.estado + "\n");
                file.Close();
            }
        }

        public static void crearCopia()//Para crear directorio/carpeta y generar la copia
        {
            string[] discos = Directory.GetLogicalDrives();//Lista los discos disponibles
            int opc;

            Console.WriteLine("Elija el disco en donde desea crear el BackUp:");
            for(int i = 0; i<discos.Length; i++)
            {
                Console.WriteLine("{0} - {1}", i+1, discos[i]);
            }
            opc = int.Parse(Console.ReadLine()) - 1;
            discos[opc] = discos[opc] + @"BackUpPropiedades\";

            if (!Directory.Exists(discos[opc]))
            {
                Directory.CreateDirectory(discos[opc]);//Crea el directorio BackUp si no existe
            }

            if (!File.Exists(discos[opc] + "empleadosFinal.csv"))
            {
                File.Copy("empleadosFinal.csv", discos[opc] + "empleadosFinal.csv");//Creo una copia del archivo sin pisar una copia existente
                File.Move(discos[opc] + "empleadosFinal.csv", discos[opc] + "empleadosFinal.bk");//Cambio la extension del archivo a .bk
            }

        }
    }
}
