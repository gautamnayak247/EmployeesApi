using ABB.Domain;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace ABB.Api.Filters
{
    public class AuthorizationAttribute : Attribute, IActionFilter
    {
        private readonly Roles[] allowedRoles;

        public AuthorizationAttribute(params Roles[] roles) => allowedRoles = roles;
        public void OnActionExecuted(ActionExecutedContext context) { }

        /// <summary>
        /// validating user is allowed or not before action is executed.
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userRole = Enum.Parse(typeof(Roles), context.HttpContext.Request.Headers[Constant.UserRoleHeader]);
            if (!string.IsNullOrWhiteSpace(userRole.ToString()))
            {
                var isUserAllowed = allowedRoles.Any(role => role.Equals(userRole));
                if (!isUserAllowed)
                {
                    throw new AccessForbiddenException("Access is forbidden!");
                }
            }
        }
    }
}
