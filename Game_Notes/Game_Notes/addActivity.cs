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

/*
 * The transfering data between activities code is from the week 2 sit313 prac. 
 */

namespace Game_Notes
{
    [Activity(Label = "addActivity")]
    public class addActivity : Activity
    {
        // strings to store the data.
        static readonly List<string> noteTitle = new List<string>();
        static readonly List<string> noteContent = new List<string>();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.add);

            // each resource required buttons, textview etc have been defined.
            Button viewAllButton = FindViewById<Button>(Resource.Id.button1);
            Button saveButton = FindViewById<Button>(Resource.Id.buttonSave);
            TextView name = FindViewById<EditText>(Resource.Id.editTextHeading);
            TextView content = FindViewById<EditText>(Resource.Id.editTextContent);

            // once the viewAllButton is clicked the following runs.
            viewAllButton.Click += (sender, e) =>
            {
                // the note entries that are entered are added to the list noteTitle and noteContent, the user is then taken to the note activity.
                var intent = new Intent(this, typeof(Game_Notes.list));
                intent.PutStringArrayListExtra("user_note", noteTitle);
                intent.PutStringArrayListExtra("user_content", noteContent);
                StartActivity(intent);
            };

            // when the save button is clicked the following runs.
            saveButton.Click += (sender, e) => 
            {
                // ensures if theres no note and the save button is pressed it isnt saved and a alert is presented.
                string newNote = "";
                if (string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(content.Text))
                {
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Warning");
                    alert.SetMessage("Note title and content needs to be filled in");
                    alert.SetPositiveButton("Ok", (senderAlert, args) => {
                    });
                    Dialog dialog = alert.Create();
                    dialog.Show();
                    newNote = "";
                }
                // adds the note to the noteTitle list.
                else
                {
                    //set alert for adding the note.
                    AlertDialog.Builder alert = new AlertDialog.Builder(this);
                    alert.SetTitle("Confirm note");
                    alert.SetMessage("Do you want to add the note: " + name.Text + "?");
                    alert.SetPositiveButton("Confirm", (senderAlert, args) => {
                        // adds the note to the list.
                        noteTitle.Add(name.Text);
                        noteContent.Add(content.Text);
                        Toast.MakeText(this, "Note Added!", ToastLength.Short).Show();
                        // clears the edit text
                        name.Text = "";
                        content.Text = "";
                    });

                    alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                        // doesn't add the note to the list and clears the edit text.
                        name.Text = "";
                        content.Text = "";
                        Toast.MakeText(this, "The note wasn't added!", ToastLength.Short).Show();
                    });

                    Dialog dialog = alert.Create();
                    dialog.Show();
                }
            };
        }
    }
}