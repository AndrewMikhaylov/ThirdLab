namespace ThirdLab.BLL
{
    public interface IGetSaveService<T>
    {
        public T ReadData();
        public void SaveData(T data);
    }
}