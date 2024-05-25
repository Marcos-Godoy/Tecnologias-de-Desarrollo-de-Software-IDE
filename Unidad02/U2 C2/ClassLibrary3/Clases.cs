using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinarNumero
{
    class Juego
    {
        int recordIntentos = 32000;

        public void comenzarJuego()
        {
            do
            {
                Console.Clear();
                Console.WriteLine("¡Empezó el juego!");
                Console.WriteLine("*****************\n");
                Jugada jugadita = new Jugada(preguntarMaximo());
                while (!jugadita.Adivino)
                {
                    jugadita.comparar(preguntarNumero());
                }
                compararRecord(jugadita.Intentos);
            } while (continuar());
        }

        public void compararRecord(int nrodeIntentos)
        {
            if (recordIntentos > nrodeIntentos)
            {
                recordIntentos = nrodeIntentos;
                Console.Clear();
                Console.WriteLine("¡Lograste un nuevo record!");
                Console.Write("Cantidad de intentos: ");
                Console.WriteLine(recordIntentos + " intento/s.");
                Console.ReadKey();
            }
        }

        private bool continuar()
        {
            string respuesta = "Z";
            do
            {
                Console.WriteLine("\n¿Querés jugar otra vez? (Escribí S para SI o N para NO)");
                respuesta = Console.ReadLine();
                Console.Clear();
                if (respuesta != "S" & respuesta != "N")
                {
                    Console.WriteLine("Las opciones son S o N, en mayúsculas.");
                }
            } while (respuesta != "S" & respuesta != "N");

            if (respuesta == "S")
                return true;
            else
            {
                Console.Write("                     (Apretá cualquier cosa para salir)");
                Console.ReadKey();
                return false;
            }

        }

        private int preguntarMaximo()
        {
            Console.WriteLine("Indique el número máximo a adivinar.");
            Console.Write("El número a adivinar estará entre 0 y el máximo elegido: ");
            int nro = 0;
            do
            {
                nro = Int32.Parse(Console.ReadLine());
                if (nro < 0 | nro > 9999)
                {
                    Console.WriteLine("\nIngrese un número válido: ");
                }
            } while (nro < 0 | nro > 9999);
            return nro;
        }

        private int preguntarNumero()
        {
            Console.Clear();
            Console.Write("Ingrese un número para acertar.\n");
            int ing = Int32.Parse(Console.ReadLine());
            Console.Clear();
            return ing;
        }

    }
}
