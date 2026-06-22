using BuilderPatternDemo.Builders;
using BuilderPatternDemo.Vehicles;
using Director = BuilderPatternDemo.Director.Director;

Console.WriteLine("=== Builder Design Pattern Demo ===");

// The client picks a concrete builder...
IBuilder carBuilder = new Car("Ford Mustang");
// ...and hands it to the Director, which knows the construction sequence.
Director carDirector = new(carBuilder);
Product car = carDirector.Construct();
car.Show();

// Same Director algorithm, a different concrete builder -> a different product.
IBuilder motorCycleBuilder = new MotorCycle("Honda CBR");
Director motorCycleDirector = new(motorCycleBuilder);
Product motorCycle = motorCycleDirector.Construct();
motorCycle.Show();

// ...and again for a truck. The Director never changes.
IBuilder truckBuilder = new Truck("Volvo FH16");
Director truckDirector = new(truckBuilder);
Product truck = truckDirector.Construct();
truck.Show();

Console.WriteLine("Notice: the Director ran the *same* steps in all cases —");
Console.WriteLine("only the concrete builder changed, yielding a different product each time.");
