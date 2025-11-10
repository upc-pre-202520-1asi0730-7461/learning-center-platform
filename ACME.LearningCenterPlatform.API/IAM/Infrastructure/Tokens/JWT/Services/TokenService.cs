using System.Security.Claims;
using System.Text;
using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;
using ACME.LearningCenterPlatform.API.IAM.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;

namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;

/// <summary>
///     Service responsible for generating and validating JSON Web Tokens (JWT).
/// </summary>
/// <remarks>
///     Tokens are created using the secret configured in <see cref="TokenSettings" /> and
///     validated with the same secret. The service returns a serialized JWT string when
///     generating tokens and the associated user id when validating tokens.
/// </remarks>
public class TokenService(IOptions<TokenSettings> tokenSettings) : ITokenService
{
    private readonly TokenSettings _tokenSettings = tokenSettings.Value;

    /// <summary>
    ///     Generates a signed JWT for the specified <paramref name="user"/>.
    /// </summary>
    /// <param name="user">User entity for which the token will be generated.</param>
    /// <returns>A signed JWT serialized as a string.</returns>
    public string GenerateToken(User user)
    {
        var secret = _tokenSettings.Secret;
        var key = Encoding.ASCII.GetBytes(secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Username)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var tokenHandler = new JsonWebTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return token;
    }

    /// <summary>
    ///     Validates the provided JWT and extracts the user id claim when validation succeeds.
    /// </summary>
    /// <param name="token">The JWT to validate.</param>
    /// <returns>
    ///     The user id extracted from the token if validation succeeds; otherwise <c>null</c>.
    /// </returns>
    /// <remarks>
    ///     Validation intentionally returns <c>null</c> for invalid or expired tokens instead of throwing.
    /// </remarks>
    public async Task<int?> ValidateToken(string token)
    {
        // If token is null or empty
        if (string.IsNullOrEmpty(token))
            // Return null 
            return null;
        // Otherwise, perform validation
        var tokenHandler = new JsonWebTokenHandler();
        var key = Encoding.ASCII.GetBytes(_tokenSettings.Secret);
        try
        {
            var tokenValidationResult = await tokenHandler.ValidateTokenAsync(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // Expiration without delay
                ClockSkew = TimeSpan.Zero
            });

            var jwtToken = (JsonWebToken)tokenValidationResult.SecurityToken;
            var userId = int.Parse(jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value);
            return userId;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }
}