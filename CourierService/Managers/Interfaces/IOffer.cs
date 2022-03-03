using System;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService.Managers
{
    public interface IOffer
    {
        string ID { get; set; }
        decimal DiscountPercentage { get; set; }
        decimal DistanceMin { get; set; }
        decimal DistanceMax { get; set; }        
        decimal WeightMin { get; set; }
        decimal WeightMax { get; set; }
        decimal GetDiscountAmount(decimal deliveryCost, InputPackage inputPackage);        
    }
}
