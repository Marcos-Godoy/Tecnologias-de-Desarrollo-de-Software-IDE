// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

    // Llamada a los métodos CRUD para probar
    CrearAlumno(1234, "Juan", "Pérez", "Calle Falsa 123");
    LeerAlumno("Juan");
    ActualizarAlumno(1235, "Juan", "Gómez", "Calle Falsa 321");
    EliminarAlumno(1235);
CrearAlumno(1235, "Lionel", "Pérez", "Calle Falsa 123");


static void CrearAlumno(int legajo, string nombre, string apellido, string direccion)
{
    using (var context = new UniversidadContext())
    {
        Alumno alumno = new Alumno()
        {
            Nombre = nombre,
            Apellido = apellido,
            Direccion = direccion,
            Legajo = legajo,
        };
        context.Alumnos.Add(alumno); // agrego el alumno a la coleccion de alumnos.
        context.SaveChanges();
        Console.WriteLine("Alumno {nombre} {apellido} creado con exito...");

    }
}

static void LeerAlumno(string nombre)
{
    using (var context = new UniversidadContext())
    {
        Alumno alumno = context.Alumnos.FirstOrDefault(a => a.Nombre == nombre);
        if(alumno == null)
        {
            Console.WriteLine("No se encontro el alumno");
        }
        else
        {
            Console.WriteLine("Se encontro...");
        }
    }
}

static void ActualizarAlumno(int legajo, string nombre, string apellido, string direccion)
{
    using (var context = new UniversidadContext())
    {
        Alumno alumno = context.Alumnos.FirstOrDefault(a => a.Nombre == nombre);
        if (alumno != null)
        {
            alumno.Nombre = nombre;
            alumno.Legajo = legajo;
            alumno.Apellido = apellido;
            alumno.Direccion = direccion;
        }
        else
        {
            Console.WriteLine("No se encontro...");

        }

    }
}

static void EliminarAlumno(int legajo)
{
    using (var context = new UniversidadContext())
    {
        var alumno = context.Alumnos.FirstOrDefault(a => a.Legajo == legajo);

        if (alumno != null)
        {
            context.Alumnos.Remove(alumno);
            context.SaveChanges();

            Console.WriteLine($"Alumno con legajo {legajo} eliminado.");
        }
        else
        {
            Console.WriteLine($"No se encontró ningún alumno con el legajo {legajo}.");
        }
    }
}