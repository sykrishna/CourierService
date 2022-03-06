using System;
namespace CourierService.Models
{
    public class OutputPackageWithDeliveryTime : OutputPackage
    {
        public decimal DeliveryTime { get; set; }        
    }
}
