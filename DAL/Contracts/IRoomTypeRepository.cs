using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL.Contracts
{
    public interface IRoomTypeRepository
    {
        List<RoomTypeDTO> GetAllRoomTypes();
        RoomTypeDTO GetRoomTypeById(int TypeId);
        void CreateRoomType(RoomTypeDTO roomTypeDto);
        void UpdateRoomType(int TypeId, RoomTypeDTO roomTypeDto);
        void DeleteRoomType(int TypeId);
    }
}
