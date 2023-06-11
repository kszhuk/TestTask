using System;
namespace TestTask.Web.Exceptions
{
    public class InternalServerErrorException : Exception
    {
        public override string Message
        {
            get
            {
                return "Generic error has occurred on the server";
            }

        }
    }
}
