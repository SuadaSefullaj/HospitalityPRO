using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRoomTypeService
    {
        List<RoomTypeDTO> GetAllRoomTypes();
        RoomTypeDTO GetRoomTypeById(int TypeId);
        void CreateRoomType(RoomTypeDTO request);
        void UpdateRoomType(int id, RoomTypeDTO request);
        void DeleteRoomType(int id);
    }
}
