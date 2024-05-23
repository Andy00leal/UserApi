# UserApi

_UserApi es una prueba de API REST desarrollada en ASP.NET Core, que utiliza PostgreSQL como base de datos. La API permite gestionar usuarios, países, departamentos y municipios.

## Requisitos
* .NET 6 SDK o superior
* PostgreSQL

## Configuración
1. Clona el repositorio:
```
git clone https://github.com/tu-usuario/UserApi.git
cd UserApi
```

2. Configura la cadena de conexión en appsettings.json:
```
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
```

3. Restaura los paquetes:
```
dotnet restore
```

4. Ejecuta la aplicación:
```
dotnet run
```

## Endpoints
* http://localhost:5228/api/user
* http://localhost:5228/api/country
* http://localhost:5228/api/department
* http://localhost:5228/api/municipality
  
## Notas
Asegúrate de que PostgreSQL esté en ejecución y que la cadena de conexión en appsettings.json esté correctamente configurada.
La base de datos se debe inicializar con el archivo script.sql.
