﻿using System.ComponentModel.DataAnnotations;

namespace OnSalePrep.Web.Data.Entities
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public float Quantity { get; set; }

        public decimal Price { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public decimal Value => (decimal)Quantity * Price;
    }
}
