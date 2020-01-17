using System.Collections.Generic;

namespace ClearSaleModel
{

    public class OffLineEntities
    {
        public List<Entity> Entities;
    }

    public class Entity
    {

        public int Id;
        public string ApiKey;
        public string ClientId;
        public string ClientSecret;
    }




}