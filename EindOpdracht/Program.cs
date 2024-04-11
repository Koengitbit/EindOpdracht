using EindOpdracht.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;
using WeekOpdracht;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<EindOpdrachtDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EindOpdrachtDbContext") ?? throw new InvalidOperationException("Connection string 'EindOpdrachtDbContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("1.0", new OpenApiInfo { Title = "V1", Version = "1.0" });
    options.SwaggerDoc("2.0", new OpenApiInfo { Title = "V2", Version = "2.0" });
    options.DocInclusionPredicate((docName, apiDesc) =>
    {
        if (!apiDesc.TryGetMethodInfo(out MethodInfo method))
            return false;

        var versions = method.DeclaringType
                        .GetCustomAttributes(true)
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

        return versions.Any(v => $"{v}" == docName);
    });

    options.OperationFilter<AddApiVersionQueryParamOperationFilter>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(config =>
    {
        config.SwaggerEndpoint("/swagger/1.0/swagger.json", "API v1");
        config.SwaggerEndpoint("/swagger/2.0/swagger.json", "API v2");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
// Might need to change this Cors to the one in the weekly exercises (we'll see)
app.UseCors("AllowWebApp");

app.MapControllers();

app.Run();
