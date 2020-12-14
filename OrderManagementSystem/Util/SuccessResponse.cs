using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrderManagementSystem.Util
{
    public class SuccessResponse
    {
        public bool Success { get; set; }

        public object Data { get; set; }

        public FailureResponse FailResponse { get; set; }
    }
}