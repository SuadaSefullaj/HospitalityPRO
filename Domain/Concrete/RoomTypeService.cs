using AutoMapper;
using DAL.Contracts;
using Domain.Contracts;
using DTO;
using HumanResourceProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IMapper _mapper;

        public RoomTypeService(IRoomTypeRepository roomTypeRepository, IMapper mapper)
        {
            _roomTypeRepository = roomTypeRepository;
            _mapper = mapper;
        }

        public List<RoomTypeDTO> GetAllRoomTypes()
        {
            var roomTypes = _roomTypeRepository.GetAllRoomTypes();
            return _mapper.Map<List<RoomTypeDTO>>(roomTypes);
        }

        public RoomTypeDTO GetRoomTypeById(int TypeId)
        {
            var roomType = _roomTypeRepository.GetRoomTypeById(TypeId);
            return _mapper.Map<RoomTypeDTO>(roomType);
        }

        public void CreateRoomType(RoomTypeDTO request)
        {
            var roomType = _mapper.Map<RoomType>(request);
            _roomTypeRepository.CreateRoomType(roomType);
        }

        public void UpdateRoomType(int TypeId, RoomTypeDTO request)
        {
            var roomType = _mapper.Map<RoomType>(request);
            roomType.TypeId = TypeId;
            _roomTypeRepository.UpdateRoomType(roomType);
        }


        public void DeleteRoomType(int TypeId)
        {
            _roomTypeRepository.DeleteRoomType(TypeId);
        }
    }
}