using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
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
                new Vehicle{ Id =1, BrandId=1, ColorId=1, ModelYear=2018, DailyPrice=270, Description="sigortalı"},
                new Vehicle{ Id =2, BrandId=2, ColorId=3, ModelYear=2018, DailyPrice=275, Description="sigortasız"},
                new Vehicle{ Id =3, BrandId=2, ColorId=4, ModelYear=2019, DailyPrice=280, Description="sigortalı"},
                new Vehicle{ Id =4, BrandId=3, ColorId=2, ModelYear=2016, DailyPrice=250, Description="sigortasız"},
                new Vehicle{ Id =5, BrandId=3, ColorId=1, ModelYear=2018, DailyPrice=275, Description="sigortasız"},
                new Vehicle{ Id =6, BrandId=3, ColorId=4, ModelYear=2019, DailyPrice=280, Description="sigortalı"},
                new Vehicle{ Id =7, BrandId=4, ColorId=2, ModelYear=2020, DailyPrice=500, Description="sigortalı"}

            };

        }

        public void Add(Vehicle vehicle)
        {
            _cars.Add(vehicle);
        }

        public void Delete(Vehicle vehicle)
        {
            Vehicle deletedVehicle = _cars.SingleOrDefault(v=>v.Id==vehicle.Id);
            _cars.Remove(deletedVehicle);
        }

        public List<Vehicle> GetAll()
        {
            return _cars;
        }

        public int GetById(Vehicle vehicle)
        {
            return vehicle.Id;
        }

        public void Update(Vehicle vehicle)
        {
            Vehicle updatedVehicle = _cars.SingleOrDefault(v => v.Id == vehicle.Id);
            updatedVehicle.BrandId = vehicle.BrandId;
            updatedVehicle.ColorId = vehicle.ColorId;
            updatedVehicle.ModelYear = vehicle.ModelYear;
            updatedVehicle.DailyPrice = vehicle.DailyPrice;
            updatedVehicle.Description = vehicle.Description;
        }
    }
}
