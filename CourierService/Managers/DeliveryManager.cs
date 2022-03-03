using System;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService.Managers
{
    public class DeliveryManager : IDeliveryManager
    {
        public DeliveryManager()
        {
        }

        public decimal GetDeliveryCost(decimal baseDeliveryCost, InputPackage inputPackage)
        {
            return baseDeliveryCost + (inputPackage.Weight * 10) + (inputPackage.Distance * 5);                                       
        }
    }
}
