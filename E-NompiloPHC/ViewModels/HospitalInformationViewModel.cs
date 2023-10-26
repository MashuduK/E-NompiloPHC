using E_NompiloPHC.Models;

namespace E_NompiloPHC.ViewModels
{
    public class HospitalInformationViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string City { get; set; }

        public string AreaCode { get; set; }
        public string Province { get; set; }
        public HospitalInformationViewModel() { }
        public HospitalInformationViewModel(HospitalInformation model)
        {
            Id = model.Id;
            Name = model.Name;
            Type = model.Type;
            City = model.City;
            AreaCode = model.AreaCode;
            Province = model.Province;
        }
        public HospitalInformation ConvertViewModel(HospitalInformationViewModel model)
        {
            return new HospitalInformation
            {
                Id = model.Id,
                Name = model.Name,
                Type = model.Type,
                City = model.City,
                AreaCode = model.AreaCode,
                Province = model.Province
            };

        }
    }
}
