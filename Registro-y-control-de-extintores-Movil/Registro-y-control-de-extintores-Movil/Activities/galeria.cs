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
        ExtintorCrud ec = new ExtintorCrud();
        Extintor extintorTemporal;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.galeria);

            layout = FindViewById<LinearLayout>(Resource.Id.galeriaLayout);
            TextView buscarBtn = FindViewById<TextView>(Resource.Id.buscarButton);
            buscarBtn.Click += BtnBuscar_Click;
            List<Extintor> lista_de_extintores = ec.ObtenerRegistros();

            poblarGaleria(lista_de_extintores);

        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            layout.RemoveAllViews();
            TextView activo = FindViewById<TextView>(Resource.Id.buscarText);
            poblarGaleria(ec.ObtenerRegistroPorActivo(activo.Text));
            activo.Text = "";
        }

        private void bottonEliminarSeleccionado(object sender, EventArgs e, Extintor extintor)
        {
            ec.EliminarImagen(extintor.Activo);
            layout.RemoveAllViews();
            poblarGaleria(ec.ObtenerRegistros());
            System.Console.WriteLine(extintor.Activo);
        }

        private void bottonModificarSeleccionado(object sender, EventArgs e, Extintor extintor)
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            extintorTemporal = extintor;
            StartActivityForResult(intent, 0);

        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            Bitmap bitmap = (Bitmap)data.Extras.Get("data");
            //imageView.SetImageBitmap(bitmap);

            ExtintorCrud ec = new ExtintorCrud();
            ec.ModificarFotoExtintor(bitmap, extintorTemporal.Activo);
            layout.RemoveAllViews();
            poblarGaleria(ec.ObtenerRegistros());

        }
        private void poblarGaleria(List<Extintor> lista_de_extintores)
        {
            
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
                    ll.RowCount = 6;
                    LinearLayout.LayoutParams layout_param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    layout_param.LeftMargin = 100;
                    layout_param.RightMargin = 100;
                    ll.LayoutParameters = layout_param;

                    int MARGIN = 10;

                    int pWidth = ll.Width;
                    int pHeight = ll.Height;

                    LinearLayout[] lista_de_layouts = new LinearLayout[16];

                    for (int pos = 0; pos < 6; pos++)
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
                    tv1.Gravity = GravityFlags.CenterHorizontal;
                    lista_de_layouts[posicion].Orientation = Orientation.Horizontal;
                    lista_de_layouts[posicion].AddView(tv1);
                    posicion++;
                    ImageView iv = new ImageView(this);
                    
                    LinearLayout.LayoutParams layout_image = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                    layout_image.Height = 200;
                    layout_image.Gravity = GravityFlags.Center;
                    layout_image.TopMargin = 20;
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


                    
                    try
                    {
                        ImageView imagen_extintor = new ImageView(this);
                        LinearLayout.LayoutParams imagen_extintor_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                        imagen_extintor_layout.Gravity = GravityFlags.Center;
                        imagen_extintor_layout.TopMargin = 60;
                        imagen_extintor_layout.Height = 500;
                        imagen_extintor.LayoutParameters = imagen_extintor_layout;
                        Bitmap bf = BitmapFactory.DecodeByteArray(extintor.Imagen, 0, extintor.Imagen.Length);
                        imagen_extintor.SetImageBitmap(bf);
                        lista_de_layouts[posicion].AddView(imagen_extintor);
                    }
                    catch (System.NullReferenceException exception)
                    {
                        TextView sinImagen = new TextView(this);
                        LinearLayout.LayoutParams imagen_extintor_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                        imagen_extintor_layout.Gravity = GravityFlags.Center;
                        sinImagen.SetTextColor(Color.White);
                        sinImagen.Gravity = GravityFlags.CenterHorizontal;
                        sinImagen.LayoutParameters = imagen_extintor_layout;
                        sinImagen.Text = "***No posee imagen***";
                        lista_de_layouts[posicion].AddView(sinImagen);
                        // Error
                    }
                    
                    posicion++;

                    LinearLayout.LayoutParams button_margin = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                    
                    button_margin.Gravity = GravityFlags.Center;
                    
                    Button actualizar = new Button(this);
                    actualizar.Click += (sender, EventArgs) => { bottonModificarSeleccionado(sender, EventArgs, extintor); };
                    actualizar.Text = "actualizar";
                    actualizar.SetTextColor(Color.White);
                    actualizar.SetBackgroundColor(Color.Black); 
                    actualizar.LayoutParameters = button_margin;

                    Button eliminar= new Button(this);
                    eliminar.Click += (sender, EventArgs) => { bottonEliminarSeleccionado(sender, EventArgs, extintor); };
                    eliminar.LayoutParameters = button_margin;
                    eliminar.Text = "eliminar";
                    eliminar.SetTextColor(Color.White);
                    eliminar.SetBackgroundColor(Color.Black);
                   
                    lista_de_layouts[posicion].AddView(actualizar);
                    posicion++;
                    lista_de_layouts[posicion].AddView(eliminar);
                    posicion++;

                    for (int i = 0; i < 5; i++) ll.AddView(lista_de_layouts[i]);


                    ImageView linea = new ImageView(this);
                    linea.SetImageResource(Resource.Drawable.linea);
                    lista_de_layouts[posicion].AddView(linea);
                    ll.AddView(lista_de_layouts[posicion]);
                    layout.AddView(ll);
                }
            }
        }
    }
}