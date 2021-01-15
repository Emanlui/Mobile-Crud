using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using Registro_y_control_de_extintores_Movil.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Registro_y_control_de_extintores_Movil.Activities
{
    [Activity(Label = "vistaExtintores")]
    public class vistaExtintores : Activity
    {
        LinearLayout ll;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vistaExtintores);
            

            LinearLayout layout = FindViewById<LinearLayout>(Resource.Id.extintorLayout);
            ll = new LinearLayout(this);
            
            TextView tv = new TextView(this);
            tv.SetText("ejemplo".ToCharArray(), 1, "ejemplo".Length-1);
            
            ll.AddView(tv);

            poblarLinearLayout();
            
            layout.AddView(ll);

            

        }

        private void poblarLinearLayout()
        {
            ExtintorCrud ec = new ExtintorCrud();
            List<Extintor> lista_de_extintores = ec.ObtenerRegistros();

            foreach (var extintor in lista_de_extintores)
            {
                ImageView iv = new ImageView(this);
                System.Console.WriteLine(extintor.Tipo);
                if (extintor.Tipo == "AB")
                {

                    File imgFile = new File("extintoresab.jpg");
                    
                    System.Console.WriteLine("ENTRA");
                    if (imgFile.Exists())
                    {

                        Android.Graphics.Bitmap myBitmap = BitmapFactory.DecodeFile(imgFile.AbsolutePath);

                        iv.SetImageBitmap(myBitmap);
                        ll.AddView(iv);
                    }
                }
                

                TextView tv1 = new TextView(this);
                tv1.SetText(extintor.Tipo.ToCharArray(), 1, extintor.Tipo.Length - 1);
                TextView tv2 = new TextView(this);
                TextView tv3 = new TextView(this);
                TextView tv4 = new TextView(this);
                TextView tv5 = new TextView(this);
                TextView tv6 = new TextView(this);
                TextView tv7 = new TextView(this);
                TextView tv8 = new TextView(this);
                TextView tv9 = new TextView(this);
                TextView tv10 = new TextView(this);
                TextView tv11 = new TextView(this);
                TextView tv12 = new TextView(this);
                TextView tv13 = new TextView(this);
                TextView tv14 = new TextView(this);
            }
            

        }
    }
}