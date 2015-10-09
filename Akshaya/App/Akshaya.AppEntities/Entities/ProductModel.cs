using System;
using System.Collections.Generic;

namespace Akshaya.AppEntities.Entities
{
    public class ProductModel : ModelBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public float BuyingPrice { get; set; }
        public float UnitPrice { get; set; }
        public int CurrentlyAvailable { get; set; }
        public List<PictureModel> Pictures { get; set; }
    }
}