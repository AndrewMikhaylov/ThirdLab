using System;

namespace ThirdLab.DAL
{
    public class Tourist
    {
        public int TouristId { get; set; }
        public string FullName { get; set; }
        public bool PayedForRoom { get; set; }
        public DateTime StartBookedDate { get; set; }
        public DateTime EndBookedDate { get; set; }
        
        public virtual Room Room { get; set; }
    }
}