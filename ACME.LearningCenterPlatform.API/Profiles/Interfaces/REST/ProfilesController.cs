using System.Net.Mime;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Model.Queries;
using ACME.LearningCenterPlatform.API.Profiles.Domain.Services;
using ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST.Resources;
using ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace ACME.LearningCenterPlatform.API.Profiles.Interfaces.REST;

/// <summary>
///     REST API controller exposing profile-related endpoints.
/// </summary>
/// <remarks>
///     Provides endpoints to create and retrieve profile aggregates.
/// </remarks>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[SwaggerTag("Available Profile Endpoints.")]
public class ProfilesController(
    IProfileCommandService profileCommandService,
    IProfileQueryService profileQueryService)
    : ControllerBase
{
    /// <summary>
    ///     Retrieves a profile by its identifier.
    /// </summary>
    /// <param name="profileId">The unique identifier of the profile to retrieve.</param>
    /// <returns>
    ///     An <see cref="ActionResult"/> containing the <see cref="ProfileResource"/> when found,
    ///     or <see cref="NotFoundResult"/> when no profile exists with the given id.
    /// </returns>
    [HttpGet("{profileId:int}")]
    [SwaggerOperation("Get Profile by Id", "Get a profile by its unique identifier.", OperationId = "GetProfileById")]
    [SwaggerResponse(200, "The profile was found and returned.", typeof(ProfileResource))]
    [SwaggerResponse(404, "The profile was not found.")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile is null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }

    /// <summary>
    ///     Creates a new profile from the provided resource representation.
    /// </summary>
    /// <param name="resource">The resource containing profile creation data.</param>
    /// <returns>
    ///     A <see cref="CreatedAtActionResult"/> with the created profile resource on success,
    ///     or <see cref="BadRequestResult"/> when creation fails.
    /// </returns>
    [HttpPost]
    [SwaggerOperation("Create Profile", "Create a new profile.", OperationId = "CreateProfile")]
    [SwaggerResponse(201, "The profile was created.", typeof(ProfileResource))]
    [SwaggerResponse(400, "The profile was not created.")]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new { profileId = profile.Id }, profileResource);
    }

    /// <summary>
    ///     Retrieves all profiles available in the system.
    /// </summary>
    /// <returns>An <see cref="ActionResult"/> with a collection of <see cref="ProfileResource"/>.</returns>
    [HttpGet]
    [SwaggerOperation("Get All Profiles", "Get all profiles.", OperationId = "GetAllProfiles")]
    [SwaggerResponse(200, "The profiles were found and returned.", typeof(IEnumerable<ProfileResource>))]
    [SwaggerResponse(404, "The profiles were not found.")]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }
}