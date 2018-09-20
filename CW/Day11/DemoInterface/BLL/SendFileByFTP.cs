using DemoInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoInterface.BLL
{
    internal class SendFileByFTP : ISending
    {
        private const string PROTOCOL_NAME = "FTP";
        public string ProtocolName
        {
            get
            {
                return PROTOCOL_NAME;
            }
        }

        public bool Check()
        {
            return true;
        }

        public void Send(string filePath)
        {
            Console.WriteLine("Send File - FTP");
        }
    }
}