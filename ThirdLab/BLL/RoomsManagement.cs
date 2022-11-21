using System;
using System.Collections.Generic;
using System.Linq;
using ThirdLab.DAL;
using Ninject;
namespace ThirdLab.BLL
{
    public class RoomsManagement : IRoomsManagement
    {
        private readonly IUnitOfWork _unitOfWork;
        public RoomsManagement()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            _unitOfWork = ninjectKernel.Get<IUnitOfWork>();
        }
        public List<Room> ReturnRoomsAtPrice(Category category)
        {
            
            return _unitOfWork.Rooms.GetAll().Where(c => c.Category == category).ToList();
        }

        public void BookRoom(int roomId, int datesId, int touristId)
        {
            var room = _unitOfWork.Rooms.GetById(roomId);
            var dates = _unitOfWork.DatesToStay.GetById(datesId);
            var tourist = _unitOfWork.Tourists.GetById(touristId);
            if (!_unitOfWork.Rooms.GetAll().ToList().Contains(room) || !RoomChecker(room,dates))
            {
                throw new ArgumentOutOfRangeException("room");
            }

            dates.Room = room;
            _unitOfWork.DatesToStay.Update(dates);
            tourist.Room = room;
            tourist.PayedForRoom = false;
            _unitOfWork.Tourists.Update(tourist);
            room.Tourists.Add(tourist);
            room.DatesToStay.Add(dates);
            _unitOfWork.Rooms.Update(room);
            _unitOfWork.Save();

        }

        public List<Room> FindFreeRoomForDate(int datesId)
        {
            var dates = _unitOfWork.DatesToStay.GetById(datesId);
            if (dates.StartBookedDates > dates.FinallBookedDates)
            {
                throw new ArgumentOutOfRangeException(nameof(dates));
            }

            return _unitOfWork.Rooms.GetAll().Where(r => RoomChecker(r, dates)).ToList();
        }

        public void PayForRoomOnBooking(int roomId, int datesId, int touristId)
        {
            var room = _unitOfWork.Rooms.GetById(roomId);
            var dates = _unitOfWork.DatesToStay.GetById(datesId);
            var tourist = _unitOfWork.Tourists.GetById(touristId);
            if (!_unitOfWork.Rooms.GetAll().ToList().Contains(room) || !RoomChecker(room,dates))
            {
                throw new ArgumentOutOfRangeException("room");
            }
            dates.Room = room;
            _unitOfWork.DatesToStay.Update(dates);
            tourist.PayedForRoom = true;
            tourist.DatesToStay = dates;
            tourist.Room = room;
            _unitOfWork.Tourists.Update(tourist);
            room.Tourists.Add(tourist);
            room.DatesToStay.Add(dates);
            _unitOfWork.Rooms.Update(room);
            _unitOfWork.Save();
        }

        public void PayForRoomAfterBooking(int touristId)
        {
            var tourist = _unitOfWork.Tourists.GetById(touristId);
            if (!_unitOfWork.Tourists.GetAll().ToList().Contains(tourist))
            {
                throw new ArgumentOutOfRangeException("tourist");
            }

            tourist.PayedForRoom = true;
            _unitOfWork.Tourists.Update(tourist);
            _unitOfWork.Rooms.Update(tourist.Room);
            _unitOfWork.Save();
        }


        private bool RoomChecker(Room room, DatesToStay dates)
        {
            int i = 0;
            foreach (DatesToStay datesToStay in room.DatesToStay)
            {
                if (datesToStay.StartBookedDates<=dates.StartBookedDates && datesToStay.FinallBookedDates>=dates.FinallBookedDates)
                {
                    return false;
                }
            }

            return true;
        }
    }
}