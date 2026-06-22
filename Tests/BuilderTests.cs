using BuilderPatternDemo.Builders;
using BuilderPatternDemo.Vehicles;
using Xunit;
using VehicleDirector = BuilderPatternDemo.Director.Director;

namespace BuilderPatternDemo.Tests;

public class BuilderTests
{
    private static Product Build(IBuilder builder) => new VehicleDirector(builder).Construct();

    [Fact]
    public void Car_Has_Expected_Type_And_Parts()
    {
        Product car = Build(new Car());

        Assert.Equal("Car", car.VehicleType);
        Assert.Contains(car.Parts, p => p.Name.Contains("4 wheels"));
        Assert.Contains(car.Parts, p => p.Name.Contains("5 leather seats"));
    }

    [Fact]
    public void MotorCycle_Has_Two_Wheels_And_One_Headlight()
    {
        Product bike = Build(new MotorCycle());

        Assert.Equal("MotorCycle", bike.VehicleType);
        Assert.Contains(bike.Parts, p => p.Name.Contains("2 wheels"));
        Assert.Contains(bike.Parts, p => p.Name.Contains("1 halogen headlight"));
    }

    [Fact]
    public void Truck_Has_Six_Wheels_And_Diesel_Engine()
    {
        Product truck = Build(new Truck());

        Assert.Equal("Truck", truck.VehicleType);
        Assert.Contains(truck.Parts, p => p.Name.Contains("6 wheels"));
        Assert.Contains(truck.Parts, p => p.Name.Contains("diesel engine"));
    }

    public static IEnumerable<object[]> AllBuilders =>
        new[]
        {
            new object[] { new Car() },
            new object[] { new MotorCycle() },
            new object[] { new Truck() },
        };

    [Theory]
    [MemberData(nameof(AllBuilders))]
    public void Each_Vehicle_Has_Seven_Priced_Parts(IBuilder builder)
    {
        Product product = Build(builder);

        // The seven component steps each add exactly one part.
        Assert.Equal(7, product.Parts.Count);

        // Every part is uniquely numbered 1..7 and carries a positive price.
        Assert.Equal(new[] { 1, 2, 3, 4, 5, 6, 7 }, product.Parts.Select(p => p.Id));
        Assert.All(product.Parts, p => Assert.True(p.Price > 0));
    }

    [Theory]
    [MemberData(nameof(AllBuilders))]
    public void TotalPrice_Equals_Sum_Of_Part_Prices(IBuilder builder)
    {
        Product product = Build(builder);

        Assert.Equal(product.Parts.Sum(p => p.Price), product.TotalPrice);
    }

    [Fact]
    public void Part_Rejects_Invalid_Values()
    {
        Assert.Throws<ArgumentException>(() => new Part(1, "  ", 10m));        // blank name
        Assert.Throws<ArgumentNullException>(() => new Part(1, null!, 10m));   // null name
        Assert.Throws<ArgumentOutOfRangeException>(() => new Part(0, "Body", 10m));   // id must be > 0
        Assert.Throws<ArgumentOutOfRangeException>(() => new Part(-1, "Body", 10m));  // negative id
        Assert.Throws<ArgumentOutOfRangeException>(() => new Part(1, "Body", -1m));   // negative price
        Assert.Throws<ArgumentException>(() => new Part(1, "Body", 9.999m));          // sub-cent price
    }

    [Fact]
    public void Part_Trims_Whitespace_From_Name()
    {
        var part = new Part(1, "  4 wheels  ", 100m);
        Assert.Equal("4 wheels", part.Name);
    }

    [Fact]
    public void Product_Rejects_Null_Part()
    {
        var product = new Product("Car");
        Assert.Throws<ArgumentNullException>(() => product.Add(null!));
    }

    [Fact]
    public void Product_Rejects_Blank_VehicleType()
    {
        Assert.Throws<ArgumentException>(() => new Product("   "));
    }

    [Fact]
    public void Product_Rejects_Duplicate_Part_Id()
    {
        var product = new Product("Car");
        product.Add(new Part(1, "Body", 100m));

        Assert.Throws<InvalidOperationException>(() => product.Add(new Part(1, "Engine", 200m)));
    }

    [Fact]
    public void Director_Rejects_Null_Builder()
    {
        Assert.Throws<ArgumentNullException>(() => new VehicleDirector(null!));
    }
}
