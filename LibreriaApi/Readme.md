
# Proyecto de Gestión de Libros y Autores

Este proyecto consiste en una API que permite gestionar libros y autores, proporcionando funcionalidades como la búsqueda y registro de libros y autores. Está diseñado como un backend RESTful que puede ser consumido por una aplicación frontend desarrollada en Blazor WebAssembly.

## Requerimientos

- **.NET 6** o superior

- **PostgreSQL** para la base de datos (o tu base de datos preferida, con la configuración adecuada)

- **Swagger** para documentación y pruebas de la API

## Descripción del Backend

El backend está construido utilizando **ASP .NET Core** y sigue la arquitectura de API RESTful. La API está documentada con **Swagger** para facilitar la interacción y comprensión de los endpoints.

### Funcionalidades Principales

- **Búsqueda de Libros**: Buscar libros por título, autor o año de publicación.

- **Registro de Libros**: Crear nuevos libros y asignarles un autor.

- **Búsqueda de Autores**: Buscar autores por nombre.

- **Registro de Autores**: Crear nuevos autores.

**Configuración**

_1\. Configuración de la Base de Datos_

Asegúrate de tener PostgreSQL (o la base de datos de tuelección) configurada.

Configura la cadena de conexión en appsettings.json:

    {
    
    "ConnectionStrings": {
    
    "DefaultConnection":"Host=localhost;Port=5432;Database=gestion\_libros;Username=postgres;Password=tu\_contraseña"
    
    }
    }

_2\. Ejecutar el Proyecto_

Para ejecutar el proyecto localmente, utiliza el siguiente comando en /Libreria.API:

    dotnet run

La API estará disponible en http://localhost:5240 o el puerto configurado.

_2\. Swagger_

La documentación interactiva de la API está disponible através de Swagger en la siguiente URL:

http://localhost:5240/swagger

_3\. Tests_

Los tests de la API están ubicados en la carpeta /Libreria.Tests, puedes ejecutarlos con el siguiente comando:

    dotnet test

