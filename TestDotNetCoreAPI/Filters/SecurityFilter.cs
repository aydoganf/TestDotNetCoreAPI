using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDotNetCoreAPI.Service;

namespace TestDotNetCoreAPI.Filters
{
    public class SecurityFilter : IAuthorizationFilter
    {
        private readonly ISessionManager sessionManager;

        public SecurityFilter(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Authorization"];

            try
            {
                if (!sessionManager.IsAuthenticated(token))
                {
                    context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
                    return;
                }
            }
            catch (Exception ex)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Unauthorized);
            }
        }
    }
}
