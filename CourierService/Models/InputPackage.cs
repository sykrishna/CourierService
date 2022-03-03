using System;
namespace CourierService.Models
{
    public class InputPackage
    {
        public string ID { get; set; }
        public decimal Weight { get; set; }
        public decimal Distance { get; set; }
        public string OfferCode { get; set; }        
    }
}
