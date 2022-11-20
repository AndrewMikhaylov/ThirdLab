using System.Data.Entity;

namespace ThirdLab.DAL
{
    public class HotelContext : DbContext
    {
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Tourist> Tourists { get; set; }
        
        public DbSet<DatesToStay> DatesToStays { get; set; }
    }
}