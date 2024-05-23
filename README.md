# UserApi
Descripción
UserApi es una prueba de API REST desarrollada en ASP.NET Core, que utiliza PostgreSQL como base de datos. La API permite gestionar usuarios, países, departamentos y municipios.

Requisitos
.NET 6 SDK o superior
PostgreSQL
Configuración
Clona el repositorio:

sh
Copiar código
git clone https://github.com/tu-usuario/UserApi.git
cd UserApi
Configura la cadena de conexión en appsettings.json:

json
Copiar código
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=YourDatabaseName;Username=YourUsername;Password=YourPassword"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
Restaura los paquetes:

sh
Copiar código
dotnet restore
Aplica las migraciones a la base de datos:

sh
Copiar código
dotnet ef database update
Ejecuta la aplicación:

sh
Copiar código
dotnet run
Endpoints
http://localhost:5228/api/user
http://localhost:5228/api/country
http://localhost:5228/api/department
http://localhost:5228/api/municipality
Notas
Asegúrate de que PostgreSQL esté en ejecución y que la cadena de conexión en appsettings.json esté correctamente configurada.
La base de datos se debe inicializar con el archivo script.sql.
