using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamarinFormsMSExtensions.ViewModels;

namespace XamarinFormsMSExtensions
{
    public partial class MainPage : ContentPage
    {
        public MainPage(IMainViewModel viewModel = null)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((MainViewModel)BindingContext).Carregar();
        }
    }
}
