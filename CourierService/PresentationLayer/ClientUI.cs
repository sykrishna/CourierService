using System;
using System.Collections.Generic;
using CourierService.Managers;
using CourierService.Models;
using CourierService.Models.Enums;

namespace CourierService.PresentationLayer
{
    public class ClientUI
    {
        public decimal BaseDeliveryCost { get; set; }
        public int NoOfPackages { get; set; }
        public List<InputPackage> InputPackages { get; set; }
        public List<IOffer> Offers { get; set; }

        IPackageManager _packageManager { get; set; }        

        public ClientUI(IPackageManager packageManager)
        {
            _packageManager = packageManager;            

            SetOffers();
            ReadBaseDeliveryCostAndNoOfPackages();
            ReadPackageDetails();
            DiplayPackageDetailsWithDiscountAndTotalCost();
        }

        public void SetOffers()
        {
            Offers = new List<IOffer>();
            Offers.Add(new OFR001(OffersEnum.OFR001.ToString(), 10, 0, 200, 70, 200));
            Offers.Add(new OFR002(OffersEnum.OFR002.ToString(), 7, 50, 150, 100, 250));
            Offers.Add(new OFR003(OffersEnum.OFR003.ToString(), 5, 50, 250, 10, 150));
        }

        public void ReadBaseDeliveryCostAndNoOfPackages()
        {
            try
            {
                Console.Write("base_delivery_cost no_of_packges : ");
                string base_delivery_cost_and_no_of_packges = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(base_delivery_cost_and_no_of_packges))
                {
                    string[] temp = base_delivery_cost_and_no_of_packges.Split(' ');

                    if (temp.Length == 2 &&
                        decimal.TryParse(temp[0], out decimal baseDeliveryCost) &&
                        int.TryParse(temp[1], out int noOfPackages))
                    {
                        BaseDeliveryCost = baseDeliveryCost;
                        NoOfPackages = noOfPackages;
                        return;
                    }
                }

                Console.WriteLine("Invalid input!");
                ReadBaseDeliveryCostAndNoOfPackages();
                
            }
            catch (Exception ex)
            {

            }            
        }

        public void ReadPackageDetails()
        {
            try
            {
                InputPackages = new List<InputPackage>();
                for (int i = 1; i <= NoOfPackages; i++)
                {
                    Console.Write("pkg_id{0} pkg_weight{0}_in_kg distance{0}_in_km offer_code{0}: ", i);
                    string packageDetails = Console.ReadLine();

                    if (!string.IsNullOrWhiteSpace(packageDetails))
                    {
                        string[] temp = packageDetails.Split(' ');

                        if (temp.Length == 4 &&
                            !string.IsNullOrWhiteSpace(temp[0]) &&
                            decimal.TryParse(temp[1], out decimal weight) &&
                            decimal.TryParse(temp[2], out decimal distance) &&
                            !string.IsNullOrWhiteSpace(temp[3]))
                        {
                            InputPackage package = new InputPackage();
                            package.ID = temp[0];
                            package.Weight = weight;
                            package.Distance = distance;
                            package.OfferCode = temp[3];

                            InputPackages.Add(package);
                            continue;
                        }
                    }

                    Console.WriteLine("Invalid input!");
                    i--;
                }                
            }
            catch (Exception ex)
            {

            }
        }

        public void DiplayPackageDetailsWithDiscountAndTotalCost()
        {
            try
            {                
                List<OutputPackage> outputPackages = new List<OutputPackage>();
                outputPackages = _packageManager.GetPackagesWithTotalDeliveryCostAndDiscount(BaseDeliveryCost, InputPackages, Offers);

                foreach (OutputPackage outputPackage in outputPackages)
                {
                    Console.WriteLine("pkg_id1 discount1 total_cost1 : {0} {1} {2}", outputPackage.ID, outputPackage.Discount, outputPackage.TotalCost);
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
