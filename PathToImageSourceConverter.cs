#region

using System;
using System.Globalization;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Data;
using System.Windows.Media.Imaging;

#endregion

// With that you can use string path for controls that needed imagesource

public class PathToImageSourceConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        string path = value as string;
        if (String.IsNullOrEmpty(path))
            return null;

        BitmapImage bitmap;
        if (path.StartsWith("isostore:"))
        {
            using (var storage = IsolatedStorageFile.GetUserStoreForApplication())
            {
                using (var sourceFile = storage.OpenFile(path.Substring(9), FileMode.Open, FileAccess.Read))
                {
                    bitmap = new BitmapImage();
                    bitmap.SetSource(sourceFile);
                    return bitmap;
                }
            }
            
        }
        
        bitmap = new BitmapImage(new Uri(path, UriKind.Relative));
        return bitmap;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
