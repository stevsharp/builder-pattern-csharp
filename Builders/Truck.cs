using BuilderPatternDemo.Vehicles;

namespace BuilderPatternDemo.Builders;

/// <summary>
/// Concrete builder that knows how to assemble a <see cref="Product"/> as a Truck.
/// It supplies the body for every step declared on <see cref="IBuilder"/>.
/// </summary>
public sealed class Truck : IBuilder
{
    private readonly Product _product = new("Truck");
    private readonly string _model;

    public Truck(string model = "Volvo")
    {
        _model = string.IsNullOrWhiteSpace(model) ? "Volvo" : model;
    }

    public void StartUpOperations()
        => Console.WriteLine($"[Truck] Build started for model '{_model}'.");

    public void BuildBody()
        => _product.Add(new Part(1, "Heavy-duty ladder chassis", 12000m));

    public void InstallEngine()
        => _product.Add(new Part(2, "12L diesel engine", 22000m));

    public void InstallTransmission()
        => _product.Add(new Part(3, "12-speed automated manual transmission", 6000m));

    public void InsertWheels()
        => _product.Add(new Part(4, "6 wheels", 4800m));

    public void InstallBrakes()
        => _product.Add(new Part(5, "Air-actuated drum brakes", 3200m));

    public void AddSeats()
        => _product.Add(new Part(6, "2 air-suspension cabin seats", 2500m));

    public void AddHeadlights()
        => _product.Add(new Part(7, "2 LED headlights + fog lamps", 1100m));

    public void EndOperations()
        => Console.WriteLine("[Truck] Build completed and load-tested.");

    public Product GetVehicle() => _product;
}
