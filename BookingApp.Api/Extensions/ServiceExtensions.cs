using BookingApp.Core.Repositories;
using BookingApp.Core.Services;
using Microsoft.Extensions.DependencyInjection;


namespace BookingApp.Api.Extensions
{
    public static class ServiceExtensions
    {
        public static void RegisterScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IRoomServiceRepository, RoomServiceRepository>();
            services.AddScoped<IRoomTypeRepository, RoomTypeRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IBookingRepository,BookingRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
            services.AddScoped<IGuestRepository,GuestRepository>();
            services.AddScoped<IBookingStatusRepository, BookingStatusRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}