namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Acme Asset Identifier Entity
/// </summary>
/// <param name="Identifier">The unique identifier for the Acme asset.</param>
public record AcmeAssetIdentifier(Guid Identifier)
{
    /// <summary>
    /// Default constructor that generates a new unique identifier.
    /// </summary>
    public AcmeAssetIdentifier() : this(Guid.NewGuid()) { }
}