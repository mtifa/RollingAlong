using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using Android.Support.V7.App;
using Android.Content.Res;
using Android.Support.V7.Widget;
using System.Drawing;
using Android.Graphics;
using RestSharp;
using LocationTracker.Data_classes;

namespace LocationTracker
{
    [Activity(Label = "RA Location Tracker", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        RelativeLayout hide;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            Window.DecorView.SetBackgroundColor(Android.Graphics.Color.Rgb(117, 117, 117));

            SetContentView(Resource.Layout.Login);

            hide = FindViewById<RelativeLayout>(Resource.Id.loadingPanel);
            hide.Visibility = ViewStates.Invisible;

            ImageView slika = FindViewById<ImageView>(Resource.Id.slikapozadine1);
            Button prijava = FindViewById<Button>(Resource.Id.prijavaGumb1);
            EditText lozinka = FindViewById<EditText>(Resource.Id.passwordprijava);
            EditText korisnickoIme = FindViewById<EditText>(Resource.Id.usernameprijava);
            slika.SetImageResource(Resource.Drawable.logof);

            prijava.Click += (b, e) => {
                hide.Visibility = ViewStates.Visible;
                var klijent = new RestClient("http://marichely.me");
                var zahtjev = new RestRequest("rolling/user/login", Method.POST)
                {
                    RequestFormat = DataFormat.Json
                };
                Login a = new Login();
                a.Username = korisnickoIme.Text;
                a.Password = lozinka.Text;
                string test = JsonConvert.SerializeObject(a);
                zahtjev.AddParameter("text/json", test, ParameterType.RequestBody);

                IRestResponse odgovor = klijent.Execute(zahtjev);

                if ((int)odgovor.StatusCode == 200)
                {
                    var locationActivity = new Intent(this, typeof(MainActivity));
                    locationActivity.PutExtra("user", odgovor.Content);
                    StartActivity(locationActivity);
                }
                else
                {
                    Toast.MakeText(this, "Krivo korisnicko ime ili lozinka", ToastLength.Short).Show();
                }
            };
        }
    }
}