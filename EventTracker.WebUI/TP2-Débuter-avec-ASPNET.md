# TP 2 – Débuter-avec-ASPNET
---
#### Objectif
Développer une application web avec ASP.NET Core pour afficher et gérer les événements de manière interactive.
---
## Développement .Net - C#
## Découverte d'ASP.NET
---
- ##### Basé sur le TP1
- ##### Ajout d'un projet de type Application Web ASP.NET
- ##### Création de la première View
- ##### Utilisation de TagsHelper
- ##### Ajout, Modification d'un Layout
- ##### Librairies externes
- ##### Liens avec les données
---

#### Étapes 

---

**0.** Pré-requis : Avoir le TP1 fonctionnel avec :
- Récupération et affichage de plusieurs événements depuis `Events.json`
- Interface `IEventDataSource` dans `EventDataSource` pour la gestion des événements

---

**1.** Création d'un projet **"ASP.NET Core Web App (Model-View-Controller)"**, nommé `EventTracker.WebUI` :
- ATTENTION A BIEN CHOISIR LE BON TYPE DE PROJET, ne pas hésiter à valider avec le formateur
- Authentification : None
- Configure for HTTPS: Yes
- Enable Docker: No
- Définir le projet comme projet de démarrage

> **Note** : Lors du premier lancement, Visual Studio peut vous proposer d'installer un certificat SSL de développement, c'est normal.

---

**2.** Étude du fichier `Program.cs` :
   - Analysez le code généré pour comprendre les configurations et leur utilité.

---

**3.** Étude du `HomeController` généré sous **"EventTracker.WebUI/Controllers"** :
   - Trois `IActionResult` : `Index`, `Privacy`, `Error`
   - Les vues associées sont dans des dossiers `Views/NOM_DE_L'ACTION`
   - Que se passe-t-il dans le fichier `Shared/_Layout.cshtml` ? 
   - Quelle est son utilité ?

---

**4.** Découverte du `ViewData`/`ViewBag` :
   - Qu'est-ce que le `ViewBag` et pourquoi est-ce déconseillé ?
   - Affectez une valeur au `ViewBag` dans le contrôleur.
   - Affichez cette valeur

---

**5.** Création d'un `HomeViewModel` :
   - Créez un `HomeViewModel` dans un dossier de la webapp `ViewModels` avec les propriétés `PageTitle` et `WelcomeMessage`.
   - Initialisez ce modèle dans le contrôleur et transmettez-le à la vue.
   - Affichez ces données dans la vue.

   - Déplacer le `ErrorViewModel` présent dans le dossier `Model` et supprimer `Model` créé par le framework pour ranger bien les choses.
   - Modifier `_ViewImports.cshtml` en conséaquence:
     ```razor
         @using EventTracker.WebUI
         @using EventTracker.WebUI.ViewModels
         @addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers  
      ```
   - Compiler et corriger les erreurs liées au déplacement de ce model

---

