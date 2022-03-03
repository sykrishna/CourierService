using System;
using System.Threading.Tasks;
using CourierService.Managers;
using CourierService.Models;
using CourierService.PresentationLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourierService
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //IHost host = Host.CreateDefaultBuilder(args).ConfigureServices((_, services) => services
            //.AddTransient<IDeliveryManager, DeliveryManager>()
            //.AddTransient<IPackageManager, PackageManager>()            
            ////.AddSingleton<, DefaultOperation>()            
            //).Build();

            //IServiceScope serviceScope = host.Services.CreateScope();
            //IServiceProvider provider = serviceScope.ServiceProvider;

            //PackageManager packageManager = provider.GetRequiredService<PackageManager>();

            DeliveryManager deliveryManager = new DeliveryManager();
            PackageManager packageManager = new PackageManager(deliveryManager);
                       
            ClientUI clientUI = new ClientUI(packageManager);                   
        }
    }
}
