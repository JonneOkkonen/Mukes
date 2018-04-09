using Android.App;
using Android.Views;
using Android.Widget;
using Mukes.Core;
using System.Collections.Generic;

namespace Mukes.Droid
{
    public class MenuListAdapter : BaseAdapter<MenuStructure>
    {
        List<MenuStructure> _list;
        Activity _activity;

        public MenuListAdapter(Activity activity, List<MenuStructure> list)
        {
            _activity = activity;
            _list = list;
        }

        public override int Count
        {
            get { return _list.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override MenuStructure this[int index]
        {
            get { return _list[index]; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View view = convertView;

            // Re-use an existing view, if one is available otherwise create a new one
            if (view == null)
                view = _activity.LayoutInflater.Inflate(Resource.Layout.MenuListAdapter, parent, false);

            MenuStructure item = this[position];
            view.FindViewById<TextView>(Resource.Id.title).Text = item.Title; // Title
            view.FindViewById<TextView>(Resource.Id.breakfestTitle).Text = "Aamiainen: "; // Breakfest Title
            view.FindViewById<TextView>(Resource.Id.breakfestDescription).Text = item.Breakfast; // Breakfest Description
            view.FindViewById<TextView>(Resource.Id.lunchTitle).Text = "Lounas: "; // Lunch Title
            view.FindViewById<TextView>(Resource.Id.lunchDescription).Text = item.Lunch; // Lunch Description
            view.FindViewById<TextView>(Resource.Id.dinnerTitle).Text = "Päivällinen: "; // Dinner Title
            view.FindViewById<TextView>(Resource.Id.dinnerDescription).Text = item.Dinner; // Dinner Description
            view.FindViewById<TextView>(Resource.Id.eveningSnackTitle).Text = "Iltapala: "; // Evening Snack Title
            view.FindViewById<TextView>(Resource.Id.eveningSnackDescription).Text = item.EveningSnack; // Evening Snack Description

            return view;
        }
    }
}