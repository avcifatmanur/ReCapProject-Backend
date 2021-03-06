using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concreate.EntityFramework;
using Entities.Concreate;
using Entities.DTOs;
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
            Vehicle result = _vehicleDal.Get(v => v.Id == car.Id && v.VehicleName == car.VehicleName);
            if (result != null)
            {
                _vehicleDal.Delete(car);
                Console.WriteLine("Araç silindi!");
            }
            else
            {
                Console.WriteLine("Araç bilgileri hatalı!");
            }
        }

        public void Update(Vehicle car)
        {
            Vehicle result = _vehicleDal.Get(v => v.Id == car.Id);
            if (result != null)
            {
                _vehicleDal.Update(car);
                Console.WriteLine("Araç güncellendi!");
            }
            else
            {
                Console.WriteLine("Böyle bir araç yok!");
            }
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

        public Vehicle GetById(int id)
        {
            return _vehicleDal.Get(v => v.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _vehicleDal.GetCarDetails();
        }
    }
}
