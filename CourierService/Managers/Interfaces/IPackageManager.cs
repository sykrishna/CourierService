using System;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService.Managers
{
    public interface IPackageManager
    {
        List<OutputPackage> GetPackagesWithTotalDeliveryCostAndDiscount(decimal baseDeliveryCost, List<InputPackage> inputPackages, List<IOffer> offers);
    }
}
