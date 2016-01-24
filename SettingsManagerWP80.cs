using System;
using System.IO.IsolatedStorage;


    // It is simple manager to save info in IsolatedStorage
    // Can be used in WP 8.0 projects, for example. But for 8.1 I will rework it for using new stuff.
    // I use it for the our WinGym project. 
    public static class SettingsManager
    {
        readonly static IsolatedStorageSettings _settings = IsolatedStorageSettings.ApplicationSettings;

        public static T GetSettings<T>(string propertie)
        {
            T temp = default(T);
            if (_settings.Contains(propertie))
            {
                temp = (T)_settings[propertie];
            }
            else
            {
                _settings.Add(propertie, default(T));
                _settings.Save();
            }
            return temp;
        }

        public static T GetSettings<T>(string propertie, T defaultvalue)
        {
            T temp = defaultvalue;
            if (_settings.Contains(propertie))
            {
                temp = (T)_settings[propertie];
            }
            else
            {
                _settings.Add(propertie, defaultvalue);
                _settings.Save();
            }
            return temp;
        }

        public static void SaveSettings<T>(string propertie, T value)
        {
            try
            {
                _settings[propertie] = value;
                _settings.Save();
            }
            catch (Exception e)
            {
                
            }

        }
    }
