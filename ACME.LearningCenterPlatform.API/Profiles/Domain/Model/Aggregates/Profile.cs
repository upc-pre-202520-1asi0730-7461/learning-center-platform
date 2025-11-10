using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Commands;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.ValueObjects;

namespace ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Aggregates;

/// <summary>
///     Represents a user profile aggregate containing personal and address information.
/// </summary>
/// <remarks>
///     This aggregate is the root for profile-related data and value objects such as
///     <see cref="PersonName"/>, <see cref="EmailAddress"/>, and <see cref="StreetAddress"/>.
/// </remarks>
public partial class Profile
{
    /// <summary>
    ///     Initializes a new empty instance of <see cref="Profile"/> with default value objects.
    /// </summary>
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
        Address = new StreetAddress();
    }

    /// <summary>
    ///     Initializes a new instance of <see cref="Profile"/> with provided personal and address fields.
    /// </summary>
    /// <param name="firstName">First name of the profile owner.</param>
    /// <param name="lastName">Last name of the profile owner.</param>
    /// <param name="email">Email address string.</param>
    /// <param name="street">Street name portion of the address.</param>
    /// <param name="city">City portion of the address.</param>
    /// <param name="state">State or region portion of the address.</param>
    /// <param name="postalCode">Postal code for the address.</param>
    /// <param name="country">Country for the address.</param>
    public Profile(string firstName, string lastName, string email, string street, string city, string state,
        string postalCode, string country)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        Address = new StreetAddress(street, city, state, postalCode, country);
    }

    /// <summary>
    ///     Initializes a new instance of <see cref="Profile"/> from a <see cref="CreateProfileCommand"/>.
    /// </summary>
    /// <param name="command">Command containing profile creation values.</param>
    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        Address = new StreetAddress(command.Street, command.Number, command.City, command.PostalCode, command.Country);
    }

    /// <summary>
    ///     Gets the profile identifier.
    /// </summary>
    public int Id { get; }

    /// <summary>
    ///     Gets the person's name value object.
    /// </summary>
    public PersonName Name { get; }

    /// <summary>
    ///     Gets the email address value object.
    /// </summary>
    public EmailAddress Email { get; }

    /// <summary>
    ///     Gets the street address value object.
    /// </summary>
    public StreetAddress Address { get; }

    /// <summary>
    ///     Gets the full name assembled from the <see cref="Name"/> value object.
    /// </summary>
    public string FullName => Name.FullName;

    /// <summary>
    ///     Gets the email address string from the <see cref="Email"/> value object.
    /// </summary>
    public string EmailAddress => Email.Address;

    /// <summary>
    ///     Gets the full street address string from the <see cref="Address"/> value object.
    /// </summary>
    public string StreetAddress => Address.FullAddress;
}