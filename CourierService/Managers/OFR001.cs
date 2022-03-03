using System;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService.Managers
{
    public class OFR001 : Offer
    {
        public OFR001()
        {
        }

        public OFR001(string ID,
            decimal DiscountPercentage,
            decimal DistanceMin,
            decimal DistanceMax,
            decimal WeightMin,
            decimal WeightMax):base(ID, DiscountPercentage, DistanceMin, DistanceMax, WeightMin, WeightMax)
        {
        }      
    }
}
