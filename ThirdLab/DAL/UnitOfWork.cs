using System;

namespace ThirdLab.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        private HotelContext context = new HotelContext();
        private IRepository<Room> roomRepository;
        private IRepository<Tourist> touristRepository;

        public RoomRepository Rooms
        {
            get
            {
                if (roomRepository==null)
                {
                    roomRepository = new RoomRepository(context);
                }

                return (RoomRepository)roomRepository;
            }
        }
        
        public TouristRepository Tourists
        {
            get
            {
                if (touristRepository==null)
                {
                    touristRepository= new TouristRepository(context);
                }

                return (TouristRepository)touristRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}