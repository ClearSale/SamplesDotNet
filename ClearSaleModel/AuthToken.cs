using System;

namespace ClearSaleModel
{
    public class AuthToken
    {
        public string Value { get; set; }

        public DateTime ExpirationDate { get; set; }
    }
}