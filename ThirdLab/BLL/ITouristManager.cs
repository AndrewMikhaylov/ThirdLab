using ThirdLab.DAL;

namespace ThirdLab.BLL
{
    public interface ITouristManager
    {
        public Tourist CreateTourist(string fullName);
    }
}