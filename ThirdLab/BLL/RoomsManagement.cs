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
            throw new NotImplementedException();
        }

        public void PayForRoomNow(Room room, DateTime[,] dates, Tourist tourist)
        {
            throw new NotImplementedException();
        }
    }
}