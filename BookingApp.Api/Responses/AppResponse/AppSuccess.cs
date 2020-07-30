namespace BookingApp.Api.Responses.AppResponse
{
    public class AppSuccess : AppResponse
    {
        public object Response { get; set; }

        public AppSuccess() : base(true)    { }

        public AppSuccess(object response) : base(true) => this.Response = response;
    }
}
