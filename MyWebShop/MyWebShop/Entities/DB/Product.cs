﻿using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebShop.Entities.DB
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Price { get; set; }
        public string? Image { get; set; }
        public Category? category { get; set; }
    }
}
