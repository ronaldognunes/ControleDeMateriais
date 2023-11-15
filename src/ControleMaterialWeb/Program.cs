using Blazored.LocalStorage;
using ControleMaterialWeb;
using ControleMaterialWeb.Autenticacao;
using ControleMaterialWeb.Configurations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<TokenAutehtication>();
builder.Services.AddScoped<AuthenticationStateProvider, TokenAutehtication>(p => p.GetRequiredService<TokenAutehtication>());
//componentes 
builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();

// adicionando os serviços
builder.Services.AddServicos();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7169/") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("controlemateriaisapi") });


await builder.Build().RunAsync();
