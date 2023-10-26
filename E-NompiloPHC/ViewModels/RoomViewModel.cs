using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }

        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalInformationId { get; set; }
        public HospitalInformation HospitalInformation { get; set; }
        public RoomViewModel() { }
        public RoomViewModel(Room model)
        {
            Id = model.Id;
            RoomNumber = model.RoomNumber;
            Type = model.Type;
            Status = model.Status;
            HospitalInformationId = model.HospitalInformationId;
            HospitalInformation = model.HospitalInformation;


        }
        public Room ConvertViewModel(RoomViewModel model)
        {
            return new Room
            {
                Id = model.Id,
                RoomNumber = model.RoomNumber,
                Type = model.Type,
                Status = model.Status,
                HospitalInformationId = model.HospitalInformationId,
                HospitalInformation = model.HospitalInformation
            };

        }
    }
}
