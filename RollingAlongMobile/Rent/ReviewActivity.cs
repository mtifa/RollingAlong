using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using RollingAlongMobile.Data_classes;
using Newtonsoft.Json;
using RestSharp;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using RollingAlongMobile.Profile;
using RollingAlongMobile.Offer;
using RollingAlongMobile.Login_and_Registration;
using RollingAlongMobile.Location;

namespace RollingAlongMobile.Rent
{
    [Activity(Label = "Review", Theme = "@style/Theme.MyDesign")]
    public class ReviewActivity : AppCompatActivity
    {
        Data_classes.Rent najam;
        List<User> korisnik;
        RatingBar zvijezdice;
        Button posaljiReviewButton;
        EditText recenzijaText;

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Review);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            // Create ActionBarDrawerToggle button and add it to the toolbar
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);


            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            setupDrawerContent(navigationView);

            navigationView.NavigationItemSelected += HomeNavigationView_NavigationItemSelected;

            zvijezdice = FindViewById<RatingBar>(Resource.Id.ratingBar1);
            posaljiReviewButton = FindViewById<Button>(Resource.Id.button2);
            recenzijaText = FindViewById<EditText>(Resource.Id.OpisRezenzije1);
            string input = Intent.GetStringExtra("rent");
            string userinput = Intent.GetStringExtra("user");
            najam = JsonConvert.DeserializeObject<Data_classes.Rent>(input);
            korisnik = JsonConvert.DeserializeObject<List<User>>(userinput);



            posaljiReviewButton.Click += (b, e) =>
            {
                if (recenzijaText.Text != null)
                {
                    korisnik = JsonConvert.DeserializeObject<List<User>>(userinput);
                    var klijent = new RestClient("http://marichely.m/");
                    var zahtjev = new RestRequest("reviews", Method.POST);
                    zahtjev.RequestFormat = DataFormat.Json;
                    zahtjev.AddHeader("rentid", najam.Rentid.ToString());
                    zahtjev.AddHeader("userapikey", korisnik[0].ApiKey);
                    CreateReview posalji = new CreateReview();
                    posalji.Description = recenzijaText.Text;
                    posalji.Stars = zvijezdice.NumStars;
                    string test = JsonConvert.SerializeObject(posalji);
                    zahtjev.AddParameter("text/json", test, ParameterType.RequestBody); //text/json
                    IRestResponse odgovor = klijent.Execute(zahtjev);
                    if ((int)odgovor.StatusCode == 200)
                    {
                        Toast.MakeText(this, "Review Sent", ToastLength.Short).Show();
                    }
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