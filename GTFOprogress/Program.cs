using GTFOprogress;
using GTFOprogress.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<RundownRepository>();
builder.Services.AddScoped<StateHandlerService>();
builder.Services.AddScoped<SettingsService>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
