using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace JaguarWebAPI.Infrastructure
{

    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAttribute : Attribute, IAsyncActionFilter
    {
        private const string HeaderApiKeyName = "X-API-Key";
        private const string QueryApiKeyName = "api_key";
        internal static string ApiKey;

        public async Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            string extractedApiKey;
            if (context.HttpContext.Request.Query.TryGetValue(QueryApiKeyName, out var extractedQueryApiKey))
                extractedApiKey = extractedQueryApiKey;
            else if (context.HttpContext.Request.Headers.TryGetValue(HeaderApiKeyName, out var extractedHeaderApiKey))
                extractedApiKey = extractedHeaderApiKey;
            else
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 401,
                    Content = "Not found Api Key"
                };
                return;
            }

            if (!ApiKey.Equals(extractedApiKey))
            {
                context.Result = new ContentResult()
                {
                    StatusCode = 403,
                    Content = "Unauthorized Access"
                };
                return;
            }

            await next();
        }
    }
}
