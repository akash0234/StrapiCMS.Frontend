
using StrapiCMS.Frontend.Components;
using StrapiCMS.ApiClient.Repositories;
using StrapiCMS.ApiClient.Services;
using StrapiSharp.Extensions;
using StrapiCMS.Frontend.SessionServices.Repositories;
using StrapiCMS.Frontend.SessionServices.Services;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Authorization;
using StrapiCMS.Frontend.AuthProvider;
using StrapiCMS.Frontend.CartServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


builder.Services.AddStrapiSharp(builder.Configuration["Strapi:ServerURI"]);
builder.Services.AddScoped<IMetaService,MetaService>();
builder.Services.AddTransient<IStrapiApiClient, StrapiApiClient>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthProvider>();
builder.Services.AddScoped<IUserCartService, UserCartService>();
builder.Services.AddSweetAlert2();


//Authentication Services
builder.Services.AddCascadingAuthenticationState();

var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
