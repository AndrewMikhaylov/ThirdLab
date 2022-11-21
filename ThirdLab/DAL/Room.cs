#nullable enable
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;


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
        public Category Category { get; set; }
        
        public virtual ICollection<DatesToStay> DatesToStay { get; set; }
        public virtual ICollection<Tourist>? Tourists { get; set; }
    }
}