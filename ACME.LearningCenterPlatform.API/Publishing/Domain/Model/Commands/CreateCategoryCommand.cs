namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

/// <summary>
/// Command to create a new category.
/// </summary>
/// <param name="Name">The name of the category.</param>
public record CreateCategoryCommand(string Name);