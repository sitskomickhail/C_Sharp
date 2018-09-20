using DemoInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoInterface.BLL
{
    internal class SenderHTTP : ISending, IEmailSending
    {
        private string _protocolName;
        public SenderHTTP(string protocolName)
        {
            _protocolName = protocolName;
        }

        public string ProtocolName
        {
            get
            {
                return _protocolName;
            }
        }
        

        public bool Check()
        {
            return true;
        }

        public void CheckFileExist()
        {

        }

        void IEmailSending.Send(string message)
        {
            Console.WriteLine("Send Email");
        }

        void ISending.Send(string fileName)
        {
            Console.WriteLine("Send file");
        }
    }
}
