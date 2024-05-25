using System.Collections;
using ClassLibrary4;


//1)
List<string> Provincias = new List<string>();
Provincias.Add("Buenos Aires");
Provincias.Add("Santa Fe");
Provincias.Add("Tucuman");
Provincias.Add("Cordoba");
Provincias.Add("Entre Rios");
Provincias.Add("Corrientes");
var listaProvincias = from c in Provincias where c.StartsWith("S") || c.StartsWith("T") select c;
Console.WriteLine("Ejericio 1:");
foreach (string p in listaProvincias)
{
    Console.WriteLine(p);
}

//2)
Console.WriteLine("Ejercicio 2:");
List<int> Numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 20, 21, 22, 23, 24, 25 };
Numeros.Add(34);
var listaNumeros = from c in Numeros where c > 20 select c;
foreach (var p in listaNumeros)
{
    Console.WriteLine(p);
}

//3)

Console.WriteLine("Ejericio 3:");
Ciudad ciudad1 = new Ciudad("Rosario", 2000);
ArrayList ciudades = new ArrayList() { new Ciudad("Mar del Plata", 1000), new Ciudad("Concordia", 1200), new Ciudad("Rio Cuarto", 3000) };
//List<Ciudad> ciudades = new List<Ciudad> { new Ciudad("Mar del Plata", 1000), new Ciudad("Concordia", 1200), new Ciudad("Rio Cuarto", 3000) };
ciudades.Add(ciudad1);

string cadena = Console.ReadLine();

var listaCiudades = from Ciudad c in ciudades where c.Nombre.ToLower().Contains(cadena) select c;
foreach (var p in listaCiudades)
{
    Console.WriteLine(p.CodigoPostal);
}

//4)
string Res = "s";
Console.WriteLine("Ejericio 4:");
List<Empleado> empleados = new List<Empleado>();
while(Res == "s")
{
    Console.WriteLine("Ingrese datos del Empleado:");
    Empleado em = new Empleado();
    em.Sueldo = Int32.Parse(Console.ReadLine());
    em.Nombre = Console.ReadLine();
    em.Id = Int32.Parse(Console.ReadLine());
    empleados.Add(em);
    Console.WriteLine("Desea seguir ingresando???:");
    Res = Console.ReadLine();
}
var listaEmpleados = from c in empleados orderby c.Sueldo descending select c;
// var listaEmpleados = empleados.OrderByDescending(e => e.Sueldo);
foreach (var p in listaEmpleados)
{
    Console.WriteLine(p.Nombre + " "+ p.Id + " " + p.Sueldo);
}

var listaEmpleados1 = from c in empleados orderby c.Sueldo ascending select c;
foreach (var p in listaEmpleados1)
{
    Console.WriteLine(p.Nombre + " " + p.Id + " " + p.Sueldo);
}
