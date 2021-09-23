using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Security
{
    public static class ControllerExtensions
    {
        public static string GetCurrentUser(this Controller controller)
        {
            return SecurityHelper.GetCurrentUser(controller.HttpContext);
        }

        public static Guid GetCurentUserId(this Controller controller)
        {
            return UserHelper.GetCurrentUserId(controller.HttpContext);
        }
    }
}
