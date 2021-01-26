using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Registro_y_control_de_extintores_Movil.Models;

namespace Registro_y_control_de_extintores_Movil.Activities
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class login : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.login);

            Button button = FindViewById<Button>(Resource.Id.loginButton);
            button.Click += delegate { StartActivity(typeof(loginForm)); };

            TextView text = FindViewById<TextView>(Resource.Id.olvidarButton);
            text.Click += delegate { StartActivity(typeof(recuperarContrasena)); };

            Context mContext = Android.App.Application.Context;
            AppPreferences ap = new AppPreferences(mContext);

            if (ap.getLogin())
            {
                StartActivity(typeof(menuPrincipal));
                Finish();
                return;
            }

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            throw new System.NotImplementedException();
        }
    }
}