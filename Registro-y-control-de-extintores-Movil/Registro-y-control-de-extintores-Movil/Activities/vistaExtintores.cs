using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Registro_y_control_de_extintores_Movil.Activities
{
    [Activity(Label = "vistaExtintores")]
    public class vistaExtintores : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vistaExtintores);


            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.extintorLayout);
            LinearLayout ll = new LinearLayout(this);
            
            TextView tv = new TextView(this);
            tv.SetText("ejemplo".ToCharArray(), 1, "ejemplo".Length-1);
            
            ll.AddView(tv);

            // Add the LinearLayout element to the ScrollView
            layout.AddView(ll);
        }
    }
}