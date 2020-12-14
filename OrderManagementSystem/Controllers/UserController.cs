using OrderManagementSystem.Util;
using ORMServices.Model;
using ORMServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace OrderManagementSystem.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        UserServices _userServices;
        public UserController(UserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpPost]
        [Route("createUser")]
        public virtual async Task<IHttpActionResult> Post(string FirstName, string LastName, string EmailAddress, long MobileNumber, string Address)
        {
            try
            {
                var createUser = await _userServices.createUserAsync(FirstName, LastName, EmailAddress, MobileNumber, Address);
                return Ok(ResponseUtil.GetResponse(true, createUser, null));

            }
            catch (Exception ex)
            {
                var response = new FailureResponse()
                {
                    Message = Messages.FAILURE_MESSAGE_CREATEUSER,
                    StatusCode = 400
                };
                return Content(HttpStatusCode.BadRequest, ResponseUtil.GetResponse(false, null, response));
            }
        }
        [HttpGet]
        [Route("getUser")]
        public virtual IHttpActionResult Get()
        {
            try
            {
                var customerData = _userServices.getAllUser();
                return Ok(ResponseUtil.GetResponse(true, customerData, null));
            }
            catch (Exception ex)
            {
                var response = new FailureResponse()
                {
                    Message = Messages.FAILURE_MESSAGE_GETALLUSER,
                    StatusCode = 400
                };
                return Content(HttpStatusCode.BadRequest, ResponseUtil.GetResponse(false, null, response));
            }
        }
        [HttpGet]
        [Route("getUserById")]
        public virtual IHttpActionResult GetUserById(int customerID)
        {
            try
            {
                var customerData = _userServices.getUserById(customerID);
                return Ok(ResponseUtil.GetResponse(true, customerData, null));
            }
            catch (Exception ex)
            {
                var response = new FailureResponse()
                {
                    Message = Messages.FAILURE_MESSAGE_GETALLUSER,
                    StatusCode = 400
                };
                return Content(HttpStatusCode.BadRequest, ResponseUtil.GetResponse(false, null, response));
            }
        }
        [HttpPut]
        [Route("updateUser")]
        public virtual async Task<IHttpActionResult> Put(int CustomerId,string FirstName, string LastName, string EmailAddress, long MobileNumber, string Address)
        {
            try
            {
                var updateUser = await _userServices.updateUserAsync(CustomerId,FirstName, LastName, EmailAddress, MobileNumber, Address);
                return Ok(ResponseUtil.GetResponse(true, updateUser, null));

            }
            catch (Exception ex)
            {
                var response = new FailureResponse()
                {
                    Message = Messages.FAILURE_MESSAGE_CREATEUSER,
                    StatusCode = 400
                };
                return Content(HttpStatusCode.BadRequest, ResponseUtil.GetResponse(false, null, response));
            }
        }

    }
}
