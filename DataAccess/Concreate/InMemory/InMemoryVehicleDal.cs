using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.InMemory
{
    public class InMemoryVehicleDal:IVehicleDal
    {
        List<Vehicle> _cars;
        public InMemoryVehicleDal()
        {
            _cars = new List<Vehicle>
            {
                new Vehicle{ CarId =1,VehicleName="Renault Clio",BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=270, Description="otomatik"},
                new Vehicle{ CarId =2,VehicleName="Ford Fiesta", BrandId=2, ColorId=3, ModelYear=2018, DailyPrice=275, Description="manuel"},
                new Vehicle{ CarId =3,VehicleName="Ford Focus", BrandId=2, ColorId=4, ModelYear=2019, DailyPrice=280, Description="otomatik"},
                new Vehicle{ CarId =4,VehicleName="Volkswagen Polo",BrandId=3, ColorId=2, ModelYear=2016, DailyPrice=250, Description="manuel"},
                new Vehicle{ CarId =5,VehicleName="Volkswagen Jetta",BrandId=3, ColorId=1, ModelYear=2018, DailyPrice=275, Description="otomatik"},
                new Vehicle{ CarId =6,VehicleName="Volkswagen Passat",BrandId=3, ColorId=4, ModelYear=2019, DailyPrice=350, Description="otomatik"},
                new Vehicle{ CarId =7,VehicleName="BMW 520d" ,BrandId=4, ColorId=2, ModelYear=2020, DailyPrice=500, Description="otomatik"}

            };

        }

        public void Add(Vehicle vehicle)
        {
            _cars.Add(vehicle);
        }
        public void Update(Vehicle vehicle)
        {
            Vehicle updatedVehicle = _cars.SingleOrDefault(v => v.CarId == vehicle.CarId);
            updatedVehicle.BrandId = vehicle.BrandId;
            updatedVehicle.ColorId = vehicle.ColorId;
            updatedVehicle.ModelYear = vehicle.ModelYear;
            updatedVehicle.DailyPrice = vehicle.DailyPrice;
            updatedVehicle.Description = vehicle.Description;
        }

        public void Delete(Vehicle vehicle)
        {
            Vehicle deletedVehicle = _cars.SingleOrDefault(v=>v.CarId == vehicle.CarId);
            _cars.Remove(deletedVehicle);
        }

        public Vehicle Get(Expression<Func<Vehicle, bool>> filter)
        {
            throw new NotImplementedException();
        }


        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<Vehicle> GetAll(Expression<Func<Vehicle, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
