using ShopDiaryProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDiaryProject.Domain.ViewModels
{
    public class ShopitemViewModel : FullAuditedEntity
    {
        public int Quantity { get; set; }
        public decimal price { get; set; }

        public Guid ProductID{ get; set; }
        public Guid ShoplistID { get; set; }

        public Shopitem ToModel()
        {
            return new Shopitem
            {
                Quantity = this.Quantity,
                price = this.price,
                CreatedDate = this.CreatedDate,
                Id = this.Id == Guid.Empty ? Guid.NewGuid() : this.Id
            };
        }

        public ShopitemViewModel(Shopitem p)
        {
            this.Quantity = p.Quantity;
            this.price = p.price;
            this.CreatedDate = p.CreatedDate;
            this.Id = p.Id;
        }

        public ShopitemViewModel()
        {

        }
    }
}
