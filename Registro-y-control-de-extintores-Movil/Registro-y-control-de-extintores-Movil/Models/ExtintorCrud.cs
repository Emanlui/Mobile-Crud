using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text; 
using System.Data.SqlClient;
using MySqlConnector;

namespace Registro_y_control_de_extintores_Movil.Models
{
    class ExtintorCrud
    {
        public Extintor extintor { set; get; }

        public byte[] obtenerByteArray(Bitmap bm)
        {
            System.IO.MemoryStream bs = new System.IO.MemoryStream();
            bm.Compress(Bitmap.CompressFormat.Png, 100, bs);
            return bs.ToArray();
        }
        public void Crear_Extintor(Bitmap imagen)
        {
            
            Conexion conexion = new Conexion();
            conexion.con.Open();

            Byte[] arreglo_imagen = obtenerByteArray(imagen);

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE extintor SET imagen = @imagen_a_insertar WHERE id = 1;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con; 
                cmd.Parameters.Add("@imagen_a_insertar", MySqlDbType.Blob).Value = arreglo_imagen;
                
                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
           
        }

        internal List<Extintor> ObtenerGaleria()
        {
            throw new NotImplementedException();
        }

        internal List<Extintor> ObtenerRegistros()
        {

            /**
             * CREATE TABLE extintor (
                id INT AUTO_INCREMENT NOT NULL, 
                id_centro INT,
                tipo VARCHAR(4) NOT NULL,    
                activo VARCHAR(50) NOT NULL, 
                ubicacion_geografica VARCHAR(50), 
                ubicacion VARCHAR(100), 
                agente_extintor VARCHAR(50),
                capacidad INT,
                ultima_prueba_hidrostatica DATE,
                proxima_prueba_hidrostatica DATE,
                proximo_mantenimiento DATE,
                presion BOOLEAN NOT NULL DEFAULT FALSE,
                rotulacion INT,
                acceso_a_extintor BOOLEAN NOT NULL DEFAULT FALSE,
                condicion_extintor BOOLEAN NOT NULL DEFAULT FALSE,
                seguro_y_marchamo BOOLEAN NOT NULL DEFAULT FALSE,
                collarin BOOLEAN NOT NULL DEFAULT FALSE,
                condicion_manguera BOOLEAN NOT NULL DEFAULT FALSE,
                condicion_boquilla BOOLEAN NOT NULL DEFAULT FALSE,
                PRIMARY KEY (id , id_centro), 
                FOREIGN KEY (id_centro)
    	            REFERENCES centro_de_trabajo (id) ON UPDATE RESTRICT)

            */
            List<Extintor> lista_de_extintores = new List<Extintor>();
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                
                cmd.CommandText = "Select * from extintor;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                MySqlDataReader registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Extintor e = new Extintor();
                    e.Activo = registros["activo"].ToString();
                    e.Tipo = registros["tipo"].ToString();
                    e.Ubicacion_geografica = registros["ubicacion_geografica"].ToString();
                    e.Ubicacion = registros["ubicacion"].ToString();
                    e.Agente_extintor = registros["agente_extintor"].ToString();
                    e.Capacidad = (int)registros["capacidad"];
                    e.Ultima_prueba_hidrostatica = registros["ultima_prueba_hidrostatica"].ToString();
                    e.Proxima_prueba_hidrostatica = registros["proxima_prueba_hidrostatica"].ToString();
                    e.Proximo_mantenimiento = registros["proximo_mantenimiento"].ToString();
                    e.Presion = (int)(ulong)registros["presion"];
                    e.Rotulacion = (int)registros["rotulacion"];
                    e.Acceso_a_extintor = (int)(ulong)registros["acceso_a_extintor"];
                    e.Condicion_extintor = (int)(ulong)registros["condicion_extintor"];
                    e.Seguro_y_marchamo = (int)(ulong)registros["seguro_y_marchamo"];
                    e.Collarin = (int)(ulong)registros["collarin"];
                    e.Condicion_manguera = (int)(ulong)registros["condicion_manguera"];
                    e.Condicion_boquilla = (int)(ulong)registros["condicion_boquilla"];
                    System.Console.WriteLine(e.ToString());
                    lista_de_extintores.Add(e);
                }

                conexion.con.Close();
            }

            return lista_de_extintores;
        }

        internal List<Extintor> ObtenerRegistroPorActivo(string text)
        {
            List<Extintor> lista_de_extintores = new List<Extintor>();
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = "SELECT * FROM extintor WHERE activo = @activo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@activo", MySqlDbType.Text).Value = text;
                MySqlDataReader registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Extintor e = new Extintor();
                    e.Activo = registros["activo"].ToString();
                    e.Tipo = registros["tipo"].ToString();
                    e.Ubicacion_geografica = registros["ubicacion_geografica"].ToString();
                    e.Ubicacion = registros["ubicacion"].ToString();
                    e.Agente_extintor = registros["agente_extintor"].ToString();
                    e.Capacidad = (int)registros["capacidad"];
                    e.Ultima_prueba_hidrostatica = registros["ultima_prueba_hidrostatica"].ToString();
                    e.Proxima_prueba_hidrostatica = registros["proxima_prueba_hidrostatica"].ToString();
                    e.Proximo_mantenimiento = registros["proximo_mantenimiento"].ToString();
                    e.Presion = (int)(ulong)registros["presion"];
                    e.Rotulacion = (int)registros["rotulacion"];
                    e.Acceso_a_extintor = (int)(ulong)registros["acceso_a_extintor"];
                    e.Condicion_extintor = (int)(ulong)registros["condicion_extintor"];
                    e.Seguro_y_marchamo = (int)(ulong)registros["seguro_y_marchamo"];
                    e.Collarin = (int)(ulong)registros["collarin"];
                    e.Condicion_manguera = (int)(ulong)registros["condicion_manguera"];
                    e.Condicion_boquilla = (int)(ulong)registros["condicion_boquilla"];
                    System.Console.WriteLine(e.ToString());
                    lista_de_extintores.Add(e);
                }

                conexion.con.Close();
            }

            return lista_de_extintores;
        }
    }
}