namespace BuilderPatternDemo.Vehicles;

/// <summary>
/// Represents the complex object under construction.
/// In the Builder pattern this is the "Product": it is assembled
/// step-by-step by a concrete builder and finally handed back to the client.
/// A product is composed of <see cref="Part"/> objects, each with an id, name and price.
/// </summary>
public sealed class Product
{
    // Each fitted component is recorded here, in assembly order.
    private readonly List<Part> _parts = new();

    /// <summary>A human-friendly name for the finished vehicle (e.g. "Car", "MotorCycle").</summary>
    public string VehicleType { get; }

    public Product(string vehicleType)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(vehicleType);
        VehicleType = vehicleType.Trim();
    }

    /// <summary>Adds a fitted component to the product.</summary>
    /// <exception cref="ArgumentNullException">The part is null.</exception>
    /// <exception cref="InvalidOperationException">A part with the same id was already added.</exception>
    public void Add(Part part)
    {
        ArgumentNullException.ThrowIfNull(part);

        if (_parts.Any(p => p.Id == part.Id))
            throw new InvalidOperationException(
                $"A part with id {part.Id} has already been added to this {VehicleType}.");

        _parts.Add(part);
    }

    /// <summary>Returns a read-only view of every part fitted during construction.</summary>
    public IReadOnlyList<Part> Parts => _parts.AsReadOnly();

    /// <summary>The combined price of every part on the product.</summary>
    public decimal TotalPrice => _parts.Sum(p => p.Price);

    /// <summary>Prints the full, priced bill of materials for the constructed vehicle.</summary>
    public void Show()
    {
        Console.WriteLine();
        Console.WriteLine($"--- {VehicleType} bill of materials ---");
        Console.WriteLine($"  {"ID",-4}{"Part",-40}{"Price",12}");

        foreach (var part in _parts)
            Console.WriteLine($"  {"#" + part.Id,-4}{part.Name,-40}{part.Price,12:C}");

        Console.WriteLine($"  {new string('-', 56)}");
        Console.WriteLine($"  {"Total",-44}{TotalPrice,12:C}");
        Console.WriteLine($"--- {VehicleType} is ready ---");
        Console.WriteLine();
    }
}
