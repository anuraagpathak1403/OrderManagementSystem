using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.Util
{
    public class ResponseUtil
    {
        public static SuccessResponse GetResponse(bool success, object data, FailureResponse errorResponse)
        {
            return new SuccessResponse() { Success = success, Data = data, FailResponse = errorResponse };
        }
    }
}