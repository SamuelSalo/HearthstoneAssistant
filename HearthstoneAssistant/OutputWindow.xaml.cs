using System;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Web;
using System.Windows.Media.Imaging;
using System.Drawing;
using System.Net;
using System.Windows.Interop;

namespace HearthstoneAssistant
{
    /// <summary>
    /// Interaction logic for OutputWindow.xaml
    /// </summary>
    public partial class OutputWindow : Window
    {
        private CardInfo cardInfo;
        protected const string apiurl = "http://wow.zamimg.com/images/hearthstone/cards/enus/original/";
        public OutputWindow(CardInfo cardInput)
        {
            InitializeComponent();
            cardInfo = cardInput;
            Title = cardInfo.name;
            IDLabel.Content = "ID: "+ cardInfo.cardId;
            nameLabel.Content = cardInfo.name;
        }
    }
}