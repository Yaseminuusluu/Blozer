using Blazored.Modal;
using BlazorVÝdeo.Server.Services.Extensions;
using BlazorVÝdeo.Server.Services.Infrastruce;
using BlazorVÝdeo.Server.Services.Services;
using MealOrdering.Server.Data.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddBlazoredModal();
builder.Services.ConfigureMapping();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOrderService,OrderService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddDbContext<MealOrderingDbContext>(config=>
{
    config.UseNpgsql("User ID=postgres;password=12345;Host=localhost;Port=5432;Database=mealordering;SearchPath=public");
    config.EnableSensitiveDataLogging();
});

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            //Token buraya geldiðinde burdaki kurallara göre çalýþmasýna saðlauan kurallar
            //Tokený oluþturan kiþiyi doðrulama yapýlýcak mý
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            //tokený üreten kiþi için ValidIssuer kullanýlýr
            ValidIssuer=builder.Configuration["JwtIssuer"],
            ValidAudience= builder.Configuration["JwtAudience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSecurityKey"]))
        };
    });
builder.Services.AddBlazoredLocalStorage();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
