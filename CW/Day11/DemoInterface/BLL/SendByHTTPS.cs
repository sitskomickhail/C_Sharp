using DemoInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoInterface.BLL
{
    internal class SendByHTTPS : BaseSender, ISending
    {
        public string ProtocolName
        {
            get
            {
                return "HTTPs";
            }
        }

        public bool Check()
        {
            return true;
        }

        public override int GetFileSize()
        {
            return 100;
        }

        public void Send(string fileName)
        {
            Console.WriteLine("Send File by HTTPS (SSL)");
        }
    }
}