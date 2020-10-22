namespace App1.Model
{
    public class Login
    {
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public Login(string Email, string Senha)
        {
            this.Email = Email;
            this.Senha = Senha;
        }

    }
}
