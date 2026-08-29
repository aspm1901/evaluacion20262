# Portal de Solicitudes de Servicio Técnico - TecnoGas Hogar

**Evaluación Continua 1** | Programación I  
Aplicación web MVC desarrollada en **.NET 10 (C#)** con persistencia en **Entity Framework Core + SQLite**, control de versiones con **Git Flow en GitHub** y despliegue en la nube mediante **Docker en Render**.

---

## 📌 1. Descripción del Caso

**"TecnoGas Hogar"** es una empresa peruana dedicada al mantenimiento e instalación de artefactos a gas en el hogar (cocinas, termas, calentadores, revisión de fugas, etc.). Este portal web interno permite al personal de atención registrar de forma rápida y confiable las solicitudes de servicio que llegan de los clientes y consultarlas en un listado en tiempo real, evitando la pérdida de información de los registros tradicionales.

---

## 🚀 2. Características y Funcionalidades

- **Registro de Solicitudes (Insert):** Formulario intuitivo con validaciones obligatorias mediante DataAnnotations (`Cliente`, `Teléfono`, `Distrito`, `Tipo de Servicio` y `Descripción`).
- **Listado en Tiempo Real (Select):** Tabla dinámica con badges visuales para cada tipo de servicio, orden cronológico descendente y alertas de confirmación.
- **Persistencia SQLite:** Base de datos relacional ligera con migraciones automáticas generadas y aplicadas con Entity Framework Core.
- **Contenerización Docker:** Imagen multi-stage optimizada para producción con SDK y Runtime de .NET 10.
- **Despliegue en Render:** Web Service accesible mediante URL pública.

---

## 🛠️ 3. Tecnologías Utilizadas

- **Lenguaje / Framework:** C# 13, ASP.NET Core 10 (MVC)
- **ORM & Base de Datos:** Entity Framework Core 10.0 con SQLite (`tecnogas.db`)
- **Frontend / UI:** Razor Views, Bootstrap 5, Bootstrap Icons
- **Contenerización:** Docker (Multi-stage build)
- **Control de Versiones:** Git & GitHub (Git Flow con Pull Requests)
- **Plataforma de Despliegue (Hosting):** Render Web Services

---

## 🌿 4. Estrategia de Ramas en Git / GitHub

El proyecto sigue una estructura limpia y ordenada de control de versiones:

- `main`: Rama de producción lista para despliegue.
- `develop`: Rama de integración donde convergen las funcionalidades aprobadas.
- `feature/modelo-sqlite`: **(Pregunta 1)** Configuración de EF Core, entidad `SolicitudServicio`, DbContext y migración inicial `InitialCreate`.
- `feature/registro-solicitud`: **(Pregunta 2)** Controlador, acciones y vista Razor para el formulario de registro (`Insert`) con validación `ModelState`.
- `feature/listado-solicitudes`: **(Pregunta 3)** Vista y consulta LINQ asíncrona (`Select`) para listar las solicitudes en orden descendente.

### Flujo de Integración:
1. Creación de cada funcionalidad en su rama `feature/*`.
2. Apertura de Pull Request hacia la rama `develop`.
3. Merge de los Pull Requests hacia `develop`.
4. Merge final de integración de `develop` hacia `main`.

---

## 💻 5. Instrucciones para Ejecución Local

### Prerrequisitos:
- .NET 10 SDK instalado.
- Visual Studio Code o Visual Studio 2022/2026.

### Pasos:
1. Clonar el repositorio:
   ```bash
   git clone https://github.com/aspm1901/evaluacion20262.git
   cd evaluacion20262
   ```
2. Restaurar dependencias y herramientas:
   ```bash
   dotnet restore
   dotnet tool restore
   ```
3. Ejecutar la aplicación:
   ```bash
   dotnet run
   ```
4. Abrir en el navegador:
   ```
   http://localhost:5000 o https://localhost:7000
   ```
*(La base de datos SQLite `tecnogas.db` y las tablas se crean y migran automáticamente en el primer arranque).*

---

## 🐳 6. Contenerización y Despliegue en Render (Docker)

### Configuración del Dockerfile Multi-Stage:
El archivo `Dockerfile` en la raíz del proyecto está configurado para compilar y empaquetar la aplicación de manera autónoma:

```dockerfile
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["TecnoGasHogar.csproj", "./"]
RUN dotnet restore "TecnoGasHogar.csproj"
COPY . .
RUN dotnet publish "TecnoGasHogar.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TecnoGasHogar.dll"]
```

### Variables de Entorno en Producción:
| Variable | Valor | Descripción |
|---|---|---|
| `ASPNETCORE_URLS` | `http://+:8080` | Puerto en el que escucha la aplicación dentro del contenedor |
| `ASPNETCORE_ENVIRONMENT` | `Production` | Entorno de ejecución en producción |

### Pasos para el Despliegue en Render:
1. Iniciar sesión en [Render Dashboard](https://dashboard.render.com/).
2. Hacer clic en **New +** y seleccionar **Web Service**.
3. Conectar el repositorio de GitHub: `aspm1901/evaluacion20262`.
4. Configurar el servicio:
   - **Name:** `tecnogas-hogar` (o `evaluacion20262`)
   - **Branch:** `main`
   - **Runtime:** `Docker`
   - **Instance Type:** `Free`
5. Hacer clic en **Deploy Web Service**.
6. Render construirá la imagen Docker y publicará la aplicación en una URL accesible públicamente.

---

## 📝 7. Entregables

- **Repositorio GitHub:** [https://github.com/aspm1901/evaluacion20262](https://github.com/aspm1901/evaluacion20262)
- **URL Pública en Render:** `[Ingresar URL generada por Render aquí]`
