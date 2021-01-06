using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IRoomAmenityRepository
    {
        public Task<RoomAmenityDTO> CreateRoomAmenity(RoomAmenityDTO roomAmenityDTO);
        public Task<RoomAmenityDTO> UpdateRoomAmenity(int roomId, RoomAmenityDTO roomAmenityDTO);
        public Task<RoomAmenityDTO> GetRoomAmenity(int amenityId);
        public Task<int> DeleteRoomAmenity(int amenityId);
        public Task<IEnumerable<RoomAmenityDTO>> GetAllRoomAmenity();
        public Task<RoomAmenityDTO> DoesRoomAmenityExist(string name, int amenityId = 0);
    }
}
