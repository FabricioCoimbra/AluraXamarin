using App1.Model;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                OnPropertyChanged();
                ((Command)EntrarComand).ChangeCanExecute();
            }
        }
        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                OnPropertyChanged();
                ((Command)EntrarComand).ChangeCanExecute();
            }
        }

        public ICommand EntrarComand { get; private set; }
        public LoginViewModel()
        {
            EntrarComand = new Command(() =>
            {
                MessagingCenter.Send<Usuario>(new Usuario(), "LoginSucesso");
            },
            () =>
            {
                return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Senha);
            });
        }
    }
}
