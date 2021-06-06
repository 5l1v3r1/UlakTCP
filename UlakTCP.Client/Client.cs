using System;
using System.Net.Sockets;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;

namespace UlakTCP.Client
{
    public class Client
    {
        public TcpClient Istemci;
        public NetworkStream AgAkimi;
        public StreamReader AkimOkuyucu;
        public StreamWriter AkimYazici;
        public Client()
        {
        }

        public void Start(string ip, int port)
        {
            Console.Title = "Client - User";

            try
            {
                Istemci = new TcpClient(ip, port);
                AgAkimi = Istemci.GetStream();
                AkimOkuyucu = new StreamReader(AgAkimi);
                AkimYazici = new StreamWriter(AgAkimi);
            }
            catch (Exception)
            {
                Console.WriteLine("Kullanici baglanamadi..!!!");
                return;
            }


            Console.WriteLine("Client-User bağlandı..");
            Console.WriteLine("Hoşgeldiniz Client-User");
            bool IsActive = true;
            while (IsActive)
            {
                Console.WriteLine("Mesajınız nedir?");
                string msg = Console.ReadLine();
                if (msg != "")
                {
                    AkimYazici.WriteLine(msg);
                    AkimYazici.Flush();
                    Console.Write("Sunucudan CEVAP geldi : ");
                    Console.WriteLine(AkimOkuyucu.ReadLine());
                }
                else
                {
                    Console.WriteLine("Boş mesaj gönderilemez..!");
                    IsActive = false;
                }

            }

            Console.WriteLine("İzlediğiniz için teşekkürler...\nHoşçakalın !!!");
        }

    }
}
