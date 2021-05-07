using System;

namespace MicroMachines.Common.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
