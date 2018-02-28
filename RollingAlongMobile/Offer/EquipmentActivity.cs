using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RollingAlongMobile.Data_classes;
using RestSharp;
using RollingAlongMobile.Rent;
using RollingAlongMobile.Profile;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using RollingAlongMobile.Adapters;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using Android.Graphics;
using RollingAlongMobile.Login_and_Registration;
using RollingAlongMobile.Location;


namespace RollingAlongMobile.Offer
{
    [Activity(Label = "Equipment", Theme = "@style/Theme.MyDesign")]
    public class EquipmentActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        public ArrayList arrayList;

        private ArrayAdapter<string> adapter;
        private SynchronizationContext sc;

        private ListView equipmentList;

        public string CatName;
        public long catId = 1;
        public long rentId;
        public long equId;
        Equipment equObj;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Equipment);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            RentByUser();
            ChooseEquipmentPerCategory();

            equipmentList.ChoiceMode = Android.Widget.ChoiceMode.Multiple; //SINGLE
            equipmentList.ItemClick += EquipmentList_ItemClick;
            equipmentList.ItemLongClick += EquipmentList_ItemLongClick;
        }
        public void ChooseEquipmentPerCategory()
        {
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            catId = Intent.GetIntExtra("catid", 0);
            var user = JsonConvert.DeserializeObject<List<User>>(text);

            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("equipment/{categoryId}", Method.GET);
            request.AddHeader("userapikey", user[0].ApiKey);
            request.AddParameter("categoryId", catId, ParameterType.UrlSegment);
            IRestResponse odgovor = client.Execute(request);
            if ((int)odgovor.StatusCode == 200)
            {
                var equipments = JsonConvert.DeserializeObject<List<Equipment>>(odgovor.Content);
                equipmentList = FindViewById<ListView>(Resource.Id.equipments11);
                var adapter2 = new EquipmentAdapter(this, equipments, text);
                equipmentList.Adapter = adapter2;
            }
        }
        private void EquipmentList_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            equipmentList.SetBackgroundColor(Color.WhiteSmoke);

            equId = equipmentList.Adapter.GetItemId(e.Position);
            equId.ToString();

            Toast.MakeText(this, "Successfully checked equipment for rent: " + equId, ToastLength.Short).Show();
            RentEquipmentAlert();
        }

        private void EquipmentList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            equipmentList.SetBackgroundColor(Color.WhiteSmoke);

            equId = equipmentList.Adapter.GetItemId(e.Position);
            equId.ToString();

            Toast.MakeText(this, "Successfully checked equipment for rent: " + equId, ToastLength.Short).Show();
            RentEquipmentAlert();
        }
        public void RentEquipmentAlert()
        {
            Android.App.AlertDialog.Builder dialog2 = new Android.App.AlertDialog.Builder(this, Android.App.AlertDialog.ThemeHoloLight);
            dialog2.SetTitle("Do you want to save a equipment?");
            dialog2.SetMessage("Save a equipment.");
            dialog2.SetCancelable(false);
            dialog2.SetPositiveButton("Yes", delegate {
                string text = Intent.GetStringExtra("user") ?? "Data not available";
                SaveEquipment();
                Intent active = new Intent(this, typeof(ActiveRentsActivity));
                active.PutExtra("user", text);
                active.PutExtra("rentid", (int)rentId);
                StartActivity(active);
            });
            dialog2.SetNegativeButton("Cancel", delegate { return; });
            dialog2.Show();
        }
        public void EquipmentObject()
        {
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("equipment", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("userapikey", user[0].ApiKey);
            IRestResponse odgovor = client.Execute(request);
            if ((int)odgovor.StatusCode == 200)
            {
                equObj = JsonConvert.DeserializeObject<Equipment>(odgovor.Content);
            }
        }
        public void RentByUser()
        {
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client2 = new RestClient("http://marichely.me:8099/");
            RestRequest request2 = new RestRequest("rent/user", Method.GET);
            request2.RequestFormat = DataFormat.Json;
            request2.AddHeader("userapikey", user[0].ApiKey);
            IRestResponse odgovor2 = client2.Execute(request2);
            if ((int)odgovor2.StatusCode == 200)
            {
                var rentuser = JsonConvert.DeserializeObject<List<Data_classes.Rent>>(odgovor2.Content);
                foreach (var item in rentuser)
                {
                    rentId = item.Rentid;
                }
            }
        }
        public void SaveEquipment()
        {
            catId = Intent.GetIntExtra("catid", 1);
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("rent/equipment", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("UserApiKey", user[0].ApiKey);
            request.AddHeader("rentid", rentId.ToString());
            request.AddHeader("equipmentid", equId.ToString());
            IRestResponse odgovor = client.Execute(request);
            if ((int)odgovor.StatusCode == 200)
            {
                Toast.MakeText(this, "Successfully rented equipment!", ToastLength.Short).Show();
            }
        }
        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var menuItem = e.MenuItem;
            menuItem.SetChecked(!menuItem.IsChecked);
            Intent profil, bicycles, active, logout, location;

            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);

            switch (menuItem.ItemId)
            {
                case Resource.Id.nav_bicycles:
                    bicycles = new Intent(this, typeof(BicyclesActivity));
                    bicycles.PutExtra("user", text);
                    StartActivity(bicycles); break;
                case Resource.Id.nav_active:
                    active = new Intent(this, typeof(ActiveRentsActivity));
                    active.PutExtra("user", text);
                    active.PutExtra("rentid", (int)rentId);
                    StartActivity(active); break;
                case Resource.Id.nav_profile:
                    profil = new Intent(this, typeof(ProfileActivity));
                    profil.PutExtra("user", text);
                    StartActivity(profil); break;
                case Resource.Id.nav_logout:
                    logout = new Intent(this, typeof(LoginActivity));
                    StartActivity(logout); break;
            }
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.refresh:
                    this.Recreate();
                    return true;
                case Resource.Id.action_help:
                    var uri = Android.Net.Uri.Parse("https://github.com/foivz/r17036/wiki/3.-Korisni%C4%8Dka-dokumentacija");
                    var intent = new Intent(Intent.ActionView, uri);
                    StartActivity(intent);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }
        void setupDrawerContent(NavigationView navigationView)
        {
            navigationView.NavigationItemSelected += (sender, e) => {
                e.MenuItem.SetChecked(true);
                drawerLayout.CloseDrawers();
            };
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            navigationView.InflateMenu(Resource.Menu.nav_menu);
            MenuInflater.Inflate(Resource.Menu.refresh, menu);

            TextView username = FindViewById<TextView>(Resource.Id.navheader_username);
            TextView email = FindViewById<TextView>(Resource.Id.email);
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            username.Text = user[0].Name + " " + user[0].Surname;
            email.Text = user[0].Email;

            return true;
        }
    }
}