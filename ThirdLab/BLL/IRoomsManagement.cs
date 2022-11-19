using System;
using System.Collections.Generic;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public interface IRoomsManagement
    {
        public List<Room> ReturnRoomsAtPrice(Category category);

        public void BookRoom(Room room, DateTime[,] dates, Tourist tourist);

        public List<Room> FindFreeRoomForDate(DateTime[,] dates);

        public void PayForRoomNow(Room room, DateTime[,] dates, Tourist tourist);
    }
}