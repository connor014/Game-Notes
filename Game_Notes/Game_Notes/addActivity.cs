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
    [Activity(Label = "addActivity")]
    public class addActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.add);


            //sends to second activity.
            var editNoteTitle = FindViewById<EditText>(Resource.Id.editTextHeading);
            var editNoteContent = FindViewById<EditText>(Resource.Id.editTextNote);
            var addNoteButton = FindViewById<Button>(Resource.Id.buttonSave);

            addNoteButton.Click += (s, e) =>
            {
                Intent next = new Intent(this, typeof(note));
                next.PutExtra("Title", editNoteTitle.Text);
                next.PutExtra("Content", editNoteContent.Text);
                StartActivity(next);
            };
        }
    }
}