using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlannerService.Models
{
    public class UserAndTokenData : UserInfo
    {
        public string accessToken { get; set; }

        public UserAndTokenData(
            UserInfo userInfo, 
            string accessToken
            ) : 
            base(userInfo.UserId, userInfo.FirstName, userInfo.LastName, userInfo.UserName, userInfo.Email, userInfo.Password, userInfo.CreatedDate)
        {
            this.accessToken = accessToken;
        }
    }
}
