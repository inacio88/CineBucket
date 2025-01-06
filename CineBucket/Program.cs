using CineBucket.Core.Configuracoes;
using CineBucket.Data;
using CineBucket.ExtensoesConfiguracao;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.AddConfiguration();
builder.AddDatabaseContext();
builder.AddHttpClientServices();
builder.AddServices();
builder.AddRepos();
var app = builder.Build();

// // Configure the HTTP request pipeline.
bool isProduction = !app.Environment.IsDevelopment();
if (isProduction)
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}
else{
    using var dbContext = new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseNpgsql(ConfiguracoesGerais.ConnectionString).Options);
    await dbContext.Database.MigrateAsync();    
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
