using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using HumanResourceProject.Models;

namespace DAL.Contracts
{
    public interface IRoomTypeRepository : IRepository<RoomType, int >
    {
        List<RoomTypeDTO> GetAllRoomTypes();
        RoomTypeDTO GetRoomTypeById(int TypeId);
        void CreateRoomType(RoomTypeDTO request);
        void UpdateRoomType(int TypeId, RoomTypeDTO request);
        void DeleteRoomType(int TypeId);


    }
}
