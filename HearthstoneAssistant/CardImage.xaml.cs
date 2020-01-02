using System;
using System.IO;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HearthstoneAssistant
{
    /// <summary>
    /// Interaction logic for CardImage.xaml
    /// </summary>
    public partial class CardImage : Window
    {
        public CardImage(string Url)
        {
            InitializeComponent();
            byte[] imageData = new byte[0];
            string redirUrl = String.Empty;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);

            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                redirUrl = response.GetResponseHeader("Location");
            }
            catch (WebException e)
            {
                HttpWebResponse response = (HttpWebResponse)e.Response;
                redirUrl = response.GetResponseHeader("Location");
            }

            imageData = new WebClient().DownloadData(redirUrl);


            var bitmapImage = new BitmapImage { CacheOption = BitmapCacheOption.OnLoad };
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(imageData);
            bitmapImage.EndInit();

            ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapImage;

            this.Background = imageBrush;
            this.Width = bitmapImage.Width;
            this.Height = bitmapImage.Height;
        }
    }
}