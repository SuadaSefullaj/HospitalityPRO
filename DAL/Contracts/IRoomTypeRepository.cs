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
        IEnumerable<RoomType> GetAllRoomTypes();
        RoomType GetRoomTypeById(int TypeId);
        RoomType CreateRoomType(RoomType request);
        RoomType UpdateRoomType(RoomType request);
        void DeleteRoomType(int TypeId);

    }
}
