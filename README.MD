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
## 1) GetSuperheroes - enter a name
- This enables the user to check if a superhero exists. If yes, they can view the superhero's powerstats, eg:

```{
      "id": "620",
      "name": "Spider-Man",
      "powerstats": {
        "intelligence": "90",
        "strength": "55",
        "speed": "67",
        "durability": "75",
        "power": "74",
        "combat": "85"
      },
 ```
- In the case of duplicates, the user can then see different 'full-names' of the superhero and then specify the intended one in the Combat end point.

## 2) Combat endpoint - enter a battlefield and two superhero names
- The battlefields are:

- The win margin is:

# Assumptions
The superhero exists!
# Approaches
## Class Diagram
- Pradeepa
## Flow Diagram
This is the initial flow:
![Code Flow](https://user-images.githubusercontent.com/111430146/196816535-ffc2abeb-2b5f-4d80-9b08-034d03b572c9.jpg)

# Future Considerations
## Team Combat
It would be interesting to be able to make teams of more than one superhero, and have them fight against each other.
## Build A Database For Statistics
Collect and analyse who is the most popular requested superhero, or which superhero wins the most/least.
## Build A Front-End
Have an eye-catching, easy to use front-end that enables the user to see what powerstats a chosen superhero has, or in the case of duplicates, an easy option to choose which one they mean.

