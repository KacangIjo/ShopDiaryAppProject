using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShopDiaryProject.Domain.Models
{
    public class Wishlist : FullAuditedEntity
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
    }
}