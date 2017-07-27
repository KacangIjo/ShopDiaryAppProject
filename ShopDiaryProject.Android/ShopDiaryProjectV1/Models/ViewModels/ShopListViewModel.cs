
using ShopDiaryProject.Domain.Models;
using System;

namespace ShopDiaryProject.Android.Models.ViewModels
{
    public class ShopListViewModel
    {
        public Guid Id { get; set; }
        public Guid ProductID { get; set; }
        public string Description { get; set; }

        
       

        public Wishlist ToModel()
        {
            return new Wishlist
            {
                Id = (Id == Guid.Empty) ? Guid.NewGuid() : Id,
                ProductID = ProductID
            };
        }
        public ShopListViewModel()
        {

        }

        public ShopListViewModel(Wishlist c)
        {
            this.Id = c.Id;
            this.ProductID = c.ProductID;
        }
       
    }
}