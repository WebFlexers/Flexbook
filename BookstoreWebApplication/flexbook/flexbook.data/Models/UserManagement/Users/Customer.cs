﻿using Flexbook.Data.Models.UserManagement;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Flexbook.Data.Models.Users
{
    public class Customer : UserBase, ICustomer
    {
        [Required]
        public Address Address { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [MaxLength(10)]
        public string LandlineNumber { get; set; }
        [MaxLength(10)]
        public string MobilePhoneNumber { get; set; }

        [MaxLength(100)]
        public Email Email { get; set; }

        [NotMapped]
        public ShoppingCart? ShoppingCart { get; set; }

        public override void Login()
        {
            throw new NotImplementedException();
        }

        public override void Logout()
        {
            throw new NotImplementedException();
        }

        public void MakeOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public void Register()
        {
            throw new NotImplementedException();
        }
    }
}
