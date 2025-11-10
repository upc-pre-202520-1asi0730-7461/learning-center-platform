namespace ACME.LearningCenterPlatform.API.Shared.Domain.Repositories;

/// <summary>
///     Represents a unit of work pattern for managing database transactions.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    ///     Asynchronously completes the unit of work, saving all changes to the database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task CompleteAsync();
}