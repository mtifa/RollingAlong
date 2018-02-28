using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using RollingAlongMobile.Data_classes;
using RestSharp;
using Android.Graphics;
using Android.Provider;
using System.IO;
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
    [Activity(Label = "Incident report", Theme = "@style/Theme.MyDesign")]
    public class IncidentReportActivity : AppCompatActivity
    {
        Button posaljiIncident;
        ImageButton odaberiSliku;
        Android.Net.Uri podaci;
        Bitmap slika;
        Data_classes.Rent najam;
        List<User> user;
        string path;
        Java.IO.File file;

        DrawerLayout drawerLayout;
        NavigationView navigationView;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.IncidentReport);

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

            string input = Intent.GetStringExtra("rent");
            string userinput = Intent.GetStringExtra("user");
            najam = JsonConvert.DeserializeObject<Data_classes.Rent>(input);
            user = JsonConvert.DeserializeObject<List<User>>(userinput);
            //RequestWindowFeature(WindowFeatures.NoTitle);
            //SetContentView(Resource.Layout.PrijavaIncidenta);
            Button prijaviinc = FindViewById<Button>(Resource.Id.posaljiIncident);
            odaberiSliku = FindViewById<ImageButton>(Resource.Id.odaberiSliku);
            EditText opis = FindViewById<EditText>(Resource.Id.Incidenttekst);

            prijaviinc.Click += (e, s) =>
            {
                RemoveRent slanje = new RemoveRent();
                slanje.IssueDesc = opis.Text;
                slanje.RentID = najam.Rentid;
                var klijent = new RestClient("http://marichely.me/");
                var zahtjev = new RestRequest("rolling/issues", Method.POST);
                zahtjev.RequestFormat = DataFormat.Json;
                zahtjev.AddParameter("text/json", JsonConvert.SerializeObject(slanje), ParameterType.RequestBody);
                zahtjev.AddHeader("userapikey", user[0].ApiKey);
                IRestResponse odgovor = klijent.Execute(zahtjev);
                zahtjev = new RestRequest("issues/pictures", Method.POST);
                if ((int)odgovor.StatusCode == 200)
                {
                    Toast.MakeText(this, "Successfully created the incident", ToastLength.Short).Show();
                    string issueid = odgovor.Content;

                    if (path != null)
                    {
                        zahtjev = new RestRequest("issues/pictures", Method.POST);
                        zahtjev.RequestFormat = DataFormat.Json;
                        zahtjev.AddHeader("userapikey", user[0].ApiKey);
                        zahtjev.AddHeader("incident", issueid);
                        zahtjev.AddFile("picture", path);
                        IRestResponse odgovor2 = klijent.Execute(zahtjev);
                        if ((int)odgovor2.StatusCode == 200)
                        {
                            Toast.MakeText(this, "Successfully created the incident", ToastLength.Short).Show();
                        }
                    }
                }
            };
            odaberiSliku.Click += (s, e) =>
            {
                var imageIntent = new Intent();
                imageIntent.SetType("image/*");
                imageIntent.SetAction(Intent.ActionGetContent);
                StartActivityForResult(
                Intent.CreateChooser(imageIntent, "Select photo"), 0);
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
        string ExportBitmapAsPNG(Bitmap bitmap)
        {
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            var filePath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData), "slika.png");
            var stream = new FileStream(filePath, FileMode.Create);
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Close();
            return filePath;
        }
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Ok)
            {
                var imageView =
                    FindViewById<ImageView>(Resource.Id.slikainc);
                imageView.SetImageURI(data.Data);
                podaci = data.Data;
                slika = MediaStore.Images.Media.GetBitmap(this.ContentResolver, podaci);
                path = ExportBitmapAsPNG(slika);

            }
        }
    }
}