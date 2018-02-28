using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V7.App;
using Android.Support.V4.Widget;
using RollingAlongMobile.Profile;
using Android.Locations;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using RollingAlongMobile.Offer;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Newtonsoft.Json;
using RollingAlongMobile.Data_classes;
using Android.Gms.Common;
using Android.Support.V4.Content;
using System.ComponentModel;
using RollingAlongMobile.Rent;
using RollingAlongMobile.Login_and_Registration;
using RestSharp;
using Android.Graphics;
using System.Collections;
using System.Timers;

namespace RollingAlongMobile.Location
{
    [Activity(Label = "Location tracking", Theme = "@style/Theme.MyDesign")]
    public class LocationActivity : AppCompatActivity, IOnMapReadyCallback, Android.Gms.Maps.GoogleMap.IInfoWindowAdapter
    {
        public static readonly int InstallGooglePlayServicesId = 1000;
        private bool _isGooglePlayServicesInstalled;
        private MapFragment _mapFragment;

        public GoogleMap map { get; private set; }
        public double Lat { get; set; }
        public double Lon { get; set; }

        public double later, longers;
        public ArrayList arrayList;
        public ArrayList arrayList2;
        public ArrayAdapter<Data_classes.Location> locAdapter;

        DrawerLayout drawerLayout;
        NavigationView navigationView;
        List<Data_classes.Location> locObj;
        LatLng latLng2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LocationTrack);

            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var toolbar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.drawer_open, Resource.String.drawer_close);
            drawerToggle.SyncState();

            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            SetupDrawerContent(navigationView);

            navigationView.NavigationItemSelected += HomeNavigationView_NavigationItemSelected;


            if (IsGPSEnabled())
            {
                _isGooglePlayServicesInstalled = TestIfGooglePlayServicesIsInstalled();

                if (_isGooglePlayServicesInstalled)
                {
                    InitMapFragment();
                }
                else
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this, Android.App.AlertDialog.ThemeHoloLight);
                    dialog.SetTitle("map Error");
                    dialog.SetMessage("Map error message");
                    dialog.SetCancelable(false);
                    dialog.SetPositiveButton("ok", delegate {
                        return;
                    });
                    dialog.SetNegativeButton("cancel", delegate {
                        return;
                    });
                    dialog.Show();
                }
            }
        }

        public bool IsGPSEnabled()
        {
            LocationManager LocMgr = Android.App.Application.Context.GetSystemService(Context.LocationService) as LocationManager;
            bool enabled = LocMgr.IsProviderEnabled(LocationManager.GpsProvider);

            if (!enabled)
            {
                Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this, Android.App.AlertDialog.ThemeHoloLight);
                dialog.SetTitle("GPS Alert");
                dialog.SetMessage("Your GPS is off!");
                dialog.SetCancelable(false);
                dialog.SetPositiveButton("Go to GPS setttings", delegate {
                    Intent intent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                    StartActivity(intent);
                });
                dialog.SetNegativeButton("Cancel", delegate { return; });
                dialog.Show();
            }

            return enabled;
        }

        private bool TestIfGooglePlayServicesIsInstalled()
        {
            try
            {
                int queryResult = GoogleApiAvailability.Instance.IsGooglePlayServicesAvailable(this);
                if (queryResult == ConnectionResult.Success)
                {
                    Console.WriteLine("Google Play Services is installed on this device.");
                    return true;
                }

                if (GoogleApiAvailability.Instance.IsUserResolvableError(queryResult))
                {
                    string errorString = GoogleApiAvailability.Instance.GetErrorString(queryResult);
                    Console.WriteLine("There is a problem with Google Play Services on this device: {0} - {1}", queryResult, errorString);
                    Dialog errorDialog = GoogleApiAvailability.Instance.GetErrorDialog(this, queryResult, InstallGooglePlayServicesId);
                    errorDialog.Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Test for google play services {0}", ex.ToString());
            }
            return false;
        }

        private void InitMapFragment()
        {
            _mapFragment = FragmentManager.FindFragmentByTag("map") as MapFragment;

            if (_mapFragment == null)
            {
                GoogleMapOptions mapOptions = new GoogleMapOptions()
                    .InvokeMapType(GoogleMap.MapTypeTerrain)
                    .InvokeZoomControlsEnabled(true)
                    .InvokeCompassEnabled(true)
                    .InvokeAmbientEnabled(true)
                    .InvokeRotateGesturesEnabled(true)
                    .InvokeMapToolbarEnabled(true);

                FragmentTransaction fragTx = FragmentManager.BeginTransaction();
                _mapFragment = MapFragment.NewInstance(mapOptions);
                fragTx.Add(Resource.Id.map, _mapFragment, "map");
                fragTx.Commit();
            }

            _mapFragment.GetMapAsync(this);
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;

            if (ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessFineLocation) ==
        Android.Content.PM.Permission.Granted &&
        ContextCompat.CheckSelfPermission(this, Android.Manifest.Permission.AccessCoarseLocation) ==
        Android.Content.PM.Permission.Granted)
            {
                map.MyLocationEnabled = true;
                map.UiSettings.MyLocationButtonEnabled = true;
                map.UiSettings.ZoomControlsEnabled = true;
                map.UiSettings.ZoomGesturesEnabled = true;
                map.UiSettings.CompassEnabled = true;

            }
            else
            {

                this.RequestPermissions(new String[] {
                    Android.Manifest.Permission.AccessCoarseLocation,
                    Android.Manifest.Permission.AccessFineLocation },
                    0);
                this.Recreate();
            }

            map.MyLocationChange += Map_MyLocationChange;
        }

        void Map_MyLocationChange(object sender, GoogleMap.MyLocationChangeEventArgs e)
        {
            map.MyLocationChange -= Map_MyLocationChange;

            LatLng latLong = new LatLng(e.Location.Latitude, e.Location.Longitude);

            Lat = e.Location.Latitude;
            Lon = e.Location.Longitude;

            Toast.MakeText(this, "Current location is red point! Coordinates: " + Lat + " " + Lon, ToastLength.Long).Show();

            PolylineOptions polylineOptions = new PolylineOptions();

            string text = Intent.GetStringExtra("user") ?? "Data not available";
            int bicId = Intent.GetIntExtra("bicycleid", 1);
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("bicycle/location", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("userapikey", user[0].ApiKey);
            request.AddParameter("bicycleid", bicId, ParameterType.QueryString);
            IRestResponse odgovor = client.Execute(request);

            if ((int)odgovor.StatusCode == 200)
            {
                locObj = JsonConvert.DeserializeObject<List<Data_classes.Location>>(odgovor.Content);
            }
            foreach (Data_classes.Location item in locObj)
            {
                var lsa = double.TryParse(item.Latitude, out later);
                var lar = double.TryParse(item.Longitude, out longers);

                if (lsa == true && lar == true)
                {
                    polylineOptions.Add(new LatLng(later, longers));
                    latLng2 = new LatLng(later, longers);
                    GetRequestUrl(latLong, latLng2);
                }

            }

            polylineOptions.Add(latLong);
            polylineOptions.InvokeColor(Color.Blue);
            map.AddPolyline(polylineOptions);

            CameraPosition.Builder builder = CameraPosition.InvokeBuilder();

            builder.Target(latLong);
            builder.Zoom(16);
            builder.Tilt(65);
            CameraPosition cameraPosition = builder.Build();
            MarkerOptions markerOpt = new MarkerOptions();
            markerOpt.SetPosition(latLong);


            foreach (var item in polylineOptions.Points)
            {
                MarkerOptions markerOptions2 = new MarkerOptions();
                markerOptions2.SetPosition(item);
                BitmapDescriptor bitmapDescriptor = BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueAzure);
                markerOptions2.SetIcon(bitmapDescriptor);
                map.AddMarker(markerOptions2);
            }

            map.AddMarker(markerOpt);
            map.SetInfoWindowAdapter(this);
            map.MyLocationEnabled = true;
            map.UiSettings.MapToolbarEnabled = true;
            map.UiSettings.MyLocationButtonEnabled = true;
            map.UiSettings.ZoomControlsEnabled = true;
            map.UiSettings.ZoomGesturesEnabled = true;

            map.AnimateCamera(CameraUpdateFactory.NewCameraPosition(cameraPosition));

            map.TrafficEnabled = true;
        }
        private String GetRequestUrl(LatLng origin, LatLng dest)
        {
            String str_org = "origin=" + origin.Latitude + "," + origin.Longitude;
            String str_dest = "destination=" + dest.Latitude + "," + dest.Longitude;
            String sensor = "sensor=false";
            String mode = "mode=driving"; //Driving, two-wheeler, motorcycle
            String param = str_org + "&" + str_dest + "&" + sensor + "&" + mode;
            String output = "json";
            String url = "https://maps.googleapis.com/maps/api/directions/" + output + "?" + param;
            return url;
        }

        public View GetInfoContents(Marker marker)
        {
            var inflater = Application.Context.GetSystemService(Context.LayoutInflaterService) as LayoutInflater;

            View v = inflater.Inflate(Resource.Layout.InfoLocation, null);

            Android.Locations.Location locationB = new Android.Locations.Location("point B");
            locationB.Latitude = marker.Position.Latitude;
            locationB.Longitude = marker.Position.Longitude;

            TextView title = (TextView)v.FindViewById(Resource.Id.txtName);
            title.Text = "lat:" + marker.Position.Latitude + " long:" + marker.Position.Longitude;
            TextView description = (TextView)v.FindViewById(Resource.Id.txtAddress);

            return v;
        }

        public View GetInfoWindow(Marker marker)
        {
            return null;
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
                    bicycles.PutExtra("latitude", Lat.ToString());
                    bicycles.PutExtra("longitude", Lon.ToString());
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

            return true;
        }
    }
}