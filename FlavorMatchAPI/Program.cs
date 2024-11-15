using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FlavorMatch.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

//Database server
DatabaseConnection db = new DatabaseConnection();
db.GetDatabaseServer();
var connectionStringAPI = db.connectionStringAPI;

//Using Azure Key Vault to store the connection string
//var apiVaultURL = new Uri("https://flavormatch.vault.azure.net/");
//var secretAPIClient = new SecretClient(apiVaultURL, new DefaultAzureCredential());
//KeyVaultSecret APISecret = secretAPIClient.GetSecret("FlavorMatchAPISecret");
//string connectionString = APISecret.Value;

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FlavorMatchAPIContext>(options =>
    options.UseSqlServer(connectionStringAPI));

builder.Services.AddScoped<IUserPreferencesRepo, UserPreferencesRepo>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
         builder =>
         {
             builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
         });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
