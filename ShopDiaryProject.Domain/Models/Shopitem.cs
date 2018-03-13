using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopDiaryProject.Domain.Models
{
    public class Shopitem : FullAuditedEntity
    {

        public int Quantity { get; set; }
        public decimal price { get; set; }

        public Guid ProductId { get; set; }
        public Product product { get; set; }
        public Guid ShoplistId { get; set; }
        public Shoplist Shoplist { get; set; }
        
        public Shopitem()
        {
            Quantity=0;
            price = 0.0M;
        }

    }
}