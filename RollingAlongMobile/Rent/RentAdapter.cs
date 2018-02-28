using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using RollingAlongMobile.Data_classes;
using Android.Graphics;
using Android.Content.Res;
using Com.Nostra13.Universalimageloader.Core;
using Newtonsoft.Json;
using RestSharp;
using RollingAlongMobile.Location;
using RollingAlongMobile.Adapters;
using System.Net;
using Android.Support.V4.Util;
using Android.Runtime;
using System.IO;

namespace RollingAlongMobile.Rent
{
    class RentAdapter : BaseAdapter<Data_classes.Rent>
    {
        string userdata;
        public List<Data_classes.Rent> Najmovi;
        private Activity activity;
        public AssetManager Assets { get; private set; }
        public Context MojKontekst { get; private set; }
        public List<Data_classes.EquipmentWithRent> equWithRentObject;
        public EquipmentWithRent equipmentWithRent;
        public string PicturePostResponse { get; set; }
        public string PictureId { get; set; }
        public Bicycle_pictures imageObj { get; set; }

        public RentAdapter(Activity activity, List<Data_classes.Rent> najmovi, string data)
        {
            this.activity = activity;
            this.Najmovi = najmovi;
            MojKontekst = activity;
            userdata = data;

            int DEFAULT_CACHE_SIZE_PROPORTION = 8;
            ActivityManager manager = (ActivityManager)MojKontekst.GetSystemService(Context.ActivityService);
            int memoryClass = manager.MemoryClass;
            int memoryClassInKilobytes = memoryClass * 1024;
            int cacheSize = memoryClassInKilobytes / DEFAULT_CACHE_SIZE_PROPORTION;
        }

        public override int Count
        {
            get
            {
                return Najmovi.Count;
            }
        }

        public override Data_classes.Rent this[int position] => throw new NotImplementedException();

        public override long GetItemId(int position)
        {
            return Najmovi[position].Rentid;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Typeface fontNormal;
            Assets = MojKontekst.Assets;
            fontNormal = Typeface.CreateFromAsset(Assets, "robotol.ttf");
            Typeface fontBold;
            fontBold = Typeface.CreateFromAsset(Assets, "roboto.ttf");

            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.RentRow, parent, false);
            var naslov = view.FindViewById<TextView>(Resource.Id.Naslov);
            var datum = view.FindViewById<TextView>(Resource.Id.Datum);
            var bicikl = view.FindViewById<TextView>(Resource.Id.Bicikl);
            var equipmentText = view.FindViewById<TextView>(Resource.Id.EquipmentText);
            var slika = view.FindViewById<ImageView>(Resource.Id.Slika);
            var cancelGumb = view.FindViewById<Button>(Resource.Id.cancel);
            var locationGumb = view.FindViewById<Button>(Resource.Id.location);
            var prijaviincidentgumb = view.FindViewById<Button>(Resource.Id.Incident);
            var ostaviRecenzijuGumb = view.FindViewById<Button>(Resource.Id.feedback);

            var glavni = view.FindViewById<RelativeLayout>(Resource.Id.glavni);


