using App1.Model;
using App1.ViewModel;
using Xamarin.Forms;

namespace App1.View
{
    public partial class ListagemView : ContentPage
    {
        private readonly ListagemViewModel ViewModel;
        public ListagemView()
        {
            InitializeComponent();
            ViewModel = new ListagemViewModel();
            BindingContext = ViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (msg) => Navigation.PushAsync(new DetalheView(msg)));
            ViewModel.CarregarVeiculos();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
