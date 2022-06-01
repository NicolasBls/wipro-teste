using Microsoft.EntityFrameworkCore;
using WiproTeste.Data;
using WiproTeste.Data.Repositories;
using WiproTeste.Profiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DataContext"));
});

builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IFilmesRepository, FilmesRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.  
app.UseSwagger();

if (app.Environment.IsDevelopment())
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
else
    app.UseSwaggerUI(c =>
    {
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint($"swagger/v1/swagger.json", "My API V1");
    });


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
