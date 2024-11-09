// Licensed under the MIT license by loonfactory.

using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Loonfactory.Google.Apis.YouTube.V3;
using Loonfactory.Google.Apis.YouTube.V3.Example;
using Loonfactory.Google.Apis.YouTube.V3.Example.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddAuthentication()
    .AddOAuth<GoogleOptions, TemporaryGoogleHandler>(GoogleDefaults.AuthenticationScheme, GoogleDefaults.DisplayName, googleOptions =>
    {
        googleOptions.ClientId = configuration["Authentication:Google:ClientId"]!;
        googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"]!;

        googleOptions.SaveTokens = true;
    });

builder.Services.AddRazorPages();
builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto | ForwardedHeaders.XForwardedHost;
});

builder.Services.AddYouTubeDataApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseForwardedHeaders();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseForwardedHeaders();
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
