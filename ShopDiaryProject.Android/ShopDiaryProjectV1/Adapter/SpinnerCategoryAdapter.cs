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
using Java.Lang;
using ShopDiaryProject.Android.Models.ViewModels;

namespace ShopDiaryProjectV1.Adapter
{
    public class SpinnerStorageAdapter : BaseAdapter
    {
        readonly Activity mActivity;
        private List<StorageViewModel> mStorages;
        public SpinnerStorageAdapter(Activity activity, List<StorageViewModel> storages)
        {
            mActivity = activity;
            mStorages = storages;
        }
        public override int Count
        {
            get { return mStorages.Count; }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = mStorages[position];
            var view = (convertView ?? mActivity.LayoutInflater.Inflate(Android.Resource.Layout.SimpleSpinnerDropDownItem,
                parent,
                false));
            var name = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            name.Text = item.Name;
            return view;
        }

        public StorageViewModel GetItemAtPosition(int position)
        {
            return mStorages[position];
        }
    }
}