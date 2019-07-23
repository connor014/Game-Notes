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
        // string to store data.
        static readonly List<string> noteTitle = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.add);

            // testing displaying list.
            Button viewAllButton = FindViewById<Button>(Resource.Id.button1);
            Button saveButton = FindViewById<Button>(Resource.Id.buttonSave);
            TextView name = FindViewById<EditText>(Resource.Id.editTextHeading);
            viewAllButton.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(Game_Notes.list));
                intent.PutStringArrayListExtra("student_name", noteTitle);
                StartActivity(intent);
            };
                saveButton.Click += (sender, e) => 
                {
                    string newName = "";
                    if (string.IsNullOrWhiteSpace(name.Text))
                    {
                        newName = "";
                    }
                    else
                    {
                        noteTitle.Add(name.Text);
                    }
                };
        }
    }
}