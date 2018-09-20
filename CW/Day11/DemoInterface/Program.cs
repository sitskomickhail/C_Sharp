using DemoInterface.BLL;
using DemoInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            //FileManager.SendFile(new SendFileByFTP(), "fileFTP.txt");
            //FileManager.SendFile(new SenderHTTP(), "fileHTTP.txt");

            FileManager.SendFile(new SendByHTTPS(), "fileHTTPS.txt");

            string[] files = new string[500];
            ISending[] senders =
                {
                   new SendByHTTPS(),
                   new SenderHTTP("http"),
                   new SendFileByFTP()
                };

            for (int i = 0; i < files.Length; i++)
            {
                for (int j = 0; j < senders.Length; j++)
                {
                    senders[j].Check();
                    Console.WriteLine(senders[j].ProtocolName);
                    FileManager.SendFile(senders[j], files[i]);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
    }
}
