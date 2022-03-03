using System;
using CourierService.Models;

namespace CourierService.Managers
{
    public class OFR003 : Offer
    {
        public OFR003()
        {
        }

        public OFR003(string ID,
            decimal DiscountPercentage,
            decimal DistanceMin,
            decimal DistanceMax,
            decimal WeightMin,
            decimal WeightMax) : base(ID, DiscountPercentage, DistanceMin, DistanceMax, WeightMin, WeightMax)
        {
        }
    }
}
