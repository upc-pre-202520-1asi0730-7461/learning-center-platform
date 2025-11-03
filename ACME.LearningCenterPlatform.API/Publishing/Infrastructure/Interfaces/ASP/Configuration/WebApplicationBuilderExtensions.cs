using ACME.LearningCenterPlatform.API.Publishing.Application.Internal.CommandServices;
using ACME.LearningCenterPlatform.API.Publishing.Application.Internal.QueryServices;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Repositories;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Services;
using ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Persistence.EFC.Repositories;

namespace ACME.LearningCenterPlatform.API.Publishing.Infrastructure.Interfaces.ASP.Configuration;

public static class WebApplicationBuilderExtensions
{
    public static void AddPublishingContextServices(this WebApplicationBuilder builder)
    {
        // Publishing Bounded Context
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<ITutorialRepository, TutorialRepository>();
        builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
        builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();
        builder.Services.AddScoped<ITutorialCommandService, TutorialCommandService>();
        builder.Services.AddScoped<ITutorialQueryService, TutorialQueryService>();
    }
}