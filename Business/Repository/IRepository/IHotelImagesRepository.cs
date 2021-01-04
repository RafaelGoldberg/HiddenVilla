using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
    public interface IHotelImagesRepository
    {
        public Task<int> CreateHotelRoomImage(HotelRoomImageDTO imageDTO);
        public Task<int> DeleteHotelRoomImageByImageID(int imageId);
        public Task<int> DeleteHotelRoomImageByRoomID(int roomId);
        public Task<int> DeleteHotelRoomImageByImageUrl(string imageUrl);
        public Task<IEnumerable<HotelRoomImageDTO>> GetHotelRoomImages(int roomId);

    }
}
