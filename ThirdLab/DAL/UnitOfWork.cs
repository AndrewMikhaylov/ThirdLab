﻿using System;

namespace ThirdLab.DAL
{
    public class UnitOfWork:IUnitOfWork
    {
        private HotelContext _context = new HotelContext();
        private IRepository<Room> _roomRepository;
        private IRepository<Tourist> _touristRepository;

        public IRepository<Room> Rooms
        {
            get
            {
                if (_roomRepository==null)
                {
                    _roomRepository = new RoomRepository(_context);
                }

                return _roomRepository;
            }
        }
        
        public IRepository<Tourist> Tourists
        {
            get
            {
                if (_touristRepository==null)
                {
                    _touristRepository= new TouristRepository(_context);
                }

                return _touristRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
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