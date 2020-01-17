using System.Collections.Generic;

namespace ClearSaleModel.Request
{
    public class RequestSend
    {

        public string ApiKey { get; set; }

        public string LoginToken { get; set; }

        public List<Order> Orders { get; set; }

        public string AnalysisLocation { get; set; }
    }

}