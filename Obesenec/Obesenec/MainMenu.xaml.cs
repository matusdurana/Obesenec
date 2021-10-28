using Obesenec.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Obesenec
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void Doprava_Button_Clicked(object sender, EventArgs e)
        {
            WordSource.Choosen = "doprava";
            Navigation.PushAsync(new MainPage());
        }
        private void Jedlo_Button_Clicked(object sender, EventArgs e)
        {
            WordSource.Choosen = "jedlo";
            Navigation.PushAsync(new MainPage());
        }
        private void Oblecenie_Button_Clicked(object sender, EventArgs e)
        {
            WordSource.Choosen = "oblecenie";
            Navigation.PushAsync(new MainPage());
        }
        private void Mix_Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

    }
}