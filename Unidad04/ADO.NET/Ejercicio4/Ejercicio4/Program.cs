using System.Data;
using System.Data.SqlClient; // Descargarlo con nuget
using System.Security.Cryptography;

DataTable dtEmpresas = new DataTable("Empresas");
dtEmpresas.Columns.Add("CustomerID",  typeof(string));
dtEmpresas.Columns.Add("CompanyName", typeof(string));

SqlConnection myconn = new SqlConnection();
//myconn.ConnectionString = "Data Source=LOCALHOST;Initial Catalog=Northwind; User ID=sa; Pwd=123";
myconn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ClienteDb";


// LO COMENTADO CORRESPONDE AL EJERCICIO REALIZADO CON DATAREADERS
/*
SqlCommand mycomando = new SqlCommand();
mycomando.CommandText = "SELECT Id, Nombre FROM Clientes";
mycomando.Connection = myconn;

myconn.Open();
SqlDataReader mydr = mycomando.ExecuteReader();
dtEmpresas.Load(mydr);
myconn.Close();
*/


// LAS SIGUIENTES 4 LINEAS SON DEL EJERCICIO DE DATAADAPTER (FILL)
SqlDataAdapter myadap = new SqlDataAdapter("SELECT Id, Nombre FROM Clientes", myconn);
myconn.Open();
myadap.Fill(dtEmpresas);
myconn.Close();

Console.WriteLine("Listado de Empresas");
foreach(DataRow rowEmpresa in dtEmpresas.Rows)
{
    string idempresa = rowEmpresa["Id"].ToString();
    string nombreempresa = rowEmpresa["Nombre"].ToString();
    Console.WriteLine(idempresa + " - " + nombreempresa);
}

// LAS SIGUIENTES LINEAS SON DEL EJERCICIO DE DATAADAPTER (update)
Console.Write("Escriba el Id que desea modificar: ");
string custid = Console.ReadLine();
DataRow[] rwempresas = dtEmpresas.Select("Id = '" + custid + "'");
if(rwempresas.Length != 1)
{
    Console.WriteLine("Id no encontrado...");
    Console.ReadLine();
    return;
}
DataRow rowMiEmpresa = rwempresas[0];
string nombreactual = rowMiEmpresa["Nombre"].ToString();
Console.WriteLine("Nombre actual de la empresa: " + nombreactual);
Console.Write("Escriba el nuevo nombre: ");
string nuevonombre = Console.ReadLine();

rowMiEmpresa.BeginEdit();
rowMiEmpresa["Nombre"] = nuevonombre;
rowMiEmpresa.EndEdit();

SqlCommand updcommand = new SqlCommand();
updcommand.Connection = myconn;
updcommand.CommandText = "UPDATE Clientes set Nombre = @Nombre where Id = @Id";
updcommand.Parameters.Add("@Nombre", SqlDbType.NVarChar, 50, "Nombre");
updcommand.Parameters.Add("@Id", SqlDbType.Int, 10, "Id");

myadap.UpdateCommand = updcommand;
myadap.Update(dtEmpresas);

// Volvemos a mostrar la tablita
Console.WriteLine("Listado de Empresas");
foreach (DataRow rowEmpresa in dtEmpresas.Rows)
{
    string idempresa = rowEmpresa["Id"].ToString();
    string nombreempresa = rowEmpresa["Nombre"].ToString();
    Console.WriteLine(idempresa + " - " + nombreempresa);
}