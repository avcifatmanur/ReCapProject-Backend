using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        List<Vehicle> GetCarsByBrandId(int id);
        List<Vehicle> GetCarsByColorId(int id);
        void Add(Vehicle car);
        void Update(Vehicle car);
        void Delete(Vehicle car);
      
    }
}
