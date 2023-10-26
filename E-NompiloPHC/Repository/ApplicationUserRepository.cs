using E_NompiloPHC.Interface;
using E_NompiloPHC.Models;
using E_NompiloPHC.ViewModels;
using System.Drawing.Printing;

namespace E_NompiloPHC.Repository
{
    public class ApplicationUserRepository : IApplicationUser
    {
        public IUnitOfWork _unitOfWork;

        public ApplicationUserRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PagedResult<ApplicationUserViewModel> GetAll(int pageNumber, int pageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (pageSize * pageNumber) - pageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().Skip(ExcludeRecords).Take(pageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll().ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
            return result;
        }

        //public PagedResult<ApplicationUserViewModel> GetAllDoctor(int pageNumber, int pageSize)
        //{
        //    throw new NotImplementedException();
        //}

        public PagedResult<ApplicationUserViewModel> GetAllDoctor(int PageNumber, int PageSize)
        {
            var vm = new ApplicationUserViewModel();
            int totalCount;
            List<ApplicationUserViewModel> vmList = new List<ApplicationUserViewModel>();
            try
            {
                int ExcludeRecords = (PageSize * PageNumber) - PageSize;
                var modelList = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).Skip(ExcludeRecords).Take(PageSize).ToList();
                totalCount = _unitOfWork.GenericRepository<ApplicationUser>().GetAll(x => x.IsDoctor == true).ToList().Count;
                vmList = ConvertModelToViewModelList(modelList);
            }
            catch (Exception) { throw; }
            var result = new PagedResult<ApplicationUserViewModel>
            {
                Data = vmList,
                TotalItems = totalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
            return result;
        }
        public PagedResult<ApplicationUserViewModel> GetAllPatient(int PageNumber, int PageSize)
        { throw new NotImplementedException(); }

        public PagedResult<ApplicationUserViewModel> SearchDoctor(int pageNumber, int pageSize, string Spicility = null)
        {
            throw new NotImplementedException();
        }

        private List<ApplicationUserViewModel> ConvertModelToViewModelList(List<ApplicationUser> modelList)
        {
            return modelList.Select(x => new ApplicationUserViewModel(x)).ToList();
        }
    }
}
