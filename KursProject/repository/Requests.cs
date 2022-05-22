using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightBooking.reposirory;
using LightBooking.modelDB;

namespace LightBooking.repository
{
    public class Requests
    {
        public static Dictionary<string, string> Login(string login, string pass)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                AUTHORIZATION auth = unitOfWork.AuthRepository.GetAll().Where(x => x.login == login && x.password == pass).FirstOrDefault();
                switch (auth.status)
                {
                    case 1: //administrator
                        {
                            Dictionary<string, string> result = new Dictionary<string, string>();
                            result.Add("Id", auth.Id.ToString());
                            result.Add("status", auth.status.ToString());
                            return result;
                        }
                    case 2: //driver
                        {
                            DRIVER driver = unitOfWork.DriverRepository.GetAll().Where(x => x.Auth_id == auth.Id).FirstOrDefault();
                            Dictionary<string, string> result = new Dictionary<string, string>();
                            result.Add("Id", driver.Id.ToString());
                            result.Add("status", auth.status.ToString());
                            result.Add("surname", driver.surname);
                            result.Add("name", driver.name);
                            result.Add("number_car", driver.number_car);
                            result.Add("brand_car", driver.brand_car);
                            result.Add("color_car", driver.color_car);
                            result.Add("count_seats", driver.brand_car);
                            result.Add("phone_number", driver.phone_number);
                            result.Add("photo_car", driver.photo_car);
                            return result;
                        }
                    case 3: //users
                        {
                            USER user = unitOfWork.UsersRepository.GetAll().Where(x => x.Auth_id == auth.Id).FirstOrDefault();
                            Dictionary<string, string> result = new Dictionary<string, string>();
                            result.Add("Id", user.Id.ToString());
                            result.Add("status", auth.status.ToString());
                            result.Add("name", user.name);
                            result.Add("surname", user.surname);
                            result.Add("phone_number", user.phone_number);
                            result.Add("photo", user.photo);
                            result.Add("email", user.email.ToString());
                            return result;
                        }
                }
            }
            return null;
        }

        public static string Reg(string Login, string Pass, string Name, string Surname, string PhoneNumber, string email, string Photo)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                AUTHORIZATION auth = new AUTHORIZATION() { login = Login, password = Pass, status = 3 };
                unitOfWork.AuthRepository.Add(auth);
                unitOfWork.Save();
                AUTHORIZATION auth2 = unitOfWork.AuthRepository.GetAll().Where(x => x.login == Login && x.password == Pass).First();
                USER user = new USER() {Auth_id = auth2.Id, name = Name, surname = Surname, phone_number = PhoneNumber, email = email, photo = Photo};
                unitOfWork.UsersRepository.Add(user);
                unitOfWork.Save();
            }
            return "Регистрация прошла успешна! ЮХУУУУУ";
        }

        public static bool AddDriver(string Name, string Surname, string Login, string Pass, string PhoneNumber, string number_car, string brand_car, string color_car, string CountSeats, string Photo)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                AUTHORIZATION auth = new AUTHORIZATION() { login = Login, password = Pass, status = 2 };
                unitOfWork.AuthRepository.Add(auth);
                unitOfWork.Save();
                AUTHORIZATION auth2 = unitOfWork.AuthRepository.GetAll().Where(x => x.login == Login && x.password == Pass).First();
                DRIVER driver = new DRIVER() { Auth_id = auth2.Id, name = Name, surname = Surname, phone_number = PhoneNumber, number_car = number_car, brand_car = brand_car, color_car = color_car, count_seats = int.Parse(CountSeats), photo_car = Photo};
                unitOfWork.DriverRepository.Add(driver);
                unitOfWork.Save();
            }
            return true;
        }

        public static bool AddFlight(string direction, DateTime date, string time, DRIVER driver)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                FLIGHT flight = new FLIGHT() {direction = direction, date = date, time = TimeSpan.Parse(time), Id_driver = driver.Id};
                unitOfWork.FlightRepository.Add(flight);
                unitOfWork.Save();
            }
            return true;
        }
        public static bool AddOrder(DateTime date, string time, USER user, FLIGHT flight)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                ORDER order = new ORDER() { date = date, time = TimeSpan.Parse(time), user_id = user.Id, flight = flight.Id };
                unitOfWork.OrderRepository.Add(order);
                unitOfWork.Save();
            }
            return true;
        }

        public static List<DRIVER> GetDrivers()
        {
            List<DRIVER> drivers = new List<DRIVER>();
            using (UnitOfWork unitsOfWork = new UnitOfWork())
            {
                drivers = unitsOfWork.DriverRepository.GetAll();
                return drivers;
            }
        }

        public static List<FLIGHT> GetFlights()
        {
            List<FLIGHT> flight = new List<FLIGHT>();
            using (UnitOfWork unitsOfWork = new UnitOfWork())
            {
                flight = unitsOfWork.FlightRepository.GetAll();
                return flight;
            }
        }
        
        public static List<ORDER> GetOrders()
        {
            List<ORDER> orders = new List<ORDER>();
            using (UnitOfWork unitsOfWork = new UnitOfWork())
            {
                orders = unitsOfWork.OrderRepository.GetAll();
                return orders;
            }
        }
        
        public static List<ORDER> GetUserOrders(USER user)
        {
            List<ORDER> orders = new List<ORDER>();
            using (UnitOfWork unitsOfWork = new UnitOfWork())
            {
                orders = unitsOfWork.OrderRepository.GetAll().Where(x => x.user_id == user.Id).ToList();
                return orders;
            }
        }
        
        public static List<USER> GetUsers()
        {
            List<USER> users = new List<USER>();
            using (UnitOfWork unitsOfWork = new UnitOfWork())
            {
                users = unitsOfWork.UsersRepository.GetAll();
                return users;
            }
        }
        public static bool DeleteUser(USER user)
        {
            using(UnitOfWork unitsOfWork = new UnitOfWork())
            {
                
                foreach (ORDER order in user.ORDERS) {
                    unitsOfWork.OrderRepository.Remove(order.Id);
                        }
                unitsOfWork.Save();
                unitsOfWork.UsersRepository.Remove(user.Id);
                unitsOfWork.Save();
                unitsOfWork.AuthRepository.Remove(user.AUTHORIZATION.Id);
                unitsOfWork.Save();
            }
            return true;
        }
        public static bool UpdateUser(USER user, string password)
        {
            using(UnitOfWork unitOfWork = new UnitOfWork())
            {
                USER userToUpdate = unitOfWork.UsersRepository.Get(user.Id);
                userToUpdate.email = user.email;
                userToUpdate.phone_number = user.phone_number;
                userToUpdate.surname = user.surname;
                userToUpdate.name = user.name;
                userToUpdate.photo = user.photo;
                unitOfWork.Save();
                if (password != null) {
                    AUTHORIZATION auth = unitOfWork.AuthRepository.Get(user.AUTHORIZATION.Id);
                    auth.password = password;
                        }
            }
            return true;
        } 

    }
}
