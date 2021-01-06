using AutoMapper;
using Business.Repository.IRepository;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository
{
    public class RoomAmenityRepository : IRoomAmenityRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        public RoomAmenityRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<RoomAmenityDTO> CreateRoomAmenity(RoomAmenityDTO roomAmenityDTO)
        {
            RoomAmenity roomAmenity = _mapper.Map<RoomAmenityDTO, RoomAmenity>(roomAmenityDTO);
            var addedRoomAmenity = await _db.RoomAmenities.AddAsync(roomAmenity);
            await _db.SaveChangesAsync();
            return _mapper.Map<RoomAmenity, RoomAmenityDTO>(addedRoomAmenity.Entity);
        }

        public async Task<int> DeleteRoomAmenity(int amenityId)
        {
            var amenityDetails = await _db.RoomAmenities.FindAsync(amenityId);
            if (amenityDetails != null)
            {
                _db.RoomAmenities.Remove(amenityDetails);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public Task<RoomAmenityDTO> DoesRoomAmenityExist(string name, int amenityId = 0)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RoomAmenityDTO>> GetAllRoomAmenity()
        {
            try
            {
                IEnumerable<RoomAmenityDTO> roomAmenityDTO = _mapper.Map<IEnumerable<RoomAmenity>, IEnumerable<RoomAmenityDTO>>(_db.RoomAmenities);
                return roomAmenityDTO;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<RoomAmenityDTO> GetRoomAmenity(int amenityId)
        {
            try
            {
                RoomAmenityDTO roomAmenity = _mapper.Map<RoomAmenity, RoomAmenityDTO>(await _db.RoomAmenities.FirstOrDefaultAsync(x => x.Id == amenityId));
                return roomAmenity;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public async Task<RoomAmenityDTO> UpdateRoomAmenity(int roomId, RoomAmenityDTO roomAmenityDTO)
        {
            try
            {
                if (roomId == roomAmenityDTO.Id)
                {
                    //valid
                    RoomAmenity roomAmenity = await _db.RoomAmenities.FindAsync(roomId);
                    RoomAmenity amenity = _mapper.Map<RoomAmenityDTO, RoomAmenity>(roomAmenityDTO, roomAmenity);

          
                    var updatedAmenity = _db.RoomAmenities.Update(amenity);
                    await _db.SaveChangesAsync();
                    return _mapper.Map<RoomAmenity, RoomAmenityDTO>(updatedAmenity.Entity);
                }
                else
                {
                    //not valid
                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
