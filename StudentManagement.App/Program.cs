using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using StudentManagement.App;
using StudentManagement.App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
builder.Services.AddHttpClient<IClassDataService, ClassDataService>(client => 
    client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

builder.Services.AddMudServices();

await builder.Build().RunAsync();
