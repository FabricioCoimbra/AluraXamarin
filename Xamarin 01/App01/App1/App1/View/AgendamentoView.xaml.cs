using App1.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgendamentoView : ContentPage
    {
        public Veiculo Veiculo { get; set; }
        public AgendamentoView(Veiculo veiculo)
        {
            InitializeComponent();
            Veiculo = veiculo;
            Title = Veiculo.Nome;
        }
    }
}