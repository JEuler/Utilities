using System;
using System.IO.IsolatedStorage;


    // It is simple manager to save info in IsolatedStorage
    // Can be used in WP projects, for example
    // I use it for the our WinGym project. 
   public static class SettingsManager {
		static ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

		public static T GetSettings<T>( string propertie ) {
			T temp = default( T );
			if ( localSettings.Values.ContainsKey( propertie ) )
			{
				temp = (T) localSettings.Values[propertie];
			}
			else {
				localSettings.Values.Add( propertie, default( T ) );
			}
			return temp;
		}

		public static T GetSettings<T>( string propertie, T defaultvalue ) {
			T temp = defaultvalue;
			if ( localSettings.Values.ContainsKey( propertie ) ) {
				temp = ( T ) localSettings.Values[ propertie ];
			}
			else {
				localSettings.Values.Add( propertie, defaultvalue );
			}
			return temp;
		}

		public static void SaveSettings<T>( string propertie, T value ) {
			try {
				localSettings.Values[ propertie ] = value;
			}
			catch ( Exception e ) {

			}

		}
