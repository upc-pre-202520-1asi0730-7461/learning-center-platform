using ACME.LearningCenterPlatform.API.Profiles.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Profiles.Application.Internal.QueryServices;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Services;
using ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.LearningCenterPlatform.API.Profiles.Infrastructure.Interfaces.ASP.Configuration.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddProfilesContextServices(this WebApplicationBuilder builder)
    {
        // Profiles Bounded Context Dependency Injection Configuration
        builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
        builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
        builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
    }
}