using System;

namespace ThirdLab.DAL
{
    public class DatesToStay
    {
        public int DatesId { get; set; }
        public DateTime StartBookedDates { get; set; }
        public DateTime FinallBookedDates { get; set; }
        public virtual Tourist Tourist { get; set; }
        public virtual Room Room { get; set; }
    }
}