using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MySqlConnector;
using Registro_y_control_de_extintores_Movil.Activities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Registro_y_control_de_extintores_Movil.Models
{
    class UsuarioCrud
    {
        public void cambiarContraseña(string contrasena, string dato)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
          
            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.CommandText = "UPDATE usuario SET usuario.password = @pass WHERE correo = @correo; ";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@pass", MySqlDbType.Text).Value = contrasena;
                cmd.Parameters.Add("@correo", MySqlDbType.Text).Value = dato;
                cmd.ExecuteNonQuery();
                conexion.con.Close();
            }
        }

        public Boolean verificacionDeUsuario(string correo)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = "SELECT * FROM usuario WHERE correo = @correo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@correo", MySqlDbType.Text).Value = correo;
                MySqlDataReader registros = cmd.ExecuteReader();
                int cont = 0;
                while (registros.Read())
                {
                    System.Console.WriteLine(correo);
                    System.Console.WriteLine(cont);
                    cont = cont + 1;
                }
                conexion.con.Close();
                if (cont > 0) return true;
                return false;
            }
        }

        public Boolean verificacionAdmin(string correo)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            Boolean verificar = false;
            int admin = 0;
            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = "SELECT * FROM usuario WHERE correo = @correo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@correo", MySqlDbType.Text).Value = correo;
                MySqlDataReader registros = cmd.ExecuteReader();
                
                while (registros.Read())
                {
                    admin = (int)registros["administrador"];
                }
                conexion.con.Close();
                if (admin == 1) return true;
                return false;
            }
        }

        internal string getCentroDeTrabajo(string correo)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            string resultado = "";
            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = "SELECT * FROM usuario JOIN centro_de_trabajo ON usuario.id_centro = centro_de_trabajo.id WHERE correo=@correo";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@correo", MySqlDbType.Text).Value = correo;
                MySqlDataReader registros = cmd.ExecuteReader();
                int cont = 0;
                if (registros.Read())
                {
                    resultado = (string)registros["nombre"];
                    cont = cont + 1;
                }
                conexion.con.Close();

                return resultado;
            }
        }

        public Boolean verificacionDeLogin(string correo, string pass)
        {
            Conexion conexion = new Conexion();
            conexion.con.Open();
            using (MySqlCommand cmd = new MySqlCommand())
            {

                cmd.CommandText = "SELECT * FROM usuario WHERE correo = @correo AND password = @pass;";
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.con;
                cmd.Parameters.Add("@correo", MySqlDbType.Text).Value = correo;
                cmd.Parameters.Add("@pass", MySqlDbType.Text).Value = pass;
                MySqlDataReader registros = cmd.ExecuteReader();
                int cont = 0;
                while (registros.Read())
                {
                    System.Console.WriteLine(correo);
                    System.Console.WriteLine(pass);
                    System.Console.WriteLine(cont);
                    cont = cont + 1;
                }
                conexion.con.Close();
                if (cont > 0) return true;
                return false;
            }
        }
    }
}