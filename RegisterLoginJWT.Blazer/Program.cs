using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RegisterLoginJWT.Blazer;
using RegisterLoginJWT.Blazer.Services;
using RegisterLoginJWT.Blazer.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddHttpClient("BackEnd", client =>
{
    client.BaseAddress = new Uri("https://localhost:7175/");
});
builder.Services.AddScoped<IUserSevices, UserServices>();
builder.Services.AddAuthorizationCore();
await builder.Build().RunAsync();
