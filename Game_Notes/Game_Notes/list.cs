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
    [Activity(Label = "list")]
    public class list : ListActivity //Activity.
    {
        // test
        //string[] items;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //
            var notesAdded = Intent.Extras.GetStringArrayList("user_note") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, notesAdded);

            //
            //items = new string[] { "Vegetables", "Fruits", "Flower Buds", "Legumes", "Bulbs", "Tubers" };
            //ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
        //
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            //
            //var t = items[position];
            //Android.Widget.Toast.MakeText(this, t, Android.Widget.ToastLength.Short).Show();
            //set alert for adding the note.
            AlertDialog.Builder alert = new AlertDialog.Builder(this);
            alert.SetTitle("Delete note");
            alert.SetMessage("Do you want to delete the note?");
            alert.SetPositiveButton("Confirm", (senderAlert, args) => {
                // removes the note from the list.
                Toast.MakeText(this, "Note deleted!", ToastLength.Short).Show();
            });

            alert.SetNegativeButton("Cancel", (senderAlert, args) => {
            });

            Dialog dialog = alert.Create();
            dialog.Show();
        }
    }
}