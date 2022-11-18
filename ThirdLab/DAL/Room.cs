#nullable enable
using System;
using System.Collections.Generic;


namespace ThirdLab.DAL
{
    public enum Category
    {
        Cheap = 1200,
        Middle = 2400,
        Expensive = 3600
    }
    public class Room
    {
        public int RoomId { get; set; }
        public bool IsTaken { get; set; }
        public bool IsBooked { get; set; }
        public Category Category { get; set; }
        public DateTime[,]? BookedDates { get; set; }
        public virtual ICollection<Tourist>? Tourists { get; set; }
    }
}