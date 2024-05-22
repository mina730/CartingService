using System.Reflection;
using Asp.Versioning.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class ConfigureSwaggerOptions
        : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider provider;

    public ConfigureSwaggerOptions(
        IApiVersionDescriptionProvider provider)
    {
        this.provider = provider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        // add swagger document for every API version discovered
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    }

    public void Configure(string? name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    private OpenApiInfo CreateVersionInfo(
            ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "My API",
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
        {
            info.Description += " deprecated API.";
        }

        return info;
    }
}
