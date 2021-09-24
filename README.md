# Exam
This is an example of  wheather application

# Backend
## startup
- configure the following properties in appsettings.json

### connection string
the connection string to MSSQL database
```
ConnectionStrings.ExampleContext
ConnectionStrings.Elmah
```
### Hosts allowed
```
CorsOptions.AllowedHosts
CorsOptions.AllowedPorts
CorsOptions.AllowedProtocols
```
### Open API data
```
OpenWheater.APIKey
OpenWheater.APILink
```

## Ejecute
Compile solution and run API proyect

This project have a swagger definition. You can see it at `https://localhost:44350/swagger/index.html`

# Frontend

## startup
execute
```bash
npm install
```
## Ejecute
```bash
npm run start
```
open 
```
http://localhost:4200/
```