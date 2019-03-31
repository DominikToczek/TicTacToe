using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
  
        private async void PlayButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new GamePage());
        }
        private void RulesButtonClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        private void ExitButtonClick(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
        }
    }
}
