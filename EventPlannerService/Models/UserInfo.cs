using System;
using System.Collections.Generic;

namespace EventPlannerService.Models
{
    public partial class UserInfo
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserInfo()
        {
        }

        public UserInfo(int userId, string firstName, string lastName, string userName, string email, string password, DateTime createdDate)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
            Email = email;
            Password = password;
            CreatedDate = createdDate;
        }
    }
}
