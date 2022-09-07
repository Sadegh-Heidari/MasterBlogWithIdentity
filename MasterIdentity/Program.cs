using Infrastructure.EFCORE.ContextDB;
using Infrastructure.Utility.ServicePresentationLayyer;
using MasterIdentity.ClaimAndPolicyClass;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(op =>
{
    op.Conventions.AuthorizeAreaFolder("Admin", "/", "Admin");
});
builder.Services.AddIoc(builder.Configuration.GetConnectionString("Sql"));
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<MasterContext>().AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(x =>
{
    x.Password.RequireDigit = true;
    x.Password.RequireLowercase = true;
    x.Password.RequiredLength = 8;
    x.SignIn.RequireConfirmedEmail = true;
});
builder.Services.ConfigureApplicationCookie(x =>
{
    x.ExpireTimeSpan = TimeSpan.FromMinutes(10);
    x.LoginPath = "/Register/LogIn";
    x.SlidingExpiration = true;
});
builder.Services.AddAuthorization(x =>
{
    x.AddPolicy("Admin", c =>
    {
        c.RequireRole("Admin");
    });
});
builder.Services.AddScoped<IClaimsTransformation, AddClaim>();
var app = builder.Build();
app.Services.AutoCreatDataBase();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();
