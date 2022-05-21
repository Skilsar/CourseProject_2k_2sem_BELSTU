using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBooking.modelDB;

namespace LightBooking.repository
{
    public class UnitOfWork : IDisposable
    {
        private model context;

        private Repository<AUTHORIZATION> authRepository;
        private Repository<FLIGHT> flightRepository;
        private Repository<DRIVER> driverRepository;
        private Repository<ORDER> orderRepository;
        private Repository<USER> usersRepository;

        public UnitOfWork(){
            context = new model();
        }

        public Repository<AUTHORIZATION> AuthRepository
        {
            get
            {
                if (authRepository == null)
                {
                    authRepository = new Repository<AUTHORIZATION>(context);
                }
                return authRepository;
            }
        }
        public Repository<FLIGHT> FlightRepository
        {
            get {
                if (flightRepository == null)
                {
                    flightRepository = new Repository<FLIGHT>(context);
                }
                return flightRepository; 
            }
        }

        public Repository<DRIVER> DriverRepository
        {
            get
            {
                if (driverRepository == null)
                {
                    driverRepository = new Repository<DRIVER>(context);
                }
                return driverRepository;
            }
        }

        public Repository<USER> UsersRepository
        {
            get
            {
                if (usersRepository == null)
                {
                    usersRepository = new Repository<USER>(context);
                }
                return usersRepository;
            }
        }

        public Repository<ORDER> OrderRepository
        {
            get
            {
                if (orderRepository == null)
                {
                    orderRepository = new Repository<ORDER> (context);
                }
                return orderRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

}
