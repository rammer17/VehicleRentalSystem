# Vehicle Rental System

## Approach
The system follows key principles and patterns:

### Factory Design Pattern
The factory pattern is used to create instances of different types of vehicles. This design pattern helps in encapsulating the instantiation logic and makes the codebase more modular and scalable. The `VehicleFactory` class is responsible for creating vehicle objects based on the input type.

### Inheritance
The inheritance principle is used to define a base class `Vehicle` with common properties and methods. Specific vehicle types like `Car`, `CargoVan`, and `Motorcycle` inherit from the `Vehicle` class, allowing them to have unique properties and behaviors while sharing common functionality.

### Key Classes
- **Vehicle**: The base class for all vehicle types, containing common attributes such as `Brand`, `Model`, `RentalStartDate`, and `RentalPeriod`.
- **Car, CargoVan, Motorcycle**: Derived classes that inherit from `Vehicle`, each representing a specific type of vehicle with additional attributes if needed.
- **VehicleFactory**: A factory class responsible for creating instances of different vehicle types.
- **Invoice**: A class that handles the generation of rental invoices, calculating costs, and formatting output.

## Project Structure
- **VehicleRentalSystem.sln**: Solution file for the project.
- **Program.cs**: Main entry point of the application.
- **Vehicle.cs**: Base class for vehicles.
- **Car.cs, CargoVan.cs, Motorcycle.cs**: Derived classes for specific vehicle types.
- **VehicleFactory.cs**: Factory class for vehicle creation.
- **Invoice.cs**: Class for generating rental invoices.