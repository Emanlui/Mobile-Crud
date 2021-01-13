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
    [Activity(Label = "menuPrincipal")]
    public class menuPrincipal : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.menuPrincipal);

            ImageButton salir = FindViewById<ImageButton>(Resource.Id.salirImage);
            salir.Click += delegate { StartActivity(typeof(login)); };

            ImageButton extintores = FindViewById<ImageButton>(Resource.Id.extintoresImage);
            extintores.Click += delegate { StartActivity(typeof(vistaExtintores)); };

            ImageButton galeria = FindViewById<ImageButton>(Resource.Id.galeriaImage);
            galeria.Click += delegate { StartActivity(typeof(galeria)); };

            ImageButton informacion = FindViewById<ImageButton>(Resource.Id.informacionImage);
            informacion.Click += delegate { StartActivity(typeof(informacionEnviada)); };

            ImageButton contacto = FindViewById<ImageButton>(Resource.Id.contactosImage);
            contacto.Click += delegate { StartActivity(typeof(contacto)); };

            ImageButton acerca = FindViewById<ImageButton>(Resource.Id.acercaImage);
            acerca.Click += delegate { StartActivity(typeof(acercaDe)); };
        }
    }
}