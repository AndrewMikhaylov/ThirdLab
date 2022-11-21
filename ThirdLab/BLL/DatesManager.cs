using System;
using System.Linq;
using Ninject;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public class DatesManager : IDatesManager
    {
        private IUnitOfWork _unitOfWork;
        DatesManager(IUnitOfWork unitOfWork)
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _unitOfWork = ninjectKernel.Get<IUnitOfWork>();
        }
        public int AddDates(DateTime start, DateTime finish, int touristId)
        {
            DatesToStay datesToStay = new DatesToStay
            {
                StartBookedDates = start,
                FinallBookedDates = finish,
                DatesId = _unitOfWork.DatesToStay.GetAll().ToList().Count,
                Tourist = _unitOfWork.Tourists.GetById(touristId)
            };
            _unitOfWork.Tourists.GetById(touristId).DatesToStay = datesToStay;
            _unitOfWork.Tourists.Update(_unitOfWork.Tourists.GetById(touristId));
            _unitOfWork.DatesToStay.Create(datesToStay);
            _unitOfWork.Save();
            return datesToStay.DatesId;
        }
    }
}