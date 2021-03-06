﻿namespace Akshaya.Data.Entities
{
    public class OrderProduct
    {
        public long Id { get; set; }
        public Product Product { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public float UnitPriceSold { get; set; }
    }
}