using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;
using RollingAlongMobile.Data_classes;
using Android.Support.Design.Widget;
using RollingAlongMobile.Profile;
using Android.Support.V7.App;
using RollingAlongMobile.Offer;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using RollingAlongMobile.Login_and_Registration;
using RollingAlongMobile.Location;
using Android.Graphics;
using System.Timers;

namespace RollingAlongMobile.Rent
{
    [Activity(Label = "Active rents", Theme = "@style/Theme.MyDesign")]
    public class ActiveRentsActivity : AppCompatActivity
    {
        public ListView rentList;

        DrawerLayout drawerLayout;
        NavigationView navigationView;
        public long rentId;
        public int catId;

        Timer timer;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ActiveRents);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView);
            navigationView.NavigationItemSelected += HomeNavigationView_NavigationItemSelected;

            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("rent/user", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("UserApiKey", user[0].ApiKey);
            IRestResponse odgovor3 = client.Execute(request);
            if ((int)odgovor3.StatusCode == 200)
            {
                var rentList = JsonConvert.DeserializeObject<List<Data_classes.Rent>>(odgovor3.Content);
                this.rentList = FindViewById<ListView>(Resource.Id.najmovi11);
                var adapter = new RentAdapter(this, rentList, text);
                this.rentList.Adapter = adapter;
            }


        }

        private void HomeNavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var menuItem = e.MenuItem;
            menuItem.SetChecked(!menuItem.IsChecked);
            Intent profil, bicycles, active, logout;

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
