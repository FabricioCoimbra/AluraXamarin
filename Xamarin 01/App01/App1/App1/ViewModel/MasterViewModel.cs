using App1.Model;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class MasterViewModel : BaseViewModel
    {
        public string Nome
        {
            get => Usuario.Nome; set
            {
                Usuario.Nome = value;
                OnPropertyChanged();
            }
        }
        public string DataNascimento
        {
            get => Usuario.DataNascimento; set
            {
                Usuario.DataNascimento = value;
                OnPropertyChanged();
            }
        }
        public string Telefone
        {
            get => Usuario.Telefone; set
            {
                Usuario.Telefone = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => Usuario.Email; set
            {
                Usuario.Email = value;
                OnPropertyChanged();
            }
        }

        public Usuario Usuario { get; set; }
        public MasterViewModel(Usuario usuario)
        {
            Usuario = usuario;
            EditarPerfilCOmmand = new Command(() => {
                MessagingCenter.Send<Usuario>(Usuario, "EditarPerfil");
            });
        }

        public ICommand EditarPerfilCOmmand { get; private set; }

    }
}
