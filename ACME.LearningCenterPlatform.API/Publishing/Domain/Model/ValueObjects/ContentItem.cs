namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.ValueObjects;

/// <summary>
/// Represents a content item with its type and content.
/// </summary>
/// <param name="Type">The type of the content item.</param>
/// <param name="Content">The actual content of the item.</param>
public record ContentItem(string Type, string Content);