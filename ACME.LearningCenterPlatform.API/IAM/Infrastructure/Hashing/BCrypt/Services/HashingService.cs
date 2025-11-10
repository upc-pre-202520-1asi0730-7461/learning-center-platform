using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;
using BCryptNet = BCrypt.Net.BCrypt;

namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;

/// <summary>
///     Responsible for hashing and verifying passwords using the BCrypt algorithm.
/// </summary>
public class HashingService : IHashingService
{
    /// <summary>
    ///     Hashes the provided <paramref name="password"/> using BCrypt.
    /// </summary>
    /// <param name="password">The plain-text password to hash.</param>
    /// <returns>The BCrypt hashed password string that can be stored.</returns>
    public string HashPassword(string password)
    {
        return BCryptNet.HashPassword(password);
    }

    /// <summary>
    ///     Verifies that the provided plain-text <paramref name="password"/> matches the stored
    ///     BCrypt <paramref name="passwordHash"/>.
    /// </summary>
    /// <param name="password">The plain-text password to verify.</param>
    /// <param name="passwordHash">The BCrypt hash to verify against.</param>
    /// <returns><c>true</c> if the password matches the hash; otherwise <c>false</c>.</returns>
    public bool VerifyPassword(string password, string passwordHash)
    {
        return BCryptNet.Verify(password, passwordHash);
    }
}