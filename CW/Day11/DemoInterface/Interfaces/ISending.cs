using System;

namespace DemoInterface.Interfaces
{
    internal interface ISending : IValidator
    {
        string ProtocolName { get; }
        void Send(string fileName);
    }
}
