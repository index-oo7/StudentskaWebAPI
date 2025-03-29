using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StudentskaWebAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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

//Registracija ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();



partial class Program
{
    static void Main()
    {
        string connectionString = "Server=DESKTOP-JGAQ95Q\\SQLEXPRESS;Database=StudentskaWebAPI;Trusted_Connection=True;TrustServerCertificate=True";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection failed: " + ex.Message);
            }
        }
    }
}
