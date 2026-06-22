using BuilderPatternDemo.Vehicles;

namespace BuilderPatternDemo.Builders;

/// <summary>
/// Concrete builder that knows how to assemble a <see cref="Product"/> as a Car.
/// It supplies the body for every step declared on <see cref="IBuilder"/>.
/// </summary>
public sealed class Car : IBuilder
{
    private readonly Product _product = new("Car");
    private readonly string _model;

    public Car(string model = "Ford")
    {
        _model = string.IsNullOrWhiteSpace(model) ? "Ford" : model;
    }

    public void StartUpOperations()
        => Console.WriteLine($"[Car] Build started for model '{_model}'.");

    public void BuildBody()
        => _product.Add(new Part(1, "Steel monocoque body", 4500m));

    public void InstallEngine()
        => _product.Add(new Part(2, "2.3L turbo petrol engine", 6500m));

    public void InstallTransmission()
        => _product.Add(new Part(3, "6-speed automatic transmission", 2800m));

    public void InsertWheels()
        => _product.Add(new Part(4, "4 wheels", 1200m));

    public void InstallBrakes()
        => _product.Add(new Part(5, "4-wheel disc brakes with ABS", 1500m));

    public void AddSeats()
        => _product.Add(new Part(6, "5 leather seats", 2000m));

    public void AddHeadlights()
        => _product.Add(new Part(7, "2 LED headlights", 600m));

    public void EndOperations()
        => Console.WriteLine("[Car] Build completed and quality-checked.");

    public Product GetVehicle() => _product;
}
