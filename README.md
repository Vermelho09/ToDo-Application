Bonjour !

Voici mon application pour votre défi technique.

J'ai créé :
  - un Frontend Angular 16 situé dans le dossier "Frontend/ToDo.WebApp";
  - une API .NET 6 que l'on peut ouvrir avec le fichier "ToDo-Project.sln";
  - une base de données SQL Server (contenant seulement une table), avec le script pour sa création situé dans "Database/Create All.sql".

J'ai créé le fichier "docker-compose.yml" et le Dockerfile pour le 'build' complet avec des dépendances, cependant, cela ne fonctionnait pas...

Alors, pour l'exécution directe, voici les informations:

- SQL:
  - Executer le fichier "Create All.sql";

- API: 
  - Il faut garantir l'accès au SQL Local à la base "Unimax" - SqlConnectionString : "Server=localhost;Database=Unimax;Trusted_Connection=True;" ou le changer sur l'API;
  - executer le profil "ToDo_API.Web";
  - ouvrir le https://localhost:7128/swagger


- Frontend: 
  - dans le chemin "Frontend/ToDo.WebApp" executer "ng serve";
  - ouvrir le https://localhost:4200;

De plus: API HealthCheck -> https://localhost:7128/health
