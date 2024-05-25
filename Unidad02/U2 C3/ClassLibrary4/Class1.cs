namespace ClassLibrary4
{
    public class Ciudad
    {
        private int _codigo;
        private string _nombre;
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public int CodigoPostal { get { return _codigo; } set { _codigo = value; } }
        public Ciudad(string nom, int cod) { 
            _codigo = cod;
            _nombre = nom; 
        }
    }
    
    public class Empleado
    {
        private int _sueldo;
        private string _nombre;
        private int _id;
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public int Id { get { return _id; } set { _id = value; } }
        public int Sueldo { get { return _sueldo; } set { _sueldo = value; } }
        /*
        public Empleado(float sueldo, string nombre, int id)
        {
            _sueldo = sueldo;
            _nombre = nombre;
            _id = id;
        }*/
    }
}
