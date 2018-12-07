using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteDotNetCoreMVCLoja.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            bool isAjaxCall = context.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";

            if (isAjaxCall)
            {
                context.HttpContext.Response.ContentType = "application/json";
                context.HttpContext.Response.StatusCode = 500;

                var messsage = context.Exception is DomainException ? context.Exception.Message : "Ocorreu um erro";
                context.Result = new JsonResult(messsage);
                context.ExceptionHandled = true;
            }

            base.OnException(context);
        }
    }
}
