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
        private bool isCircleMove = false;


		public GamePage ()
		{
			InitializeComponent ();
            LabelMove.Text = "Ruch: X";
		}

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            gameGrid.HeightRequest = width;
        }

        private void FieldSelectionClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (isCircleMove)
            {
                btn.Text = "O";
                LabelMove.Text = "Ruch: X";
            }
            else
            {
                btn.Text = "X";
                LabelMove.Text = "Ruch: O";
            }
            isCircleMove = !isCircleMove;
            btn.IsEnabled = false;
        }

        private List<Button> GetButtons()
        {
            var grid = this.Content as Grid;
            var btnList = grid.Children.Where(b => b is Button).Cast<Button>().ToList();
            btnList.RemoveAt(9);
            return btnList;
        }

        private bool IsWinner(List<Button> btnList)
        {
            bool rowCheck = CheckButtons(btnList, 0, 1, 2) || CheckButtons(btnList, 3, 4, 5) || CheckButtons(btnList, 7, 8, 9);
            bool columnCheck = CheckButtons(btnList, 0, 3, 6) || CheckButtons(btnList, 1, 4, 7) || CheckButtons(btnList, 2, 5, 8);
            bool diagonalCheck = CheckButtons(btnList, 0, 4, 8) || CheckButtons(btnList, 2, 4, 6);

            return rowCheck || columnCheck || diagonalCheck;
        }

        private bool CheckButtons(List<Button> btnList, int a, int b, int c)
        {
            return (btnList[a].Text != "") && (btnList[a].Text == btnList[b].Text) && (btnList[b].Text == btnList[c].Text);
        }
    }
}