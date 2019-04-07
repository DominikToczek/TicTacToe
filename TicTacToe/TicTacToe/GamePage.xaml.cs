using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GamePage : ContentPage
	{
        private string currentSymbol = Cross;
        const string Circle = "O";
        const string Cross = "X";
        const string Empty = "";


		public GamePage ()
		{
			InitializeComponent ();
            LabelMove.Text = $"Ruch: {Cross}";
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            gameGrid.HeightRequest = width;
        }

        private async void FieldSelectionClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            
            btn.Text = currentSymbol;
            btn.IsEnabled = false;
            
            if (IsWinner(GetButtons()))
            {
                await DisplayAlert("Wygrana", $"Wygrywa: {currentSymbol}", "OK");
                ClearFields(GetButtons());
            }
            else
            {
                if (!AreEmptyFields(GetButtons()))
                {
                    await DisplayAlert("Remis", "Gra zakończyła się remisem.", "OK");
                    ClearFields(GetButtons());
                }
            }

            currentSymbol = currentSymbol == Circle ? Cross : Circle;
            LabelMove.Text = $"Ruch: {currentSymbol}";
        }

        private List<Button> GetButtons()
        {
            return new List<Button> { btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9 };
        }

        private bool IsWinner(List<Button> btnList)
        {
            bool rowCheck = CheckButtons(btnList, 0, 1, 2) || CheckButtons(btnList, 3, 4, 5) || CheckButtons(btnList, 7, 8, 9);
            bool columnCheck = CheckButtons(btnList, 0, 3, 6) || CheckButtons(btnList, 1, 4, 7) || CheckButtons(btnList, 2, 5, 8);
            bool diagonalCheck = CheckButtons(btnList, 0, 4, 8) || CheckButtons(btnList, 2, 4, 6);

            return rowCheck || columnCheck || diagonalCheck;
        }

        private bool AreEmptyFields(List<Button> btnList)
        {
            return btnList.Any(f => f.Text == Empty);
        }

        private bool CheckButtons(List<Button> btnList, int a, int b, int c)
        {
            return (btnList[a].Text != Empty) && (btnList[a].Text == btnList[b].Text) && (btnList[b].Text == btnList[c].Text);
        }

        private void ClearFields(List<Button> btnList)
        {
            foreach (Button btn in btnList)
            {
                btn.Text = Empty;
                btn.IsEnabled = true;
            }
        }
    }
}