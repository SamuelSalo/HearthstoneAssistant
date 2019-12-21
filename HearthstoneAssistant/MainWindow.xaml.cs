using System.Windows;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json;

namespace HearthstoneAssistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        protected string json = string.Empty;
        protected const string apiurl = "https://omgvamp-hearthstone-v1.p.rapidapi.com/cards/";
        protected const string apikey = "831129d93cmsh608e397103ead70p1dd02bjsnf164767338db";
        protected const string apihost = "omgvamp-hearthstone-v1.p.rapidapi.com";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            string cardname = System.Uri.EscapeUriString(SearchBox.Text);
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(apiurl + cardname);

            request.Method = WebRequestMethods.Http.Get;

            request.Headers["x-rapidapi-host"] = apihost;
            request.Headers["x-rapidapi-key"] = apikey;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                json = reader.ReadToEnd();
            }

            File.WriteAllText("output.json", json);
            CardInfo cardInfo = JsonConvert.DeserializeObject<CardInfo>(json.Substring(1, json.Length - 2));
            OutputWindow outputWindow = new OutputWindow(cardInfo);
            outputWindow.Show();
            this.Close();
        }
    }
}