using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using FlavorMatch.Components;
using FlavorMatch.Components.Account;
using FlavorMatch.Data;
using FlavorMatch.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Database server
DatabaseConnection db = new DatabaseConnection();
db.GetDatabaseServer();
var ConnectionStringServer = db.server;

//api connection string
var apiConnectionStringEnd = builder.Configuration.GetConnectionString("APIConnectionString");
var apiFullConnectionString = "Server=" + ConnectionStringServer + apiConnectionStringEnd;

//var APIVaultURL = new Uri("https://flavormatch.vault.azure.net/");
//var secretAPIClient = new SecretClient(APIVaultURL, new DefaultAzureCredential());
//KeyVaultSecret APISecret = secretAPIClient.GetSecret("FlavorMatchAPISecret");
//string apiConnectionString = APISecret.Value;

//normal connection string
var idConnectionStringEnd = builder.Configuration.GetConnectionString("IdentityConnectionString");
var idFullConnectionString = "Server=" + ConnectionStringServer + idConnectionStringEnd;

//var vaultURL = new Uri("https://flavormatch.vault.azure.net/");
//var secretClient = new SecretClient(vaultURL, new DefaultAzureCredential());
//KeyVaultSecret vaultSecret = secretClient.GetSecret("FlavorMatchSecret");
//string connectionString = vaultSecret.Value;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityUserAccessor>();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddAuthentication(options =>
    {
        options.DefaultScheme = IdentityConstants.ApplicationScheme;
        options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
    })
    .AddIdentityCookies();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(idFullConnectionString));
builder.Services.AddDbContext<FlavorMatchAPIContext>(options =>
        options.UseSqlServer(apiFullConnectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();

builder.Services.AddSingleton<IEmailSender<ApplicationUser>, IdentityNoOpEmailSender>();

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
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Add additional endpoints required by the Identity /Account Razor components.
app.MapAdditionalIdentityEndpoints();

app.Run();
