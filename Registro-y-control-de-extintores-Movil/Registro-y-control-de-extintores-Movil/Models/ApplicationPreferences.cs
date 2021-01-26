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
        private static String LOGIN_ACCESS_KEY = "false";
        private static String CORREO_ACCESS_KEY = "correo"; //Value Access Key Name
        public AppPreferences(Context context)
        {
            this.mContext = context;
            nameSharedPrefs = PreferenceManager.GetDefaultSharedPreferences(mContext);
            namePrefsEditor = nameSharedPrefs.Edit();
        }
        public void guardarCorreoPass(string correo, Boolean data) 
        {
            namePrefsEditor.PutString(CORREO_ACCESS_KEY, correo);
            namePrefsEditor.PutBoolean(LOGIN_ACCESS_KEY, data);
            namePrefsEditor.Commit();
        }
        public string getCorreoKey() 
        {
            return nameSharedPrefs.GetString(CORREO_ACCESS_KEY, "");
        }
       
        public Boolean getLogin()
        {
            return nameSharedPrefs.GetBoolean(LOGIN_ACCESS_KEY, false);
        }

        public void setLogin(Boolean data)
        {
            namePrefsEditor.PutBoolean(LOGIN_ACCESS_KEY, data);
            namePrefsEditor.Commit();
        }
    }
}