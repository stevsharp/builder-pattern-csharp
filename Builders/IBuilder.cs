using BuilderPatternDemo.Vehicles;

namespace BuilderPatternDemo.Builders;

/// <summary>
/// Declares the construction steps that every concrete vehicle builder must supply.
/// The <see cref="Director"/> talks only to this interface, so it can build any
/// vehicle without knowing which concrete builder it is driving.
/// </summary>
public interface IBuilder
{
    /// <summary>Performs any setup work needed before assembly begins.</summary>
    void StartUpOperations();

    /// <summary>Builds the main body/frame of the vehicle.</summary>
    void BuildBody();

    /// <summary>Installs the engine/power unit.</summary>
    void InstallEngine();

    /// <summary>Fits the transmission/drivetrain.</summary>
    void InstallTransmission();

    /// <summary>Inserts the appropriate number of wheels for this vehicle.</summary>
    void InsertWheels();

    /// <summary>Fits the braking system.</summary>
    void InstallBrakes();

    /// <summary>Adds the seats for this vehicle.</summary>
    void AddSeats();

    /// <summary>Adds the headlights to the vehicle.</summary>
    void AddHeadlights();

    /// <summary>Performs any finishing work after the core assembly is complete.</summary>
    void EndOperations();

    /// <summary>Returns the fully constructed product to the client.</summary>
    Product GetVehicle();
}
