using System;

namespace UlakTCP.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SERVER başlatılıyor...!");
            Server server = new Server("127.1.1", 5768);
            server.Start();
        }
    }
}
