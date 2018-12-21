using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Web.FilterAttribute
{
    public class ExceptionHandlingAttribute: HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary(
                    new
                    {
                        controller = "Error",
                        action = "Index"
                    })
            );
            base.OnException(filterContext);
        }
    }
}