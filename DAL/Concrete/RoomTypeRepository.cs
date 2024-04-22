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
        private readonly IMapper _mapper;

        public RoomTypeRepository(HospitalityPRO_DbContext dbContext, IMapper mapper) : base(dbContext)
        {
            _mapper = mapper;
        }

        public List<RoomTypeDTO> GetAllRoomTypes()
        {
            var roomTypes = GetAll();
            return _mapper.Map<List<RoomTypeDTO>>(roomTypes);
        }

        public RoomTypeDTO GetRoomTypeById(int TypeId)
        {
            var roomType = GetById(TypeId);
            return _mapper.Map<RoomTypeDTO>(roomType);
        }

        public void CreateRoomType(RoomTypeDTO roomTypeDto)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeDto);
            Add(roomType);
            PersistChangesToTrackedEntities();
        }

        public void UpdateRoomType(int TypeId, RoomTypeDTO roomTypeDto)
        {
            var roomType = GetById(TypeId);
            _mapper.Map(roomTypeDto, roomType);
            Update(roomType);
            PersistChangesToTrackedEntities();
        }

        public void DeleteRoomType(int TypeId)
        {
            Remove(TypeId);
            PersistChangesToTrackedEntities();
        }
    }
}