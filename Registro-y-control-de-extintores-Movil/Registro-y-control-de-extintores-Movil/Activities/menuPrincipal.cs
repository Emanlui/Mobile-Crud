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

            ImageView salir = FindViewById<ImageView>(Resource.Id.salirImage);
            salir.Click += delegate { StartActivity(typeof(login)); };

            ImageView extintores = FindViewById<ImageView>(Resource.Id.extintoresImage);
            extintores.Click += delegate { StartActivity(typeof(vistaExtintores)); };

            ImageView galeria = FindViewById<ImageView>(Resource.Id.galeriaImage);
            galeria.Click += delegate { StartActivity(typeof(galeria)); };

            ImageView informacion = FindViewById<ImageView>(Resource.Id.informacionImage);
            informacion.Click += delegate { StartActivity(typeof(informacionEnviada)); };

            ImageView contacto = FindViewById<ImageView>(Resource.Id.contactosImage);
            contacto.Click += delegate { StartActivity(typeof(contacto)); };

            ImageView acerca = FindViewById<ImageView>(Resource.Id.acercaImage);
            acerca.Click += delegate { StartActivity(typeof(acercaDe)); };
        }
    }
}