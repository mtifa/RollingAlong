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
using Com.Cepheuen.Elegantnumberbutton.View;

namespace RollingAlongMobile.Offer
{
    [Activity(Label = "Bicycles", Theme = "@style/Theme.MyDesign")]
    public class BicyclesActivity : AppCompatActivity, ElegantNumberButton.IOnValueChangeListener
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;

        public ArrayList arrayList;
        public ArrayAdapter<Category> catAdapter;

        private Spinner sp;
        private ArrayAdapter<string> adapter;
        private SynchronizationContext sc;
        private ListView bicycleList;

        public long catId = 1;
        public long rentId;
        public long bicId;
        public double rentDays;
        Bicycle bicObj;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Bicycles);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerToggle.SyncState();
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            SetupDrawerContent(navigationView);
            navigationView.NavigationItemSelected += HomeNavigationView_NavigationItemSelected;

            sp = FindViewById<Spinner>(Resource.Id.spinner);
            adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleDropDownItem1Line);
            sp.Adapter = adapter;

            sc = SynchronizationContext.Current;

            ChooseCat();
            sp.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(sp_ItemSelected);

            var btnShow = FindViewById<ElegantNumberButton>(Resource.Id.btnNumber);
            btnShow.Click += delegate
            {
                Toast.MakeText(this, "Choose duration of rent in days!", ToastLength.Short).Show();
            };
            btnShow.SetOnValueChangeListener(this);

            ChooseBicPerCat();

            bicycleList.ChoiceMode = Android.Widget.ChoiceMode.Single;
            bicycleList.ItemClick += BicycleList_ItemClick;
            bicycleList.ItemLongClick += BicycleList_ItemLongClick;
        }


        private void sp_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            string toast = string.Format("You choosed the {0} category. Now click on bicycle!", sp.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();

            catId = sp.Adapter.GetItemId(e.Position);
            catId = catId + 1;
            ChooseBicPerCat();
            sc = SynchronizationContext.Current;
        }
        public void ChooseBicPerCat()
        {
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("bicycle/cat{category}", Method.GET);
            request.AddHeader("userapikey", user[0].ApiKey);
            request.AddParameter("category", catId, ParameterType.UrlSegment);
            IRestResponse odgovor = client.Execute(request);
            if ((int)odgovor.StatusCode == 200)
            {
                var bics = JsonConvert.DeserializeObject<List<Bicycle>>(odgovor.Content);
                bicycleList = FindViewById<ListView>(Resource.Id.bicycles11);
                var adapter2 = new BicyclesAdapter(this, bics, text);
                bicycleList.Adapter = adapter2;
            }
        }

        private async void ChooseCat()
        {
            adapter.Clear();

            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("category", Method.GET);
            request.AddHeader("UserApiKey", user[0].ApiKey);
            var odgovor = client.Execute(request);

            try
            {
                await Task.Run(() =>
                {
                    IRestResponse<List<Category>> reponse = client.Execute<List<Category>>(request);
                    foreach (var cat in reponse.Data)
                    {
                        sc.Post(new SendOrPostCallback(o =>
                        {
                            adapter.Add(o as string);
                            adapter.NotifyDataSetChanged();
                            catId = adapter.GetItemId(cat.Categoryid);
                        }), cat.Name);
                    }
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void RentAlert()
        {
            Android.App.AlertDialog.Builder dialog2 = new Android.App.AlertDialog.Builder(this, Android.App.AlertDialog.ThemeHoloLight);
            dialog2.SetTitle("Do you want to rent a bicycle?");
            dialog2.SetMessage("Save a rent.");
            dialog2.SetCancelable(false);
            dialog2.SetPositiveButton("Yes", delegate {
                SaveRent();
                Intent equ = new Intent(this, typeof(EquipmentActivity));
                string text = Intent.GetStringExtra("user") ?? "Data not available";
                equ.PutExtra("catid", (int)catId);
                equ.PutExtra("rentid", (int)rentId);
                equ.PutExtra("user", text);
                StartActivity(equ);

            });
            dialog2.SetNegativeButton("Cancel", delegate { return; });
            dialog2.Show();
        }
        private void BicycleList_ItemLongClick(object sender, AdapterView.ItemLongClickEventArgs e)
        {
            bicycleList.SetBackgroundColor(Color.WhiteSmoke);

            bicId = bicycleList.Adapter.GetItemId(e.Position);
            bicId.ToString();

            BicycleObject();

            if (bicObj.State == 1)
            {
                Toast.MakeText(this, "You can't rent this bicycle, because it's already rented! Please check another!", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Successfully checked bicycle: " + bicId, ToastLength.Short).Show();
                RentAlert();
            }
        }

        private void BicycleList_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            bicycleList.SetBackgroundColor(Color.WhiteSmoke);

            bicId = bicycleList.Adapter.GetItemId(e.Position);
            bicId.ToString();

            BicycleObject();

            if (bicObj.State == 1)
            {
                Toast.MakeText(this, "You can't rent this bicycle, because it's already rented! Please check another!", ToastLength.Short).Show();
            }
            else
            {
                Toast.MakeText(this, "Successfully checked bicycle: " + bicId, ToastLength.Short).Show();
                RentAlert();
            }
        }

        public void BicycleObject()
        {
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("bicycle/{id}", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("userapikey", user[0].ApiKey);
            request.AddParameter("id", bicId, ParameterType.UrlSegment);
            IRestResponse odgovor = client.Execute(request);
            if ((int)odgovor.StatusCode == 200)
            {
                bicObj = JsonConvert.DeserializeObject<Bicycle>(odgovor.Content);
            }
        }
        public void SaveRent()
        {

            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);

            var latitudes = Intent.GetStringExtra("latitude") ?? "Data not available";
            var longers = Intent.GetStringExtra("longitude") ?? "Data not available";

            Data_classes.Location sda = new Data_classes.Location
            {
                Latitude = latitudes,
                Longitude = longers,
                LocationG = "Current location",
                Bicycle = bicObj
            };

            RestClient client3 = new RestClient("http://marichely.me:8099/");
            RestRequest request3 = new RestRequest("bicycle/location", Method.POST);
            request3.RequestFormat = DataFormat.Json;
            request3.AddHeader("userapikey", user[0].ApiKey);
            string test1 = JsonConvert.SerializeObject(sda);
            request3.AddParameter("application/json", test1, ParameterType.RequestBody);
            IRestResponse odgovor3 = client3.Execute(request3);
            if ((int)odgovor3.StatusCode == 200)
            {
                var locate = JsonConvert.DeserializeObject<Data_classes.Location>(odgovor3.Content);
            }

            Data_classes.Rent ds = new Data_classes.Rent();
            ds.Bicycle = bicObj;
            var bicIdstat = ds.Bicycle.Bicycleid;

            DateTime now = DateTime.UtcNow;
            ds.Date_from = now.ToString("yyyy-MM-ddTHH\\:mm\\:ssZ");
            ds.Date_to = now.AddDays(rentDays).ToString("yyyy-MM-ddTHH\\:mm\\:ssZ");

            ds.Status = 1;
            ds.User = user[0];
            ds.Location = sda;


            RestClient client4 = new RestClient("http://marichely.me:8099/");
            RestRequest request4 = new RestRequest("bicycle/update", Method.POST);
            request4.RequestFormat = DataFormat.Json;
            request4.AddHeader("userapikey", user[0].ApiKey);
            request4.AddQueryParameter("bicycleid", bicId.ToString());
            request4.AddQueryParameter("status", "1");
            IRestResponse odgovor4 = client4.Execute(request4);
            if ((int)odgovor4.StatusCode == 200)
            {
                var bicstat = JsonConvert.DeserializeObject<Data_classes.Bicycle>(odgovor4.Content);
                Toast.MakeText(this, ("Successfully changed status of bicycle!" + ds.Bicycle.Name), ToastLength.Short).Show();
            }

            RestClient client2 = new RestClient("http://marichely.me:8099/");
            RestRequest request2 = new RestRequest("rent", Method.POST);
            request2.RequestFormat = DataFormat.Json;
            request2.AddHeader("userapikey", user[0].ApiKey);
            string test3 = JsonConvert.SerializeObject(ds);
            request2.AddParameter("application/json", test3, ParameterType.RequestBody);
            IRestResponse odgovor2 = client2.Execute(request2);
            if ((int)odgovor2.StatusCode == 200)
            {
                var rentObj2 = JsonConvert.DeserializeObject<Data_classes.Rent>(odgovor2.Content);
                Toast.MakeText(this, ("Successfully rented a bicycle: " + ds.Bicycle.Name), ToastLength.Short).Show();
            }
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

        void SetupDrawerContent(NavigationView navigationView)
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

        public void OnValueChange(ElegantNumberButton view, int oldValue, int newValue)
        {
            rentDays = newValue;
        }
    }
}