using Blazored.LocalStorage;
using Blazored.Modal;
using BlazorVİdeo.Client;
using BlazorVİdeo.Client.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddBlazoredModal();
builder.Services.AddScoped<ModalManager>();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
