using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlogsNTags.API.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            //This catches any unhandled exceptions, it could also regulate custom exceptions and provide appropriate response

            context.ModelState.AddModelError("message", "Unexpected error on server, please try again");

            context.HttpContext.Response.StatusCode = 500;

            var ListOfErrors = context.ModelState.Where(x => x.Value.Errors.Count() > 0)
                 .ToDictionary(x => x.Key, y => y.Value.Errors.Select(c => c.ErrorMessage));
            
            context.Result = new JsonResult(ListOfErrors);

            base.OnException(context);
        }
    }
}
