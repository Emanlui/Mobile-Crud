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
using Xamarin.Essentials;

namespace Registro_y_control_de_extintores_Movil.Activities
{
    [Activity(Label = "contacto")]
    public class contacto : Activity
    {
        public void llamarNumero(string numero)
        {
            try
            {
                PhoneDialer.Open(numero);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Error
            }
            catch (Exception ex)
            {
                // Other error has occurred.  
            }
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.contacto);
            
            TextView numero1 = FindViewById<TextView>(Resource.Id.numeroText1);
            numero1.Click += delegate { llamarNumero("26004122"); };

            TextView numero2 = FindViewById<TextView>(Resource.Id.numeroText2);
            numero2.Click += delegate { llamarNumero("26004125"); };

            TextView numero3 = FindViewById<TextView>(Resource.Id.numeroText3);
            numero3.Click += delegate { llamarNumero("26004052"); };

            TextView numero4 = FindViewById<TextView>(Resource.Id.numeroText4);
            numero4.Click += delegate { llamarNumero("26004094"); };
        }
    }
}