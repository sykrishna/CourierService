using System;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService.Managers
{
    public interface IDeliveryManager
    {
        decimal GetDeliveryCost(decimal baseDeliveryCost, InputPackage inputPackage);
    }
}
