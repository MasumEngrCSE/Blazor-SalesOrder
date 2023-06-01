using BlazorBootstrap;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SalesOrder.Web;
using SalesOrder.Web.Services.Implementation;
using SalesOrder.Web.Services.Interface;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7147/") });
builder.Services.AddBlazorBootstrap();
//https://localhost:7147/
//builder.HostEnvironment.BaseAddress

builder.Services.AddScoped<IStateInfoService, StateInfoService>();
builder.Services.AddScoped<ISaleOrderService, SaleOrderService>();

await builder.Build().RunAsync();
