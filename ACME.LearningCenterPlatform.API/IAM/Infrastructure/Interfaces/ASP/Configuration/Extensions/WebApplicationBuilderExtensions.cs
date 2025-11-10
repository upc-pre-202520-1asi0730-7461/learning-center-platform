using ACME.LearningCenterPlatform.API.IAM.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.IAM.Application.Internal.OutboundServices;
using ACME.LearningCenterPlatform.API.IAM.Application.Internal.QueryServices;
using ACME.LearningCenterPlatform.API.IAM.Domain.Repositories;
using ACME.LearningCenterPlatform.API.IAM.Domain.Services;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using ACME.LearningCenterPlatform.API.IAM.Infrastructure.Tokens.JWT.Services;
using ACME.LearningCenterPlatform.API.IAM.Interfaces.ACL;
using ACME.LearningCenterPlatform.API.IAM.Interfaces.ACL.Services;


namespace ACME.LearningCenterPlatform.API.IAM.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddIamContextServices(this WebApplicationBuilder builder)
    {
        // IAM Bounded Context Injection Configuration

        // TokenSettings Configuration
        builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));

        // Service dependency injection configuration
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserCommandService, UserCommandService>();
        builder.Services.AddScoped<IUserQueryService, UserQueryService>();
        builder.Services.AddScoped<ITokenService, TokenService>();
        builder.Services.AddScoped<IHashingService, HashingService>();
        builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

    }

    public static void AddCorsPolicy(this WebApplicationBuilder builder)
    {
        // Add CORS Policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllPolicy",
                policy => policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });    
    }
    
}