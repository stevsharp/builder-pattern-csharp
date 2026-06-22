namespace BuilderPatternDemo.Vehicles;

/// <summary>
/// A single component that makes up a <see cref="Product"/>.
/// Each part carries an identifier, a descriptive name, and a price.
/// </summary>
public class Part
{
    /// <summary>Unique number identifying the part within its product.</summary>
    public int Id { get; }

    /// <summary>Descriptive name of the component (e.g. "4 wheels").</summary>
    public string Name { get; }

    /// <summary>Price of the component.</summary>
    public decimal Price { get; }

    public Part(int id, string name, decimal price)
    {
        ArgumentOutOfRangeException.ThrowIfNegativeOrZero(id);
        ArgumentException.ThrowIfNullOrWhiteSpace(name);
        ArgumentOutOfRangeException.ThrowIfNegative(price);

        // Guard against accidental sub-cent prices that won't display correctly.
        if (decimal.Round(price, 2) != price)
            throw new ArgumentException("Part price cannot have more than two decimal places.", nameof(price));

        Id = id;
        Name = name.Trim();
        Price = price;
    }

    public override string ToString() => $"#{Id,-3} {Name,-40} {Price,12:C}";
}
