# Trade Categorization System
Credit Suisse - IT C#.NET Developer Test

# Description
This project is a .NET-based system designed for categorizing bank trades with a focus on scalability, maintainability, and flexibility.
Utilizing the principles of Object-Oriented Programming (OOP) and adhering to SOLID principles, it showcases an implementation of Domain-Driven Design (DDD) to efficiently manage and categorize trades in a banking portfolio.

# Features

# Dynamic Trade Categorization:
Leverages a strategy pattern to categorize trades into predefined categories such as EXPIRED, MEDIUMRISK, and HIGHRISK based on the trade's value, the client's sector and payment date.
This system is designed to easily accommodate new categories or modification of existing ones without impacting the core functionality.

# Design Pattern Implementation:
Utilizes several design patterns including Strategy and Factory, to ensure the system's extensibility and maintainability.

# Answer for Question 2:
To accommodate the new PEP (Politically Exposed Person) category within the existing design, it would need to create a new class that implements the `ITradeCategoryStrategy` interface, let's call it `PEPStrategy`. This class should contain the logic to determine if a trade falls into the PEP category by overriding the `IsMatch` method to return true if the `IsPoliticallyExposed` property of the `ITrade` instance is true. Additionally, it would need to update the `TradeCategoryStrategyFactory` class to include an instance of this new `PEPStrategy` class in its strategies dictionary. This ensures that when the `CategorizeTrades` method iterates through the trades, it can correctly identify and categorize trades that are politically exposed. This approach aligns with the principles of object-oriented programming and the use of the Strategy pattern, allowing for easy extension and maintenance of the categorization logic.
