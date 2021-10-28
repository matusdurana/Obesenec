using Obesenec.Model;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Obesenec
{
    public partial class App
    {
        public App()

        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
