![marvel](https://user-images.githubusercontent.com/111800846/196658259-7181313e-821f-440e-8726-91ed776492e7.jpg)



# Superhero API : Group project
The aim of this project is to develop an API project solution in C# by implementing object-oriented principles with well designed, extendable, readable and well tested code. Our Superhero Combat API integrates with a free public API https://superheroapi.com/ and gets statistics for comic book heroes so that they face each other in combat!

# Instructions
## Pre-Requisites
The machine running the application should have .NET 6.0 (or above) installed, with the following technologies & Dependencies:
- ASP.NET Core MVC 6 (Web API Project)
- Moq
- Postman or Swagger
- Entity Framework Mirgrations
- NuGet
- NUnit testing framework
- Visual Studio 2022

To run the application:

- Clone the repository to your computer
- Run the application, for example on Visual Studio
- After swagger loads with the API, feel free to enter two superhero names and your chosen battlefield. 
- Execute to let the battle begin!

# Key Features
There are two GET endpoints:
### 1) GetSuperheroes - enter a name
- This enables the user to check if a superhero exists. If yes, they can view the superhero's powerstats, eg:

```
  {
    "name": "Plastic Man",
    "realName": "Patrick O'Brian",
    "combat": 56,
    "durability": 100,
    "intelligence": 50,
    "power": 100,
    "speed": 23,
    "strength": 63
  }
 ```
- In the case of duplicates, the user can then see the different 'realName' of the superheroes and specify the intended one in the Combat end point.

### 2) Combat endpoint - enter a battlefield and two superhero names (optional real names)
- Valid battlefields are:
```
Volcano, Area51, HighGPlanet, Multiverse, BankVault, OpenField
```

- In the case where there are multiple superheroes of the same name returned, you will then have to input your chosen [more specific] superhero by putting the Real Name, for example:
![image](https://user-images.githubusercontent.com/111430146/198313003-db69c91e-d5ab-4fc3-8890-3190d837309e.png)
- The win margin is:
```
CloseCall, SolidWin, NoChance, Tie
```
# Assumptions
The superhero exists!
# Approaches
## Design
There are 3 layers: The Controller, The Service and The Repository
The controller - 
The Service layer checks the validity of the battlefield and handles the battle.  The Combat Handler 
Repo - communicates with the external API and filters the data returned, also handles exceptions (duplication error, API data returned errors). Converts JSON to datamodel.

## Class Diagram
![image](https://user-images.githubusercontent.com/111430146/199102391-4cebccfd-d234-4d6a-9ca5-09bb4c2f7682.png)

## Flow Diagram
This is the Combat Flow diagram:
![Combat Code Flow](https://user-images.githubusercontent.com/111430146/199102930-69156113-3cab-4e6c-8437-cada5b7523e4.jpg)


# Future Considerations
## Team Combat
It would be interesting to be able to make teams of more than one superhero, and have them fight against each other.
## Build A Database For Statistics
Collect and analyse who is the most popular requested superhero, or which superhero wins the most/least.
## Build A Front-End
Have an eye-catching, easy to use front-end that enables the user to see what powerstats a chosen superhero has, or in the case of duplicates, an easy option to choose which one they mean.

