using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ThirdLab.DAL
{
    public class TouristRepository : IRepository<Tourist>
    {
        private HotelContext context;

        public TouristRepository(HotelContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<Tourist> GetAll()
        {
            return context.Tourists.ToList();
        }

        public Tourist GetById(int id)
        {
            return context.Tourists.Find(id);
        }

        public void Create(Tourist item)
        {
            context.Tourists.Add(item);
        }

        public void Update(Tourist item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(Tourist item)
        {
            Tourist room = context.Tourists.Find(item);
            if (room!=null)
            {
                context.Tourists.Remove(item);
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