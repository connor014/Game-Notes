using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using AlertDialog = Android.App.AlertDialog;

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

            // when the about button is clicked it provides the user with the about prompt explaining the app.
            // assignes the about button to a variable.
            var btnAbout = FindViewById<Button>(Resource.Id.buttonAbout);

            // When the about button is clicked the following alert runs.
            btnAbout.Click += (sender, e) =>
            {
                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("About");
                alert.SetMessage("The Game Notes app allows you to create any notes you need, whether its keeping track of pre orders, games lent to friends or games soon to be released, Game Notes is the only note taking app you'll need for everything gaming.");
                alert.SetPositiveButton("Ok", (senderAlert, args) => {
                });
                Dialog dialog = alert.Create();
                dialog.Show();
            };
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}