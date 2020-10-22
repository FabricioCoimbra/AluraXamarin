using App1.Model;
using App1.Service;
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
        private string msgErroLogin;
        public string MsgErroLogin
        {
            get { return msgErroLogin; }
            set
            {
                msgErroLogin = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TemErro));
            }
        }
        public bool TemErro
        {
            get { return !string.IsNullOrEmpty(msgErroLogin); }
        }

        private bool aguarde;
        public bool Aguarde
        {
            get => aguarde;
            set
            {
                aguarde = value;
                OnPropertyChanged();
            }
        }
        public ICommand EntrarComand { get; private set; }
        public LoginViewModel()
        {
            MsgErroLogin = string.Empty;
            Aguarde = false;
            EntrarComand = new Command(async () =>
            {
                Aguarde = true;
                try
                {
                    await new LoginService().FazerLogin(new Login(Usuario, Senha));
                }
                finally
                {
                    Aguarde = false;
                }
            },
            () =>
            {
                return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Senha);
            });
        }
    }
}
