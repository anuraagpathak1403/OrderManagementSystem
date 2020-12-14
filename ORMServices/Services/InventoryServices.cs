using AutoMapper;
using ORMData.Repository;
using ORMModels.Models;
using ORMServices.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ORMServices.Services
{
    public class InventoryServices
    {
        InventoryRepository _inventoryRepository;
        InventoryAttachmentRepository _inventoryAttachmentRepository;
        public InventoryServices(InventoryRepository inventoryRepository, InventoryAttachmentRepository inventoryAttachmentRepository)
        {
            _inventoryRepository = inventoryRepository;
            _inventoryAttachmentRepository = inventoryAttachmentRepository;
        }

        public virtual InventoryDataAttachementModel getAllInventory()
        {
            InventoryDataAttachementModel inventoryDataAttachementModel = new InventoryDataAttachementModel();
            List<Inventory> getInventoryData = _inventoryRepository.getAllInventory();
            List<InventoryModel> inventoryModel = Mapper.Map<List<Inventory>, List<InventoryModel>>(getInventoryData);
            inventoryDataAttachementModel.inventoryModel = inventoryModel;
            //Retrieve attachments
            foreach (var data in inventoryDataAttachementModel.inventoryModel)
            {
                List<InventoryAttachement> inventoryAttachment = _inventoryAttachmentRepository.getAllAttachement(data.ImageInventoryId);
                List<InventoryAttachmentModel> inventoryModelData = Mapper.Map<List<InventoryAttachement>, List<InventoryAttachmentModel>>(inventoryAttachment);
                data.inventoryAttachmentModel = inventoryModelData;
            }
            return inventoryDataAttachementModel;
        }

        public int saveAttachement(InventoryAttachmentModel inventoryAttachmentModel)
        {
            InventoryAttachement inventoryAttachment = new InventoryAttachement();
            inventoryAttachment.CreatedBy = 1;
            inventoryAttachment.ModifiedBy = 1;
            inventoryAttachment.CreatedDate = DateTime.Now;
            inventoryAttachment.ModifiedDate = DateTime.Now;
            inventoryAttachment.AttachmentPath = inventoryAttachmentModel.AttachmentPath;
            inventoryAttachment.FileName = inventoryAttachmentModel.FileName;
            InventoryAttachement inventory = _inventoryAttachmentRepository.Create(inventoryAttachment);
            _inventoryAttachmentRepository.SaveAsync();
            InventoryAttachmentModel inventoryModelData = Mapper.Map<InventoryAttachement, InventoryAttachmentModel>(inventory);
            return (int)inventoryModelData.Id;
        }

        public virtual async Task<InventoryModel> createInventoryAsync(InventoryModel inventoryModel)
        {
            Inventory inventory = new Inventory();
            inventory.AvailableQuantity = inventoryModel.AvailableQuantity;
            inventory.Barcode = inventoryModel.Barcode;
            inventory.Height = inventoryModel.Height;
            inventory.InventoryName = inventoryModel.InventoryName;
            inventory.Stock_Keeping_Unit = inventoryModel.Stock_Keeping_Unit;
            inventory.Weight = inventoryModel.Weight;
            inventory.Price = inventoryModel.Price;
            inventory.ImageInventoryId = inventoryModel.ImageInventoryId;
            inventory.isActive = true;
            inventory.CreatedBy = 1;
            inventory.ModifiedBy = 1;
            inventory.CreationDate = DateTime.Now;
            inventory.ModificationDate = DateTime.Now;
            _inventoryRepository.Create(inventory);
            await _inventoryRepository.SaveAsync();
            InventoryModel inventoryModelData = Mapper.Map<Inventory, InventoryModel>(inventory);
            return inventoryModelData;
        }

        public virtual async Task<InventoryModel> updateInventoryAsync(InventoryModel inventoryModel)
        {
            var inventoryData = _inventoryRepository.Read(inventoryModel.Id);
            inventoryData.AvailableQuantity = inventoryModel.AvailableQuantity;
            inventoryData.Barcode = inventoryModel.Barcode;
            inventoryData.Height = inventoryModel.Height;
            inventoryData.InventoryName = inventoryModel.InventoryName;
            inventoryData.Stock_Keeping_Unit = inventoryModel.Stock_Keeping_Unit;
            inventoryData.Weight = inventoryModel.Weight;
            inventoryData.Price = inventoryModel.Price;
            inventoryData.ImageInventoryId = inventoryModel.ImageInventoryId;
            inventoryData.isActive = inventoryModel.isActive;
            inventoryData.ModifiedBy = 1;
            inventoryData.ModificationDate = DateTime.Now;
            _inventoryRepository.Update(inventoryData);
            await _inventoryRepository.SaveAsync();
            InventoryModel inventoryModelData = Mapper.Map<Inventory, InventoryModel>(inventoryData);
            return inventoryModelData;
        }

        public object DeleteFile(long attachementId)
        {
            var deleteFile = _inventoryAttachmentRepository.DeleteFile(attachementId);
            return deleteFile;
        }
    }
}