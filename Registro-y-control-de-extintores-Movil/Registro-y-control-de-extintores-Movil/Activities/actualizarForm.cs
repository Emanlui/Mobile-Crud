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
    [Activity(Label = "actualizarForm")]
    public class actualizarForm : Activity
    {
        int extintor_id;
        Extintor extintor = new Extintor();
        Button dateProximaHidrostatica;
        Button dateUltimaHidrostatica;
        Button dateProximoMantenimiento;
        Boolean proximoManteClick = false;
        Boolean proximaHidroClick = false;
        Boolean ultimoHidroClick = false;

        ExtintorCrud ec = new ExtintorCrud();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.actualizarForm);
            extintor_id = base.Intent.GetIntExtra("extintor",0);
            
            
            extintor = ec.ObtenerRegistroPorID(extintor_id.ToString());
            llenarFormulario();
            
            extintor.Id = extintor_id;
            Button actualizarBtn = (Button)FindViewById<Button>(Resource.Id.actualizarBtn);
            actualizarBtn.Click += actualizarAction;
        }

        private void actualizarAction(object sender, EventArgs extintor)
        {

            Spinner tipoSpinner = FindViewById<Spinner>(Resource.Id.tipoSpinner);
            this.extintor.Tipo = tipoSpinner.SelectedItem.ToString();

            EditText ubicacionText = FindViewById<EditText>(Resource.Id.ubicacionText);
            this.extintor.Ubicacion = ubicacionText.Text;

            Spinner agenteSpinner = FindViewById<Spinner>(Resource.Id.spinnerAgente);
            this.extintor.Agente_extintor = agenteSpinner.SelectedItem.ToString();

            Spinner capacidadSpinner = FindViewById<Spinner>(Resource.Id.spinnerCapacidad);
            if (capacidadSpinner.SelectedItem.ToString() == "5")
            {
                this.extintor.Capacidad = 5;
            } else if (capacidadSpinner.SelectedItem.ToString() == "15")
            {
                this.extintor.Capacidad = 10;
            }
            else
            {
                this.extintor.Capacidad = 20;
            }

            Spinner spinnerPresion = FindViewById<Spinner>(Resource.Id.spinnerPresion);
            if (spinnerPresion.SelectedItem.ToString() == "Correcta")
            {
                this.extintor.Presion = 1;
            }
            else
            {
                this.extintor.Presion = 0;
            }

            Spinner spinnerRotulacion = FindViewById<Spinner>(Resource.Id.spinnerRotulacion);
            if (spinnerRotulacion.SelectedItem.ToString() == "Correcta")
            {
                this.extintor.Rotulacion = 1;
            }else if (spinnerRotulacion.SelectedItem.ToString() == "Incorrecta")
            {
                this.extintor.Rotulacion = 0;
            }
            else
            {
                this.extintor.Rotulacion = -1;
            }

            Spinner spinnerAcceso = FindViewById<Spinner>(Resource.Id.spinnerAcceso);
            if (spinnerAcceso.SelectedItem.ToString() == "Si")
            {
                this.extintor.Acceso_a_extintor = 1;
            }
            else
            {
                this.extintor.Acceso_a_extintor = 0;
            }

            Spinner spinnerCondicion = FindViewById<Spinner>(Resource.Id.spinnerCondicion);
            if (spinnerCondicion.SelectedItem.ToString() == "Bueno")
            {
                this.extintor.Condicion_extintor = 1;
            }
            else
            {
                this.extintor.Condicion_extintor = 0;
            }

            Spinner spinnerSeguro = FindViewById<Spinner>(Resource.Id.spinnerSeguro);
            if (spinnerSeguro.SelectedItem.ToString() == "Bien")
            {
                this.extintor.Seguro_y_marchamo = 1;
            }
            else
            {
                this.extintor.Seguro_y_marchamo = 0;
            }

            Spinner spinnerCollarin = FindViewById<Spinner>(Resource.Id.spinnerCollarin);
            if (spinnerCollarin.SelectedItem.ToString() == "Si")
            {
                this.extintor.Collarin = 1;
            }
            else
            {
                this.extintor.Collarin = 0;
            }

            Spinner spinnerManguera = FindViewById<Spinner>(Resource.Id.spinnerManguera);
            if (spinnerManguera.SelectedItem.ToString() == "Buena")
            {
                this.extintor.Condicion_manguera  = 1;
            }
            else
            {
                this.extintor.Condicion_manguera = 0;
            }

            Spinner spinnerBoquilla = FindViewById<Spinner>(Resource.Id.spinnerBoquilla);
            if (spinnerBoquilla.SelectedItem.ToString() == "Buena")
            {
                this.extintor.Condicion_boquilla = 1;
            }
            else
            {
                this.extintor.Condicion_boquilla = 0;
            }

            System.Console.WriteLine(this.extintor.Proxima_prueba_hidrostatica);
            System.Console.WriteLine(this.extintor.Proximo_mantenimiento);
            System.Console.WriteLine(this.extintor.Ultima_prueba_hidrostatica);
            if (!proximaHidroClick)
            {
                try
                {
                    this.extintor.Proxima_prueba_hidrostatica = formatearFecha(this.extintor.Proxima_prueba_hidrostatica);
                }catch(Exception exception)
                {
                    this.extintor.Proxima_prueba_hidrostatica = formatearFecha(DateTime.Now);
                }
            }

            if (!proximoManteClick)
            {
                try
                {
                    this.extintor.Proximo_mantenimiento = formatearFecha(this.extintor.Proximo_mantenimiento);
                }
                catch (Exception exception)
                {
                    this.extintor.Proximo_mantenimiento = formatearFecha(DateTime.Now);
                }
            }

            if (!ultimoHidroClick)
            {
                try
                {
                    this.extintor.Ultima_prueba_hidrostatica = formatearFecha(this.extintor.Ultima_prueba_hidrostatica);
                }
                catch (Exception exception)
                {
                    this.extintor.Ultima_prueba_hidrostatica = formatearFecha(DateTime.Now);
                }
            }

            System.Console.WriteLine(this.extintor.Proxima_prueba_hidrostatica);
            System.Console.WriteLine(this.extintor.Proximo_mantenimiento);
            System.Console.WriteLine(this.extintor.Ultima_prueba_hidrostatica);


            Boolean verificadorDeActualizar = ec.ActualizarExtintor(this.extintor);
            if (verificadorDeActualizar)
            {
                StartActivity(typeof(menuPrincipal));
            }
            else
            {
                Toast.MakeText(this, "Error a la hora de actualizar el extintor", ToastLength.Short).Show();
                StartActivity(typeof(menuPrincipal));
            }

    }

        private void llenarFormulario()
        {
            
            poblarDate();
            poblarSpinners();
            
        }

        private void poblarDate()
        {
            dateProximaHidrostatica = (Button)FindViewById<Button>(Resource.Id.dateProximaHidrostatica);
            dateProximaHidrostatica.Click += delegate {
                OnClickProximoHidro();
             };
            dateUltimaHidrostatica = (Button)FindViewById<Button>(Resource.Id.dateUltimaHidrostatica);
            dateUltimaHidrostatica.Click += delegate {
                OnClickUltimaHidro();
            };
            dateProximoMantenimiento = (Button)FindViewById<Button>(Resource.Id.dateProximoMantenimiento);
            dateProximoMantenimiento.Click += delegate {
                OnClickProximoMantenimiento();
            };

        }

        private void OnClickProximoHidro()
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                String fecha = formatearFecha(time);
                this.extintor.Proxima_prueba_hidrostatica = fecha;
                dateProximaHidrostatica.Text = fecha;
                System.Console.WriteLine(this.extintor.Proxima_prueba_hidrostatica);
            });
            this.proximaHidroClick = true;
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        private void OnClickUltimaHidro()
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                String fecha = formatearFecha(time);
                this.extintor.Ultima_prueba_hidrostatica = fecha;
                dateUltimaHidrostatica.Text = fecha;
                System.Console.WriteLine(this.extintor.Ultima_prueba_hidrostatica);
            });
            this.ultimoHidroClick = true;
            frag.Show(FragmentManager, DatePickerFragment.TAG);
            
        }

        private void OnClickProximoMantenimiento()
        {
            DatePickerFragment frag = DatePickerFragment.NewInstance(delegate (DateTime time)
            {
                String fecha = formatearFecha(time);
                this.extintor.Proximo_mantenimiento = fecha;
                dateProximoMantenimiento.Text = fecha;
                System.Console.WriteLine(this.extintor.Proximo_mantenimiento);
            });
            this.proximoManteClick = true;
            frag.Show(FragmentManager, DatePickerFragment.TAG);
        }

        public void poblarSpinners()
        {
          
            TextView activo = FindViewById<TextView>(Resource.Id.activoText);
            activo.Text = "Activo: " + extintor.Id;

            dateProximaHidrostatica.Text = formatearFecha(extintor.Proxima_prueba_hidrostatica);
            dateUltimaHidrostatica.Text = formatearFecha(extintor.Ultima_prueba_hidrostatica);
            dateProximoMantenimiento.Text = formatearFecha(extintor.Proximo_mantenimiento);

            EditText ubicacionText = FindViewById<EditText>(Resource.Id.ubicacionText);
            ubicacionText.SetText(extintor.Ubicacion.ToCharArray(), 0, extintor.Ubicacion.Length);

            Spinner tipoSpinner = FindViewById<Spinner>(Resource.Id.tipoSpinner);
            Spinner agenteSpinner = FindViewById<Spinner>(Resource.Id.spinnerAgente);
            Spinner capacidadSpinner = FindViewById<Spinner>(Resource.Id.spinnerCapacidad);
            Spinner presionSpinner = FindViewById<Spinner>(Resource.Id.spinnerPresion);
            Spinner rotulacionSpinner = FindViewById<Spinner>(Resource.Id.spinnerRotulacion);
            Spinner accesoSpinner = FindViewById<Spinner>(Resource.Id.spinnerAcceso);
            Spinner condicionSpinner = FindViewById<Spinner>(Resource.Id.spinnerCondicion);
            Spinner seguroSpinner = FindViewById<Spinner>(Resource.Id.spinnerSeguro);
            Spinner collarinSpinner = FindViewById<Spinner>(Resource.Id.spinnerCollarin);
            Spinner mangueraSpinner = FindViewById<Spinner>(Resource.Id.spinnerManguera);
            Spinner boquillaSpinner = FindViewById<Spinner>(Resource.Id.spinnerBoquilla);

            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.TipoExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            tipoSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.AgenteExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            agenteSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                     this, Resource.Array.CapacidadExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            capacidadSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.PresionExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            presionSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.RotulaciónExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            rotulacionSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.AccesoExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            accesoSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.CondicionExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            condicionSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.SeguroExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            seguroSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.CollarinExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            collarinSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.MangueraExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mangueraSpinner.Adapter = adapter;

            adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.BoquillaExtintor, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            boquillaSpinner.Adapter = adapter;
        }

        public String formatearFecha(Object time)
        {
            string fecha_modificada = "";
            try
            {
                string[] fecha = time.ToString().Split(" ");
                string[] modificar_formato = fecha[0].Split("/");
                fecha_modificada = modificar_formato[2] + "-" + modificar_formato[0] + "-" + modificar_formato[1];
            }catch(Exception exception)
            {
                fecha_modificada = "Sin fecha";
            }
            
            return fecha_modificada;
        }

    }
}