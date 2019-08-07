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
    [Activity(Label = "list")]
    public class list : ListActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // gets the data from the previous activity then displays it in a list view.
            var notesAdded = Intent.Extras.GetStringArrayList("user_note") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, notesAdded);
        }

        // When a listview item is clicked.
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            // gets the list data.
            var notesAdded = Intent.Extras.GetStringArrayList("user_note") ?? new string[0];
            var notesContent = Intent.Extras.GetStringArrayList("user_content") ?? new string[0];

            // stores the clicked position in a variable.
            var t = notesAdded[position];
            var s = notesContent[position];

            if (notesAdded[position] == "")
            {
                return;
            }
            else
            {
                // displays the note through an alert.
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle(t);
                alert.SetMessage(s);
                alert.SetPositiveButton("Delete", (senderAlert, args) => {
                    // removes the note from the list.
                    notesAdded[position] = "";
                    notesContent[position] = "";

                    // updates the list.
                    this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, notesAdded);
                    Toast.MakeText(this, "Note deleted!", ToastLength.Short).Show();
                });

                alert.SetNegativeButton("Cancel", (senderAlert, args) => {
                });

                Dialog dialog = alert.Create();
                dialog.Show();
            }
        }
    }
}