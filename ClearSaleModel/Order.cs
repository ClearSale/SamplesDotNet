using System;
using System.Collections.Generic;
namespace ClearSaleModel
{
    public class Order
    {
        public string ID { get; set; }
        
        public DateTime Date { get; set; }
       
        public string Email { get; set; }
        
        public decimal TotalItems {get;set;}

        public decimal TotalOrder { get; set; }

        public decimal TotalShipping { get; set; }

        public int QtyInstallments { get; set; }
        
        public string Currency { get; set; }
        
        public string IP { get; set; }

        public string Obs { get; set; }

        public string Status { get; set; }

        public List<Payment> Payments { get; set; }

        public Person BillingData { get; set; }

        public Person ShippingData { get; set; }

        public List<Item> Items { get; set; }

        public List<Custom> CustomFields { get; set; }

        public string SessionID { get; set; }

        public bool Reanalysis { get; set; }

    }

   
}