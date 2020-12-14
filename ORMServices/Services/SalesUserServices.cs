using AutoMapper;
using ORMData.Repository;
using ORMModels.Models;
using ORMServices.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ORMServices.Services
{
    public class SalesUserServices
    {
        SalesUserRepository _salesUserRepository;
        public SalesUserServices(SalesUserRepository salesUserRepository)
        {
            _salesUserRepository = salesUserRepository;
        }

        public virtual async Task<SalesUserModel> createSalesUserAsync(SalesUserModel salesUserModel)
        {
            //Login domain will be created by using First 3 letter of firstName , LastName and last 4 digit of mobile number.
            string mobNumber = Convert.ToString(salesUserModel.MobileNumber);
            string loginDomainMob = mobNumber.Substring(mobNumber.Length - 4, 4);
            var loginDomain = string.Format("{0}{1}", salesUserModel.FirstName.Substring(0, 3), salesUserModel.LastName.Substring(0, 3)) + loginDomainMob;
            salesUserModel.LoginDomain = loginDomain;
            salesUserModel.CreationDate = DateTime.Now;
            salesUserModel.ModificationDate = DateTime.Now;
            salesUserModel.CreatedBy = 1;
            salesUserModel.ModifiedBy = 1;
            salesUserModel.isActive = true;
            SalesManInfo salesManInfo = Mapper.Map<SalesUserModel, SalesManInfo>(salesUserModel);
            _salesUserRepository.Create(salesManInfo);
            await _salesUserRepository.SaveAsync();
            return salesUserModel;
        }

        public List<SalesUserModel> getAllSalesUser()
        {
            List<SalesManInfo> salesUser = _salesUserRepository.getAllActiveUser();
            List<SalesUserModel> salesManInfo = Mapper.Map<List<SalesManInfo>, List<SalesUserModel>>(salesUser);
            return salesManInfo;
        }

        public object getSalesUserById(int userID)
        {
            var salesUserData = _salesUserRepository.Read(userID);
            return salesUserData;
        }

        public virtual async Task<SalesUserModel> updateSalesUserAsync(SalesUserModel salesUserModel)
        {
            SalesManInfo salesManInfo = _salesUserRepository.Read(salesUserModel.Id);
            salesManInfo.ModificationDate = DateTime.Now;
            salesManInfo.FirstName = salesUserModel.FirstName;
            salesManInfo.LastName = salesUserModel.LastName;
            salesManInfo.MobileNumber = salesUserModel.MobileNumber;
            _salesUserRepository.Update(salesManInfo);
            await _salesUserRepository.SaveAsync();
            SalesUserModel salesManModel = Mapper.Map<SalesManInfo, SalesUserModel>(salesManInfo);
            return salesManModel;
        }
    }
}