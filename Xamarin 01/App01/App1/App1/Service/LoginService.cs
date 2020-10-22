using App1.Erro;
using App1.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Service
{
    public class LoginService : BaseService
    {
        public async Task FazerLogin(Login login)
        {
            try
            {
                var campos = new FormUrlEncodedContent(new[]
                            {
                            new KeyValuePair<string, string>("email", login.Email),
                            new KeyValuePair<string, string>("senha", login.Senha)
                        }
                        );
                var response = await Client.PostAsync("/login", campos);
                if (response.IsSuccessStatusCode)
                    MessagingCenter.Send(new Usuario(), "LoginSucesso");
                else
                    MessagingCenter.Send(new LoginException("Erro ao autenticar o usuário \n" + await response.Content.ReadAsStringAsync()), "FalhaLogin");
            }
            catch 
            {
                MessagingCenter.Send(
                    new LoginException("Ocorreu um erro de comunicação com o servidor \n" + "Por favor, Verifique sua conexão e tente mais tarde!"),
                    "FalhaLogin");
            }
        }
    }
}
