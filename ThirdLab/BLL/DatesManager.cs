using System;
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
        public DatesToStay AddDates(DateTime start, DateTime finish)
        {
            DatesToStay datesToStay = new DatesToStay
            {
                StartBookedDates = start,
                FinallBookedDates = finish
            };
            _unitOfWork.DatesToStay.Create(datesToStay);
            _unitOfWork.Save();
            return datesToStay;
        }
    }
}