using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration.Extensions;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Interfaces.ASP.Configuration;

/// <summary>
///     A controller model convention that converts controller and action route templates to kebab-case.
/// </summary>
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    /// <summary>
    ///     Applies the kebab-case naming convention to the controller model.
    /// </summary>
    /// <param name="controller">The controller model to modify.</param>
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);

        foreach (var selector in controller.Actions.SelectMany(a => a.Selectors))
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
    }

    /// <summary>
    ///     Replaces the [controller] placeholder in the route template with the kebab-case version of the specified name.
    /// </summary>
    /// <param name="selector">The selector model containing the route template.</param>
    /// <param name="name">The name to convert to kebab-case.</param>
    /// <returns>The updated attribute route model, or null if the selector has no attribute route model.</returns>
    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel != null
            ? new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
            }
            : null;
    }
}