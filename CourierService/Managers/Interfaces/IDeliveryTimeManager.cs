using System;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService.Managers
{
    public interface IDeliveryTimeManager
    {
        List<OutputPackageWithDeliveryTime> GetPackageDetailsWithDiscountAndTotalCostAndDeliveryTime(
            int NoOfVehicles,
            List<Vehicle> vehicles,
            List<InputPackageWithDeliveryTime> inputPackagesWithDeliveryTime,
            List<OutputPackageWithDeliveryTime> outputPackageWithDeliveryTimes);
    }
}
