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
    [Activity(Label = "loginForm")]
    public class loginForm : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.loginForm);
            Button button = FindViewById<Button>(Resource.Id.Login);
            button.Click += loginClick;

        }

        private void loginClick(object sender, EventArgs e)
        {
            EditText usuario = FindViewById<EditText>(Resource.Id.usuarioText);
            EditText pass = FindViewById<EditText>(Resource.Id.contrasenaText);

            UsuarioCrud uc = new UsuarioCrud();
            Context mContext = Android.App.Application.Context;
            AppPreferences ap = new AppPreferences(mContext);


            if (uc.verificacionDeLogin(usuario.Text, pass.Text))
            {
                ap.guardarCorreoPass(usuario.Text, true);
                StartActivity(typeof(menuPrincipal));
                Finish();
                return;
            }
            else
            {
                ap.setLogin(false);    
                Toast.MakeText(this, "El correo o contraseña incorrecta", ToastLength.Short).Show();
            }
        }
    }
}