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

namespace Game_Notes
{
    [Activity(Label = "note")]
    public class note : ListActivity 
    {
        //
        string[] items;
        protected override void OnCreate(Bundle bundle) 
        {
            base.OnCreate(bundle);
            items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
        //protected override void OnListItemClick(ListView l, View v, int position, long id);
    }

}