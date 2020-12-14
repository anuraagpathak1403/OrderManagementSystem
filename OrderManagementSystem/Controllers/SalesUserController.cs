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
    [RoutePrefix("api/SalesUser")]
    public class SalesUserController : ApiController
    {
        SalesUserServices _salesUserServices;

        public SalesUserController(SalesUserServices salesUserServices)
        {
            _salesUserServices = salesUserServices;
        }
        [HttpPost]
        [Route("createSalesUser")]
        public virtual async Task<IHttpActionResult> Post(SalesUserModel salesUserModel)
        {
            try
            {
                var createUser = await _salesUserServices.createSalesUserAsync(salesUserModel);
                return Ok(ResponseUtil.GetResponse(true, createUser, null));

            }
            catch (Exception ex)
            {
                var response = new FailureResponse()
                {
                    Message = Messages.FAILURE_MESSAGE_CREATESALESUSER,
                    StatusCode = 400
                };
                return Content(HttpStatusCode.BadRequest, ResponseUtil.GetResponse(false, null, response));
            }
        }
        [HttpGet]
        [Route("getSalesUser")]
        public virtual IHttpActionResult Get()
        {
            try
            {
                var salesUserData = _salesUserServices.getAllSalesUser();
                return Ok(ResponseUtil.GetResponse(true, salesUserData, null));
            }
            catch (Exception ex)
            {
                var response = new FailureResponse()
                {
                    Message = Messages.FAILURE_MESSAGE_GETALLSALESUSER,
                    StatusCode = 400
                };
                return Content(HttpStatusCode.BadRequest, ResponseUtil.GetResponse(false, null, response));
            }
        }
        [HttpGet]
        [Route("getSalesUserById")]
        public virtual IHttpActionResult getSalesUserById(int userID)
        {
            try
            {
                var customerData = _salesUserServices.getSalesUserById(userID);
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
        [Route("updateSalesUser")]
        public virtual async Task<IHttpActionResult> Put(SalesUserModel salesUserModel)
        {
            try
            {
                var updateUser = await _salesUserServices.updateSalesUserAsync(salesUserModel);
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
