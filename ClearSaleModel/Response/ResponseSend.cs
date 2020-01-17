using System.Collections.Generic;

namespace ClearSaleModel
{
    public class ResponseSend
    {
        public List<OrderScoreStatus> Orders { get; set; }

        public string TransactionID { get; set; }
    }
}