using System;
using System.Collections.Generic;
using System.Linq;
using CourierService.Models;

namespace CourierService.Managers
{
    public class PackageManager : IPackageManager
    {

        IDeliveryManager _deliveryManager { get; set; }
        public PackageManager(IDeliveryManager deliveryManager)
        {
            _deliveryManager = deliveryManager;
        }

        public List<OutputPackage> GetPackagesWithTotalDeliveryCostAndDiscount(decimal baseDeliveryCost, List<InputPackage> inputPackages, List<IOffer> offers)
        {            
            List<OutputPackage> outputPackages = new List<OutputPackage>();
            foreach (InputPackage inputPackage in inputPackages)
            {
                OutputPackage outputPackage = new OutputPackage();
                outputPackage.ID = inputPackage.ID;

                decimal tempDeliveryCost;
                    
                tempDeliveryCost = _deliveryManager.GetDeliveryCost(baseDeliveryCost, inputPackage);
                
                if (offers.Any(s => s.ID == inputPackage.OfferCode))
                {
                    outputPackage.Discount = offers.Where(s => s.ID == inputPackage.OfferCode).FirstOrDefault().GetDiscountAmount(tempDeliveryCost, inputPackage);
                }

                outputPackage.TotalCost = tempDeliveryCost - outputPackage.Discount;
                outputPackages.Add(outputPackage);
            }
            return outputPackages;
        }
    }
}
