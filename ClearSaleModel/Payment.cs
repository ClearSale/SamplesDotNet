using System;


namespace ClearSaleModel
{
    public class Payment
    {
        
        public DateTime Date { get; set; }
     
        public int Type { get; set; }

        public string Gateway { get; set; }
        
        public string CardHolderName { get; set; }

        public decimal Amount { get; set; }

        public string Brand { get; set; }

        public int CardType { get; set; }
  
        public string CardExpirationDate { get; set; }  

        public string CardBin { get; set; }

        public string CardEndNumber { get; set; }

        public string Nsu { get; set; }

    }
}