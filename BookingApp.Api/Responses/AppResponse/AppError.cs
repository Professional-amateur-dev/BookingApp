namespace BookingApp.Api.Responses.AppResponse
{
    public class AppError : AppResponse
    {
        public string Reason { get; set; }
        public string Message { get; set; }
        public AppError(string reason) : base(false) => this.Reason = reason;
    }
}