using System;

namespace ThirdLab.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public void Save();
        public TouristRepository Tourists { get;}
        public RoomRepository Rooms { get;}
    }
}