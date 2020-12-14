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
    [RoutePrefix("api/OrderStatus")]
    public class OrderStatusController : ApiController
    {
        OrderStatusServices _orderStatusServices;
        public OrderStatusController(OrderStatusServices orderStatusServices)
        {
            _orderStatusServices = orderStatusServices;
        }
        //Create Order
        [HttpPost]
        [Route("createOrder")]
        public virtual async Task<IHttpActionResult> Post(OrderStatusModel orderStatusModel)
        {
            try
            {
                var createUser = await _orderStatusServices.createOrderAsync(orderStatusModel);
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
        //Get all Order
        [HttpGet]
        [Route("getAllOrders")]
        public virtual IHttpActionResult Get(string status)
        {
            try
            {
                var customerData = _orderStatusServices.getAllOrders(status);
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
        //Get all customer order details
        [HttpGet]
        [Route("getCustomerOrderStatus")]
        public virtual IHttpActionResult getCustomerOrderStatus(long customerId)
        {
            try
            {
                var customerData = _orderStatusServices.getCustomerOrderStatus(customerId);
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
        //Update order status details
        [HttpPut]
        [Route("updateOrderStatus")]
        public virtual IHttpActionResult updateOrderStatus(long orderId, long statusId)
        {
            try
            {
                var updateData = _orderStatusServices.updateOrderStatus(orderId, statusId);
                return Ok(ResponseUtil.GetResponse(true, updateData, null));
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
    }
}
