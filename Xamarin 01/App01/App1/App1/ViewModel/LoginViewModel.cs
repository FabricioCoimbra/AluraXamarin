using App1.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
            }
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
            msgErroLogin = string.Empty;
            Aguarde = false;
            EntrarComand = new Command(async () =>
            {
                Aguarde = true;
                using (var client = new HttpClient())
                {
                    var campos = new FormUrlEncodedContent(new[]
                            {
                                new KeyValuePair<string, string>("email", Usuario),
                                new KeyValuePair<string, string>("senha", Senha)
                            }
                        );
                    client.BaseAddress = new Uri("https://aluracar.herokuapp.com");
                    var response = await client.PostAsync("/login", campos);
                    if (response.IsSuccessStatusCode)
                        MessagingCenter.Send<Usuario>(new Usuario(), "LoginSucesso");
                    else
                        MsgErroLogin = await response.Content.ReadAsStringAsync();
                }
                Aguarde = false;
            },
            () =>
            {
                return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Senha);
            });
        }
    }
}
