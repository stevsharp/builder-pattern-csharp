# Builder Pattern Demo (C# / .NET 9)

A clean, professional implementation of the **Builder** creational design pattern.

## The pattern

The Builder pattern separates the *construction* of a complex object from its
*representation*, so the same construction process can produce different products.

| Participant   | Role in this project                                                                 |
|---------------|--------------------------------------------------------------------------------------|
| **Product**   | The complex object under construction (the vehicle and its bill of materials).        |
| **IBuilder**  | Interface declaring the construction steps every concrete builder must implement.     |
| **Car**       | Concrete builder — assembles a `Product` as a car.                                    |
| **MotorCycle**| Concrete builder — assembles a `Product` as a motorcycle.                             |
| **Director**  | Controls the *order* of the build steps; delegates the work to an `IBuilder`.         |

### IBuilder steps

`StartUpOperations()` → `BuildBody()` → `InsertWheels()` → `AddHeadlights()` →
`EndOperations()` → `GetVehicle()`

The first five perform the work; `GetVehicle()` returns the finished product.

## Project layout

```
BuilderPatternDemo/
├── Builders/
│   ├── IBuilder.cs      # the builder interface
│   ├── Car.cs           # concrete builder
│   └── MotorCycle.cs    # concrete builder
├── Director/
│   └── Director.cs      # drives the construction sequence
├── Vehicles/
│   └── Product.cs       # the complex object being built
└── Program.cs           # client / demo entry point
```

## Run it

```bash
dotnet run
```

## Why the Director matters

Notice in `Program.cs` that the **same** `Director.Construct()` algorithm builds both a
car and a motorcycle. Only the concrete builder passed in changes — the construction
sequence lives in exactly one place.

## Connect with Me

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Profile-blue)](https://www.linkedin.com/in/spyros-ponaris-913a6937/)
