# 💼 ConsultTech Manager

Application web de gestion pour une société de consulting IT, permettant de gérer les **consultants**, leurs **missions**, les **clients** et les **compétences**.

---

## 📋 Contexte du Projet

**ConsultTech** est une entreprise de consulting IT de taille moyenne comptant environ 50 consultants.  
L’objectif de cette application est de centraliser et automatiser la gestion des missions, compétences et disponibilités, afin d’éliminer les processus manuels basés sur Excel et emails.

---

## 🚀 Objectif de l’application

Créer une **application web complète** de gestion qui permet :

### 👨‍💻 Gestion des Consultants
- Enregistrer les informations de chaque consultant (nom, prénom, email, date d’embauche)
- Gérer leur portefeuille de compétences avec les niveaux d’expertise
- Visualiser leur historique de missions
- Identifier rapidement leur disponibilité

### 🧠 Gestion des Compétences
- Répertorier toutes les compétences techniques (langages, frameworks, outils, méthodologies)
- Catégoriser les compétences (Développement, Infrastructure, Data, Soft Skills)
- Définir des niveaux d’expertise (Débutant, Intermédiaire, Avancé, Expert)

### 🏢 Gestion des Clients
- Enregistrer les informations des clients (nom de l’entreprise, secteur d’activité, adresse, contact)
- Suivre l’historique des missions réalisées pour chaque client

### 📅 Gestion des Missions
- Créer une mission avec : titre, description, dates de début/fin, budget estimé
- Affecter un consultant à une mission
- Lier la mission à un client

---

## 👥 Utilisateurs Cibles

- **Responsables RH** : Gestion des consultants et de leurs compétences  
- **Managers** : Affectation des consultants aux missions et suivi des clients

---

## ⚙️ Technologies utilisées

| Type | Outil / Framework |
|------|--------------------|
| Backend | ASP.NET Core (.NET 9) |
| Frontend | Razor Pages / Blazor / ASP.NET MVC |
| Base de données | SQL Server / Entity Framework Core |
| Outils | Visual Studio |

---

## 🧱 Architecture

L’application suit une architecture inspirée de la **Clean Architecture** :

Cette approche garantit une **séparation claire des responsabilités**, une **évolutivité** et une **maintenabilité** à long terme.

---

## 🧰 Prérequis

- [.NET SDK 9.0+](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/sql-server)
- [Visual Studio 2022](https://visualstudio.microsoft.com/)
- Git (optionnel)

---

## 🏗️ Installation et exécution

### 1. Cloner le dépôt
```bash
git clone https://github.com/bipblop555/ConsulTech.git
```

Créer une nouvelle propriété de démarrage multiple pour lancer l'API ainsi que le WEB simultanément

## 🗄️ Base de données (SQL Server)

### 🧩 Schéma général

Le projet utilise **Microsoft SQL Server** comme base de données principale.

Voici les tables et leurs relations principales :

- **Categories** : Liste des catégories de compétences (ex. Développement, Infrastructure…)
- **Niveaux** : Définit le niveau de maîtrise d’une compétence (Débutant, Intermédiaire, Expert…)
- **Competences** : Compétences techniques ou fonctionnelles (liées à une catégorie et un niveau)
- **Consultants** : Employés du cabinet (avec leur statut et date d’embauche)
- **CompetenceConsultant** : Table d’association entre les consultants et leurs compétences
- **Clients** : Entreprises clientes du cabinet
- **Missions** : Projets réalisés pour les clients (liés à un client et éventuellement un consultant)

Modifiez la phrase de connection selon vos besoins

```cs
builder.Services.AddDbContext<ConsultTechContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConsultTechDbContext")));
```
La database, ainsi que les tables sont générés en **Code First** au lancement de la commande dotnet ef ci-dessous.
Une fois à la racine du projet lancez cette commande afin de créer la database et les tables.

```bash
dotnet ef database update -p .\ConsulTech.Core\ -s .\ConsulTech.Api
```