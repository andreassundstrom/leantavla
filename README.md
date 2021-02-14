# Leantavla
Projektet skapar en modell för förbättringsarbete.
## Kom igång
Konfigurera appsettings.json:
````json
"ConnectionStrings": {
        "Leantavla": "Server=localhost;Database=Leantavla;Trusted_Connection=True;"
    }
````

Skapa/uppdatera databasen
````
PM> Update-database
````
## Bygg och starta med docker-compose
Använd docker-compose filen för att bygga och starta applikationen.
Applikationen skapar en container för webapplikationen och en sql-server 
container.

Sätt ett lösenord till databasen i applikationen. För att starta migrering/skapa databas
anropa ändpunkten `api/migrations`.

Exempel i `appsettings.json`:
````JSON
"ConnectionStrings": {
        "Leantavla": "Server=db;Database=Leantavla;User=SA;Password=Your_password123;"
    }
````

Exempel i `docker-compose.yml`:
````yml
    db:
        image: "mcr.microsoft.com/mssql/server:2019-latest"
        environment:
            SA_PASSWORD: "Your_password123"
            ACCEPT_EULA: "Y"
        ports:
````