            naslov.Typeface = fontBold;
            datum.Typeface = fontNormal; bicikl.Typeface = fontNormal;

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(Najmovi[position].Date_from));
            DateTimeOffset dateTimeOffset2 = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(Najmovi[position].Date_to));

            DateTime now = DateTime.UtcNow;
            if (dateTimeOffset2 < now)
            {
                Najmovi[position].Status = 3;
            }

            string status = "not set";

            switch (Najmovi[position].Status)
            {
                case 1: status = "Reserved"; break;
                case 2: status = "Active"; break;
                case 3: status = "Expired"; break;
            }
            if (Najmovi[position].Status == 1)
            {
                locationGumb.Visibility = ViewStates.Visible;
                prijaviincidentgumb.Visibility = ViewStates.Visible;
                ostaviRecenzijuGumb.Visibility = ViewStates.Gone;
                cancelGumb.Visibility = ViewStates.Visible;
                var param1 = (RelativeLayout.LayoutParams)cancelGumb.LayoutParameters;
                param1.AddRule(LayoutRules.RightOf, Resource.Id.Incident);
            }
            if (Najmovi[position].Status == 2)
            {
                cancelGumb.Visibility = ViewStates.Gone;
                ostaviRecenzijuGumb.Visibility = ViewStates.Gone;
                locationGumb.Visibility = ViewStates.Visible;
                prijaviincidentgumb.Visibility = ViewStates.Visible;
                var param1 = (RelativeLayout.LayoutParams)locationGumb.LayoutParameters;
                param1.AddRule(LayoutRules.RightOf, Resource.Id.Incident);
            }
            if (Najmovi[position].Status == 3)
            {
                ostaviRecenzijuGumb.Visibility = ViewStates.Visible;
                cancelGumb.Visibility = ViewStates.Gone;
                locationGumb.Visibility = ViewStates.Gone;
                prijaviincidentgumb.Visibility = ViewStates.Gone;
            }

            var user = JsonConvert.DeserializeObject<List<User>>(userdata);
            var restClient = new RestClient("http://marichely.me:8099/");
            var restRequest = new RestRequest("bicycle/picture/id/all", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("UserApiKey", user[0].ApiKey);
            restRequest.AddHeader("bicycleid", Najmovi[position].Bicycle.Bicycleid.ToString());
            IRestResponse restResponse = restClient.Execute(restRequest);
            if ((int)restResponse.StatusCode == 200)
            {
                imageObj = JsonConvert.DeserializeObject<Bicycle_pictures>(restResponse.Content);
            }

            if (equWithRentObject != null)
            {
                EquipmentWithRentView();

                foreach (var item in equWithRentObject)
                {
                    equipmentWithRent = item;
                }
            }


            naslov.Text = "Rent name: " + Najmovi[position].Rentid.ToString();
            datum.Text = "From: " + dateTimeOffset.ToLocalTime().ToString() + "\n" + "To: " + dateTimeOffset2.ToLocalTime().ToString() + "\n" + "Status: " + status;
            bicikl.Text = "Bicycle name: " + Najmovi[position].Bicycle.Name + "\n" + "Category: " + Najmovi[position].Bicycle.Category.Name + "\n" + "Price per day: " + Najmovi[position].Bicycle.Price_per_day + " " + Najmovi[position].Bicycle.Currency
                            + "\n" + "Price per hour: " + Najmovi[position].Bicycle.Price_per_hour + " " + Najmovi[position].Bicycle.Currency + "\n";
            if (equWithRentObject != null)
            {
                equipmentText.Text = "Equipment name: " + equipmentWithRent.Name;
            }

            var restClient2 = new RestClient("http://marichely.me:8099/");
            var restRequest2 = new RestRequest("bicycle/picture/id", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            if (imageObj.PictureIds.Count > 0)
            {
                PictureId = imageObj.PictureIds[imageObj.PictureIds.Count - 1];
                String fileName = PictureId + ".jpeg";
                var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                var filePath = System.IO.Path.Combine(documentsPath, fileName);
                Bitmap bmp = null;
                byte[] imgData = new byte[0];
                if (File.Exists(filePath))
                {
                    imgData = ByteFileToArray(filePath);
                }
                else
                {
                    restRequest2.AddHeader("Content-Type", "image/jpeg");
                    restRequest2.AddHeader("UserApiKey", user[0].ApiKey);
                    restRequest2.AddHeader("imageid", PictureId);
                    IRestResponse restResponse2 = restClient2.Execute(restRequest2);
                    restResponse2.ContentType = "image/jpeg";
                    if ((int)restResponse2.StatusCode == 200)
                    {
                        imgData = restResponse2.RawBytes;
                        ByteArrayToFile(filePath, imgData);
                    }
                }

                bmp = BitmapFactory.DecodeByteArray(imgData, 0, imgData.Length);
                slika.SetImageBitmap(bmp);
            }

            prijaviincidentgumb.Click += (e, s) =>
            {
                Intent incident = new Intent(MojKontekst, typeof(IncidentReportActivity));

                string serializiraniNajmovi = JsonConvert.SerializeObject(Najmovi[position]);

                incident.PutExtra("user", userdata);
                incident.PutExtra("rent", serializiraniNajmovi);
                MojKontekst.StartActivity(incident);
            };
            ostaviRecenzijuGumb.Click += (e, s) =>
            {
                Intent incident = new Intent(MojKontekst, typeof(ReviewActivity));
                string serializiraniNajmovi = JsonConvert.SerializeObject(Najmovi[position]);
                incident.PutExtra("user", userdata);
                incident.PutExtra("rent", serializiraniNajmovi);
                MojKontekst.StartActivity(incident);
            };
            locationGumb.Click += (e, s) =>
            {
                Intent lokacija = new Intent(MojKontekst, typeof(LocationActivity));
                lokacija.PutExtra("user", userdata);
                lokacija.PutExtra("bicycleid", Najmovi[position].Bicycle.Bicycleid);
                MojKontekst.StartActivity(lokacija);
            };

            cancelGumb.Click += (e, s) =>
            {
                var klijent = new RestClient("http://marichely.me:8099/");
                var zahtjev = new RestRequest("rent/object", Method.DELETE);
                zahtjev.RequestFormat = DataFormat.Json;
                zahtjev.AddHeader("userapikey", user[0].ApiKey);
                string test1 = JsonConvert.SerializeObject(Najmovi[position]);
                zahtjev.AddParameter("application/json", test1, ParameterType.RequestBody);
                IRestResponse odgovor = klijent.Execute(zahtjev);
                if ((int)odgovor.StatusCode == 200)
                {
                    Toast.MakeText(MojKontekst, "Successfully removed the Rent", ToastLength.Short).Show();
                }
                Najmovi.Remove(Najmovi[position]);
            };


            return view;
        }
        public bool ByteArrayToFile(string fileName, byte[] byteArray)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(byteArray, 0, byteArray.Length);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return false;
            }
        }

        public byte[] ByteFileToArray(string fileName)
        {
            try
            {
                using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    byte[] byteArray = new byte[fs.Length];
                    fs.Read(byteArray, 0, (int)fs.Length);
                    return byteArray;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return null;
            }
        }

        public void EquipmentWithRentView()
        {
            string text = activity.Intent.GetStringExtra("user") ?? "Data not available";
            var rentid = activity.Intent.GetIntExtra("rentid", 104);
            var user = JsonConvert.DeserializeObject<List<User>>(text);
            RestClient client = new RestClient("http://marichely.me:8099/");
            RestRequest request = new RestRequest("rent/equipment", Method.GET);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("UserApiKey", user[0].ApiKey);
            request.AddHeader("rentid", rentid.ToString());
            IRestResponse odgovor3 = client.Execute(request);
            if ((int)odgovor3.StatusCode == 200)
            {
                equWithRentObject = JsonConvert.DeserializeObject<List<Data_classes.EquipmentWithRent>>(odgovor3.Content);
            }
        }

    }
}