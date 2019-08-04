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

/*
 * The transfering data between activities code is from the week 2 sit313 prac. 
 */

namespace Game_Notes
{
    [Activity(Label = "addActivity")]
    public class addActivity : Activity
    {
        // string to store the data.
        static readonly List<string> noteTitle = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.add);

            // each resource required buttons, textview etc have been defined.
            Button viewAllButton = FindViewById<Button>(Resource.Id.button1);
            Button saveButton = FindViewById<Button>(Resource.Id.buttonSave);
            TextView name = FindViewById<EditText>(Resource.Id.editTextHeading);

            // once the viewAllButton is clicked the following runs.
            viewAllButton.Click += (sender, e) =>
            {
                // the note entries that are entered are added to the list noteTitle, the user is then taken to the note activity.
                var intent = new Intent(this, typeof(Game_Notes.list));
                intent.PutStringArrayListExtra("student_name", noteTitle);
                StartActivity(intent);
            };

            // when the save button is clicked the following runs.
            saveButton.Click += (sender, e) => 
            {
                // ensures if theres no note and the save button is pressed it isnt saved.
                string newName = "";
                if (string.IsNullOrWhiteSpace(name.Text))
                {
                    newName = "";
                }
                // adds the note to the noteTitle list.
                else
                {
                    noteTitle.Add(name.Text);
                }
                // empties the text field.
                name.Text = "";
            };
        }
    }
}