using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductAPI.Application.Handlers;
using ProductAPI.Domain.Interfaces;
using ProductAPI.Infrastructure.Context;
using ProductAPI.Infrastructure.Enums;
using ProductAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var databaseProviderStr = builder.Configuration.GetValue<string>("DatabaseProvider");

DatabaseProviderEnum databaseProvider;

if (!Enum.TryParse(databaseProviderStr, out databaseProvider))
    throw new InvalidOperationException("Provedor de banco de dados não configurado");

var connectionString = builder.Configuration.GetConnectionString(databaseProvider.GetDescription());
if (string.IsNullOrWhiteSpace(connectionString))
    throw new InvalidOperationException("Configuração de banco de dados não encontrdo");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    switch (databaseProvider)
    {
        case DatabaseProviderEnum.SQLite:
            options.UseSqlite(connectionString, b => b.MigrationsAssembly("ProductAPI.Infrastructure"));
            break;

        case DatabaseProviderEnum.PostgreSQL:
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("ProductAPI.Infrastructure"));
            break;
        default:
            throw new InvalidOperationException("Provedor de banco de dados não encontrado");
    }
});

//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

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

// Create Migration

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    switch (databaseProvider)
    {
        case DatabaseProviderEnum.SQLite:
            context.Database.Migrate();
            break;
        case DatabaseProviderEnum.PostgreSQL:
            context.Database.Migrate();
            break;
        case DatabaseProviderEnum.SqlServer:
            break;
        case DatabaseProviderEnum.Mysql:
            break;
        default:
            break;
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
