using BuilderPatternDemo.Vehicles;

namespace BuilderPatternDemo.Builders;

/// <summary>
/// Concrete builder that knows how to assemble a <see cref="Product"/> as a MotorCycle.
/// It supplies the body for every step declared on <see cref="IBuilder"/>.
/// </summary>
public sealed class MotorCycle : IBuilder
{
    private readonly Product _product = new("MotorCycle");
    private readonly string _model;

    public MotorCycle(string model = "Honda")
    {
        _model = string.IsNullOrWhiteSpace(model) ? "Honda" : model;
    }

    public void StartUpOperations()
        => Console.WriteLine($"[MotorCycle] Build started for model '{_model}'.");

    public void BuildBody()
        => _product.Add(new Part(1, "Tubular steel frame", 1200m));

    public void InstallEngine()
        => _product.Add(new Part(2, "650cc parallel-twin engine", 3500m));

    public void InstallTransmission()
        => _product.Add(new Part(3, "6-speed manual chain drive", 900m));

    public void InsertWheels()
        => _product.Add(new Part(4, "2 wheels", 600m));

    public void InstallBrakes()
        => _product.Add(new Part(5, "Front & rear disc brakes", 700m));

    public void AddSeats()
        => _product.Add(new Part(6, "1 dual-rider saddle", 300m));

    public void AddHeadlights()
        => _product.Add(new Part(7, "1 halogen headlight", 150m));

    public void EndOperations()
        => Console.WriteLine("[MotorCycle] Build completed and road-tested.");

    public Product GetVehicle() => _product;
}
