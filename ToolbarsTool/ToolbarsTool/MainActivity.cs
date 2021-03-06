using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Views;

namespace ToolbarsTool
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

            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetActionBar(toolbar);

           // toolbar.Title = "Menu";
           // toolbar.InflateMenu(Resource.Menu.home);

            //ActionBar.Title = "Hello from Toolbar";


            //var toolbarBottom = FindViewById<Toolbar>(Resource.Id.toolbar_bottom);

            //toolbarBottom.Title = "Photo Editing";
            //toolbarBottom.InflateMenu(Resource.Menu.photo_edit);
            //toolbarBottom.MenuItemClick += (sender, e) => {
            //  Toast.MakeText(this, "Bottom toolbar pressed: " + e.Item.TitleFormatted, ToastLength.Short).Show();
            //};

        }


        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Top ActionBar pressed: " + item.TitleFormatted, ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }



        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        //{
        //    Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

        //    base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}
    }
}