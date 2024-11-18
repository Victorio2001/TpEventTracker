### TP 1 - EventTracker

#### Objectif
Prendre en main Visual Studio et explorer les concepts de base du développement .NET en C# en créant un outil de gestion d’événements et d’inscriptions.
---
#### Technologies
- **.NET 8**, **C#**, **JSON**, **Git**
---
## Prise en main de Visual Studio
## Développement .Net - C#
---
- ##### Création d'une Application console
- ##### Algorithmie
- ##### Découpage en couches applicatives
- ##### Premier apercu du Framework .NET 6
- ##### Utilisation du gestionnaire de package NuGet 
- ##### Lien avec GIT
---
#### Cas pratique : Transformer un fichier JSON en objet et le manipuler
---

#### Étapes du TP

0. **Intégration avec Git** : 
   - Commit pour chaque étape, gestion des versions et des branches pour les fonctionnalités supplémentaires

1. **Créer une solution de type application console**
   - **Nom de la solution** : EventTracker
   - **Nom du projet** : EventTracker.Console
   - Ajout de la ligne `Console.ReadLine();` pour éviter que la console se ferme de suite

2. **Première compilation de test**

3. **Création du projet `EventTracker.DataSource` dans la solution `EventTracker`**
   - Type : Bibliothèque de classes
   - Rôle : Fournir des données d'événements et d'information streaming, chargées depuis un fichier JSON
   - Création d'un dossier **"JsonFiles"** pour y stocker un fichier **"Event.json"**

4. **Création des modèles d'événements et de information streaming**
   - Création d’un projet `EventTracker.Model` dans la solution `EventTracker`
   - Création des odèles : `EventModel` et `LocationModel` avec propriétés les propriétés présentes dans le JSON (attention aux règles de nommage)
   - Par défault, la classe est `internal`, modifier l'accès en `public`
   - Lien avec les champs JSON via des attributs comme `[JsonPropertyName]`
   - Recherche sur les différents type à donner aux champs: https://learn.microsoft.com/fr-fr/dotnet/csharp/language-reference/builtin-types/integral-numeric-types


5. **Développement du DataSource**
   - Installer la dépendance au projet `EventTracker.Model` dans le projet `EventTracker.DataSource`
   - Création d'une interface `IEventDataSource` pour la gestion des événements, dans un dossier Interfaces
   - Déclarer une méthode `GetEventFromJSON()` retournant un`EventModel` dans cette interface
   - Création d'une classe DataSource `EventDataSource` en la faisant hériter de l'interface
   - Implémentation de la méthode `GetEventFromJSON()` pour:
      - Charger les événements depuis un fichier JSON
      - Transformer le json en objets définis par les modèles
      - Gestion des erreurs en lancant des exceptions
      - Renvoi de l'objet

   - Documentatiosn utiles  
      - Manipulation JSON : https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/how-to
      - Gestion des exceptions et erreur : https://learn.microsoft.com/fr-fr/dotnet/csharp/fundamentals/exceptions/creating-and-throwing-exceptions


6. **Modification de Program.cs dans le projet Console**
   - Installer les dépendances auc projets `EventTracker.Model` et `EventTracker.DataSource` dans le projet `EventTracker.Console`
   - Afficher les événements
   - Création d'une méthode pour afficher les données formatées
   - Tests et affichage


7. **Création d'un projet de test unitaire**

- Ajouter un nouveau projet de type "xUnit Test Project" à la solution :
- Nom du projet : `EventTracker.Tests`
- Création d'une classe de test `EventDataSourceTests.cs` dans le projet EventTracker.Tests
- Développer un test unitaire utile et ayant du sens de la méthode `EventDataSource.GetEventFromJSON()`

- Documentation utile pour les tests unitaires : https://learn.microsoft.com/fr-fr/dotnet/core/testing/unit-testing-with-dotnet-test


8. **Pour aller plus loin**
   - Complexificaiton JSON et des modèles, récupération d'une liste d'events
   - Passer au Json `Events.json` pour passer sur une liste d'objets et modifier le code pour que cela fonctionne
   - Commencer à installer SSMS et Docker Desktop  

