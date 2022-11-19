using System;

namespace ThirdLab.DAL
{
    public interface IUnitOfWork : IDisposable
    {
        public void Save();
        public IRepository<Tourist> Tourists { get;}
        public IRepository<Room> Rooms { get;}
    }
}