using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace VuelingExam.Business.Facade.Filters
{
    public class NotImplementedExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is NotImplementedException)
            {
                var httpResponseMessage = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(actionExecutedContext.Exception.Message, System.Text.Encoding.UTF8, "text/plain"),
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "Not Implemented Error"
                };
                actionExecutedContext.Response = httpResponseMessage;
            }
            base.OnException(actionExecutedContext);
        }
    }
}