using System;
using System.Collections.Generic;
using CourierService.Models;

namespace CourierService.Managers
{
    public abstract class Offer : IOffer
    {
        public string ID { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DistanceMin { get; set; }
        public decimal DistanceMax { get; set; }        
        public decimal WeightMin { get; set; }
        public decimal WeightMax { get; set; }

        public Offer()
        {
        }

        public Offer(string ID,
            decimal DistancePercentage,
            decimal DistanceMin,
            decimal DistanceMax,            
            decimal WeightMin,
            decimal WeightMax)
        {
            this.ID = ID;
            this.DiscountPercentage = DistancePercentage;

            this.DistanceMin = DistanceMin;
            this.DistanceMax = DistanceMax;
            
            this.WeightMin = WeightMin;
            this.WeightMax = WeightMax;
        }

        public decimal GetDiscountAmount(decimal deliveryCost, InputPackage inputPackage)
        {
            decimal discountAmount = 0;
            if ((inputPackage.Distance >= DistanceMin && inputPackage.Distance <= DistanceMax)
                && (inputPackage.Weight >= WeightMin && inputPackage.Weight <= WeightMax))
            {
                discountAmount = deliveryCost * (DiscountPercentage / 100);
            }
            return discountAmount;
        }
    }
}
