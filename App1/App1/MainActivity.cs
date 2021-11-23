using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;



namespace App1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView textView1;

        int number;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.layout1);

            Button button1 = FindViewById<Button>(Resource.Id.button1);

            textView1 = FindViewById<TextView>(Resource.Id.textView1);

            FindViewById<Button>(Resource.Id.button1).Click += (e, o) =>
             textView1.Text = (++number).ToString();

            //FindViewById<Button>(Resource.Id.btnDecrement).Click += (e, o) =>
            //  txtNumber.Text = (--number).ToString();

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}