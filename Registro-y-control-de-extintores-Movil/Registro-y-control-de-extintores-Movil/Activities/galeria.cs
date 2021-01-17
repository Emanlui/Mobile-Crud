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
        LinearLayout layout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.galeria);

            layout = FindViewById<LinearLayout>(Resource.Id.galeriaLayout);

            ExtintorCrud ec = new ExtintorCrud();
            List<Extintor> lista_de_extintores = ec.ObtenerRegistros();

            poblarGaleria(lista_de_extintores);

        }

        private void poblarGaleria(List<Extintor> lista_de_extintores)
        {
            System.Console.WriteLine(lista_de_extintores.Count);
            if (lista_de_extintores.Count == 0)
            {

                TextView noHayRegistros = new TextView(this);
                string mensaje = " ***No existen extintores***";
                noHayRegistros.SetText(mensaje.ToCharArray(), 0, mensaje.Length);
                noHayRegistros.SetTextColor(Android.Graphics.Color.White);
                noHayRegistros.Gravity = GravityFlags.CenterHorizontal;
                layout.AddView(noHayRegistros);
            }
            else
            {

                foreach (var extintor in lista_de_extintores)
                {

                    GridLayout ll = new GridLayout(this);
                    ll.ColumnCount = 1;
                    ll.RowCount = 4;
                    LinearLayout.LayoutParams layout_param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    layout_param.LeftMargin = 100;
                    layout_param.RightMargin = 100;
                    ll.LayoutParameters = layout_param;

                    int MARGIN = 10;

                    int pWidth = ll.Width;
                    int pHeight = ll.Height;

                    LinearLayout[] lista_de_layouts = new LinearLayout[16];

                    for (int pos = 0; pos < 4; pos++)
                    {
                        LinearLayout.LayoutParams layout_grid = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                        
                        layout_grid.Gravity = GravityFlags.Center;
                        layout_grid.SetMargins(MARGIN, MARGIN, MARGIN, MARGIN);
                        lista_de_layouts[pos] = new LinearLayout(this);
                        lista_de_layouts[pos].LayoutParameters = layout_grid;

                    }

                    int posicion = 0;

                    TextView tv1 = new TextView(this);
                    string activo = " Activo: " + extintor.Activo;
                    tv1.SetText(activo.ToCharArray(), 1, activo.Length - 1);
                    tv1.SetTextColor(Android.Graphics.Color.White);
                    lista_de_layouts[posicion].Orientation = Orientation.Horizontal;
                    lista_de_layouts[posicion].AddView(tv1);

                    ImageView iv = new ImageView(this);
                    
                    LinearLayout.LayoutParams layout_image = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                    layout_image.Height = 200;
                    layout_image.Width = 200;
                    layout_image.Gravity = GravityFlags.Center;
                    layout_image.TopMargin = 60;
                    iv.LayoutParameters = layout_image;
                    if (extintor.Tipo == "AB")
                    {

                        iv.SetImageResource(Resource.Drawable.extintoresab);
                        lista_de_layouts[posicion].AddView(iv);

                    }
                    else if (extintor.Tipo == "ABC")
                    {

                        iv.SetImageResource(Resource.Drawable.extintoresabc);
                        lista_de_layouts[posicion].AddView(iv);

                    }
                    else if (extintor.Tipo == "BC")
                    {

                        iv.SetImageResource(Resource.Drawable.extintoresbc);
                        lista_de_layouts[posicion].AddView(iv);

                    }
                    else
                    {
                        iv.SetImageResource(Resource.Drawable.extintoresc);
                        lista_de_layouts[posicion].AddView(iv);

                    }
                    posicion++;

                    LinearLayout.LayoutParams button_margin = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                    
                    
                    button_margin.Gravity = GravityFlags.Center;
                    
                    Button actualizar = new Button(this);
                    actualizar.Text = "actualizar";
                    actualizar.SetTextColor(Color.White);
                    actualizar.SetBackgroundColor(Color.Black); 
                    actualizar.LayoutParameters = button_margin;

                    Button eliminar= new Button(this);
                    eliminar.LayoutParameters = button_margin;
                    eliminar.Text = "eliminar";
                    eliminar.SetTextColor(Color.White);
                    eliminar.SetBackgroundColor(Color.Black);
                   
                    lista_de_layouts[posicion].AddView(actualizar);
                    posicion++;
                    lista_de_layouts[posicion].AddView(eliminar);
                    posicion++;


                    for (int i = 0; i < 3; i++) ll.AddView(lista_de_layouts[i]);


                    ImageView linea = new ImageView(this);
                    linea.SetImageResource(Resource.Drawable.linea);
                    lista_de_layouts[posicion].AddView(linea);
                    ll.AddView(lista_de_layouts[posicion]);
                    layout.AddView(ll);
                }
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            //base.OnActivityResult(requestCode, resultCode, data);
            
            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            //imageView.SetImageBitmap(bitmap);
                 
            //ExtintorCrud ec = new ExtintorCrud();
            //ec.Crear_Extintor(bitmap);
            

        }
        private void BtnCamera_Click(object sender, System.EventArgs e)
        {
            //Intent intent = new Intent(MediaStore.ActionImageCapture);
            //StartActivityForResult(intent, 0);
        }
    }
}