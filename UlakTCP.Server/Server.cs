using System;
using System.IO;
using System.Net.Sockets;

namespace UlakTCP.Server
{

    public class Server
    {
        private TcpListener TcpDinleyicisi;
        public Server(string ip, int port)
        {
            TcpDinleyicisi = new TcpListener(System.Net.IPAddress.Parse(ip), port);
        }

        public void Start()
        {
            Console.Title = "Server - 0xCAFE-0xBABE";
            TcpDinleyicisi.Start();
            Console.WriteLine("65535. Port Dinlemeye alındı..!");

            Socket IstemciSoketi = TcpDinleyicisi.AcceptSocket();

            if (!IstemciSoketi.Connected)
            {
                Console.WriteLine("Sunucu başlatılamadı!!!");
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("İstemci sunucuya bağlandı..");
                    NetworkStream AgAkimi = new NetworkStream(IstemciSoketi);
                    StreamWriter AkimYazici = new StreamWriter(AgAkimi);
                    StreamReader AkimOkuyucu = new StreamReader(AgAkimi);

                    try
                    {
                        string istemciString = AkimOkuyucu.ReadLine();
                        Console.WriteLine("Gelen Data : " + istemciString);
                        int uzunluk = istemciString.Length;

                        AkimYazici.WriteLine(uzunluk.ToString());

                        AkimYazici.Flush();
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Sunucu kapanıyor...");
                        return;
                    }                    

                }
                IstemciSoketi.Close();
                Console.WriteLine("Sunucu kapatılıyor...");
                Console.ReadLine();

            }
        }
    }
}