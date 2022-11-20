using System;
using System.Collections.Generic;
using System.Linq;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public class RoomsManagement : IRoomsManagement
    {
        private IUnitOfWork _unitOfWork;

        public RoomsManagement(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public List<Room> ReturnRoomsAtPrice(Category category)
        {
            
            return _unitOfWork.Rooms.GetAll().Where(c => c.Category == category).ToList();
        }

        public void BookRoom(Room room, DatesToStay dates, Tourist tourist)
        {
            if (!_unitOfWork.Rooms.GetAll().ToList().Contains(room))
            {
                throw new ArgumentOutOfRangeException("room");
            }
            if (!RoomChecker(room,dates))
            {
                throw new ArgumentOutOfRangeException();
            }

            dates.Room = room;
            dates.Tourist = tourist;
            _unitOfWork.DatesToStay.Update(dates);
            tourist.Room = room;
            tourist.DatesToStay = dates;
            tourist.PayedForRoom = false;
            _unitOfWork.Tourists.Update(tourist);
            room.IsBooked = true;
            room.Tourists.Add(tourist);
            room.DatesToStay.Add(dates);
            _unitOfWork.Rooms.Update(room);
            _unitOfWork.Save();

        }

        public List<Room> FindFreeRoomForDate(DatesToStay dates)
        {
            if (dates.StartBookedDates > dates.FinallBookedDates)
            {
                throw new ArgumentOutOfRangeException(nameof(dates));
            }

            return _unitOfWork.Rooms.GetAll().Where(r => RoomChecker(r, dates)).ToList();
        }

        public void PayForRoomOnBooking(Room room, DatesToStay dates, Tourist tourist)
        {
            if (!_unitOfWork.Rooms.GetAll().ToList().Contains(room))
            {
                throw new ArgumentOutOfRangeException("room");
            }

            if (!RoomChecker(room,dates))
            {
                throw new ArgumentOutOfRangeException();
            }

            dates.Room = room;
            dates.Tourist = tourist;
            _unitOfWork.DatesToStay.Update(dates);
            tourist.PayedForRoom = true;
            tourist.DatesToStay = dates;
            tourist.Room = room;
            _unitOfWork.Tourists.Update(tourist);
            room.IsTaken = true;
            room.IsBooked = true;
            room.Tourists.Add(tourist);
            room.DatesToStay.Add(dates);
            _unitOfWork.Rooms.Update(room);
            _unitOfWork.Save();
        }

        public void PayForRoomAfterBooking(Tourist tourist)
        {
            if (!_unitOfWork.Tourists.GetAll().ToList().Contains(tourist))
            {
                throw new ArgumentOutOfRangeException("tourist");
            }

            tourist.PayedForRoom = true;
            _unitOfWork.Tourists.Update(tourist);
            tourist.Room.IsTaken = true;
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