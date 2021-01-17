using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Registro_y_control_de_extintores_Movil.Models;
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

            Context mContext = Android.App.Application.Context;
            AppPreferences ap = new AppPreferences(mContext);

            
            SetContentView(Resource.Layout.menuPrincipal);

            UsuarioCrud uc = new UsuarioCrud();

            TextView tv = FindViewById<TextView>(Resource.Id.centroText);
            string mensaje = "Centro de Trabajo: " + uc.getCentroDeTrabajo(ap.getCorreoKey());
            tv.Text = mensaje;

            ImageView salir = FindViewById<ImageView>(Resource.Id.salirImage);
            salir.Click += salirButton;

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

        private void salirButton(object sender, EventArgs e)
        {
            Context mContext = Android.App.Application.Context;
            AppPreferences ap = new AppPreferences(mContext);
            ap.guardarCorreoPass("", "");
            StartActivity(typeof(login)); 
        }
    }
}