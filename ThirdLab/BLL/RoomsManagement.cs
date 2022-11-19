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

        public void BookRoom(Room room, DateTime[,] dates, Tourist tourist)
        {
            
        }

        public List<Room> FindFreeRoomForDate(DateTime[,] dates)
        {
            if (dates[0,0]> dates[0,1])
            {
                throw new ArgumentOutOfRangeException(nameof(dates));
            }

            var rooms = _unitOfWork.Rooms.GetAll().Where(r => RoomChecker(r, dates)).ToList();

            return rooms;
        }

        public void PayForRoomNow(Room room, DateTime[,] dates, Tourist tourist)
        {
            throw new NotImplementedException();
        }

        private bool RoomChecker(Room room, DateTime[,] dates)
        {
            int i = 0;
            foreach (DateTime startDate in room.StartBookedDates)
            {
                if (startDate<=dates[0,0] && room.FinallBookedDates[i]>=dates[1,0])
                {
                    return false;
                }
            }

            return true;
        }
    }
}