﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using ShopDiaryProject.Domain.Models;

namespace ShopDiaryProjectV1.Models
{
    public class InventoryViewModel
    {
        public Guid Id { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public Guid StorageId { get; set; }
        public InventoryViewModel()
        {

        }

        public InventoryViewModel(Inventory inv)
        {
            Id = inv.Id;
            ExpirationDate = inv.ExpirationDate;
            StorageId = inv.StorageId;
        }
    }
}