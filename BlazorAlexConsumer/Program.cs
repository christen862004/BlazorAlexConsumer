using BlazorAlexConsumer.Models;
using BlazorAlexConsumer.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorAlexConsumer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddHttpClient<IServices<Employee>, EmployeService>(
                httpclient => httpclient.BaseAddress =
                    new Uri(builder.Configuration.GetValue<string>("ApiIp")));

            builder.Services.AddHttpClient<IServices<Department>, DepartmentServices>(
                httpclient => httpclient.BaseAddress = 
                    new Uri(builder.Configuration.GetValue<string>("ApiIp"))
                ); 
            //builder.Services.AddScoped<IServices<Employee>, EmployeService>();
            //builder.Services.AddScoped<IServices<Department>, DepartmentServices>();
            ////DAy3
            //builder.Services.AddScoped(
            //    sp => 
            //    new HttpClient { 
            //        BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiIp")) });//register HttpClient
            //sp.GetRequiredService<IConfiguration>()["ApiIp"]
            await builder.Build().RunAsync();
        }
    }
}
