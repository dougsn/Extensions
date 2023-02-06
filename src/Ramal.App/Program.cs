using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ramal.App.Configuration;
using Ramal.App.Data;
using Ramal.Business.Interfaces;
using Ramal.Data;
using Ramal.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
  options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddDbContext<MeuDbContext>(option =>
{
    option.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.ResolveDependencies();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews(o =>
{
    o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => "O valor preenchido � inv�lido para este campo.");
    o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => "Este campo precisa ser preenchido.");
    o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => "Este campo precisa ser preenchido.");
    o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => "� necess�rio que o body na requisi��o n�o esteja vazio.");
    o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor(x => "O valor preenchido � inv�lido para este campo.");
    o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => "O valor preenchido � inv�lido para este campo.");
    o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => "O campo deve ser num�rico");
    o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor(x => "O valor preenchido � inv�lido para este campo.");
    o.ModelBindingMessageProvider.SetValueIsInvalidAccessor(x => "O valor preenchido � inv�lido para este campo.");
    o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => "O campo deve ser num�rico.");
    o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => "Este campo precisa ser preenchido.");

    o.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/erro/500");
    app.UseStatusCodePagesWithRedirects("/erro/{0}");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Funcionario}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
