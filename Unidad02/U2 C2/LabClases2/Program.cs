﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases;

namespace LabClases2
{
    class Program
    {
        static void Main(string[] args)
        {
            B b = new B();
            A a = b;
            a.F(); // a.f
            b.F(); // b.f
            a.G(); // b.g 
            b.G(); // b.g

            Console.ReadKey();

        }
    }
}