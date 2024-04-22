using AutoMapper;
using DAL.Contracts;
using HumanResourceProject.Models;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class RoomTypeRepository : IRoomTypeRepository
    {
        private readonly HospitalityPRO_DbContext _dbContext;
        private readonly IMapper _mapper;

        public RoomTypeRepository(HospitalityPRO_DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public List<RoomTypeDTO> GetAllRoomTypes()
        {
            var roomTypes = _dbContext.RoomTypes.ToList();
            return _mapper.Map<List<RoomTypeDTO>>(roomTypes);
        }

        public RoomTypeDTO GetRoomTypeById(int TypeId)
        {
            var roomType = _dbContext.RoomTypes.FirstOrDefault(rt => rt.TypeId == TypeId);
            return _mapper.Map<RoomTypeDTO>(roomType);
        }

        public void CreateRoomType(RoomTypeDTO roomTypeDto)
        {
            var roomType = _mapper.Map<RoomType>(roomTypeDto);
            _dbContext.RoomTypes.Add(roomType);
            _dbContext.SaveChanges();
        }

        public void UpdateRoomType(int TypeId, RoomTypeDTO roomTypeDto)
        {
            var roomType = _dbContext.RoomTypes.Find(TypeId);
            _mapper.Map(roomTypeDto, roomType);
            _dbContext.SaveChanges();
        }

        public void DeleteRoomType(int TypeId)
        {
            var roomType = _dbContext.RoomTypes.Find(TypeId);
            _dbContext.RoomTypes.Remove(roomType);
            _dbContext.SaveChanges();
        }
    }
}