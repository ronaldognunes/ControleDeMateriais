using ControleMateriaisApi.Repository;
using ControleMateriaisApi.Repository.Context;
using ControleMateriaisApi.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AplicationContext>(opt => opt.UseSqlite(builder.Configuration.GetConnectionString("db")));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IMaterialRepository, MaterialRepository>();
builder.Services.AddScoped<ISaidaRepository, SaidaRepository>();
builder.Services.AddScoped<IEntradaRepository, EntradaRepository>();
builder.Services.AddScoped<IEntradaMaterialRepository, EntradaMaterialRepository>();
builder.Services.AddScoped<ISaidaMaterialRepository, SaidaMaterialRepository>();
builder.Services.AddScoped<IPoloRepository, PoloRepository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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
