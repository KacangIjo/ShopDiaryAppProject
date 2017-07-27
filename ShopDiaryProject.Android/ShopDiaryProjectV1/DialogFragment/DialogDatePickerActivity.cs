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
using static Android.Widget.DatePicker;

namespace ShopDiaryProjectV1
{
   public class OnDatePickedEventArgs:EventArgs
    {
        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public OnDatePickedEventArgs(DateTime date):base()
        {
            Date = date;
        }

    }
    class DialogDatePickerActivity:DialogFragment
    {
        private DateTime clickedDate;
        private DatePicker mDatePicker;
        private Button mButtonOK;
        public event EventHandler<OnDatePickedEventArgs> OnPickDateComplete;
        public override  View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.DialogPageDatePicker, container, false);
          
            mButtonOK = view.FindViewById<Button>(Resource.Id.buttonAddExpDateOk);
            mDatePicker = view.FindViewById<DatePicker>(Resource.Id.datePickerAddExpDate);
            clickedDate=mDatePicker.DateTime;
            clickedDate.ToString();
            mButtonOK.Click += BtnOk_Click;
            return view;
        }

     
        private void BtnOk_Click(object sender, EventArgs e)
        {
            clickedDate = mDatePicker.DateTime;
            OnPickDateComplete.Invoke(this, new OnDatePickedEventArgs(clickedDate));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            //Dialog.Window.Attributes.WindowAnimation = Resource.Style.dialogueAnimation; //set animasi
        }
    }
}