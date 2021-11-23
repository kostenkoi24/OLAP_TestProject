using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;


using Android.Content;
using Android.Views;
using Java.Util;
//using static Java.Interop.JniEnvironment;

namespace ListView_Add
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : ListActivity //AppCompatActivity
    {
        List<string> items;
        ArrayAdapter<string> adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            
            items = new List<string>(new[] { "Some item" });
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleListItemActivated1, items);
            ListAdapter = adapter;
            FindViewById<Button>(Resource.Id.button1).Click += HandleClick;
            
        }
                

        protected void HandleClick(object sender, EventArgs e)
        {
            adapter.Add(""+FindViewById<EditText>(Resource.Id.editText1).Text +"");
            adapter.NotifyDataSetChanged();
            Android.Widget.Toast.MakeText(this, "Method was called", ToastLength.Short).Show();
        }

       

    } 
}