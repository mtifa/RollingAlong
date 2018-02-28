using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RestSharp;
using RollingAlongMobile.Data_classes;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using RollingAlongMobile.Rent;
using RollingAlongMobile.Offer;
using RollingAlongMobile.Location;
using RollingAlongMobile.Login_and_Registration;

namespace RollingAlongMobile.Profile
{
    [Activity(Label = "My profile", Theme = "@style/Theme.MyDesign")]
    public class ProfileActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        Button izmjeniProfil;
        EditText ime, prezime, email;
        List<User> user;

        protected override void OnCreate(Android.OS.Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView);
            navigationView.NavigationItemSelected += HomeNavigationView_NavigationItemSelected;


            izmjeniProfil = FindViewById<Button>(Resource.Id.IzmjeniProfil);
            ime = FindViewById<EditText>(Resource.Id.ImeText);
            prezime = FindViewById<EditText>(Resource.Id.PrezimeText);
            email = FindViewById<EditText>(Resource.Id.EmailText);
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            user = JsonConvert.DeserializeObject<List<User>>(text);
            ime.Text = user[0].Name;
            prezime.Text = user[0].Surname;
            email.Text = user[0].Email;

            izmjeniProfil.Click += (b, e) => {
                User changedProfile = user[0];
                changedProfile.Name = ime.Text;
                changedProfile.Surname = prezime.Text;
                changedProfile.Email = email.Text;
                var klijent = new RestClient("http://marichely.me");
                var zahtjev = new RestRequest("rolling/users/updates", Method.POST);
                zahtjev.RequestFormat = DataFormat.Json;
                zahtjev.AddParameter("text/json", JsonConvert.SerializeObject(changedProfile), ParameterType.RequestBody);
                zahtjev.AddHeader("userapikey", user[0].ApiKey);
                IRestResponse odgovor = klijent.Execute(zahtjev);
                if ((int)odgovor.StatusCode == 200)
                {
                    Toast.MakeText(this, "Successfully updated your profile", ToastLength.Short).Show();
                }
            };

        }
        private void HomeNavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
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
