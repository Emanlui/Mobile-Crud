using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Registro_y_control_de_extintores_Movil.Models
{
    class Conexion
    {
        public MySqlConnection con;

        public Conexion()
        {
            string host = "sql5.freemysqlhosting.net";
            string db = "sql5387073";
            string user = "sql5387073";
            string conexion_a_la_base = "server=" + host + ";userid=" + user + ";password=1ppt4rpjYR;database=" + db;

            con = new MySqlConnection(conexion_a_la_base);

        }
    }
    
}