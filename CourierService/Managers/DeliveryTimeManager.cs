using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CourierService.Models;

namespace CourierService.Managers
{
    public class DeliveryTimeManager : IDeliveryTimeManager
    {
        public DeliveryTimeManager()
        {
        }

        public List<OutputPackageWithDeliveryTime> GetPackageDetailsWithDiscountAndTotalCostAndDeliveryTime(
            int noOfVehicles,
            List<Vehicle> vehicles,
            List<InputPackageWithDeliveryTime> inputPackagesWithDeliveryTime,
            List<OutputPackageWithDeliveryTime> outputPackageWithDeliveryTimes
            )
        {
            try
            {                                
                if (inputPackagesWithDeliveryTime.Count >= 1)
                {                                                           
                    for (int i = 0; i < noOfVehicles; i++)
                    {
                        vehicles[i].InputPackagesWithDeliveryTime = sum_up_recursive(inputPackagesWithDeliveryTime, vehicles[i].MaxWeight, new List<InputPackageWithDeliveryTime>());
                        foreach (InputPackageWithDeliveryTime inputPackageWithDeliveryTime in vehicles[i].InputPackagesWithDeliveryTime)
                        {                            
                            outputPackageWithDeliveryTimes.Where(s => s.ID == inputPackageWithDeliveryTime.ID).FirstOrDefault().DeliveryTime = inputPackageWithDeliveryTime.Distance / vehicles[i].MaxSpeed;
                            decimal tempMaxDeliveryTime = vehicles[i].InputPackagesWithDeliveryTime.Max(s => s.DeliveryTIme);
                            vehicles[i].NextAvailability = 2 * tempMaxDeliveryTime;
                            inputPackagesWithDeliveryTime.Remove(inputPackageWithDeliveryTime);                            
                        }

                        if (inputPackagesWithDeliveryTime.Count <= 0)
                        {
                            break;
                        }
                        else 
                        {
                            i = vehicles.OrderByDescending(s => s.NextAvailability).FirstOrDefault().ID - 1;
                        }                        
                    }
                }
                
            }
            catch (Exception ex)
            {

            }
            return outputPackageWithDeliveryTimes;
        }        

        private List<InputPackageWithDeliveryTime> sum_up_recursive(List<InputPackageWithDeliveryTime> numbers, decimal target, List<InputPackageWithDeliveryTime> partial)
        {
            decimal s = 0;
            foreach (InputPackageWithDeliveryTime x in partial) s += x.Weight;

            //if (s == target)
                //Console.WriteLine("sum(" + string.Join(",", partial.ToArray()) + ")=" + target);

            if (s >= target)
                return partial;


            for (int i = 0; i < numbers.Count; i++)
            {
                List<InputPackageWithDeliveryTime> remaining = new List<InputPackageWithDeliveryTime>();
                InputPackageWithDeliveryTime n = numbers[i];
                for (int j = i + 1; j < numbers.Count; j++) remaining.Add(numbers[j]);

                List<InputPackageWithDeliveryTime> partial_rec = new List<InputPackageWithDeliveryTime>(partial);
                partial_rec.Add(n);

                if (numbers.Count > 1)
                {
                    sum_up_recursive(remaining, target, partial_rec);
                }
            }

            return partial;
        }
    }
}
