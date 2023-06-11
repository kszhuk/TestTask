using System;
namespace TestTask.Web.Exceptions
{
    public class NotFoundException : Exception
    {
        public override string Message
        {
            get
            {
                return "Record not found";
            }

        }
    }
}
