using System;
using System.Collections.Generic;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public interface IRoomsManagement
    {
        public List<Room> ReturnRoomsAtPrice(Category category);

        public void BookRoom(Room room, DatesToStay dates, Tourist tourist);

        public List<Room> FindFreeRoomForDate(DatesToStay dates);

        public void PayForRoomOnBooking(Room room, DatesToStay dates, Tourist tourist);

        public void PayForRoomAfterBooking(Tourist tourist);
    }
}