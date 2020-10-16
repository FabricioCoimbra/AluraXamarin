using App1.Model;
using App1.ViewModel;
using Xamarin.Forms;

namespace App1.View
{
    public partial class ListagemView : ContentPage
    {
        public ListagemView()
        {
            InitializeComponent();

            BindingContext = new ListagemViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<Veiculo>(this, "VeiculoSelecionado", (msg) => Navigation.PushAsync(new DetalheView(msg)));
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<Veiculo>(this, "VeiculoSelecionado");
        }
    }
}
