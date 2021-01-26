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
    [Activity(Label = "MensajeRestablecer")]
    public class MensajeRestablecer : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MensajeRestablecer);

            Button devolverse = FindViewById<Button>(Resource.Id.volverInicio);
            devolverse.Click += delegate { StartActivity(typeof(login)); };
        }
    }
}