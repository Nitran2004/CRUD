# Proyecto Identity

Este proyecto es una aplicación web que implementa un sistema de autenticación y autorización. Si los usuarios no están logueados, no podrán acceder a ninguna de las operaciones CRUD y serán redirigidos automáticamente a la página de inicio de sesión.

## Características

- Sistema de autenticación y autorización.
- URLs protegidas que requieren iniciar sesión para acceder a cualquier funcionalidad CRUD.
- Redirección automática al login si el usuario intenta acceder a recursos sin estar autenticado.
- Gestión de usuarios y roles dentro del sistema.

## Requisitos

Para ejecutar este proyecto necesitas:

- [ASP.NET Core](https://dotnet.microsoft.com/download/dotnet-core)
- [Entity Framework](https://docs.microsoft.com/en-us/ef/core/)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
  
## Instalación

1. Clona el repositorio:

   git clone https://github.com/Nitran2004/ProyectoIdentity.git
2. Ve al directorio del proyecto:
    cd ProyectoIdentity
3. Configura la cadena de conexión a tu base de datos SQL Server en el archivo appsettings.json:
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;Trusted_Connection=True;MultipleActiveResultSets=true"
}
4. Ejecuta las migraciones de la base de datos:
  dotnet ef database update
5. Inicia la aplicación:

## Uso
Navega a la página principal del proyecto.
Intenta acceder a cualquier funcionalidad CRUD (como crear, leer, actualizar o eliminar registros).
Si no estás logueado, serás redirigido automáticamente a la página de inicio de sesión.
Después de iniciar sesión, podrás acceder a las operaciones de CRUD disponibles para tu rol de usuario.

## Tecnologías utilizadas
ASP.NET Core para el backend y manejo de autenticación.
Entity Framework para la gestión de la base de datos.
Bootstrap para el diseño responsivo del frontend.

## Contribución
Si deseas contribuir al proyecto, sigue estos pasos:

Haz un fork del proyecto.
Crea una rama para tu funcionalidad (git checkout -b nueva-funcionalidad).
Realiza tus cambios y haz un commit (git commit -m 'Agrega nueva funcionalidad').
Sube tu rama (git push origin nueva-funcionalidad).
Abre un Pull Request.
## Licencia
Este proyecto está licenciado bajo la licencia MIT. Ver el archivo LICENSE para más detalles.

Este es el contenido completo del archivo `README.md`, listo para que lo copies y uses en tu proyecto.

