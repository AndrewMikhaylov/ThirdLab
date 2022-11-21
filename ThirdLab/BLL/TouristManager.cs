using System.Linq;
using Ninject;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public class TouristManager : ITouristManager
    {
        private IUnitOfWork _unitOfWork;
        TouristManager(IUnitOfWork unitOfWork)
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _unitOfWork = ninjectKernel.Get<IUnitOfWork>();
        }
        public int CreateTourist(string fullName)
        {
            Tourist tourist = new Tourist
            {
                FullName = fullName,
                TouristId = _unitOfWork.Tourists.GetAll().ToList().Count
            };
            _unitOfWork.Tourists.Create(tourist);
            _unitOfWork.Save();
            return tourist.TouristId;
        }
    }
}