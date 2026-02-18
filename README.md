## BellaVista Web - Prueba Técnica

Proyecto desarrollado como parte de prueba técnica.

Sistema web para la gestión de productos de café, implementando arquitectura MVC + API REST con SQL Server.

---

## Tecnologías Utilizadas

- .NET 8 / ASP.NET Core MVC
- API REST
- SQL Server 2022
- ADO.NET
- Bootstrap 5
- Git (flujo con ramas)

## Estructura de Ramas (Git Flow)

- `main` → versión estable
- `develop` → integración de features
- `feature/api-productos`
- `feature/productos-crud`

## Base de Datos

Los scripts se encuentran en la carpeta:

## /Database


## Archivos:

- schema.sql → estructura de tablas
- seed.sql → datos de prueba

## Cómo ejecutar

1. Crear base de datos en SQL Server:
 sql
CREATE DATABASE BellaVistaDB;
Ejecutar:

-- schema.sql
-- seed.sql

## Configuración

Editar el archivo:
appsettings.json

## Actualizar cadena de conexión:

"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=BellaVistaDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

## Cómo Ejecutar el Proyecto

En la carpeta raíz del proyecto:

dotnet restore
dotnet build
dotnet run


Abrir en el navegador:
http://localhost:5235/Productos

## Funcionalidades Implementadas

CRUD completo de productos
API REST (GET, POST, PUT, DELETE)
Frontend MVC basado en el diseño solicitado
Validaciones
Manejo de ramas con Git

Endpoints API

Base URL:
http://localhost:5235/api/ProductosApi

GET /api/ProductosApi
POST /api/ProductosApi
PUT /api/ProductosApi/{id}
DELETE /api/ProductosApi/{id}

## Autor

Nombre: Allan Garcia
Prueba Técnica - 2026
