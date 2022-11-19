using System;
using System.Collections.Generic;
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
        public List<Room> ReturnRoomsAtPrice()
        {
            throw new NotImplementedException();
        }

        public void BookRoom(Room room, DateTime[,] dates, Tourist tourist)
        {
            throw new NotImplementedException();
        }

        public List<Room> FindFreeRoomForDate(DateTime[,] dates)
        {
            throw new NotImplementedException();
        }

        public void PayForRoomNow(Room room, DateTime[,] dates, Tourist tourist)
        {
            throw new NotImplementedException();
        }
    }
}