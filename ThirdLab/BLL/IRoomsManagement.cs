using System;
using System.Collections.Generic;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public interface IRoomsManagement
    {
        public List<Room> ReturnRoomsAtPrice(Category category);

        public void BookRoom(int roomId, int datesId, int touristId);

        public List<Room> FindFreeRoomForDate(int datesId);

        public void PayForRoomOnBooking(int roomId, int datesId, int touristId);

        public void PayForRoomAfterBooking(int touristId);
    }
}