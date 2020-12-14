using OrderManagementSystem.Util;
using ORMServices.Model;
using ORMServices.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace OrderManagementSystem.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        InventoryServices _inventoryServices;
        public InventoryController(InventoryServices inventoryServices)
        {
            _inventoryServices = inventoryServices;
        }
       
        [HttpPost]
        [Route("Upload")]
        //Inventory attachement upload
        public IHttpActionResult Post()
        {
            int inventoryAttachmentId=0;
            try
            {
                InventoryAttachmentModel inventoryAttachmentModel = new InventoryAttachmentModel();
                var httpRequest = HttpContext.Current.Request;
                HttpFileCollection uploads = HttpContext.Current.Request.Files;
                foreach (string file in httpRequest.Files)
                {
                    var docfiles = new List<string>();
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/InventoryImages/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);
                    string filePaths = filePath;
                    inventoryAttachmentModel.AttachmentPath = filePath;
                    inventoryAttachmentModel.FileName = postedFile.FileName;
                    inventoryAttachmentId = _inventoryServices.saveAttachement(inventoryAttachmentModel);
                }
                return Ok(ResponseUtil.GetResponse(true, inventoryAttachmentId, null));
            }

            catch (WebException ex)
            {
                var response = new FailureResponse()
                {
                    Message = Messages.FAILURE_MESSAGE_CREATEUSER,
                    StatusCode = 400
                };
                return Content(HttpStatusCode.BadRequest, ResponseUtil.GetResponse(false, null, response));
            }
        }
        //Delete Inventory attachement upload
        [HttpPost]
        [Route("DeleteUploadedFile")]
        public IHttpActionResult DeleteFile(long attachementId)
        {
            var deleteattachement = _inventoryServices.DeleteFile(attachementId);
            return Ok(ResponseUtil.GetResponse(true, deleteattachement, null));
        }
        //Create Inventory
        [HttpPost]
        [Route("createInventory")]
        //Update Inventory
        public virtual async Task<IHttpActionResult> Post(InventoryModel inventoryModel)
        {
            try
            {
                var createInventory = await _inventoryServices.createInventoryAsync(inventoryModel);
                return Ok(ResponseUtil.GetResponse(true, createInventory, null));
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
        [HttpPut]
        [Route("updateInventory")]
        public virtual async Task<IHttpActionResult> Put(InventoryModel inventoryModel)
        {
            try
            {
                var updateInventory = await _inventoryServices.updateInventoryAsync(inventoryModel);
                return Ok(ResponseUtil.GetResponse(true, updateInventory, null));
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
        //Get All Inventory
        [HttpGet]
        [Route("getAllInventory")]
        public virtual IHttpActionResult Get()
        {
            try
            {
                var customerData = _inventoryServices.getAllInventory();
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
    }
}
