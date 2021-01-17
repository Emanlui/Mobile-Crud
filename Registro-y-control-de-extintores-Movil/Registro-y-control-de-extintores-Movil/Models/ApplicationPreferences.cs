using System;
using Android.Content;
using Android.Preferences;
namespace Registro_y_control_de_extintores_Movil.Models
{
    public class AppPreferences
    {
        private ISharedPreferences nameSharedPrefs;
        private ISharedPreferencesEditor namePrefsEditor; //Declare Context,Prefrences name and Editor name
        private Context mContext;
        private static String CORREO_ACCESS_KEY = "correo"; //Value Access Key Name
        private static String PASS_ACCESS_KEY = "pass"; //Value Access Key Name
        public AppPreferences(Context context)
        {
            this.mContext = context;
            nameSharedPrefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            namePrefsEditor = nameSharedPrefs.Edit();
        }
        public void guardarCorreoPass(string correo, string pass) 
        {
            namePrefsEditor.PutString(CORREO_ACCESS_KEY, correo);
            namePrefsEditor.PutString(PASS_ACCESS_KEY, pass);
            namePrefsEditor.Commit();
        }
        public string getCorreoKey() 
        {
            return nameSharedPrefs.GetString(CORREO_ACCESS_KEY, "");
        }
        public string getPassKey()
        {
            return nameSharedPrefs.GetString(PASS_ACCESS_KEY, "");
        }
    }
}