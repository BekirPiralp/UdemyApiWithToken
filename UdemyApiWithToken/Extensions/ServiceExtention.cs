using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Domain.Repositorys;
using UdemyApiWithToken.Domain.Services;
using UdemyApiWithToken.Domain.UnitOfWork;
using UdemyApiWithToken.Mapping;
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
            
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddSingleton<DbContext,UdemyApiWithTokenContext>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            services.AddCors(opts =>
            {
                opts.AddDefaultPolicy( builder =>
                {         //Tüm kaynaklar --- tüm headerler ----- tüm methodlar
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });

                ////www.abc.com için
                //opts.AddPolicy("abcPolicy", builder =>
                //{
                //    builder.WithOrigins("https://www.abc.com").AllowAnyHeader().AllowAnyMethod();
                //});
            });
        }
    }
}
