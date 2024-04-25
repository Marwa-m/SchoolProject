using CleanArchitecture.Core;
using CleanArchitecture.Core.MiddleWare;
using CleanArchitecture.Infrastructure;
using CleanArchitecture.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Dependency injection
//Dependency injection
builder.Services.AddInfrastructureDependencies()
                .AddServiceDependencies()
                .AddCoreDependencies()
                .AddServiceRegistration(builder.Configuration);
#endregion

#region Localization
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
{
    opt.ResourcesPath = "";
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    List<CultureInfo> supportedCultures = new List<CultureInfo>
    {
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar-EG")
    };

    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

#endregion


#region Allow Cors
var CORS = "_cors";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: CORS,
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});
#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

#region localization
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseCors(CORS);
app.UseAuthorization();

app.MapControllers();

app.Run();
