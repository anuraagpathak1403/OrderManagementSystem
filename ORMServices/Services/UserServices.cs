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
    public class UserServices
    {
        UserRepository _userRepository;
        public UserServices(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public virtual async Task<Customers> createUserAsync(string FirstName, string LastName, string EmailAddress, long MobileNumber, string Address)
        {
            //Global Password
            string password = "123456";
            byte[] encData_byte = new byte[password.Length];
            encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
            string encodedData = Convert.ToBase64String(encData_byte);
            //
            Customers customers = new Customers();
            customers.CreationDate = DateTime.Now;
            customers.ModificationDate = DateTime.Now;
            customers.FirstName = FirstName;
            customers.LastName = LastName;
            customers.MobileNumber = MobileNumber;
            customers.Address = Address;
            customers.EmailAddress = EmailAddress;
            customers.Password = encodedData;
            _userRepository.Create(customers);
            await _userRepository.SaveAsync();
            return customers;
        }

        public List<Customers> getAllUser()
        {
            List<Customers> customerData = _userRepository.getAllUser();
            return customerData;
        }

        public Customers getUserById(int customerID)
        {
            var customerData = _userRepository.Read(customerID);
            return customerData;
        }

        public virtual async Task<Customers> updateUserAsync(int customerId, string firstName, string lastName, string emailAddress, long mobileNumber, string address)
        {
            Customers customers = _userRepository.Read(customerId);
            customers.ModificationDate = DateTime.Now;
            customers.FirstName = firstName;
            customers.LastName = lastName;
            customers.MobileNumber = mobileNumber;
            customers.Address = address;
            customers.EmailAddress = emailAddress;
            _userRepository.Update(customers);
            _userRepository.SaveAsync().GetAwaiter().GetResult();
            return customers;
        }
    }
}