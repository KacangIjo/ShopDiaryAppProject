using ShopDiaryProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDiaryProject.Domain.ViewModels
{
    public class WishlistViewModel:FullAuditedEntity
    {
        public Guid ProductID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }

        public Wishlist ToModel()
        {
            return new Wishlist
            {
                
                Product = this.Product,
                Quantity=this.Quantity,
                Description=this.Description,
                Id = this.Id == Guid.Empty ? Guid.NewGuid() : this.Id
            };
        }

        public WishlistViewModel(Wishlist w)
        {
            this.Product = w.Product;
            this.Quantity = w.Quantity;
            this.Description = w.Description;
            this.Id = w.Id;
        }
    }
}
