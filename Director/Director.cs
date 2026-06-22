using BuilderPatternDemo.Builders;
using BuilderPatternDemo.Vehicles;

namespace BuilderPatternDemo.Director;

/// <summary>
/// The Director controls the construction algorithm. It defines the order in which
/// the building steps are executed but delegates the actual work to whichever
/// <see cref="IBuilder"/> it is given. This keeps the assembly sequence in one
/// place and independent of the concrete product being built.
/// </summary>
public sealed class Director
{
    private readonly IBuilder _builder;

    public Director(IBuilder builder)
    {
        _builder = builder ?? throw new ArgumentNullException(nameof(builder));
    }

    /// <summary>
    /// Runs the fixed construction sequence and returns the finished product.
    /// </summary>
    public Product Construct()
    {
        _builder.StartUpOperations();
        _builder.BuildBody();
        _builder.InstallEngine();
        _builder.InstallTransmission();
        _builder.InsertWheels();
        _builder.InstallBrakes();
        _builder.AddSeats();
        _builder.AddHeadlights();
        _builder.EndOperations();

        return _builder.GetVehicle();
    }
}
