
using ShopDiaryProject.Domain.Models;
using System;

namespace ShopDiaryProject.Android.Models.ViewModels
{
    public class InventoryViewModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Price { get; set; }

        public Guid ProductId { get; set; }
        public Guid StorageId { get; set; }


        public Inventory ToModel()
        {
            return new Inventory
            {
                Id = (Id == Guid.Empty) ? Guid.NewGuid() : Id,
                Quantity = Quantity,
                ExpirationDate = ExpirationDate,
                Price = Price,
                ProductId=ProductId,
                StorageId=StorageId
               
            };
        }
        public InventoryViewModel()
        {

        }

        public InventoryViewModel(Inventory i)
        {
            this.Id = i.Id;
            this.Quantity = i.Quantity;
            this.ExpirationDate = i.ExpirationDate;
            this.Price = i.Price;
            this.ProductId = i.ProductId;
            this.StorageId = i.StorageId;


        }
       
    }
}