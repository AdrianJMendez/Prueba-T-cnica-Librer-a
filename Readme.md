
# Proyecto de Gestión de Libros y Autores

Este proyecto es una solución completa compuesta por una API RESTful desarrollada en .NET 7 y un frontend en Blazor WebAssembly, diseñada para gestionar libros y autores. La aplicación permite registrar y buscar libros por título, autor o año, así como registrar y consultar información de autores.

**Tecnologías y Herramientas**

*Back-End:*

-   .NET 7 (ASP.NET Core Web API)
    
-   Entity Framework Core 7.x (ORM)
    
-   PostgreSQL (Base de datos relacional)
    
-   Clean Architecture (Entidades, DTOs, Repositorios, Servicios, Controladores, etc.)
    
-   Swagger (OpenAPI 3.0) para documentación interactiva
    
-   Pruebas unitarias con xUnit, Moq y FluentAssertions
    
-   Inyección de dependencias
    
-   Patrones aplicados: Repositorio, Unidad de Trabajo
    

*Front-End:*

-   Blazor WebAssembly (.NET 7)
    
-   Tailwind CSS (Diseño moderno y responsive)
    
-   MudBlazor (Componentes de UI avanzados)
    
-   Consumo de la API RESTful con HttpClient
    
-   Soporte para Progressive Web Apps (PWA)
    
-   Componentización y servicios inyectados
    

**Estructura General del Repositorio**

Raíz del repositorio:

/  
├── LibreriaApi/ → Backend: API RESTful  
│ ├── LibreriaApi.Application  
│ ├── LibreriaApi.Domain  
│ ├── LibreriaApi.Infrastructure  
│ ├── LibreriaApi.Persistence  
│ └── LibreriaApi.Tests → Pruebas unitarias del backend  
│  
├── LibreriaFrontEnd/ → Frontend: Blazor WebAssembly  
│ ├── LibreriaApp.Client  
│ ├── LibreriaApp.Server → En Blazor Hosted  
│ └── LibreriaApp.Shared  


 **Instalación y Ejecución**

1.  Clona el repositorio:  
    git clone [https://github.com/tu-usuario/LibreriaApp.git](https://github.com/tu-usuario/LibreriaApp.git)
    
2.  Configura la base de datos PostgreSQL y edita la cadena de conexión en appsettings.json:  
    "DefaultConnection": `"Host=localhost;Port=5432;Database=gestion_libros;Username=postgres;Password=tu_contraseña"`
    
3.  Ejecuta la API:  
  

  

    cd LibreriaApi  
        dotnet run
    
4.  Ejecuta el frontend:  

    cd LibreriaFrontEnd/LibreriaApp.Server  
    dotnet run
    

Documentación de API

Una vez ejecutado el backend, puedes acceder a la documentación Swagger en:  
[http://localhost:5240/swagger](http://localhost:5240/swagger)
