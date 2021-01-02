using System;

namespace FTX.Exceptions
{
    public class FTXException : Exception
    {
        public FTXException(string message, Exception ex) : base (message, ex)
        {
        }

        public FTXException(string message): base (message)
        {
        }
    }
}
