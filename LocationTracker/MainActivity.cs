using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Android.Locations;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using LocationTracker.Data_classes;
using System.Timers;

namespace LocationTracker
{
    [Activity(Label = "Location tracker")] 
    public class MainActivity : AppCompatActivity, ILocationListener
    {
        static readonly string TAG = "X:" + typeof(MainActivity).Name;
        TextView _addressText;
        Android.Locations.Location _currentLocation;
        LocationManager _locationManager;
        string _locationProvider;
        TextView _locationText;
        TextView _rentText;
        RelativeLayout hide;
        Timer timer;
        public double latitude;
        public double longitude;
        public string locid;
        public long rentid;
        List<Bicycle> bicObj;
        Bicycle bicItem;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);

            _addressText = FindViewById<TextView>(Resource.Id.address_text);
            _locationText = FindViewById<TextView>(Resource.Id.location_text);
            _rentText = FindViewById<TextView>(Resource.Id.rent);
            hide = FindViewById<RelativeLayout>(Resource.Id.loadingPanel);
            hide.Visibility = ViewStates.Visible;
            Toast.MakeText(this, "Please wait while location loading!", ToastLength.Short).Show();

            InitializeLocationManager();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e) 
        {
            RunOnUiThread(() => {
                GetBicByUser();
            });
        }
        public void GetBicByUser()
        {
            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("bicycle", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("userapikey", user[0].ApiKey);
            IRestResponse odgovor = client.Execute(request);
            if ((int)odgovor.StatusCode == 200)
            {
                bicObj = JsonConvert.DeserializeObject<List<Bicycle>>(odgovor.Content);
                foreach (var item in bicObj)
                {
                    bicItem = item;
                    _rentText.Text = "Bicycle ID: " + bicItem.Bicycleid; 
                    if (item.State == 1)
                    {
                        LocationPost();
                    }
                }
            }
        }
        public void LocationPost()
        {
            Data_classes.Location sda = new Data_classes.Location
            {
                Latitude = latitude.ToString(),
                Longitude = longitude.ToString(),
                LocationG = "Current location",
                Bicycle = bicItem
            };

            string text = Intent.GetStringExtra("user") ?? "Data not available";
            var user = JsonConvert.DeserializeObject<List<User>>(text);
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
        }
        void InitializeLocationManager()
        {
            _locationManager = (LocationManager)GetSystemService(LocationService);
            Criteria criteriaForLocationService = new Criteria
            {
                Accuracy = Accuracy.Fine
            };
            IList<string> acceptableLocationProviders = _locationManager.GetProviders(criteriaForLocationService, true);

            if (acceptableLocationProviders.Any())
            {
                _locationProvider = acceptableLocationProviders.First();
            }
            else
            {
                _locationProvider = string.Empty;
            }
        }
        public async Task InitLocationAsync()
        {
            if (_currentLocation == null)
            {
                _addressText.Text = "Can't determine the current address. Try again in a few minutes.";
                return;
            }

            Address address = await ReverseGeocodeCurrentLocation();
            DisplayAddress(address);
        }

        async Task<Address> ReverseGeocodeCurrentLocation()
        {
            Geocoder geocoder = new Geocoder(this);
            IList<Address> addressList =
                await geocoder.GetFromLocationAsync(_currentLocation.Latitude, _currentLocation.Longitude, 10);

            Address address = addressList.FirstOrDefault();
            return address;
        }
        void DisplayAddress(Address address)
        {
            if (address != null)
            {
                StringBuilder deviceAddress = new StringBuilder();
                for (int i = 0; i < address.MaxAddressLineIndex; i++)
                {
                    deviceAddress.AppendLine(address.GetAddressLine(i));
                }
                _addressText.Text = deviceAddress.ToString();
            }
            else
            {
                _addressText.Text = "Unable to determine the address. Try again in a few minutes!";
            }
        }

        public async void OnLocationChanged(Android.Locations.Location location)
        {
            _currentLocation = location;
            if (_currentLocation == null)
            {
                _locationText.Text = "Unable to determine your location. Try again in a short while!";
            }
            else
            {
                hide.Visibility = ViewStates.Invisible;
                latitude = _currentLocation.Latitude;
                longitude = _currentLocation.Longitude;

                GetBicByUser();
                timer = new Timer();
                timer.Interval = 6000;
                timer.Enabled = true;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                _locationText.Text = string.Format("Latitude: {0:f6}, Longitude: {1:f6}", _currentLocation.Latitude, _currentLocation.Longitude);
                Address address = await ReverseGeocodeCurrentLocation();
                DisplayAddress(address);
            }
        }
        protected override void OnResume()
        {
            base.OnResume();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
        }
        protected override void OnPause()
        {
            base.OnPause();
            _locationManager.RequestLocationUpdates(_locationProvider, 0, 0, this);
        }

        public void OnProviderDisabled(string provider) { }

        public void OnProviderEnabled(string provider) { }

        public void OnStatusChanged(string provider, Availability status, Bundle extras) { }
    }
}

