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
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.actualizarForm);
            extintor_id = base.Intent.GetIntExtra("extintor",0);
            System.Console.WriteLine(extintor_id);
            ExtintorCrud ec = new ExtintorCrud();
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
            this.extintor.Ubicacion_geografica = ubicacionText.Text;

            EditText ubicacionGeoText = FindViewById<EditText>(Resource.Id.ubicacionGeoText);
            this.extintor.Ubicacion = ubicacionGeoText.Text;

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

            DatePicker dateUltimaPruebaHidro = FindViewById<DatePicker>(Resource.Id.dateUltimaHidrostatica);
            this.extintor.Ultima_prueba_hidrostatica = dateUltimaPruebaHidro.DateTime.ToString();

            DatePicker dateProximaPruebaHidro = FindViewById<DatePicker>(Resource.Id.dateProximaHidrostatica);
            this.extintor.Proxima_prueba_hidrostatica = dateProximaPruebaHidro.DateTime.ToString();

            DatePicker dateProximoMantenimiento = FindViewById<DatePicker>(Resource.Id.dateProximoMantenimiento);
            this.extintor.Proximo_mantenimiento = dateProximoMantenimiento.DateTime.ToString();

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

    }

        private void llenarFormulario()
        {
            
            poblarDate();
            poblarSpinners();
            
        }

        private void poblarDate()
        {
            DatePicker datePicker1 = (DatePicker)FindViewById<DatePicker>(Resource.Id.dateProximaHidrostatica);
            datePicker1.UpdateDate(2016, 5, 22);
            DatePicker datePicker2 = (DatePicker)FindViewById<DatePicker>(Resource.Id.dateUltimaHidrostatica);
            datePicker2.UpdateDate(2016, 5, 22);
            DatePicker datePicker3 = (DatePicker)FindViewById<DatePicker>(Resource.Id.dateProximoMantenimiento);
            datePicker3.UpdateDate(2016, 5, 22);
        }

        public void poblarSpinners()
        {
            System.Console.WriteLine(extintor.Ubicacion);
            System.Console.WriteLine(extintor.Ubicacion_geografica);
            EditText ubicacionText = FindViewById<EditText>(Resource.Id.ubicacionText);
            ubicacionText.SetText(extintor.Ubicacion.ToCharArray(), 0, extintor.Ubicacion.Length);

            EditText ubicacionGeoText = FindViewById<EditText>(Resource.Id.ubicacionGeoText);
            ubicacionGeoText.SetText(extintor.Ubicacion_geografica.ToCharArray(),0, extintor.Ubicacion_geografica.Length);

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
    }
}