
using ShopDiaryProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopDiaryApp.API.Models.ViewModels
{
    public class InventorylogViewModel
    {
        public Guid Id { get; set; }
        public string CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LogDate { get; set; }
        public string Description { get; set; }
        public Guid InventoryId { get; set; }

        public Inventorylog ToModel()
        {
            return new Inventorylog
            {
                Id = (Id == Guid.Empty) ? Guid.NewGuid() : Id,
                CreatedUserId = CreatedUserId,
                CreatedDate = CreatedDate,
                LogDate = LogDate,
                Description=Description,
                InventoryId=InventoryId
            };
        }
        public InventorylogViewModel()
        {

        }

        public InventorylogViewModel(Inventorylog i)
        {
            this.Id = i.Id;
            this.CreatedUserId = i.CreatedUserId;
            this.CreatedDate = i.CreatedDate;
            this.LogDate = i.LogDate;
            this.Description = i.Description;
            this.InventoryId = i.InventoryId;


        }
       
    }
}