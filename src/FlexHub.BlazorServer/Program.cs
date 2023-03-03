using FlexHub.BlazorServer.StartupConfig;
using FlexHub.Data;
using MatBlazor;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAdB2C"));

builder.Services.AddControllersWithViews().AddMicrosoftIdentityUI();

builder.Services.AddRazorPages(opts => opts.RootDirectory = "/RazorComponents");
builder.Services.AddServerSideBlazor()
    .AddMicrosoftIdentityConsentHandler();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer("name=Default");
});

builder.Services.AddMatBlazor();
builder.AddRepositoryServices();
builder.AddRadzen();
builder.AddStores();

WebApplication app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.UseRewriter(
    new RewriteOptions().Add(
        context =>
        {
            if (context.HttpContext.Request.Path.Equals("/MicrosoftIdentity/Account/SignedOut"))
            {
                context.HttpContext.Response.Redirect("/");
            }
        }
    )
);

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
