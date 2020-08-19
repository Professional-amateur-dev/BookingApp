using BookingApp.Data.Entities;
using System.Collections.Generic;

namespace BookingApp.Api.Responses
{
    public class RoomTypePaginatedResponse : BaseResponse
    {
        public RoomTypePaginatedResponse()
        {
            
        }

        public RoomTypePaginatedResponse(List<RoomType> roomTypes,int page, int count, int perPage)
        {
            RoomTypes = roomTypes;
            Count = count;
            PerPage = perPage;
            Page = page;
            Success = true;
        }

        public List<RoomType> RoomTypes { get; }
        public int Count { get; }
        public int PerPage { get; }
        public int Page { get; set; } = 1;
    }
}
