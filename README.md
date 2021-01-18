# XamarinFormsMSExtensions

Exemplo de Xamarin.Forms com Microsoft Extensions

Vamos ao Nuget Instalar o [Microsoft Extensions](https://docs.microsoft.com/en-us/dotnet/api/?WT.mc_id=DOP-MVP-5003242) em todos os projetos.

Vamos instalar em todos os projetos:

* [Microsoft.Extensions.Hosting](https://www.nuget.org/packages/Microsoft.Extensions.Hosting/)
* [Microsoft.Extensions.Configuration](https://www.nuget.org/packages/Microsoft.Extensions.Configuration/)
* [Microsoft.Extensions.DependencyInjection](Microsoft.Extensions.DependencyInjection/)
* [Microsoft.Extensions.Logging](Microsoft.Extensions.Logging/)

Em Seguida precisamos criar como embedded resource o arquivo [appsettings.json](https://github.com/TBertuzzi/XamarinFormsMSExtensions/blob/master/XamarinFormsMSExtensions/appsettings.json)

Então criamos a classe [Startup.cs](https://github.com/TBertuzzi/XamarinFormsMSExtensions/blob/master/XamarinFormsMSExtensions/Startup.cs) como se estivessemos utilizando uma aplicação asp.net core. o Nome Startup é apenas como sugestão sendo que pode ser utilizado qualquer nome para a classe.
O Conteudo deve simular a configuração de Inicio do Asp.net core, subindo os serviços de injeção de Dependencia , log e etc.

Inclusive graças ao HostingEnvironment podemos utilizar logicas em Desenvolvimento e produção de forma separada.

Devemos Alterar o App.xaml.cs para entender a injeção de Dependencia e chamada da pagina inicial :

```csharp

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
    }
}


```

No Caso das ViewModels podemos utilizar Uma Interface para Cada uma :

```csharp

using System;
namespace XamarinFormsMSExtensions.ViewModels
{
    public interface IMainViewModel
    {
    }
}

```

E Configurado nas Paginas Xaml :

```csharp

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

```

É Possivel injetar serviços igual a utilização do Asp.net core.

Um Exemplo completo da configuração esta disponivel nesse repositorio.

Caso queira um exemplo de utilização Pratica [clique aqui](https://github.com/TBertuzzi/PokeXamarin)
