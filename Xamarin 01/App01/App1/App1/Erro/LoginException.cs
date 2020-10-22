using System;

namespace App1.Erro
{
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message) { }
    }
}
