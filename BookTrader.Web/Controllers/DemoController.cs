using System;
using System.IO;
using BookTrader.Data.ApiModel;
using BookTrader.Data.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTrader.Web.Controllers
{
    /// <summary>
    /// Added for demo purpose only
    /// </summary>
    [ApiController]
    [Route("/api/demo/[action]")]
    public class DemoController
    {
        [HttpPost]
        [Route("/api/demo/seed")]        
        public ApiResponse<MessageResponse> Seed(AuthDemoRequest request)
        {
            if (request == null) return new ApiResponse<MessageResponse>(ErrorResponse.InvalidParams);
            
            if (string.IsNullOrWhiteSpace(request.Auth)) return new ApiResponse<MessageResponse>(ErrorResponse.UnauthorizedAccess);

            var demoAuth = EnvironmentUtil.GetEnv("DEMO_AUTH");
            
            if (string.IsNullOrWhiteSpace( demoAuth )) return new ApiResponse<MessageResponse>(ErrorResponse.DemoAuthNotSetup);

            if (request.Auth.Equals(demoAuth))
            {
                DatabaseSeedUtil.DropData();
                DatabaseSeedUtil.SeedData();
            }
            else
            {
                new ApiResponse<MessageResponse>(ErrorResponse.UnauthorizedAccess);

            }

            return new ApiResponse<MessageResponse>(new MessageResponse {Message = "Database seeded successfully"});
        }
    }
}