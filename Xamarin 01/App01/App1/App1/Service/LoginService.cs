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
            var campos = new FormUrlEncodedContent(new[]
                    {
                            new KeyValuePair<string, string>("email", login.Email),
                            new KeyValuePair<string, string>("senha", login.Senha)
                        }
                );
            var response = await Client.PostAsync("/login", campos);
            if (response.IsSuccessStatusCode)
                MessagingCenter.Send<Usuario>(new Usuario(), "LoginSucesso");
            else
                MessagingCenter.Send<LoginException>(new LoginException("Erro ao autenticar o usuário \n" + await response.Content.ReadAsStringAsync()), "FalhaLogin");
                     
        }
    }
}
