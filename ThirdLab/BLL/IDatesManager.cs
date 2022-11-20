using System;
using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public interface IDatesManager
    {
        public DatesToStay AddDates(DateTime start, DateTime finish);
    }
}