# Sistema de Elecciones

## Descripción del Proyecto
El Sistema de Elecciones es un proyecto que brinda soporte al proceso de elecciones en una Entidad o Empresa. Su objetivo principal es apoyar en la creación de una campaña, registro de candidatos y padrón de votantes de una campaña, así como el registro de las votaciones realizadas.

## Estructura del Proyecto
La solución se organiza siguiendo una arquitectura en capas para promover la separación de responsabilidades y la mantenibilidad. Los principales proyectos son:

*   **src/SistemaElecciones.ApiRest**: Proyecto ASP.NET Core Web API que expone los endpoints para el consumo desde el cliente. Maneja la autenticación, validación y orquestación de servicios.
*   **src/SistemaElecciones.WebApp**: Cliente Front-end construido con Blazor WebAssembly. Proporciona la interfaz de usuario interactiva que se ejecuta en el navegador.
*   **src/SistemaElecciones.Services**: Capa de aplicación que contiene la lógica de negocio. Orquesta el flujo de datos entre la presentación y el acceso a datos.
*   **src/SistemaElecciones.DataAccess**: Capa de acceso a datos utilizando Entity Framework Core. Contiene el `DbContext` y las configuraciones de las entidades.
*   **src/SistemaElecciones.Repositories**: Implementación del patrón Repositorio (y repositorio genérico) para abstraer el acceso a la base de datos.
*   **src/SistemaElecciones.Entities**: Capa de dominio que contiene las definiciones de las entidades del negocio.
*   **src/SistemaElecciones.Dto**: Objetos de Transferencia de Datos (DTOs) utilizados para intercambiar información entre las capas y a través de la red.
*   **src/SistemaElecciones.Common**: Biblioteca de utilidades y constantes compartidas entre los diferentes proyectos de la solución.
*   **test/SistemaElecciones.UnitTests**: Proyecto de pruebas unitarias para validar la lógica y componentes del sistema.

## Arquitectura
El proyecto implementa una **Arquitectura Limpia (Clean Architecture)** o N-Capas, enfocada en la independencia de frameworks y testabilidad.

*   **Patrones utilizados**:
    *   **Repository Pattern**: Para desacoplar la lógica de negocio del acceso a datos.
    *   **Dependency Injection**: Uso extensivo del contenedor de inyección de dependencias de .NET y Scrutor para el registro automático.
    *   **DTO Pattern**: Para separar el modelo de dominio de los modelos de vista/API.

## Tecnologías Utilizadas

### Backend (.NET 9)
*   **ASP.NET Core Web API**: Framework principal para el backend.
*   **Entity Framework Core**: ORM para la interacción con SQL Server.
*   **JWT (JSON Web Tokens)**: Para la autenticación y autorización segura.
*   **Serilog**: Biblioteca para registro de eventos (logging) estructurado.
*   **Scalar**: Herramienta para documentación y pruebas de API interactiva.

### Frontend (Blazor WebAssembly)
*   **Blazor WebAssembly**: Framework SPA basado en .NET.
*   **Blazor Bootstrap**: Componentes de UI basados en Bootstrap para Blazor.
*   **SweetAlert2**: Para cuadros de diálogo y alertas modales estéticas.

## Dependencias
A continuación se describen algunas de las dependencias clave utilizadas en la solución:

*   **Microsoft.EntityFrameworkCore.SqlServer**: Proveedor de base de datos para SQL Server.
*   **Microsoft.AspNetCore.Authentication.JwtBearer**: Middleware para soportar la autenticación basada en tokens JWT.
*   **Serilog.AspNetCore / Serilog.Sinks.MSSqlServer**: Integración de Serilog con ASP.NET Core y soporte para guardar logs en SQL Server.
*   **Scrutor**: Extensión para escanear ensamblados y registrar servicios en el contenedor DI automáticamente.
*   **Blazored.Toast**: Biblioteca para mostrar notificaciones tipo "toast" en Blazor.
*   **Blazored.SessionStorage**: Abstracción para manejar `sessionStorage` del navegador en Blazor.
*   **CurrieTechnologies.Razor.SweetAlert2**: Wrapper de Blazor para la librería SweetAlert2.
