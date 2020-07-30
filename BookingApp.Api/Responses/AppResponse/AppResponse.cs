using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Api.Responses.AppResponse
{
    public class AppResponse : ActionResult
    {
        public bool Success { get; set; } = false;
        public AppResponse(bool success) => this.Success = success;
    }
}