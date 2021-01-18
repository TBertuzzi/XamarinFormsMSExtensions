using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XamarinFormsMSExtensions
{
   
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = ServiceProvider.GetService<MainPage>();
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
