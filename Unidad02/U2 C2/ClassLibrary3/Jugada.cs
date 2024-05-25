using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdivinarNumero
{
    class Jugada
    {
        private int numero = 0, intentos = 0;
        private bool adivino = false;

        public Jugada(int maxNumero)
        {
            Random rnd = new Random();
            Numero = rnd.Next(maxNumero);
        }

        public int Numero
        {
            get
            {
                return numero;
            }

            set
            {
                numero = value;
            }
        }

        public int Intentos
        {
            get
            {
                return intentos;
            }

            set
            {
                intentos = value;
            }
        }

        public bool Adivino
        {
            get
            {
                return adivino;
            }

            set
            {
                adivino = value;
            }
        }

        public bool comparar(int numeroIngresado)
        {
            Console.Clear();
            Console.WriteLine("Ingrese otro número para adivinar: ");
            if (numeroIngresado == numero)
            {
                adivino = true;
                Console.Write("¡Lo adivinaste!");
                Console.ReadKey();
            }
            else
            {
                adivino = false;
            }
            intentos++;
            return adivino;
        }


    }
}
