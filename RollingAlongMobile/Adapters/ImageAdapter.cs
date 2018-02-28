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
using Android.Support.V4.View;
using Java.Lang;

namespace RollingAlongMobile.Adapters
{
    public class ImageAdapter : PagerAdapter
    {
        private Context context;
        private int[] imageList = {
            /*Resource.Drawable.flower1,
             Resource.Drawable.flower2,
              Resource.Drawable.flower3,*/
        };

        public ImageAdapter(Context context)
        {
            this.context = context;
        }
        public override int Count
        {
            get
            {
                return imageList.Length;
            }
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object objectValue)
        {
            return view == ((ImageView)objectValue);
        }

        public override Java.Lang.Object InstantiateItem(View container, int position)
        {
            ImageView imageView = new ImageView(context);
            imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
            imageView.SetImageResource(imageList[position]);
            ((ViewPager)container).AddView(imageView, 0);
            return imageView;
        }

        public override void DestroyItem(View container, int position, Java.Lang.Object objectValue)
        {
            ((ViewPager)container).RemoveView((ImageView)objectValue);
        }
    }
}