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
        LinearLayout layout;
        private int lineaImage;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vistaExtintores);
            layout = FindViewById<LinearLayout>(Resource.Id.extintorLayout);
            ExtintorCrud ec = new ExtintorCrud();
            List<Extintor> lista_de_extintores = ec.ObtenerRegistros();
            poblarLinearLayout(lista_de_extintores);

            var btnBuscar = FindViewById<Button>(Resource.Id.buscarButton);
            btnBuscar.Click += BtnBuscar_Click;
        }

        private void BtnBuscar_Click(object sender, EventArgs e)
        {

            LinearLayout lv = FindViewById<LinearLayout>(Resource.Id.extintorLayout);
            lv.RemoveAllViews();
            TextView activo = FindViewById<TextView>(Resource.Id.activoText);

            ExtintorCrud ec = new ExtintorCrud();
            List<Extintor> lista_de_extintores = ec.ObtenerRegistroPorActivo(activo.Text);
            poblarLinearLayout(lista_de_extintores);
            activo.Text = "";
        }

        private void poblarLinearLayout(List<Extintor> lista_de_extintores)
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
                    ll.RowCount = 17;
                    LinearLayout.LayoutParams layout_param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    layout_param.LeftMargin = 100;
                    layout_param.RightMargin = 100;
                    ll.LayoutParameters = layout_param;

                    int MARGIN = 10;

                    int pWidth = ll.Width;
                    int pHeight = ll.Height;

                    LinearLayout[] lista_de_layouts = new LinearLayout[17];

                    for (int pos = 0; pos < 17; pos++)
                    {
                        LinearLayout.LayoutParams layout_grid = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;

                        layout_grid.Gravity = GravityFlags.Center;
                        layout_grid.SetMargins(MARGIN, MARGIN, MARGIN, MARGIN);
                        lista_de_layouts[pos] = new LinearLayout(this);
                        lista_de_layouts[pos].LayoutParameters = layout_grid;

                    }



                    ImageView iv = new ImageView(this);
                    LinearLayout.LayoutParams layout_image = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;
                    layout_image.Gravity = GravityFlags.Center;
                    layout_image.TopMargin = 60;
                    iv.LayoutParameters = layout_image;
                    int posicion = 0;
                    if (extintor.Tipo == "AB")
                    {

                        iv.SetImageResource(Resource.Drawable.extintoresab);
                        lista_de_layouts[posicion].AddView(iv);
                        posicion++;

                    }
                    else if (extintor.Tipo == "ABC")
                    {

                        iv.SetImageResource(Resource.Drawable.extintoresabc);
                        lista_de_layouts[posicion].AddView(iv);
                        posicion++;

                    }
                    else if (extintor.Tipo == "BC")
                    {

                        iv.SetImageResource(Resource.Drawable.extintoresbc);
                        lista_de_layouts[posicion].AddView(iv);
                        posicion++;

                    }
                    else
                    {
                        iv.SetImageResource(Resource.Drawable.extintoresc);
                        lista_de_layouts[posicion].AddView(iv);
                        posicion++;

                    }

                    LinearLayout.LayoutParams layout_grid_elements = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;

                    TextView tv1 = new TextView(this);
                    string activo = " Activo: " + extintor.Activo;
                    tv1.SetText(activo.ToCharArray(), 1, activo.Length - 1);
                    tv1.SetTextColor(Android.Graphics.Color.White);
                    lista_de_layouts[posicion].AddView(tv1);
                    posicion++;

                    TextView tv2 = new TextView(this);
                    string agente_extintor = " Agente: " + extintor.Agente_extintor;
                    tv2.SetText(agente_extintor.ToCharArray(), 1, agente_extintor.Length - 1);
                    tv2.SetTextColor(Android.Graphics.Color.White);
                    lista_de_layouts[posicion].AddView(tv2);
                    posicion++;

                    TextView tv3 = new TextView(this);
                    string capacidad = " Capacidad: " + extintor.Capacidad.ToString();
                    tv3.SetText(capacidad.ToCharArray(), 1, capacidad.ToString().Length - 1);
                    tv3.SetTextColor(Android.Graphics.Color.White);
                    lista_de_layouts[posicion].AddView(tv3);
                    posicion++;

                    TextView tv4 = new TextView(this);
                    string ubicacion = " Ubicación: " + extintor.Ubicacion;
                    tv4.SetText(ubicacion.ToCharArray(), 1, ubicacion.Length - 1);
                    tv4.SetTextColor(Android.Graphics.Color.White);
                    lista_de_layouts[posicion].AddView(tv4);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv5 = new TextView(this);
                    TextView text5 = new TextView(this);
                    LinearLayout l5 = new LinearLayout(this);

                    l5.LayoutParameters = layout_grid_elements;
                    l5.Orientation = Orientation.Horizontal;

                    text5.SetText("Collarín: ".ToCharArray(), 0, "Collarín:".Length);
                    text5.SetTextColor(Android.Graphics.Color.White);

                    LinearLayout.LayoutParams tv5_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv5_layout.LeftMargin = 30;
                    tv5.LayoutParameters = tv5_layout;

                    if (extintor.Collarin == 1)
                    {
                        tv5.SetText("Si ".ToCharArray(), 0, "Si".Length);
                        tv5.SetTextColor(Android.Graphics.Color.Green);

                    }
                    else
                    {
                        tv5.SetText("No ".ToCharArray(), 0, "No".Length);
                        tv5.SetTextColor(Android.Graphics.Color.Red);
                    }

                    l5.AddView(text5);
                    l5.AddView(tv5);
                    lista_de_layouts[posicion].AddView(l5);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv6 = new TextView(this);
                    TextView text6 = new TextView(this);
                    LinearLayout l6 = new LinearLayout(this);

                    l6.LayoutParameters = layout_grid_elements;
                    l6.Orientation = Orientation.Horizontal;

                    text6.SetText("Condición de la manguera: ".ToCharArray(), 0, "Condición de la manguera:".Length);
                    text6.SetTextColor(Android.Graphics.Color.White);

                    LinearLayout.LayoutParams tv6_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv6_layout.LeftMargin = 30;
                    tv6.LayoutParameters = tv6_layout;

                    if (extintor.Condicion_manguera == 1)
                    {
                        tv6.SetText("Buena ".ToCharArray(), 0, "Buena".Length);
                        tv6.SetTextColor(Android.Graphics.Color.Green);

                    }
                    else
                    {
                        tv6.SetText("Mala ".ToCharArray(), 0, "Mala".Length);
                        tv6.SetTextColor(Android.Graphics.Color.Red);
                    }

                    l6.AddView(text6);
                    l6.AddView(tv6);
                    lista_de_layouts[posicion].AddView(l6);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv7 = new TextView(this);
                    string ultima_prueba = " Última prueba hidrostatica: " + extintor.Ultima_prueba_hidrostatica;
                    tv7.SetText(ultima_prueba.ToCharArray(), 1, ultima_prueba.Length - 1);
                    tv7.SetTextColor(Android.Graphics.Color.White);
                    lista_de_layouts[posicion].AddView(tv7);
                    posicion++;

                    TextView tv8 = new TextView(this);
                    TextView text8 = new TextView(this);
                    LinearLayout l8 = new LinearLayout(this);

                    l8.LayoutParameters = layout_grid_elements;
                    l8.Orientation = Orientation.Horizontal;

                    text8.SetText("Rotulación: ".ToCharArray(), 0, "Rotulación:".Length);
                    text8.SetTextColor(Android.Graphics.Color.White);

                    LinearLayout.LayoutParams tv8_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv8_layout.LeftMargin = 30;
                    tv8.LayoutParameters = tv8_layout;

                    if (extintor.Rotulacion == -1)
                    {
                        tv8.SetText("No cuenta con rotulación ".ToCharArray(), 0, "No cuenta con rotulación".Length);
                        tv8.SetTextColor(Android.Graphics.Color.Yellow);

                    }
                    else if (extintor.Rotulacion == 0)
                    {
                        tv8.SetText("Incorrecta ".ToCharArray(), 0, "Incorrecta".Length);
                        tv8.SetTextColor(Android.Graphics.Color.Red);
                    }
                    else
                    {
                        tv8.SetText("Correcta ".ToCharArray(), 0, "Correcta".Length);
                        tv8.SetTextColor(Android.Graphics.Color.Green);
                    }
                    l8.AddView(text8);
                    l8.AddView(tv8);
                    lista_de_layouts[posicion].AddView(l8);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv9 = new TextView(this);
                    TextView text9 = new TextView(this);
                    LinearLayout l9 = new LinearLayout(this);

                    l9.LayoutParameters = layout_grid_elements;
                    l9.Orientation = Orientation.Horizontal;

                    text9.SetText("Acceso a extintor: ".ToCharArray(), 0, "Acceso a extintor:".Length);
                    text9.SetTextColor(Android.Graphics.Color.White);

                    LinearLayout.LayoutParams tv9_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv9_layout.LeftMargin = 30;
                    tv9.LayoutParameters = tv8_layout;

                    if (extintor.Acceso_a_extintor == 1)
                    {
                        tv9.SetText("Si ".ToCharArray(), 0, "Si".Length);
                        tv9.SetTextColor(Android.Graphics.Color.Green);

                    }
                    else
                    {
                        tv9.SetText("No ".ToCharArray(), 0, "No".Length);
                        tv9.SetTextColor(Android.Graphics.Color.Red);
                    }

                    l9.AddView(text9);
                    l9.AddView(tv9);
                    lista_de_layouts[posicion].AddView(l9);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv10 = new TextView(this);
                    TextView text10 = new TextView(this);
                    LinearLayout l10 = new LinearLayout(this);
                    l10.LayoutParameters = layout_grid_elements;
                    l10.Orientation = Orientation.Horizontal;

                    text10.SetText("Presión: ".ToCharArray(), 0, "Presión:".Length);
                    text10.SetTextColor(Android.Graphics.Color.White);

                    tv10.SetText("Incorrecta ".ToCharArray(), 0, " Incorrecta".Length);
                    tv10.SetTextColor(Android.Graphics.Color.Red);
                    LinearLayout.LayoutParams tv10_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv10_layout.LeftMargin = 30;
                    tv10.LayoutParameters = tv10_layout;

                    if (extintor.Presion == 1)
                    {
                        tv10.SetText("Correcta ".ToCharArray(), 0, "Correcta".Length);
                        tv10.SetTextColor(Android.Graphics.Color.Green);
                    }
                    l10.AddView(text10);
                    l10.AddView(tv10);


                    lista_de_layouts[posicion].AddView(l10);

                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv11 = new TextView(this);
                    TextView text11 = new TextView(this);
                    LinearLayout l11 = new LinearLayout(this);

                    l11.LayoutParameters = layout_grid_elements;
                    l11.Orientation = Orientation.Horizontal;

                    text11.SetText("Seguro y marchamo: ".ToCharArray(), 0, "Seguro y marchamo:".Length);
                    text11.SetTextColor(Android.Graphics.Color.White);

                    LinearLayout.LayoutParams tv11_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv11_layout.LeftMargin = 30;
                    tv11.LayoutParameters = tv11_layout;

                    if (extintor.Seguro_y_marchamo == 1)
                    {
                        tv11.SetText("Bien ".ToCharArray(), 0, "Bien".Length);
                        tv11.SetTextColor(Android.Graphics.Color.Green);

                    }
                    else
                    {
                        tv11.SetText("Mal ".ToCharArray(), 0, "Mal".Length);
                        tv11.SetTextColor(Android.Graphics.Color.Red);
                    }

                    l11.AddView(text11);
                    l11.AddView(tv11);
                    lista_de_layouts[posicion].AddView(l11);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv12 = new TextView(this);
                    TextView text12 = new TextView(this);
                    LinearLayout l12 = new LinearLayout(this);

                    l12.LayoutParameters = layout_grid_elements;
                    l12.Orientation = Orientation.Horizontal;

                    text12.SetText("Condición del extintor: ".ToCharArray(), 0, "Condición del extintor:".Length);
                    text12.SetTextColor(Android.Graphics.Color.White);

                    LinearLayout.LayoutParams tv12_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv12_layout.LeftMargin = 30;
                    tv12.LayoutParameters = tv12_layout;

                    if (extintor.Condicion_extintor == 1)
                    {
                        tv12.SetText("Buena ".ToCharArray(), 0, "Buena".Length);
                        tv12.SetTextColor(Android.Graphics.Color.Green);

                    }
                    else
                    {
                        tv12.SetText("Mala ".ToCharArray(), 0, "Mala".Length);
                        tv12.SetTextColor(Android.Graphics.Color.Red);
                    }

                    l12.AddView(text12);
                    l12.AddView(tv12);
                    lista_de_layouts[posicion].AddView(l12);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv13 = new TextView(this);
                    TextView text13 = new TextView(this);
                    LinearLayout l13 = new LinearLayout(this);

                    l13.LayoutParameters = layout_grid_elements;
                    l13.Orientation = Orientation.Horizontal;

                    text13.SetText("Condición de la boquilla: ".ToCharArray(), 0, "Condición de la boquilla:".Length);
                    text13.SetTextColor(Android.Graphics.Color.White);

                    LinearLayout.LayoutParams tv13_layout = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    tv13_layout.LeftMargin = 30;
                    tv13.LayoutParameters = tv13_layout;

                    if (extintor.Condicion_boquilla == 1)
                    {
                        tv13.SetText("Buena ".ToCharArray(), 0, "Buena".Length);
                        tv13.SetTextColor(Android.Graphics.Color.Green);

                    }
                    else
                    {
                        tv13.SetText("Mala ".ToCharArray(), 0, "Mala".Length);
                        tv13.SetTextColor(Android.Graphics.Color.Red);
                    }

                    l13.AddView(text13);
                    l13.AddView(tv13);
                    lista_de_layouts[posicion].AddView(l13);
                    posicion++;

                    //-----------------------------------------------------------------

                    TextView tv14 = new TextView(this);
                    string proximo_mantenimiento = " Próximo mantenimiento: " + extintor.Proximo_mantenimiento;
                    tv14.SetText(proximo_mantenimiento.ToCharArray(), 1, proximo_mantenimiento.Length - 1);
                    tv14.SetTextColor(Android.Graphics.Color.White);

                    //System.Console.WriteLine(posicion);
                    lista_de_layouts[posicion].AddView(tv14);
                    posicion++;


                    for (int i = 0; i < 14; i++) ll.AddView(lista_de_layouts[i]);


                    

                    LinearLayout.LayoutParams button_margin = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent); ;

                    button_margin.Gravity = GravityFlags.Center;
                    Button actualizarBtn = new Button(this);
                    actualizarBtn.Click += (sender, EventArgs) => { botonActualizarSeleccionado(sender, EventArgs, extintor); };
                    actualizarBtn.LayoutParameters = button_margin;
                    actualizarBtn.Text = "Actualizar";
                    actualizarBtn.SetTextColor(Android.Graphics.Color.White);
                    actualizarBtn.SetBackgroundColor(Android.Graphics.Color.Black);
                    lista_de_layouts[posicion].AddView(actualizarBtn);
                    ll.AddView(lista_de_layouts[posicion]);
 
                    posicion++;

                    ImageView linea = new ImageView(this);
                    linea.SetImageResource(Resource.Drawable.linea);
                    System.Console.WriteLine(posicion);
                    lista_de_layouts[posicion].AddView(linea);
                    ll.AddView(lista_de_layouts[posicion]);
                   

                    layout.AddView(ll);
                }
            }

        }

        private void botonActualizarSeleccionado(object sender, EventArgs eventArgs, Extintor extintor)
        {
            Intent intent = new Intent(base.BaseContext, typeof(Activities.actualizarForm));
            intent.PutExtra("extintor", extintor.Id);

            StartActivity(intent);
    }
    }
}