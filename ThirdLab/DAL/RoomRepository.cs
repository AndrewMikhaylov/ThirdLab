using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ThirdLab.DAL
{
    public class RoomRepository : IRepository<Room>
    {
        private HotelContext context;

        public RoomRepository(HotelContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<Room> GetAll()
        {
            return context.Rooms.ToList();
        }

        public Room GetById(int id)
        {
            return context.Rooms.Find(id);
        }

        public void Create(Room item)
        {
            context.Rooms.Add(item);
        }

        public void Update(Room item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Room item)
        {
            Room room = context.Rooms.Find(item);
            if (room!=null)
            {
                context.Rooms.Remove(item);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected void Dispose(bool disposing)
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