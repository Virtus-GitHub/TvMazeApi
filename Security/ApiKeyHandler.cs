using Microsoft.AspNetCore.Authorization;
using TvMazeApi.Interfaces;
using TvMazeApi.Models;

namespace TvMazeApi.Utils
{
    /// <summary>
    /// Api Key Handler 
    /// </summary>
    public class ApiKeyHandler(IHttpContextAccessor _httpContextAccessor, IApiKeyValidation _apiKeyValidation) : AuthorizationHandler<ApiKeyRequirement>
    {
        private readonly IHttpContextAccessor httpContextAccessor = _httpContextAccessor;
        private readonly IApiKeyValidation apiKeyValidation = _apiKeyValidation;

        /// <summary>
        /// HandleRequirementAsync method to handle validation
        /// </summary>
        /// <param name="context"></param>
        /// <param name="requirement"></param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ApiKeyRequirement requirement)
        {
            string apiKey = _httpContextAccessor?.HttpContext?.Request.Headers[Constants.ApiKeyHeaderName].ToString();

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            if (!_apiKeyValidation.IsValidApiKey(apiKey))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
