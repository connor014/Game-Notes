using System;
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
    public class note : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.note);

            string title = Intent.GetStringExtra("Title" ?? "Not Recieved");
            string content = Intent.GetStringExtra("Content" ?? "Not Recieved");

            var titleName = FindViewById<TextView>(Resource.Id.textViewHeading);
            var titleContent = FindViewById<TextView>(Resource.Id.textViewNote);
            var titleButton = FindViewById<Button>(Resource.Id.buttonHome);

            titleName.Text = title;
            titleContent.Text = content;
            titleButton.Click += delegate
            {
                this.Finish();
            };
        }
    }
}