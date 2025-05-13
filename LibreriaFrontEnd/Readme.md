**LibreriaApp — Frontend (Blazor WebAssembly)**
-----------------------------------------------

Este es el frontend del sistema LibreriaApp, desarrollado enBlazor WebAssembly. Consume una API RESTful construida en .NET 7 y permitegestionar libros y autores. La aplicación tiene una interfaz moderna yresponsive, utilizando Tailwind CSS y MudBlazor.

 **Tecnologías Utilizadas**

 - Blazor WebAssembly (.NET 7)
   
 - Tailwind CSS — diseño moderno, utilitario y responsive

   

 - MudBlazor — componentes UI ricos para Blazor

  

 - C# & Razor Components

  

 - Progressive Web App (PWA) — soporte básico incluido

   

 - Consumo de API RESTful con HttpClient

   

 - Inyección de dependencias de servicios

   

 - Componentización y reutilización

**Estructura Principal del Proyecto**

_Raíz del proyecto frontend:_

LibreriaFrontEnd/
├── LibreriaApp.Client/ ← ProyectoBlazor WebAssembly
│ ├──Pages/ ← Componentes de página(Registro y Listado de Autores y Libros)
│ ├──Services/ ← Servicios que consumen la APIRESTful
│ ├──Shared/ ← DTOs compartidos con el backend
│ ├──wwwroot/ ← Archivos estáticos,Tailwind CSS, íconos PWA, etc.
│ └──Program.cs ← Configuración de servicios, HttpClient, MudBlazor
├── LibreriaApp.Server/ ← ProyectoAPI backend hospedado (si Blazor está comohosted)
├── LibreriaApp.Shared/ ← DTOscompartidos entre cliente y servidor
└── ...

**Configuración Inicial**


_Navegar a la carpeta del frontend:_

    cd LibreriaApp/LibreriaFrontEnd

_Instalar dependencias de Tailwind CSS :_

    cd LibreriaApp.Client
    npm install

_Compilar Tailwind CSS:_

    cd LibreriaApp.Client
    npm run build:css


_Ejecutar el frontend :_

    cd LibreriaApp.Server
    dotnet run

**Capturas de pantalla**


![Imagen de Referencia]([https://ibb.co/pvBSxYx1](https://i.ibb.co/0jRxcHcn/Captura-de-pantalla-12-5-2025-232347-localhost.jpg))

![Imagen de Referencia]([https://ibb.co/pjcVp1ZF](https://i.ibb.co/F42ZthJT/Captura-de-pantalla-12-5-2025-23261-localhost.jpg))

![Imagen de Referencia]([https://ibb.co/XrbzZfGW](https://i.ibb.co/S4PKXDZ6/Captura-de-pantalla-12-5-2025-23273-localhost.jpg))
