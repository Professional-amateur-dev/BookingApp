
using AutoMapper;
using BookingApp.Api.Requests;
using BookingApp.Api.Responses;
using BookingApp.Core.Repositories;

namespace RoomTypes.Api.Services
{
    public interface IRoomTypeService
    {
        RoomTypePaginatedResponse GetPaginatedResponse(PaginatedRoomTypeRequest request);
    }

    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository roomTypeRepository;
        private readonly IMapper mapper;

        public RoomTypeService(
            IRoomTypeRepository roomTypeRepository,
            IMapper mapper
        )
        {
            this.roomTypeRepository = roomTypeRepository;
            this.mapper = mapper;
        }

        public RoomTypePaginatedResponse GetPaginatedResponse(PaginatedRoomTypeRequest request)
        {
            var roomTypes = this.roomTypeRepository.GetPaginatedRoomTypes(
                request.Page,
                request.Search,
                request.Sort
            );

            /* SELECT COUNT(*) FROM roomTypes WHERE title LIKE '' ... */
            int count = this.roomTypeRepository.Count(request.Search);

            var response = new RoomTypePaginatedResponse(roomTypes, request.Page, count, this.roomTypeRepository.PerPage);
            return response;
        }
    }
}