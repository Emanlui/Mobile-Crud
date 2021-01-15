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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.vistaExtintores);
            

            layout = FindViewById<LinearLayout>(Resource.Id.extintorLayout);
            
            poblarLinearLayout();
            
        }

        private void poblarLinearLayout()
        {
            ExtintorCrud ec = new ExtintorCrud();
            List<Extintor> lista_de_extintores = ec.ObtenerRegistros();

            

            foreach (var extintor in lista_de_extintores)
            {
                

                GridLayout ll = new GridLayout(this);
                ll.ColumnCount = 2;
                ll.RowCount = 7;
                LinearLayout.LayoutParams layout_param = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                layout_param.LeftMargin = 100;
                ll.LayoutParameters = layout_param;

                int MARGIN = 10;

                int pWidth = ll.Width;
                int pHeight = ll.Height;

                LinearLayout[] lista_de_layouts = new LinearLayout[20];

                for (int pos = 0; pos < 15; pos++)
                {
                          LinearLayout.LayoutParams layout_grid = new LinearLayout.LayoutParams(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                          lista_de_layouts[pos] = new LinearLayout(this);
                    
                          layout_grid.SetMargins(MARGIN, MARGIN, MARGIN, MARGIN);
                          lista_de_layouts[pos].LayoutParameters = layout_grid;
                          System.Console.WriteLine(pos);
                          ll.AddView(lista_de_layouts[pos]);
                }

                

                ImageView iv = new ImageView(this);
                int posicion = 0;
                if (extintor.Tipo == "AB")
                {

                    iv.SetImageResource(Resource.Drawable.extintoresab);
                    lista_de_layouts[posicion].AddView(iv);
                    posicion++;
                    
                }else if(extintor.Tipo == "ABC")
                {

                    iv.SetImageResource(Resource.Drawable.extintoresabc);
                    lista_de_layouts[posicion].AddView(iv);
                    posicion++;

                }else if(extintor.Tipo == "BC")
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


                TextView tv1 = new TextView(this);
                string tipo = " Tipo: " + extintor.Tipo;
                tv1.SetText(tipo.ToCharArray(), 1, tipo.Length - 1);
                tv1.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv1);
                posicion++;

                TextView tv2 = new TextView(this);
                string agente_extintor = " Agente: " + extintor.Agente_extintor;
                tv2.SetText(agente_extintor.ToCharArray(), 1, agente_extintor.Length-1);
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

                TextView tv5 = new TextView(this);
                string collarin = " Collarin: " + extintor.Collarin.ToString();
                tv5.SetText(collarin.ToCharArray(), 1, collarin.Length - 1);
                tv5.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv5);
                posicion++;

                TextView tv6 = new TextView(this);
                string condicion_manguera = " Condicion de la manguera: " + extintor.Condicion_manguera.ToString();
                tv6.SetText(condicion_manguera.ToCharArray(), 1, condicion_manguera.Length - 1);
                tv6.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv6);
                posicion++;

                TextView tv7 = new TextView(this);
                string ultima_prueba = " Última prueba hidrostatica: " + extintor.Ultima_prueba_hidrostatica;
                tv7.SetText(ultima_prueba.ToCharArray(), 1, ultima_prueba.Length - 1);
                tv7.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv7);
                posicion++;

                TextView tv8 = new TextView(this);
                string rotulacion = " Rotulacion: " + extintor.Rotulacion.ToString();
                tv8.SetText(rotulacion.ToCharArray(), 1, rotulacion.Length - 1);
                tv8.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv8);
                posicion++;

                TextView tv9 = new TextView(this);
                string acceso_a_extintor = " Acceso a extintor: " + extintor.Acceso_a_extintor.ToString();
                tv9.SetText(acceso_a_extintor.ToCharArray(), 1, acceso_a_extintor.Length - 1);
                tv9.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv9);
                posicion++;

                TextView tv10 = new TextView(this);
                string presion = " Presion: " + extintor.Presion.ToString();
                tv10.SetText(presion.ToCharArray(), 1, presion.Length - 1);
                tv10.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv10);
                posicion++;

                TextView tv11 = new TextView(this);
                string seguro = " Seguro y marchamo: " + extintor.Seguro_y_marchamo.ToString();
                tv11.SetText(seguro.ToCharArray(), 1, seguro.Length - 1);
                tv11.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv11);
                posicion++;

                TextView tv12 = new TextView(this);
                string condicion_extintor = " Condición del extintor: " + extintor.Condicion_extintor.ToString();
                tv12.SetText(condicion_extintor.ToCharArray(), 1, condicion_extintor.Length - 1);
                tv12.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv12);
                posicion++;

                TextView tv13 = new TextView(this);
                string condicion_boquilla = " Condición de la boquilla: " + extintor.Condicion_boquilla.ToString();
                tv13.SetText(condicion_boquilla.ToCharArray(), 1, condicion_boquilla.Length - 1);
                tv13.SetTextColor(Android.Graphics.Color.White);
                lista_de_layouts[posicion].AddView(tv13);
                posicion++;


                TextView tv14 = new TextView(this);
                string proximo_mantenimiento = " Próximo mantenimiento: " + extintor.Proximo_mantenimiento;
                tv14.SetText(proximo_mantenimiento.ToCharArray(), 1, proximo_mantenimiento.Length - 1);
                tv14.SetTextColor(Android.Graphics.Color.White);

                System.Console.WriteLine(posicion);
                lista_de_layouts[posicion].AddView(tv14);
                posicion++;
                
                layout.AddView(ll);
            }
            

        }
    }
}