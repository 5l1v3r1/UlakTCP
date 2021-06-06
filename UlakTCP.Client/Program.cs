using System;

namespace UlakTCP.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CLIENT-USER başlatılıyor...!");
            Client client = new Client();
            client.Start("127.1.1", 5768);
            
        }
    }
}
