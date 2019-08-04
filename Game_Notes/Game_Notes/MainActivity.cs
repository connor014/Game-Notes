using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;

/*
 * The game notes app takes the information the user inputs and prints it out on the final activity. 
 */
namespace Game_Notes
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // when the button "add note" is clicked it takes the user to the create note activity.
            // assigning the button to buttonAddNote variable.
            var buttonAddNote = FindViewById<Button>(Resource.Id.buttonAdd);
            // once clicked the next activity is started.
            buttonAddNote.Click += delegate {

                Intent name = new Intent(this, typeof(addActivity));
                StartActivity(name);
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}