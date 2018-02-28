using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using Com.Nostra13.Universalimageloader.Core;
using RollingAlongMobile.Data_classes;
using Android.Graphics;
using System.IO;
using RestSharp;
using Newtonsoft.Json;

namespace RollingAlongMobile.Adapters
{
    class BicyclesAdapter : BaseAdapter<Bicycle>
    {
        string userData;
        public List<Bicycle> Bicycles;
        private Activity Activity;
        public AssetManager Assets { get; private set; }
        public Context Context { get; private set; }
        public string PicturePostResponse { get; set; }
        public string PictureId { get; set; }
        public Bicycle_pictures imageObj { get; set; }
        public long CatId { get; set; }


        public BicyclesAdapter(Activity activity, List<Bicycle> bicycles, string data)
        {
            this.Activity = activity;
            this.Bicycles = bicycles;
            Context = activity;
            userData = data;
        }

        public override long GetItemId(int position)
        {
            return Bicycles[position].Bicycleid;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Typeface fontNormal;
            Assets = Context.Assets;
            fontNormal = Typeface.CreateFromAsset(Assets, "robotol.ttf");
            Typeface fontBold;
            fontBold = Typeface.CreateFromAsset(Assets, "roboto.ttf");

            var view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.BicycleRow, parent, false);
            var naslov = view.FindViewById<TextView>(Resource.Id.Naslov);
            var bicikl = view.FindViewById<TextView>(Resource.Id.Bicikl);
            var slika = view.FindViewById<ImageView>(Resource.Id.Slika);
            var glavni = view.FindViewById<RelativeLayout>(Resource.Id.glavni);


            naslov.Typeface = fontBold;
            bicikl.Typeface = fontNormal;


            string status = "Status is not set";

            switch (Bicycles[position].State)
            {
                case 1: status = "Reserved"; break;
                case 2: status = "Active"; break;
                case 3: status = "Expired"; break;
            }
            if (Bicycles[position].State == 1)
            {

                /*naslov.Visibility = ViewStates.Invisible;
                bicikl.Visibility = ViewStates.Invisible;
                slika.Visibility = ViewStates.Invisible;*/
            }
            if (Bicycles[position].State == 2)
            {
                bicikl.SetTextColor(Color.ParseColor("#8A9D5A"));
            }
            if (Bicycles[position].State == 3)
            {
                bicikl.SetTextColor(Color.ParseColor("#8A9D5A"));
            }

            var user = JsonConvert.DeserializeObject<List<User>>(userData);
            var restClient = new RestClient("http://marichely.me:8099/");
            var restRequest = new RestRequest("bicycle/picture/id/all", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            restRequest.AddHeader("UserApiKey", user[0].ApiKey);
            restRequest.AddHeader("bicycleid", Bicycles[position].Bicycleid.ToString());
            IRestResponse restResponse = restClient.Execute(restRequest);
            if ((int)restResponse.StatusCode == 200)
            {
                imageObj = JsonConvert.DeserializeObject<Bicycle_pictures>(restResponse.Content);
            }

            naslov.Text = "Bicycle name: " + Bicycles[position].Name.ToString();
            bicikl.Text = "Category: " + Bicycles[position].Category.Name + "\n" + "State: " + status + "\n" + "Price per day: " + Bicycles[position].Price_per_day + " " + Bicycles[position].Currency
                            + "\n" + "Price per hour: " + Bicycles[position].Price_per_hour + " " + Bicycles[position].Currency + "\n";
            var id = Bicycles[position].Bicycleid;

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
        public override int Count
        {
            get
            {
                return Bicycles.Count;
            }
        }

        public override Bicycle this[int position] => throw new NotImplementedException();
    }
}