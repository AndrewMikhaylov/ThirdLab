using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ThirdLab.DAL
{
    public class DatesRepository : IRepository<DatesToStay>
    {
        private HotelContext context;

        public DatesRepository(HotelContext context)
        {
            this.context = context;
        }
        
        public IEnumerable<DatesToStay> GetAll()
        {
            return context.DatesToStays.ToList();
        }

        public DatesToStay GetById(int id)
        {
            return context.DatesToStays.Find(id);
        }

        public void Create(DatesToStay item)
        {
            context.DatesToStays.Add(item);
        }

        public void Update(DatesToStay item)
        {
            context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(DatesToStay item)
        {
            DatesToStay dates = context.DatesToStays.Find(item);
            if (dates!=null)
            {
                context.DatesToStays.Remove(item);
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}