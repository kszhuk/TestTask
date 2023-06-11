using System;
namespace TestTask.Web.Exceptions
{
    public class BadRequestException : Exception
    {
        public override string Message
        {
            get
            {
                return "Bad request";
            }

        }
    }
}
