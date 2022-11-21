using System;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public interface IDatesManager
    {
        public int AddDates(DateTime start, DateTime finish, int touristId);
    }
}