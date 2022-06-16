using Microsoft.OpenApi.Models;

namespace UdemyApiWithToken.Extensions
{
    public static class SwagerAddExtension
    {
        public static void SwagerAddAuthorization(this IServiceCollection services)
        {
            services.AddSwaggerGen(
                    opt =>{
                        opt.SwaggerDoc("v1", new OpenApiInfo { Title = "Udemy eğitimi API", Version = "v01" });

                        opt.AddSecurityDefinition("Bearer",new OpenApiSecurityScheme{
                            In = ParameterLocation.Header,
                            Description = "Lütfen geçerli token'ı giriniz.",
                            Name = "İzin al",
                            Type = SecuritySchemeType.Http,
                            BearerFormat = "JWT",
                            Scheme = "Bearer"
                        });

                        var oASS = new OpenApiSecurityScheme{
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        };

                        var value = new List<String>(); 
                        opt.AddSecurityRequirement(new OpenApiSecurityRequirement{{
                                oASS,
                                value
                            }
                        }) ;
                    }
                );
        }
    }
}
