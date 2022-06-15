using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Repositorys;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;
using UdemyApiWithToken.Mapping;
using UdemyApiWithToken.Security.Token;
using UdemyApiWithToken.Services;

namespace UdemyApiWithToken.Extensions
{
    public static class ServiceExtention
    {
        public static void Olustur(this IServiceCollection services)
        {

            //her karşılaşınca IProductService görünce ProductService oluştur
            //services.AddTransient<IProductService, ProductService>();

            //Bir reponse boyuca
            services.AddScoped<IProductService, ProductService>();

            //uygulama boyunca 1 defa
            //services.AddSingleton<IProductService, ProductService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddSingleton<DbContext,UdemyApiWithTokenContext>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy(builder =>
                {         //Tüm kaynaklar --- tüm headerler ----- tüm methodlar
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

                ////www.abc.com için
                //opts.AddPolicy("abcPolicy", builder =>
                //{
                //    builder.WithOrigins("https://www.abc.com").AllowAnyHeader().AllowAnyMethod();
                //});
            });

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static void Addjwt(this IServiceCollection services,WebApplicationBuilder builder)
        {
            var tokenOptions = builder.Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            //services.AddAuthentication("Benimshemam");
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                jwtBearerOpt => {
                    jwtBearerOpt.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = true, //dinleyeni kontrolet kimler dinleyecek
                        ValidateIssuer = true, //yayınlayanı kontrolet
                        ValidateLifetime = true, //süresini kontrolet
                        ValidateIssuerSigningKey = true, //imzalamayı kontrol et kim imzalamış
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        IssuerSigningKey = SignHandler.GetSecurityKey(tokenOptions.SecurityKey),
                    };
                });
        }

        public static void TokenOptionOlusturucu(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));
        }
    }
}
