using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        List<Vehicle> GetAll();
        Vehicle GetById(int id);
        List<CarDetailDto> GetCarDetails();
        void Add(Vehicle car);
        void Update(Vehicle car);
        void Delete(Vehicle car);
      
    }
}
