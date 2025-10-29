using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Commands;

namespace ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;

/// <summary>
/// Represents a category entity in the publishing bounded context.
/// </summary>
public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class.
    /// </summary>
    public Category()
    {
        Name = string.Empty;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class with the specified name.
    /// </summary>
    /// <param name="name">The name of the category.</param>
    public Category(string name)
    {
        Name = name;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Category"/> class using a CreateCategoryCommand.
    /// </summary>
    /// <param name="command">The <see cref="CreateCategoryCommand"/> command containing the category details.</param>
    public Category(CreateCategoryCommand command)
    {
        Name = command.Name;
    }
}