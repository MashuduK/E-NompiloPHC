﻿using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Repository
{
    public class RoomRepository : IRoom
    {
        private IUnitOfWork _unitOfWork;

        public RoomRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new RoomViewModel();
            int totalCount;
            List<RoomViewModel> vmList = new List<RoomViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<Room>().GetAll(includeProperties: "HospitalInformation").Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<Room>().GetAll().ToList().Count;
                vmList = ConverModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }

            var result = new PagedResult<RoomViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }
        private List<RoomViewModel> ConverModelToViewModelList(List<Room> modelList)
        {
            return modelList.Select(x => new RoomViewModel(x)).ToList();
        }

       
        public void DeleteRoom(int id)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(id);
            _unitOfWork.GenericRepository<Room>().Delete(model);
            _unitOfWork.Save();

        }


        public RoomViewModel GetRoomById(int RoomId)
        {
            var model = _unitOfWork.GenericRepository<Room>().GetById(RoomId);
            var vm = new RoomViewModel(model);
            return vm;
        }


        public void InsertRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConvertViewModel(Room);
            _unitOfWork.GenericRepository<Room>().Add(model);
            _unitOfWork.Save();
        }

        public void UpdateRoom(RoomViewModel Room)
        {
            var model = new RoomViewModel().ConvertViewModel(Room);
            var ModelById = _unitOfWork.GenericRepository<Room>().GetById(model.Id);
            ModelById.Type = Room.Type;
            ModelById.Status = Room.Status;
            ModelById.HospitalInformationId = Room.HospitalInformationId;


            _unitOfWork.GenericRepository<Room>().Update(ModelById);
            _unitOfWork.Save();
        }

       
        
    }
}
