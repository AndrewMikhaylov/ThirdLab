using System;

namespace ThirdLab.DAL
{
    public class Tourist
    {
        public int TouristId { get; set; }
        public string FullName { get; set; }
        public bool PayedForRoom { get; set; }
        public virtual DatesToStay DatesToStay { get; set; }
        public virtual Room Room { get; set; }
    }
}