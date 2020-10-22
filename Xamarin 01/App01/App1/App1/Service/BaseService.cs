using System;
using System.Net.Http;

namespace App1.Service
{
    public abstract class BaseService
    {
        protected const string BASE_ADDRESS = "https://aluracar.herokuapp.com";
        public HttpClient Client { get; private set; }

        protected BaseService() => Client = new HttpClient
        {
            BaseAddress = new Uri(BASE_ADDRESS)
        };
    }
}
