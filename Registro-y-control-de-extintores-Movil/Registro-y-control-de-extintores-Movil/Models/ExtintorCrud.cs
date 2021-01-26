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

        UsuarioCrud uc = new UsuarioCrud();

        public byte[] obtenerByteArray(Bitmap bm)
        {
            System.IO.MemoryStream bs = new System.IO.MemoryStream();
            bm.Compress(Bitmap.CompressFormat.Jpeg, 100, bs);
            return bs.ToArray();
        } 
        internal void EliminarImagen(string activo)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE extintor SET imagen = null WHERE activo=@activo; ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;

                cmd.Parameters.Add("@activo", MySqlDbType.VarChar).Value = activo;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
        }

        internal List<Extintor> ObtenerRegistros()
        {

            List<Extintor> lista_de_extintores = new List<Extintor>();
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Context mContext = Android.App.Application.Context;
                AppPreferences ap = new AppPreferences(mContext);


                if (uc.verificacionAdmin(ap.getCorreoKey()))
                {
                    cmd.CommandText = "Select * from extintor where extintor.habilitado=1";
                }
                else
                {
                    cmd.CommandText = "Select * from extintor,usuario,centro_de_trabajo WHERE usuario.id_centro=centro_de_trabajo.id and centro_de_trabajo.id = extintor.id_centro and correo=@correo and extintor.habilitado=1;";
                }

                
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@correo", MySqlDbType.Text).Value = ap.getCorreoKey();
                MySqlDataReader registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Extintor e = new Extintor();
                    e.Id = (int)registros["id"];
                    e.Activo = registros["activo"].ToString();
                    e.Tipo = registros["tipo"].ToString();
                    e.Ubicacion_geografica = registros["ubicacion_geografica"].ToString();
                    e.Ubicacion = registros["ubicacion"].ToString();
                    e.Agente_extintor = registros["agente_extintor"].ToString();
                    e.Capacidad = (int)registros["capacidad"]; 
                    
                    try { 
                        e.Ultima_prueba_hidrostatica = registros["ultima_prueba_hidrostatica"].ToString();
                    }catch(System.InvalidCastException exception)
                    {
                        e.Ultima_prueba_hidrostatica = "Sin fecha";
                    }

                    try
                    {
                        e.Proxima_prueba_hidrostatica = registros["proxima_prueba_hidrostatica"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Proxima_prueba_hidrostatica = "Sin fecha";
                    }

                    try
                    {
                        e.Proximo_mantenimiento = registros["proximo_mantenimiento"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Proximo_mantenimiento = "Sin fecha";
                    }
                    
                    e.Presion = (int)(ulong)registros["presion"];
                    e.Rotulacion = (int)registros["rotulacion"];
                    e.Acceso_a_extintor = (int)(ulong)registros["acceso_a_extintor"];
                    e.Condicion_extintor = (int)(ulong)registros["condicion_extintor"];
                    e.Seguro_y_marchamo = (int)(ulong)registros["seguro_y_marchamo"];
                    e.Collarin = (int)(ulong)registros["collarin"];
                    e.Condicion_manguera = (int)(ulong)registros["condicion_manguera"];
                    e.Condicion_boquilla = (int)(ulong)registros["condicion_boquilla"];
                    try { 
                        e.Imagen = (byte[])registros["imagen"];
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Imagen = null;
                    }
                    System.Console.WriteLine(e.ToString());
                    lista_de_extintores.Add(e);
                }

                conexion.con.Close();
            }

            return lista_de_extintores;
        }

        internal void ModificarFotoExtintor(Bitmap bitmap, string activo)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();

            Byte[] arreglo_imagen = obtenerByteArray(bitmap);

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE extintor SET imagen = @imagen_a_insertar WHERE activo = @activo;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@imagen_a_insertar", MySqlDbType.Blob).Value = arreglo_imagen;
                cmd.Parameters.Add("@activo", MySqlDbType.Text).Value = activo;

                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }

        }

        internal List<Extintor> ObtenerRegistroPorActivo(string text)
        {
            List<Extintor> lista_de_extintores = new List<Extintor>();
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Context mContext = Android.App.Application.Context;
                AppPreferences ap = new AppPreferences(mContext);


                if (uc.verificacionAdmin(ap.getCorreoKey()))
                {
                    cmd.CommandText = "SELECT * FROM extintor WHERE extintor.activo = @activo and extintor.habilitado=1;";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM extintor,usuario,centro_de_trabajo WHERE extintor.activo = @activo and usuario.id_centro=centro_de_trabajo.id and centro_de_trabajo.id = extintor.id_centro and correo=@correo and extintor.habilitado=1;";
                    cmd.Parameters.Add("@correo", MySqlDbType.Text).Value = ap.getCorreoKey();
                }
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@activo", MySqlDbType.Text).Value = text;
                MySqlDataReader registros = cmd.ExecuteReader();
                while (registros.Read())
                {
                    Extintor e = new Extintor();
                    e.Id = (int)registros["id"];
                    e.Activo = registros["activo"].ToString();
                    e.Tipo = registros["tipo"].ToString();
                    e.Ubicacion_geografica = registros["ubicacion_geografica"].ToString();
                    e.Ubicacion = registros["ubicacion"].ToString();
                    e.Agente_extintor = registros["agente_extintor"].ToString();
                    e.Capacidad = (int)registros["capacidad"];
                    try
                    {
                        e.Ultima_prueba_hidrostatica = registros["ultima_prueba_hidrostatica"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Ultima_prueba_hidrostatica = "Sin fecha";
                    }

                    try
                    {
                        e.Proxima_prueba_hidrostatica = registros["proxima_prueba_hidrostatica"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Proxima_prueba_hidrostatica = "Sin fecha";
                    }

                    try
                    {
                        e.Proximo_mantenimiento = registros["proximo_mantenimiento"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Proximo_mantenimiento = "Sin fecha";
                    }
                    e.Presion = (int)(ulong)registros["presion"];
                    e.Rotulacion = (int)registros["rotulacion"];
                    e.Acceso_a_extintor = (int)(ulong)registros["acceso_a_extintor"];
                    e.Condicion_extintor = (int)(ulong)registros["condicion_extintor"];
                    e.Seguro_y_marchamo = (int)(ulong)registros["seguro_y_marchamo"];
                    e.Collarin = (int)(ulong)registros["collarin"];
                    e.Condicion_manguera = (int)(ulong)registros["condicion_manguera"];
                    e.Condicion_boquilla = (int)(ulong)registros["condicion_boquilla"];
                    try
                    {
                        e.Imagen = (byte[])registros["imagen"];
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Imagen = null;
                    }
                    
                    lista_de_extintores.Add(e);
                }

                conexion.con.Close();
            }

            return lista_de_extintores;
        }

        internal Boolean ActualizarExtintor(Extintor extintor)
        {
            Conexion conexion = new Conexion();

            try { 
                conexion.con.Open();


                using (MySqlCommand cmd = new MySqlCommand())
                {
                    cmd.CommandText = "UPDATE extintor SET tipo=@tipo,ubicacion_geografica=@ubicacion_geografica," +
                        "ubicacion=@ubicacion, agente_extintor=@agente_extintor, capacidad=@capacidad," +
                        "ultima_prueba_hidrostatica=@ultima_prueba_hidrostatica, proxima_prueba_hidrostatica=@proxima_prueba_hidrostatica," +
                        "proximo_mantenimiento=@proximo_mantenimiento, presion = @presion, rotulacion = @rotulacion," +
                        "acceso_a_extintor=@acceso_a_extintor, condicion_extintor=@condicion_extintor, seguro_y_marchamo=@seguro_y_marchamo," +
                        "collarin=@collarin, condicion_manguera=@condicion_manguera, condicion_boquilla=@condicion_boquilla WHERE id = @id;";
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = conexion.con;
                    cmd.Parameters.Add("@tipo", MySqlDbType.Text).Value = extintor.Tipo;
                    cmd.Parameters.Add("@ubicacion_geografica", MySqlDbType.Text).Value = extintor.Ubicacion_geografica;
                    cmd.Parameters.Add("@ubicacion", MySqlDbType.Text).Value = extintor.Ubicacion;
                    cmd.Parameters.Add("@agente_extintor", MySqlDbType.Text).Value = extintor.Agente_extintor;
                    cmd.Parameters.Add("@capacidad", MySqlDbType.Int32).Value = extintor.Capacidad;
                    cmd.Parameters.Add("@ultima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Ultima_prueba_hidrostatica;
                    cmd.Parameters.Add("@proxima_prueba_hidrostatica", MySqlDbType.Date).Value = extintor.Proxima_prueba_hidrostatica;
                    cmd.Parameters.Add("@proximo_mantenimiento", MySqlDbType.Date).Value = extintor.Proximo_mantenimiento;
                    cmd.Parameters.Add("@presion", MySqlDbType.Int32).Value = extintor.Presion;
                    cmd.Parameters.Add("@rotulacion", MySqlDbType.Int32).Value = extintor.Rotulacion;
                    cmd.Parameters.Add("@acceso_a_extintor", MySqlDbType.Int32).Value = extintor.Acceso_a_extintor;
                    cmd.Parameters.Add("@condicion_extintor", MySqlDbType.Int32).Value = extintor.Condicion_extintor;
                    cmd.Parameters.Add("@seguro_y_marchamo", MySqlDbType.Int32).Value = extintor.Seguro_y_marchamo;
                    cmd.Parameters.Add("@collarin", MySqlDbType.Int32).Value = extintor.Collarin;
                    cmd.Parameters.Add("@condicion_manguera", MySqlDbType.Int32).Value = extintor.Condicion_manguera;
                    cmd.Parameters.Add("@condicion_boquilla", MySqlDbType.Int32).Value = extintor.Condicion_boquilla;
                    cmd.Parameters.Add("@id", MySqlDbType.Int32).Value = extintor.Id;

                    System.Console.WriteLine(extintor.Proxima_prueba_hidrostatica);
                    System.Console.WriteLine(extintor.Ultima_prueba_hidrostatica);
                    System.Console.WriteLine(extintor.Proximo_mantenimiento);
                    

                cmd.ExecuteNonQuery();
                    conexion.con.Close();
                }
                return true;
            }catch(Exception exception)
            {
                return false;
            }
        }

        internal Extintor ObtenerRegistroPorID(string id)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            Extintor e = new Extintor();
            using (MySqlCommand cmd = new MySqlCommand())
            {
                Context mContext = Android.App.Application.Context;
                AppPreferences ap = new AppPreferences(mContext);

                cmd.CommandText = "SELECT * FROM extintor WHERE extintor.id = @id and extintor.habilitado=1";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@id", MySqlDbType.Text).Value = id;
                MySqlDataReader registros = cmd.ExecuteReader();
                
                if (registros.Read())
                {
                    
                    e.Id = (int)registros["id"];
                    e.Activo = registros["activo"].ToString();
                    e.Tipo = registros["tipo"].ToString();
                    e.Ubicacion_geografica = registros["ubicacion_geografica"].ToString();
                    e.Ubicacion = registros["ubicacion"].ToString();
                    e.Agente_extintor = registros["agente_extintor"].ToString();
                    e.Capacidad = (int)registros["capacidad"];
                    try
                    {
                        e.Ultima_prueba_hidrostatica = registros["ultima_prueba_hidrostatica"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Ultima_prueba_hidrostatica = "Sin fecha";
                    }

                    try
                    {
                        e.Proxima_prueba_hidrostatica = registros["proxima_prueba_hidrostatica"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Proxima_prueba_hidrostatica = "Sin fecha";
                    }

                    try
                    {
                        e.Proximo_mantenimiento = registros["proximo_mantenimiento"].ToString();
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Proximo_mantenimiento = "Sin fecha";
                    }
                    e.Presion = (int)(ulong)registros["presion"];
                    e.Rotulacion = (int)registros["rotulacion"];
                    e.Acceso_a_extintor = (int)(ulong)registros["acceso_a_extintor"];
                    e.Condicion_extintor = (int)(ulong)registros["condicion_extintor"];
                    e.Seguro_y_marchamo = (int)(ulong)registros["seguro_y_marchamo"];
                    e.Collarin = (int)(ulong)registros["collarin"];
                    e.Condicion_manguera = (int)(ulong)registros["condicion_manguera"];
                    e.Condicion_boquilla = (int)(ulong)registros["condicion_boquilla"];
                    try
                    {
                        e.Imagen = (byte[])registros["imagen"];
                    }
                    catch (System.InvalidCastException exception)
                    {
                        e.Imagen = null;
                    }

                }

                conexion.con.Close();
            }

            return e;
        }
    }
}