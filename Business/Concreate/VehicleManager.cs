using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class VehicleManager : IVehicleService
    {
        IVehicleDal _vehicleDal;
        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public void Add(Vehicle car)
        {
            if (car.VehicleName.Length>=2 && car.DailyPrice>0)
            {
                _vehicleDal.Add(car);
                Console.WriteLine("Yeni araç eklendi!");
            }
            else {
                Console.WriteLine("Araç ismi en az 2 karakter ve günlük ücret sıfırdan büyük olmalı!");
            }
            
        }

        public void Delete(Vehicle car)
        {
            _vehicleDal.Delete(car);
            Console.WriteLine("Araç silindi!");
        }

        public void Update(Vehicle car)
        {
            _vehicleDal.Update(car);
            Console.WriteLine("Araç güncellendi!");
        }

        public List<Vehicle> GetAll()
        {
            return _vehicleDal.GetAll(); 
        }

        public List<Vehicle> GetCarsByBrandId(int id)
        {
            return _vehicleDal.GetAll(c => c.BrandId == id);
        }

        public List<Vehicle> GetCarsByColorId(int id)
        {
            return _vehicleDal.GetAll(c => c.ColorId == id);
        }
    }
}
