using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Registro_y_control_de_extintores_Movil.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Registro_y_control_de_extintores_Movil.Activities
{
    [Activity(Label = "galeria")]
    public class galeria : Activity
    {
        ImageView imageView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.galeria);

            var btnCamera = FindViewById<Button>(Resource.Id.fotoButton);
            imageView = FindViewById<ImageView>(Resource.Id.imagen);
            btnCamera.Click += BtnCamera_Click;
        }
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            imageView.SetImageBitmap(bitmap);
                 
            ExtintorCrud ec = new ExtintorCrud();
            ec.Crear_Extintor(bitmap);
            

        }
        private void BtnCamera_Click(object sender, System.EventArgs e)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            StartActivityForResult(intent, 0);
        }
    }
}