**6.** Création d'un contrôleur `EventController` sous "EventTracker.WebUI/Controllers" :
   - Créez un nouveau contrôleur nommé `EventController`.
   - Ajoutez un constructeur (raccourci `ctor`).
   - Ajoutez une action `Index` (vide pour l'instant) et une vue associée.

---

**7.** Modification de `Program.cs` pour définir `EventController` comme contrôleur par défaut.

---

**8.** Modification du menu principal :
   - Ajoutez une nouvelle entrée au menu principal pointant vers `EventController` et sa vue `Index`.

---

**9.** Découverte de la commande `dotnet` :
   - Ouvrez une console dans le dossier de la solution.
   - Exécutez la commande :
   ```bash
   setx ASPNET_ENVIRONMENT "Development"
   ```
   - Ensuite, explorez les options disponibles avec :
   ```bash
   dotnet -h
   ```
   - Exécutez le projet avec la commande (dans le dossier de la solutioncd):
   ```bash
   dotnet run --project EventTracker.WebUI
   ```

---

**10.** Récupération des données via le `EventDataSource` du TP1 :
   - Créer un `EventViewModel` qui centralisera les données a afficher sur la page
   - Utilisez le `EventDataSource` pour charger les événements.
   - Convertir la liste d'`EventModel` en liste d'`EventViewModel` (trouver le meilleur moyen, le plus clean)
   - Centralisez les données dans un `EventIndexViewModel` contenant une liste d'`EventViewModel` et une propriété `PageTitle`.
   - Retournez ce modèle à la vue `Index` du `EventController`.
   - Affichez les données de manière structurée avec Bootstrap pour une mise en page propre.

---

**11.** Découverte des `TagHelpers` et des vues partielles (`Partials`) :
   - Créez une vue partielle `_EventRow` un événement, cette vue partielle sera appellée en boucle pour afficher un élément dans la liste
   - Utilisez des `TagHelpers` pour intégrer Bootstrap et gérer l'affichage dynamique des données.
   - **Documentation** : [Partial Views in ASP.NET Core](https://www.dotnettricks.com/learn/aspnetcore/partial-views-and-view-components)


---

**12.** Ajout de dépendances externes :
   - **[Visual Studio uniquement]** Utilisation de LibMan pour la gestion de bibliothèques front-end :
      - Clic droit sur le projet `WebUI`, "Add" → "Client-Side Library".
      - Choisir une bibliothèque CSS et une JS (au choix) à ajouter (par exemple: Animate.css).
   - Vérification du fichier `libman.json`.
   - Vérification de la présence de `app.UseStaticFiles()` dans `Program.cs`.
   - Intégration des bibliothèques ajoutées dans le layout (`_Layout.cshtml`), idéalement près du `</footer>`.
   - Recherche/Explication: Utilisation de `RenderSectionAsync()` pour appeler/utiliser la section `Scripts` dans une vue spécifique.
   - Testez l’intégration des bibliothèques installées.

---

Pour rendre l'étape 3 plus intéressante, remplaçons le `TagHelper` initial par un `TagHelper` qui affiche une "carte événement" stylisée avec les détails d'un événement, plutôt que de se limiter à une simple zone de texte.

### 13 : Création d'un `TagHelper` "EventCard"

Ce `TagHelper` va afficher une carte (card) d’événement avec des informations stylisées, comme le nom, la date, le lieu, et une brève description de l’événement.

---

### 14 : Création d’un dossier `TagHelpers` : 
   - Dans le projet `EventTracker.WebUI`, ajoutez un dossier nommé `TagHelpers`.

---

### 15 : Création de la classe `EventCardTagHelper` :
   - Ajoutez une classe `EventCardTagHelper.cs` dans le dossier `TagHelpers`, et configurez-la pour hériter de `TagHelper`.
   - Le `TagHelper` prendra en charge les propriétés de `EventModel`, comme `Name`, `Date`, `Location`, et `Description`.
        Voici un exemple de code pour `EventCardTagHelper` :

        ```csharp
        using Microsoft.AspNetCore.Razor.TagHelpers;
        using System;

        public class EventCardTagHelper : TagHelper
        {
            [HtmlAttributeName("name")]
            public string Name { get; set; }

            [HtmlAttributeName("date")]
            public DateTime Date { get; set; }

            [HtmlAttributeName("location")]
            public string Location { get; set; }

            [HtmlAttributeName("description")]
            public string Description { get; set; }

            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                output.TagName = "div";
                output.Attributes.SetAttribute("class", "card shadow-sm mb-4");

                output.Content.SetHtmlContent($@"
                    <div class='card-body'>
                        <h5 class='card-title text-primary'>{Name}</h5>
                        <h6 class='card-subtitle mb-2 text-muted'>{Location}</h6>
                        <p class='card-text'>{Description.Substring(0, Math.Min(50, Description.Length))}...</p>
                        <p class='card-text'><small class='text-muted'>Date : {Date:dd MMM yyyy}</small></p>
                    </div>
                ");
            }
        }
        ```
    
    - **Enregistrement du `TagHelper` dans `_ViewImports.cshtml`** :
    - Ouvrez le fichier `_ViewImports.cshtml` (situé dans le dossier `Views`) et ajoutez la ligne suivante pour enregistrer le `TagHelper` :

        ```razor
        @addTagHelper *, EventTracker.WebUI
        ```

    - **Utilisation du `EventCardTagHelper` dans la vue partielle `_EventRow`** :
    - Dans la vue `_EventRow.cshtml`, utilisez le nouveau `TagHelper` pour chaque événement au lieu de coder les balises manuellement.
    - Appelez le `TagHelper` avec les propriétés appropriées

---

### 16 : Création d’un formulaire d’ajout d’événement avec `HttpGet` et `HttpPost` :
   - Dans `EventController`, ajoutez une action `Add` avec `[HttpGet]` pour afficher le formulaire :

     ```csharp
     [HttpGet]
     public IActionResult Add()
     {
         return View();
     }
     ```

   - Créez un `AddEventViewModel` avec une propriété `EventToAdd` de type `EventModel`.
   - Créez une vue `Add.cshtml` qui utilise `AddEventViewModel` et qui lie les champs de `EventToAdd` à un formulaire :

     ```razor
     <form method="post" asp-action="Add" asp-controller="Event">
         <div class="form-group">
             <label asp-for="EventToAdd.Name"></label>
             <input asp-for="EventToAdd.Name" class="form-control" />
         </div>
         <!-- Ajouter les autres champs ici -->
         <button type="submit" class="btn btn-primary">Ajouter l'événement</button>
     </form>
     ```

   - Modifiez `_Layout.cshtml` pour ajouter un lien vers le formulaire d’ajout dans le menu.
   - Ajoutez une action `Add` avec `[HttpPost]` dans `EventController` pour traiter la soumission du formulaire.

     ```csharp
     [HttpPost]
     public IActionResult Add(AddEventViewModel model)
     {
         if (ModelState.IsValid)
         {
             // Traitement de l'ajout de l'événement
         }
         return View(model);
     }
     ```

---

### 17 : Ajout de validation avec `DataAnnotations` :

   - Ajoutez des annotations dans `EventModel` pour valider les champs. Exemple :

     ```csharp
     [Required]
     [StringLength(50, ErrorMessage = "Le nom ne peut dépasser 50 caractères")]
     public string Name { get; set; }
     ```

   - Utilisez `ModelState` pour vérifier la validité des données dans `Add`.
   - Ajoutez le script de validation dans `Add.cshtml` pour activer la validation côté client :

     ```razor
     <partial name="_ValidationScriptsPartial" />
     ```

   - Affichez les erreurs de validation dans le formulaire :

     ```html
     <div asp-validation-summary="All"></div>
     ```

---

### 18 : Ajout d’une liste de localisations :
   - Dans le `AddEventViewModel`, ajoutez les propriétés `LocationId` de type int et `LocationsAvailable` de type `IList<SelectListItem>` pour permettre la sélection de localisations.
   - Initialisez `LocationsAvailable` dans `EventController` pour fournir une liste de localisations disponibles.
   - Utilisez un `select` avec le `TagHelper` pour afficher la liste déroulante :

     ```html
     <select asp-for="EventToAdd.LocationId" asp-items="Model.LocationAvailable" class="form-control"></select>
     ```

---

### 19 : Ajouter l’injection de dépendances :
   - Dans `EventTracker.WebUI`, ajoutez une classe `ServicesExtensionMethods.cs` pour configurer l’injection de dépendances pour `IEventDataProvider` :

     ```csharp
     public static class ServicesExtensionMethods
     {
         public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
         {
             services.AddScoped<IEventDataProvider, EventDataProvider>();
             return services;
         }
     }
     ```

   - Dans `Program.cs`, ajoutez la ligne suivante pour enregistrer les services :

     ```csharp
     builder.Services.AddDependencyInjection();
     ```

   - Modifiez le constructeur de `EventController` pour utiliser l’injection de dépendances :

     ```csharp
     private readonly IEventDataProvider eventDataProvider;

     public EventController(IEventDataProvider eventDataProvider)
     {
         this.eventDataProvider = eventDataProvider;
     }
     ```

---

### 20 : Pour aller plus loin :
   - **Configuration** : Explorez la configuration dans ASP.NET Core : https://docs.microsoft.com/fr-fr/aspnet/core/fundamentals/configuration/
   - **Installer SQL Server Developer** via Docker.
   - **Entity Framework** : Étudiez la mise en place d’Entity Framework pour une gestion de données avancée : https://docs.microsoft.com/fr-fr/ef/core/get-started/overview/install
