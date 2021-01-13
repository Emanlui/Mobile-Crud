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
    [Activity(Label = "recuperarContrasena")]
    public class recuperarContrasena : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.recuperarContrasena);

            Button button = FindViewById<Button>(Resource.Id.recuperarButton);
            button.Click += delegate { StartActivity(typeof(login)); };

        }
    }
}