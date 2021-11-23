//using Android.App;
//using Android.OS;
//using Android.Support.V7.App;
//using Android.Runtime;
//using Android.Widget;

//namespace SQLiteDB
//{
//    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
//    public class MainActivity : AppCompatActivity
//    {
//        protected override void OnCreate(Bundle savedInstanceState)
//        {
//            base.OnCreate(savedInstanceState);
//            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
//            // Set our view from the "main" layout resource
//            SetContentView(Resource.Layout.activity_main);
//        }
//        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
//        {
//            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

//            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
//        }
//    }
//}



using Android.App;
using Android.OS;
using Android.Widget;
using SQLiteDB.Resources.Helper;
using SQLiteDB.Resources.Model;
using System.Collections.Generic;
using Person = SQLiteDB.Resources.Model.Person;

namespace SQLiteDB
{
    [Activity(Label = "SQLiteDB", MainLauncher = true)]
    public class MainActivity : Activity
    {
        ListView lstViewData;
        List<Person> listSource = new List<Person>();
        Database db;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource  
            SetContentView(Resource.Layout.activity_main);
            //Create Database  
            db = new Database();
            db.createDatabase();
            lstViewData = FindViewById<ListView>(Resource.Id.listView);
            var edtName = FindViewById<EditText>(Resource.Id.edtName);
            var edtDepart = FindViewById<EditText>(Resource.Id.edtDepart);
            var edtEmail = FindViewById<EditText>(Resource.Id.edtEmail);
            var btnAdd = FindViewById<Button>(Resource.Id.btnAdd);
            var btnEdit = FindViewById<Button>(Resource.Id.btnEdit);
            var btnRemove = FindViewById<Button>(Resource.Id.btnRemove);
            //Load Data  
            LoadData();
            //Event  
            btnAdd.Click += delegate
            {
                Person person = new Person()
                {
                    Name = edtName.Text,
                    Department = edtDepart.Text,
                    Email = edtEmail.Text
                };
                db.insertIntoTable(person);
                LoadData();
            };
            btnEdit.Click += delegate
            {
                Person person = new Person()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Name = edtName.Text,
                    Department = edtDepart.Text,
                    Email = edtEmail.Text
                };
                db.updateTable(person);
                LoadData();
            };
            btnRemove.Click += delegate
            {
                Person person = new Person()
                {
                    Id = int.Parse(edtName.Tag.ToString()),
                    Name = edtName.Text,
                    Department = edtDepart.Text,
                    Email = edtEmail.Text
                };
                db.removeTable(person);
                LoadData();
            };
            lstViewData.ItemClick += (s, e) =>
            {
                //Set Backround for selected item  
                for (int i = 0; i < lstViewData.Count; i++)
                {
                    if (e.Position == i)
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Black);
                    else
                        lstViewData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
                //Binding Data  
                var txtName = e.View.FindViewById<TextView>(Resource.Id.txtView_Name);
                var txtDepart = e.View.FindViewById<TextView>(Resource.Id.txtView_Depart);
                var txtEmail = e.View.FindViewById<TextView>(Resource.Id.txtView_Email);
                edtEmail.Text = txtName.Text;
                edtName.Tag = e.Id;
                edtDepart.Text = txtDepart.Text;
                edtEmail.Text = txtEmail.Text;
            };
        }
        private void LoadData()
        {
            listSource = db.selectTable();
            var adapter = new ListViewAdapter(this, listSource);
            lstViewData.Adapter = adapter;
        }
    }
}