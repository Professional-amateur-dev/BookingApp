using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using BookingApp.Data.Entities;
using System;

namespace BookingApp.Api.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext dontuse, HttpContext context)
        {
            var user = (User)context.Items["User"];
            if (user == null)
            {
                // not logged in
                return;
            }
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var a = (User)context.HttpContext.Items["User"];

        }
    }
}
