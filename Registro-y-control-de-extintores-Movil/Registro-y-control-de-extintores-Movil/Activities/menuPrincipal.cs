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

            LinearLayout extintores = FindViewById<LinearLayout>(Resource.Id.extintoresLayout);
            extintores.Click += delegate { StartActivity(typeof(vistaExtintores)); };

            LinearLayout galeria = FindViewById<LinearLayout>(Resource.Id.galeriaLayout);
            galeria.Click += delegate { StartActivity(typeof(galeria)); };

            LinearLayout informacion = FindViewById<LinearLayout>(Resource.Id.informacionLayout);
            informacion.Click += delegate { StartActivity(typeof(informacionEnviada)); };

            LinearLayout contacto = FindViewById<LinearLayout>(Resource.Id.contactosLayout);
            contacto.Click += delegate { StartActivity(typeof(contacto)); };

            LinearLayout acerca = FindViewById<LinearLayout>(Resource.Id.acercaLayout);
            acerca.Click += delegate { StartActivity(typeof(acercaDe)); };

            LinearLayout correoLayout = FindViewById<LinearLayout>(Resource.Id.correoLayout);
            correoLayout.Click += delegate { StartActivity(typeof(correo)); };

        }
    }
}