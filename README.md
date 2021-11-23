* Directorios *

- ./database : Scripts para creacion de objetos en la base de datos
- ./WebApi: Directorio del proyecto de la API

* Descripcion de la API *

- Empleados 
  - Listar todos los empleados : GET /api/MaEmpleados/
  - Consultar por ID: GET /api/MaEmpleados/{id}
  - Consultar por Documento: GET /api/MaEmpleados/ByIdentDocument/{docIdentNumero}
  - Consultar por palabras en nombres o apellidos: api/MaEmpleados/ByName/{palabras}
    palabras separadas por espacios
  - Editar datos: PUT /api/MaEmpleados/{id}
  - Insertar datos: POST:
    {
        "docIdentTipo": "CC",
        "docIdentNumero": 91489836,
        "nombre1": "Javier",
        "nombre2": "Mauricio",
        "apellido1": "Martinez",
        "apellido2": "Ortega",
        "idSubArea": 2,
        "fechIns": "2021-11-23T00:00:00"
    } 

- Areas
  - Listar : GET /api/TbAreas/
  - Consultar por ID: GET /api/TbAreas/{id}
  - Editar datos: PUT /api/TbAreas/{id}
  - Insertar datos: POST:

- SubAreas
  - Listar : GET /api/TbSubAreas/
  - Consultar por ID: GET /api/TbSubAreas/{id}
  - Editar datos: PUT /api/TbSubAreas/{id}
  - Insertar datos: POST:

- Tipos de documento de identificacion
  - Listar : GET /api/TTbTipoDocumentoIdents/
  - Consultar por ID: GET /api/TbTipoDocumentoIdents/{id}
  - Editar datos: PUT /api/TbTipoDocumentoIdents/{id}
  - Insertar datos: POST:


* Ejecucion *
- Ejecutar los scripst en el directorio ./database/ en el orden en que aparecen en el archivo README.md del directorio
- Abrir la solucion FanalcaTest.sln con Visual Studio
- Editar Program.cs metodo Main para definir la cadena de conexion real ala base de datos
- Ejecutar
- La api se ejecuta por https://localhost:44304

