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

        public RoomTypeService(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository;
        }

        public List<RoomTypeDTO> GetAllRoomTypes()
        {
            return _roomTypeRepository.GetAllRoomTypes();
        }

        public RoomTypeDTO GetRoomTypeById(int TypeId)
        {
            return _roomTypeRepository.GetRoomTypeById(TypeId);
        }

        public void CreateRoomType(RoomTypeDTO roomTypeDto)
        {
            _roomTypeRepository.CreateRoomType(roomTypeDto);
        }

        public void UpdateRoomType(int TypeId, RoomTypeDTO roomTypeDto)
        {
            _roomTypeRepository.UpdateRoomType(TypeId, roomTypeDto);
        }

        public void DeleteRoomType(int TypeId)
        {
            _roomTypeRepository.DeleteRoomType(TypeId);
        }
    }
}

