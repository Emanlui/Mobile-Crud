using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
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
            mail.Body = textBody.Text;

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
                Dialog popupDialog = new Dialog(this);
                popupDialog.SetContentView(Resource.Layout.MensajeDeError);
                popupDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
                popupDialog.Window.SetTitle("Error a la hora de enviar un correo");
                popupDialog.Show();
                popupDialog.Window.SetLayout(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                popupDialog.Window.SetBackgroundDrawableResource(Android.Resource.Color.Transparent);
                StartActivity(typeof(menuPrincipal));
            }

            textAsunto.Text = "";
            textBody.Text = "";
            StartActivity(typeof(menuPrincipal)); 

        }
    }
}