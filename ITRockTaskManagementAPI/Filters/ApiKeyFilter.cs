using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ITRockTaskManagementAPI.Filters
{
    public class ApiKeyFilter : IAuthorizationFilter
    {
        private const string ApiKeyHeaderName = "X-API-KEY";
        private readonly string _apiKey;

        public ApiKeyFilter(IConfiguration configuration)
        {
            _apiKey = configuration["ApiKey"]; 
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers.TryGetValue(ApiKeyHeaderName, out var providedApiKey) ||
                !_apiKey.Equals(providedApiKey))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
