using System;
using System.Windows;

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

            IDLabel.Content = "ID: " + cardInfo.cardId;
            nameLabel.Content = cardInfo.name;

            if (!String.IsNullOrEmpty(cardInfo.text))
            {
                string tmpText;
                tmpText = cardInfo.text.Replace("<b>", "");
                tmpText = tmpText.Replace("</b>", "");
                tmpText = tmpText.Replace("\\n", Environment.NewLine);
                cardTextBlock.Text = tmpText;
            }
            else
                cardTextBlock.Text = "";

            costLabel.Content = $"Cost: {cardInfo.cost}";
            atkLabel.Content = $"ATK: {cardInfo.attack}";
            hpLabel.Content = $"HP: {cardInfo.health}";
            raceLabel.Content = $"Race: {cardInfo.race}";
            eliteLabel.Content = cardInfo.elite ? "Elite ?: Yes" : "Elite ?: No";
            rarityLabel.Content = $"Rarity: {cardInfo.rarity}";
            factionLabel.Content = $"Faction: {cardInfo.faction}";
            setLabel.Content = $"Card Set: {cardInfo.cardSet}";
        }

        private void ShowCard(object sender, RoutedEventArgs e)
        {
            CardImage cardImage = new CardImage((bool)goldCheckBox.IsChecked ? cardInfo.imgGold : cardInfo.img);
            cardImage.Show();
        }
    }
}