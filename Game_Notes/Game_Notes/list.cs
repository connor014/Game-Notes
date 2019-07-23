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
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            var notesAdded = Intent.Extras.GetStringArrayList("student_name") ?? new string[0];
            this.ListAdapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItem1, notesAdded);
        }
        //
        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            //
        }
    }
}