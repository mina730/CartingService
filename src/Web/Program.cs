using System.Net;
using CartingService.Infrastructure.Data;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddKeyVaultIfConfigured(builder.Configuration);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    await app.InitialiseDatabaseAsync();
    app.UseDeveloperExceptionPage();
}
else
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseExceptionHandler("/error");
}

app.UseHealthChecks("/health");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSwaggerUi(settings =>
{
    settings.Path = "/api";
    settings.DocumentPath = "/api/specification.json";
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapRazorPages();

app.MapFallbackToFile("index.html");

app.UseExceptionHandler(options =>
{
    options.Run(
        async context =>
        {
            var ex = context.Features.Get<IExceptionHandlerFeature>();
            if (ex != null)
            {
                var exception = ex.Error;
                context.Response.StatusCode = GetStatusFromExceptionType(exception);// (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "text/html";
                if (ex != null)
                {
                    var err = $"<h1> Error Code: {context.Response.StatusCode}</h1>" +
                    $"{ exception.Message}";//$"{ex.Error.StackTrace}";
                    await context.Response.WriteAsync(err).ConfigureAwait(false);
                }
            }
        });
});

static int GetStatusFromExceptionType(Exception type)
{
    int code = 500;
    switch (type)
    {
        case NotFoundException _:
            code = 404;
            break;
        case UnauthorizedAccessException _:
            code = 401;
            break;
    }
    return code;
}

app.Map("/", () => Results.Redirect("/api"));

app.MapEndpoints();

app.Run();

public partial class Program { }
