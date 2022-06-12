using Microsoft.EntityFrameworkCore;
using UdemyApiWithToken.Domain.Entities;
using UdemyApiWithToken.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Olustur();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UdemyApiWithTokenContext>(
    opt =>
    {
        opt.UseSqlServer(
            builder.Configuration.GetConnectionString("Varsayilan")
            ); 
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
