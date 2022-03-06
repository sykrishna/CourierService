using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using CourierService.Managers;
using CourierService.Models;
using CourierService.PresentationLayer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CourierService.Models.Enums;

namespace CourierService
{
    class MainClass
    {
        static List<IOffer> Offers;

        public static void Main(string[] args)
        {           
            var services = new ServiceCollection()
            .AddTransient<IDeliveryManager, DeliveryManager>()
            .AddTransient<IPackageManager, PackageManager>()
            .AddTransient<IDeliveryTimeManager, DeliveryTimeManager>();

            var serviceProvider = services.BuildServiceProvider();
            
            IPackageManager packageManager = serviceProvider.GetService<IPackageManager>();
            IDeliveryTimeManager deliveryTimeManager = serviceProvider.GetService<IDeliveryTimeManager>();


            //First Challenge
            SetOffers();
            IClient client1 = new Client1(Offers, packageManager);
            client1.Start();

            //Second Challenge implimented with out modifing existing implimentation
            SetOffers();
            IClient client2 = new Client2(Offers, packageManager, deliveryTimeManager);
            client2.Start();

        }

        public static void SetOffers()
        {
            Offers = new List<IOffer>();
            Offers.Add(new OFR001(OffersEnum.OFR001.ToString(), 10, 0, 200, 70, 200));
            Offers.Add(new OFR002(OffersEnum.OFR002.ToString(), 7, 50, 150, 100, 250));
            Offers.Add(new OFR003(OffersEnum.OFR003.ToString(), 5, 50, 250, 10, 150));
        }
    }
}
