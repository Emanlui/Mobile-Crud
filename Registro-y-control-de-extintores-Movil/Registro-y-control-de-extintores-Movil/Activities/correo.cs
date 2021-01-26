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
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Registro_y_control_de_extintores_Movil.Activities
{
    [Activity(Label = "correo")]
    public class correo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.correo);

            var btnEnviar = FindViewById<Button>(Resource.Id.Enviar);
            btnEnviar.Click += BtnEnviar_Click;

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            // Objetos de la pagina
            var textAsunto = FindViewById<EditText>(Resource.Id.Asunto);
            var textBody = FindViewById<EditText>(Resource.Id.Contenido);
            var enviarBtn = FindViewById<Button>(Resource.Id.Enviar);

            // Parámetros
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("emanuellejs1999@gmail.com");
            mail.To.Add("emanuellejs@hotmail.es");
            mail.Subject = textAsunto.Text;

            Context mContext = Android.App.Application.Context;
            AppPreferences ap = new AppPreferences(mContext);
            String body = "Este correo fue enviado por: " + ap.getCorreoKey() + " \n";
            mail.Body = body + textBody.Text;

            // Archivos
            //System.Net.Mail.Attachment attachment;
            //attachment = new System.Net.Mail.Attachment(filename);
            //mail.Attachments.Add(attachment);
            //end email attachment part

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("emanuellejs1999@gmail.com", "");
            SmtpServer.EnableSsl = true;
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) {
                return true;
            };
            try
            {
                SmtpServer.Send(mail);
            }
            catch(Exception exception)
            {
                Toast.MakeText(this, "Error al enviar el correo electrónico", ToastLength.Short).Show();
                StartActivity(typeof(menuPrincipal));
            }

            textAsunto.Text = "";
            textBody.Text = "";
            StartActivity(typeof(menuPrincipal)); 

        }
    }
}