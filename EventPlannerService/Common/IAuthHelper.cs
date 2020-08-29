using EventPlannerService.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventPlannerService.Common
{
    public interface IAuthHelper
    {
        Task<String> getToken(UserInfo _userData);

    }
}
