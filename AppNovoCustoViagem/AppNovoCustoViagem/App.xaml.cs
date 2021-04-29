using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using System.Collections.Generic;
using AppNovoCustoViagem.Model;
using System.Globalization;

namespace AppNovoCustoViagem
{
    public partial class App : Application
    {
        public List<Pedagio> ListaPedagios = new List<Pedagio>();

        public App()
        {
            InitializeComponent();

            CultureInfo.CurrentCulture = new CultureInfo("pt-BR");

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
