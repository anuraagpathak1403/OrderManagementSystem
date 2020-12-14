using AutoMapper;
using ORMData.Repository;
using ORMModels.Models;
using ORMServices.Model;
using Sp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ORMServices.Services
{
    public class OrderStatusServices
    {
        OrderStatusRepository _orderStatusRepository;
        SalesUserRepository _salesUserRepository;
        InventoryRepository _inventoryRepository;
        StatusMasterRepository _statusMasterRepository;
        public OrderStatusServices(OrderStatusRepository orderStatusRepository, SalesUserRepository salesUserRepository, InventoryRepository inventoryRepository, StatusMasterRepository statusMasterRepository)
        {
            _orderStatusRepository = orderStatusRepository;
            _salesUserRepository = salesUserRepository;
            _inventoryRepository = inventoryRepository;
            _statusMasterRepository = statusMasterRepository;
        }

        public virtual async Task<string> createOrderAsync(OrderStatusModel orderStatusModel)
        {
            OrderStatus orderStatus = new OrderStatus();
            orderStatus.CreationDate = DateTime.Now;
            orderStatus.ModificationDate = DateTime.Now;
            orderStatus.CustomerId = orderStatusModel.CustomerId;
            var salesManData = _salesUserRepository.Read(orderStatusModel.SalesManLoginDomain);
            var checkSalesManId = _salesUserRepository.getSalesManDetails(salesManData.LoginDomain);
            if (checkSalesManId != null)
                orderStatus.SalesManLoginDomain = orderStatusModel.SalesManLoginDomain;
            else
                throw new CustomException("User is Inactive or not available");

            var checkInventoryStock = _inventoryRepository.checkInventoryData(orderStatusModel.InventoryId);
            if (checkInventoryStock != null)
                orderStatus.InventoryId = orderStatusModel.InventoryId;
            else
                throw new CustomException(checkInventoryStock.InventoryName + " " + "is not available");

            orderStatus.UnitOrder = orderStatusModel.UnitOrder;
            orderStatus.Height = orderStatusModel.Height;
            orderStatus.Weight = orderStatusModel.Weight;

            if (orderStatusModel.Weight != 0)
                orderStatus.PurchaseAmount = checkInventoryStock.Price * orderStatus.Weight;
            else
                orderStatus.PurchaseAmount = checkInventoryStock.Price * orderStatus.Height;
            orderStatus.Status = Constants.placedId;
            orderStatus.CreatedBy = orderStatusModel.CustomerId;
            orderStatus.ModifiedBy = orderStatusModel.CustomerId;
            OrderStatus order = _orderStatusRepository.Create(orderStatus);
            await _orderStatusRepository.SaveAsync();
            OrderStatusModel orderStatusModelData = Mapper.Map<OrderStatus, OrderStatusModel>(order);

            var leftUnitInStock = (checkInventoryStock.AvailableQuantity - orderStatusModel.UnitOrder);
            checkInventoryStock.AvailableQuantity = leftUnitInStock;
            checkInventoryStock.ModificationDate = DateTime.Now;
            _inventoryRepository.Update(checkInventoryStock);
            await _inventoryRepository.SaveAsync();
            string successMessage = Constants.OrderPlaced + " " + orderStatusModelData.PurchaseAmount;
            return successMessage;
        }

        public string updateOrderStatus(long orderId, long statusId)
        {
            string successMessage = string.Empty;
            var orderData = _orderStatusRepository.Read(orderId);
            if (orderData != null)
            {
                orderData.Status = statusId;
                orderData.ModificationDate = DateTime.Now;
                _orderStatusRepository.Update(orderData);
                _orderStatusRepository.SaveAsync();
                var statusData = _statusMasterRepository.Read(statusId);
                successMessage = orderId + " " + Constants.successData + " " + statusData.StatusName;
            }
            return successMessage;
        }

        public List<OrderStatusModel> getAllOrders(string status)
        {
            List<OrderStatus> orderStatuses = new List<OrderStatus>();
            List<OrderStatusModel> orderStatusModels = new List<OrderStatusModel>();
            List<StatusMaster> statusData = _statusMasterRepository.readAllData();
            foreach (var data in statusData)
            {
                if (data.StatusName.ToUpper() == status.ToUpper().Trim() && data.StatusName.ToUpper() == Constants.ALL)
                {
                    orderStatuses = _orderStatusRepository.getDetailedData();
                    orderStatusModels = Mapper.Map<List<OrderStatus>, List<OrderStatusModel>>(orderStatuses);
                }
                else
                    if (data.StatusName.ToUpper() == status.ToUpper().Trim() && data.StatusName.ToUpper() == Constants.placed.ToUpper())
                    orderStatuses = _orderStatusRepository.getPlacedData(Constants.placedId);
                else
                    if (data.StatusName.ToUpper() == status.ToUpper().Trim() && data.StatusName.ToUpper() == Constants.approved.ToUpper())
                    orderStatuses = _orderStatusRepository.getPlacedData(Constants.approvedId);
                else
                    if (data.StatusName.ToUpper() == status.ToUpper().Trim() && data.StatusName.ToUpper() == Constants.cancelled.ToUpper())
                    orderStatuses = _orderStatusRepository.getPlacedData(Constants.cancelledId);
                else
                    if (data.StatusName.ToUpper() == status.ToUpper().Trim() && data.StatusName.ToUpper() == Constants.inDelivery.ToUpper())
                    orderStatuses = _orderStatusRepository.getPlacedData(Constants.inDeliveryId);
                else
                    if (data.StatusName.ToUpper() == status.ToUpper().Trim() && data.StatusName.ToUpper() == Constants.completed.ToUpper())
                    orderStatuses = _orderStatusRepository.getPlacedData(Constants.completedId);

                orderStatusModels = Mapper.Map<List<OrderStatus>, List<OrderStatusModel>>(orderStatuses);
            }

            return orderStatusModels;

        }

        public List<CustomerOrderStatusModel> getCustomerOrderStatus(long customerId)
        {
            CustomerOrderStatusModel customerOrderStatus2 = new CustomerOrderStatusModel();
            List<CustomerOrderStatusModel> listCustomerOrderStatus = new List<CustomerOrderStatusModel>();
            List<OrderStatus> orderStatusModels = _orderStatusRepository.getOrderDetailsByCustomerID(customerId);
            List<OrderStatusModel> listorderStatusModels = Mapper.Map<List<OrderStatus>, List<OrderStatusModel>>(orderStatusModels);
            foreach (OrderStatusModel data in listorderStatusModels)
            {
                CustomerOrderStatusModel customerOrderStatus = new CustomerOrderStatusModel();
                customerOrderStatus.OrderID = data.Id;
                customerOrderStatus.CustomerFullName = data.CustomerFullName;
                customerOrderStatus.CurrentStatus = data.CurrentStatus;
                customerOrderStatus.InventoryName = data.InventoryName;
                customerOrderStatus.OrderedDate = data.CreationDate.Date;
                customerOrderStatus.PurchaseAmount = data.PurchaseAmount;
                customerOrderStatus.UnitOrder = data.UnitOrder;
                customerOrderStatus.Weight = data.Weight;
                customerOrderStatus.Height = data.Height;
                customerOrderStatus.Status = data.CurrentStatus;
                customerOrderStatus.SaleManFullName = data.SalesManFullName;
                listCustomerOrderStatus.Add(customerOrderStatus);
            }
            return listCustomerOrderStatus;
        }
    }
}