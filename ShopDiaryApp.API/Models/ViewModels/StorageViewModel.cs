using ShopDiaryProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopDiaryApp.API.Models.ViewModels
{
    public class StorageViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Block { get; set; }
        public string Area { get; set; }
        public string Description { get; set; }

        public Guid LocationId { get; set; }
       

        public Storage ToModel()
        {
            return new Storage
            {
                Id = (Id == Guid.Empty) ? Guid.NewGuid() : Id,
                Name = Name,
                Block = Block,
                Area = Area,
                Description = Description,
                LocationId = LocationId
            };
        }
        public StorageViewModel()
        {

        }

        public StorageViewModel(Storage s)
        {
            this.Id = s.Id;
            this.Name = s.Name;
            this.Description = s.Description;
            this.Area = s.Area;
            this.Block = s.Block;
            this.LocationId = s.LocationId;
            
        }
       
    }
}