using AutoMapper;
using DAL.Contracts;
using HumanResourceProject.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities.Models;

namespace DAL.Concrete
{
    internal class RoomTypeRepository : BaseRepository<RoomType, int>, IRoomTypeRepository
    {


        public RoomTypeRepository(HospitalityPRO_DbContext dbContext, IMapper mapper) : base(dbContext)
        {
      
        }

        public IEnumerable<RoomType> GetAllRoomTypes()
        {
            return GetAll();
        }

        public RoomType GetRoomTypeById(int TypeId)
        {
            return GetById(TypeId);
        }

        public RoomType CreateRoomType(RoomType request)
        {
            Add(request);
            PersistChangesToTrackedEntities();
            return request;
        }

        public RoomType UpdateRoomType(RoomType request)
        {
            Update(request);
            PersistChangesToTrackedEntities();
            return request;
        }

        public void DeleteRoomType(int TypeId)
        {
            Remove(TypeId);
            PersistChangesToTrackedEntities();
        }
    }
}