using System.Data;
using System.Data.SqlClient;

DataTable dtAlumnos = new DataTable();
// Creamos las columnas
DataColumn colIDAlumno = new DataColumn("IDAlumno", typeof(int));
colIDAlumno.ReadOnly = true; // indicamos que sera readonly
colIDAlumno.AutoIncrement = true; // sera autoincremental
colIDAlumno.AutoIncrementSeed = 0; // el primer numero sera 0
colIDAlumno.AutoIncrementStep = 1; // se incrementara de a 1
DataColumn colApellido = new DataColumn("Apellido", typeof(string));
DataColumn colNombre = new DataColumn("Nombre", typeof(string));
// Agregamos las columnos a la tabla
dtAlumnos.Columns.Add(colApellido);
dtAlumnos.Columns.Add(colNombre);
dtAlumnos.Columns.Add(colIDAlumno);
dtAlumnos.PrimaryKey = new DataColumn[] { colIDAlumno }; // Establecemos la clave primaria

// Creamos las Filas y las agregamos a la tabla
DataRow rwAlumno = dtAlumnos.NewRow();
rwAlumno[colApellido] = "Perez";
rwAlumno[colNombre] = "Juan";
dtAlumnos.Rows.Add(rwAlumno);
DataRow rwAlumno2 = dtAlumnos.NewRow();
rwAlumno2["Apellido"] = "Perez";
rwAlumno2["Nombre"] = "Marcelo";
dtAlumnos.Rows.Add(rwAlumno2);

DataTable dtCursos = new DataTable("Cursos");
// Creamos las columnas
DataColumn colIDCurso = new DataColumn("IDCurso", typeof(int));
colIDCurso.ReadOnly = true; // indicamos que sera readonly
colIDCurso.AutoIncrement = true; // sera autoincremental
colIDCurso.AutoIncrementSeed = 1; // el primer numero sera 1
colIDCurso.AutoIncrementStep = 1; // se incrementara de a 1
DataColumn colCurso = new DataColumn("Curso", typeof(string));
// Agregamos las columnos a la tabla
dtCursos.Columns.Add(colCurso);
dtCursos.Columns.Add(colIDCurso);
dtCursos.PrimaryKey = new DataColumn[] { colIDCurso }; // Establecemos la clave primaria

DataRow rwCurso = dtCursos.NewRow();
rwCurso[colCurso] = "Informatica";
dtCursos.Rows.Add(rwCurso);

// Creamos el DataSet y le agregamos las tablas
DataSet dsUniversidad = new DataSet();
dsUniversidad.Tables.Add(dtCursos);
dsUniversidad.Tables.Add(dtAlumnos);

// Creamos la tabla intermedia
DataTable dtAlumnos_Cursos = new DataTable("Alumnos_Cursos");
DataColumn col_ac_IDAlumno = new DataColumn("IDAlumno", typeof(int));
DataColumn col_ac_IDCurso = new DataColumn("IDCurso", typeof(int));
dtAlumnos_Cursos.Columns.Add(col_ac_IDCurso);
dtAlumnos_Cursos.Columns.Add(col_ac_IDAlumno);
dsUniversidad.Tables.Add(dtAlumnos_Cursos);

//Creamos las relaciones entre las tablas mediante las ids.
DataRelation relAlumno_ac = new DataRelation("Alumno_Cursos", colIDAlumno, col_ac_IDAlumno);
DataRelation relCurso_ac = new DataRelation("Curso_Alumnos", colIDCurso, col_ac_IDCurso);
dsUniversidad.Relations.Add(relAlumno_ac);
dsUniversidad.Relations.Add(relCurso_ac);

// Llenamos la tabla intermedia con valores
DataRow rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
rwAlumnosCursos[col_ac_IDAlumno] = 0; // alumno juan perez
rwAlumnosCursos[col_ac_IDCurso] = 1; // curso informatica
dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);
rwAlumnosCursos = dtAlumnos_Cursos.NewRow();
rwAlumnosCursos[col_ac_IDAlumno] = 1; // alumno marcelo perez
rwAlumnosCursos[col_ac_IDCurso] = 1; // curso informatica
dtAlumnos_Cursos.Rows.Add(rwAlumnosCursos);

Console.Write("Por favor ingrese el nombre del curso: ");
string materia = Console.ReadLine();
Console.WriteLine("Listado de Alumnos del curso " + materia);
DataRow[] row_CursoInf = dtCursos.Select("Curso = '" + materia + "'"); // Tomamos todos los cursos con la materia informatica
foreach(DataRow rowCu in row_CursoInf)
{
    DataRow[] row_AlumnosInf = rowCu.GetChildRows(relCurso_ac); // Filas de la tabla intermedia que están relacionadas con el curso informatica
    foreach(DataRow rowAl in row_AlumnosInf)
    {
        Console.WriteLine(rowAl.GetParentRow(relAlumno_ac)[colApellido].ToString() + ", " + rowAl.GetParentRow(relAlumno_ac)[colNombre].ToString());
    }
}
Console.ReadLine();

// Representar los alumnos por pantalla para el laboratorio 1
/*
Console.WriteLine("Listado de Alumnos:");
foreach(DataRow row in dtAlumnos.Rows)
{
    Console.WriteLine(row[colApellido].ToString() + ", " + row[colNombre].ToString());
}
Console.ReadLine();
*/
