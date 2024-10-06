using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filter
{
    public class MyFilterAttribute : Attribute, IFilterMetadata 
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("On Action Executed");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("on action Excuting");
        }
    }
}
