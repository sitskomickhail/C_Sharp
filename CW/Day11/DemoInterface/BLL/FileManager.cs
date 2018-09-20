using DemoInterface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoInterface.BLL
{
    internal static class FileManager
    {
        public static void SendFile(ISending sender, string fileName)
        {
            sender.Send(fileName);
        }
    }
}
