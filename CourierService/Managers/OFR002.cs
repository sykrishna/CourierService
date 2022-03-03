using System;
using CourierService.Models;

namespace CourierService.Managers
{
    public class OFR002 : Offer
    {
        public OFR002()
        {
        }

        public OFR002(string ID,
            decimal DiscountPercentage,
            decimal DistanceMin,
            decimal DistanceMax,
            decimal WeightMin,
            decimal WeightMax) : base(ID, DiscountPercentage, DistanceMin, DistanceMax, WeightMin, WeightMax)
        {
        }
    }
}
