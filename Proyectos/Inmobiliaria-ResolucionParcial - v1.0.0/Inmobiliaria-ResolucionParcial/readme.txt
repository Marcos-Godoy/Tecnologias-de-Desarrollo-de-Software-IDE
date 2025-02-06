NOTAS IMPORTANTES 

1) Este ejemplo es una propuesta de resoluci�n del examen, en algunos casos se implementaron algunas cosas m�s para que tambi�n sea a futuro una referencia para el TPI. 

2) Tener presente que es solo UNA propuesta, por lo que NO es la �NICA opci�n v�lida. 

3) El mismo no est� 100% finalizado, siendo que siempre es posible mejorar la implementaci�n con m�s tiempo. En algunos lugares de dejaron comentarios con posibles mejoras. Obviamente no se esperaba que estas mejoras sean consideradas por el alumno en el parcial. 

4) En donde dice �Inmobiliaria� (nombre de la SLN, carpetas, nombre de los proyectos, namespace) se esperaba que el alumno pusiera su apellido. 

	Ejemplo supuniendo que el apellido es "Perez" entonces: 

	Nombre de la soluci�n: Perez.sln
	
	Proyectos:
		Inmobiliaria.WebApi -> Perez.WebApi
		Inmobiliaria.Domain -> Perez.Domain
		Inmobiliaria.UI.Desktop -> Perez.UI.Desktop
		
	Idem carpetas y namespaces.

5) Se crea un "PropiedadDto" y "TipoPropiedadDto" que busca desacoplar 100% el backend del frontend. A los fines del examen era v�lido "compartir" la entidad Propiedad. Si es importante que el alumno comprenda el impacto de acoplamiento que esto genera desde lo conceptual. 

6) Se implementan algunas validaciones del lado del cliente y otras del lado del servidor para mostrar c�mo se podr�a haber avanzado. Para el alcance del parcial ambas opciones son v�lidas. Tener presente que, en un sistema real, nuestra API de servicios nunca puede "confiarse" de que la presentaci�n va a realizar estas validaciones, por lo que al menos en el backend las mismas deber�a estar y probablemente algunas las deber�amos redundar por usabilidad. 

7) Tanto la URL de los endpoints, como el string de conexi�n en un ejemplo real se recomienda moverlos a un archivo de configuraci�n que nos d� la posibilidad de ajustarlos sin tener que recompilar la soluci�n. 

8) Notar que hay dos clases que se llaman PropiedadDto, una del lado del frontend y otra del lado del backend. Se duplica para evitar agregar un nuevo proyecto. Como se mencion� antes, esto requer�a agregar m�s clases ya que tambi�n es necesario implementar el m�todo ToDto en el servicio para poder mapear de la entidad al Dto. Para el parcial era v�lido usar siempre la misma entidad. Esto se agreg� para poder cumplimentar el requerimiento de Aprobaci�n directa de la consulta. Notar que se "aplana" en propiedades, el campo descripci�n de tipo de propiedad. 

9) Depuraci�n y prueba: A los fines de la depuraci�n se configur� que arranquen inicialmente el proyecto de presentaci�n y el web api. Recordar que esto se puede modificar haciendo bot�n derecho en la soluci�n y cambiando los proyectos de inicio de m�ltiple por single. 

10) Nombres de proyectos: Se podr�an haber usado otros nombres en la medida que sean representativos. Se mantuvieron los que fueron mencionados mayormente durante el cursado. Dejamos algunas variantes: 
	- Para domain por ejemplo se podr�a utilizar AppCore o simplemente Core que son t�rminos que aparecen en varios libros de referencia. 

	- Para presentaci�n se podr�a haber utilizado simplemente UI, Escritorio, Desktop, Winform, Presentaci�n, etc. Se opto por esta opci�n para dejarlo preparado si se quiere agregar un proyecto Web. 

	- WebAPI podr�a ser Endpoints, Api, PubliAPI, etc. 

Era v�lido crear otros proyectos adicionales para mejorar el desacoplamiento. Ejemplos: una capa de entidades, sacar el contexto de EF a un proyecto de Infraestructura. Mover los API clients en otro proyecto. Todas estas cosas, que son perfectamente v�lidas, no las recomendamos para el parcial ya que agregan complejidad y siempre vamos a tener un tiempo acotado. 

11) En las pantallas se podr�a mejorar la est�tica, como as� tambi�n ajustar el nombre de las columnas de la grilla. Notar por ejemplo que TipoPropiedadId no tendr�a sentido que siga saliendo una vez implementado el requerimiento de Aprobaci�n directa ya que agregamos el campo descripci�n del tipo de propiedad. 

 