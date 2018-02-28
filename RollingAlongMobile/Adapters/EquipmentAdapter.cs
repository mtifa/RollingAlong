using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Views;
using Android.Widget;
using RollingAlongMobile.Data_classes;
using Android.Graphics;

namespace RollingAlongMobile.Adapters
{
    class EquipmentAdapter : BaseAdapter<Equipment>
    {
        string userdata;
        public List<Equipment> Equipments;
        private Activity Activity;
        public AssetManager Assets { get; private set; }
        public Context MojKontekst { get; private set; }
        public long CatId { get; set; }


        public EquipmentAdapter(Activity activity, List<Equipment> equipments, string data)
        {
            this.Activity = activity;
            this.Equipments = equipments;
            MojKontekst = activity;
            userdata = data;
        }

        public override long GetItemId(int position)
        {
            return Equipments[position].Equipmentid;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            Typeface fontNormal;
            Assets = MojKontekst.Assets;
            fontNormal = Typeface.CreateFromAsset(Assets, "robotol.ttf");
            Typeface fontBold;
            fontBold = Typeface.CreateFromAsset(Assets, "roboto.ttf");

            var view = convertView ?? Activity.LayoutInflater.Inflate(Resource.Layout.EquipmentRow, parent, false);
            var naslov = view.FindViewById<TextView>(Resource.Id.Naslov);
            var bicikl = view.FindViewById<TextView>(Resource.Id.Bicikl);
            //var slika = view.FindViewById<ImageView>(Resource.Id.Slika);
            var glavni = view.FindViewById<RelativeLayout>(Resource.Id.glavni);

            naslov.Typeface = fontBold;
            bicikl.Typeface = fontNormal;

            string status = "not set";

            switch (Equipments[position].State)
            {
                case 1: status = "Reserved"; break;
                case 2: status = "Active"; break;
                case 3: status = "Expired"; break;
            }

            naslov.Text = "Equipment name: " + Equipments[position].Name.ToString();
            bicikl.Text = "Equipment ID: " + Equipments[position].Equipmentid + "\n" + "Category: " + Equipments[position].Category.Name + "\n" + "State: " + status + "\n" + "Price per day: " + Equipments[position].Price_per_day + " " + Equipments[position].Currency
                            + "\n" + "Price per hour: " + Equipments[position].Price_per_hour + " " + Equipments[position].Currency + "\n";
            var id = Equipments[position].Equipmentid;

            var catidbic = Equipments[position].Category.Categoryid;

            if (Equipments[position].Equipmentid == Equipments[position].Category.Categoryid)
            {
                CatId = Equipments[position].Category.Categoryid;
            }

            return view;
        }

        public override int Count
        {
            get
            {
                return Equipments.Count;
            }
        }

        public override Equipment this[int position] => throw new NotImplementedException();
    }
}