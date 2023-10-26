
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;

namespace E_NompiloPHC.Interface
{
    public interface IRoom
    {
        PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
        RoomViewModel GetRoomById(int RoomId);
        void UpdateRoom(RoomViewModel Room);
        void InsertRoom(RoomViewModel Room);
        void DeleteRoom(int id);
    }
}
