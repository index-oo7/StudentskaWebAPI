using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentskaWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registracija StudentskaWebApiContext
builder
    .Services
    .AddDbContext<StudentskaWebApiContext>(options =>
    options.UseSqlServer(
        builder
        .Configuration
        .GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// CORS za sve origin-e, u produkcji zameniti sa specificnim domenima
//.WithOrigins("domen1", "domen2")
app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();