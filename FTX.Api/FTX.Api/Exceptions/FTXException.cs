using System;

namespace FTX.Api.Exceptions
{
    public class FTXException : Exception
    {
        public FTXException(string message, Exception ex) : base (message, ex)
        {
        }
    }
}
