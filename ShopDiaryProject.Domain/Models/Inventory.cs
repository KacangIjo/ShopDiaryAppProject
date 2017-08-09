using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopDiaryProject.Domain.Models
{
    public class Inventory : FullAuditedEntity
    {
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string ItemName { get; set; }
        public decimal Price { get; set; }
        public bool IsConsumed { get; set; }
        public Guid StorageId { get; set; }
        public Storage Storage { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        public Inventory()
        {
        
        }
    }
}