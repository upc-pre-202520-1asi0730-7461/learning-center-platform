using Cortex.Mediator.Notifications;

namespace ACME.LearningCenterPlatform.API.Shared.Domain.Model.Events;

/// <summary>
///     Represents a domain event in the system.
/// </summary>
/// This interface extends
/// <see cref="INotification" />
/// to integrate with the mediator pattern for event handling.
public interface IEvent : INotification
{
}