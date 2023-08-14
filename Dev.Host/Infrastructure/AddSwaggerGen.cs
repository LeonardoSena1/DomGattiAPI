using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Dev.Host.Infrastructure
{
    public class AddSwaggerGen
    {
        public class SwaggerGen
        {
            /// <summary>
            /// swagger configuration
            /// </summary>
            /// <param name="servicesCollection"></param>
            public static void ConfigureSwaggerGenService(IServiceCollection servicesCollection)
            {
                servicesCollection.AddSwaggerGen(options =>
                {
                    options.SwaggerDoc("v2", new OpenApiInfo
                    {
                        Title = "Dev",
                        Version = "v2",
                        Description = "",
                        Contact = new OpenApiContact
                        {
                            Name = "",
                            Email = "",
                        },
                    });

                    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

                    options.DocInclusionPredicate((docName, description) => true);

                    options.EnableAnnotations();

                    options.ResolveConflictingActions(e => e.First());

                    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme()
                    {
                        Name = "Dev-Key",
                        In = ParameterLocation.Header,
                        Type = SecuritySchemeType.ApiKey,
                        Description = "Authorization by x-api-key inside request's header",
                        Scheme = "Dev-Key"
                    });

                    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                       { new OpenApiSecurityScheme()
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "ApiKey",
                                },
                                In = ParameterLocation.Header
                            }, new List<string>()
                       }
                    });
                }).AddSwaggerGenNewtonsoftSupport();
            }


            /// <summary>
            /// swagger configuration use
            /// </summary>
            /// <param name="app"></param>
            public static void ConfigureSwaggerUse(WebApplication app)
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v2/swagger.json", "v2");
                    options.RoutePrefix = string.Empty;
                });
            }
        }
    }
}
