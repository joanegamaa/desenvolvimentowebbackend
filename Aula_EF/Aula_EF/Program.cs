using Aula_EF.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider(options => {
     // Ativa a validacao de escopo. False evita erro de BD inexistente
});


builder.Services.AddControllersWithViews();

//ConfiguraCAOo da Entity Framework Core
builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration["Data:Exemplo_EF_BD26:ConnectionString"],

    sqlServerOptionsAction: sqlOptions => {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(30),
            errorNumbersToAdd: null);
    }));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Fabricante}/{action=Index}/{id?}");

//SeedData.Initialize(app.Services);
SeedData.EnsurePopulated(app);

app.Run();