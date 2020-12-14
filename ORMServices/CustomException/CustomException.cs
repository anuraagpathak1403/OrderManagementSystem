using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sp.Services
{
    public class CustomException:Exception
    {
     
        public CustomException(String message):base(message)
        {
          
        }
    }
}