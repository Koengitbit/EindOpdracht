using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace WeekOpdracht
{
    public class AddApiVersionQueryParamOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Bepaal de API-versie van de huidige operatie
            var apiVersion = context.DocumentName;

            if (apiVersion == null || apiVersion == "1.0") return;

            // Voeg de api-version query parameter toe, indien nog niet aanwezig of anders dan versie 1.0
            var parameter = operation.Parameters
                .FirstOrDefault(p => p.Name == "api-version" && p.In == ParameterLocation.Query);

            if (parameter == null)
            {
                parameter = new OpenApiParameter
                {
                    Name = "api-version",
                    In = ParameterLocation.Query,
                    Required = true,
                    Description = "API version",
                    Schema = new OpenApiSchema
                    {
                        Type = "string"
                    },
                };

                operation.Parameters.Add(parameter);
            }

            // Stel de standaardwaarde van de parameter in op de huidige API-versie
            parameter.Example = new OpenApiString(apiVersion);
        }
    }
}
