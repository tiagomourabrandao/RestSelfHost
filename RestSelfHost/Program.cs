using Microsoft.Owin.Hosting;
using System;

namespace RestSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {

            string baseAddress = "http://localhost:5000/";

            using (WebApp.Start(url: baseAddress))
            {
                Console.WriteLine("Programa rodando na porta 5000");
                System.Threading.Thread.Sleep(-1);
            }

        }
    }
}
