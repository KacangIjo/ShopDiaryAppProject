﻿using ShopDiaryProject.Domain.Models;
using System;

namespace ShopDiaryProject.Android.Models.ViewModels
{
    public class LocationViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string AddedUserId { get; set; }

       

        public Location ToModel()
        {
            return new Location
            {
                Id = (Id == Guid.Empty) ? Guid.NewGuid() : Id,
                Name = Name,
                Address = Address,
                Description = Description,
                AddedUserId = AddedUserId
            };
        }
        public LocationViewModel()
        {

        }

        public LocationViewModel(Location l)
        {
            this.Id = l.Id;
            this.Name = l.Name;
            this.Description = l.Description;
            this.Address = l.Address;
            this.AddedUserId = l.AddedUserId;
            
        }
       
    }
}