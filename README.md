# Recipe Application – Part 1

## 1. Project Overview

The Recipe Application is a standalone C# console application developed using Visual Studio and .NET 8. The application was created as part of a Portfolio of Evidence based on a case study about Sanele, who wants to learn how to prepare different meals.

The purpose of the application is to allow users to create, view and manage a recipe by entering ingredients, quantities, units of measurement and preparation instructions.

The application also allows users to scale ingredient quantities, reset quantities to their original values and clear existing recipes.

## 2. Technologies Used

- **Programming Language:** C#
- **Development Environment:** Visual Studio
- **Framework:** .NET 8
- **Application Type:** Console Application
- **Version Control:** Git and GitHub

## 3. Application Features

The application provides the following functionality:

1. **Enter a New Recipe:** Allows users to enter a recipe name, the number of ingredients, ingredient names, quantities, units of measurement and preparation steps.

2. **Display Recipe:** Displays the complete recipe, including all ingredients and numbered preparation instructions.

3. **Scale Recipe:** Allows users to adjust ingredient quantities using three scaling options:
   - 0.5 – Half the original quantity.
   - 2 – Double the original quantity.
   - 3 – Triple the original quantity.

4. **Reset Quantities:** Restores all ingredient quantities to their original values.

5. **Clear Recipe:** Removes the current recipe and allows the user to enter a new one.

6. **Exit Application:** Closes the console application.

## 4. Project Structure

The project is organised into the following files:

- **Program.cs:** Contains the main application, menu, user input handling and application functionality.
- **Models/Ingredient.cs:** Defines the Ingredient class, including its name, quantity, unit of measurement and original quantity.
- **Models/Recipe.cs:** Defines the Recipe class and manages recipe information, ingredient arrays, preparation steps, displaying, scaling and resetting quantities.
- **RecipeApplication.csproj:** Contains the project configuration.

## 5. Programming Concepts Implemented

The following programming concepts were applied:

- Classes and objects.
- Automatic properties.
- Arrays for storing ingredients and preparation steps.
- Methods for organising application functionality.
- Loops for collecting and displaying information.
- Conditional statements and switch cases.
- String manipulation and formatting.
- User input and output using Console.ReadLine() and Console.WriteLine().
- Input validation.
- XML documentation comments explaining methods, parameters and functionality.

## 6. How to Compile and Run the Application

### Requirements

Before running the application, ensure that you have:

- Visual Studio 2022 or a compatible IDE.
- .NET 8 SDK installed.

### Using Visual Studio

1. Download and extract the project ZIP file.
2. Open the extracted project folder.
3. Open `RecipeApplication.csproj` in Visual Studio.
4. Allow Visual Studio to restore the project dependencies.
5. Select **Build > Build Solution**.
6. Press **Ctrl + F5** to run the console application.

### Using the .NET CLI

Alternatively, open a terminal in the directory containing `RecipeApplication.csproj` and execute:

```bash
dotnet restore
dotnet build
dotnet run
```

## 7. Data Storage

The application stores recipe information in memory using arrays and objects.

No database or external storage system is used. Recipe information is temporary and is automatically lost when the application is closed, as required by the assessment specifications.

## 8. GitHub Repository

The source code for this project is maintained using GitHub.

**GitHub Repository:** [Insert your GitHub repository URL here]

The repository contains the project source code and development commit history.

The required submission tag for this assessment is:

`Part1`

## 9. Author

**Name:** Vuyo Yapi

**Project:** Recipe Application – Part 1

**Language:** C#

**Institution:** Rosebank College

---

*This project was developed for academic assessment purposes as part of a Software Development Portfolio of Evidence.*
