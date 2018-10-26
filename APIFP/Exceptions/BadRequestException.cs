using System;
using System.Collections.Generic;
using System.Text;

namespace APIFP.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {

        }

        public BadRequestException(string json)
            :base(json)
        {

        }
    }
}
