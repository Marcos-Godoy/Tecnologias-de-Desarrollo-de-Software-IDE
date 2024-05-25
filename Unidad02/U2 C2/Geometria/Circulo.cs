using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometria
{
    public class Circulo
    {
        private int m_radio;

        public int Radio
        {
            get
            {
                throw new System.NotImplementedException();
            }

            set
            {
            }
        }

        public void CalcularPerimetro()
        {
            throw new System.NotImplementedException();
        }

        public void CalcularSuperficie()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Triangulo
    {
        float lado;

        public Triangulo(int a)
        {

        }

        public float Lado
        {
            get
            {
                return lado;
            }

            set
            {
                lado = value;
            }
        }

        public double CalcularPerimetro()
        {
            return lado*3;
        }

        public double CalcularSuperficie()
        {
            return 1;
        }
    }

    public class Poligono
    {
        public double CalcularPerimetro()
        {
            return 1;
        }

        public double CalcularSuperficie()
        {
            return 1;
        }
    }

    public class Rectangulo : Poligono
    {

    }

    public class Cuadrado : Rectangulo
    {

    }

}
