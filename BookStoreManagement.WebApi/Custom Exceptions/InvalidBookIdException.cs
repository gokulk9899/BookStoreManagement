using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreManagement.WebApi.Custom_Exceptions
{
    public class InvalidBookIdException : Exception
    {
        public InvalidBookIdException(int Id):base(String.Format("bookId {0} is Invalid",Id))
        {

        }
    }
}
