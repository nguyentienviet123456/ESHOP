using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace Web.FilterAttribute
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private bool _isUnauthorized;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (string.IsNullOrEmpty(authCookie?.Value))
            {
                return false;
            }

            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
            if (string.IsNullOrEmpty(ticket?.Name) || ticket.Expiration < DateTime.Now)
            {
                return false;
            }
            FormsAuthentication.SetAuthCookie(ticket.Name, true);

            var session = HttpContext.Current.Session["Admin"];
            if (session != null)
            {
                _isUnauthorized = true;
                return true;
            }
            _isUnauthorized = false;
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (_isUnauthorized)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Unauthorized",
                            action = "Index"
                        })
                );
            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(
                        new
                        {
                            controller = "Login",
                            action = "Index"
                        })
                );
            }
        }
    }
}