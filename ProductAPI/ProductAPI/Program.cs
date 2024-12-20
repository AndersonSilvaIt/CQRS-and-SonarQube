using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Application.Handlers;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infrastructure.Context;
using ProductAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddMediatR(typeof(ProductCreateHandler).Assembly);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {

        Version = "v1",
        Title = "Product API",
        Description = "API to manager product, using DDD, CQRS, and SQLite",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Anderson",
            Email = "anderson.silvait@outlook.com",
            Url = new Uri("https://productapi.com")
        }
    });

    // TODO
    // Inclui comentários XML para documentação dos endpoints
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
