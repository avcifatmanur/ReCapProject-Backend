using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Abstract
{
    public interface IVehicleDal
    {
        int GetById(Vehicle vehicle);
        List<Vehicle> GetAll();
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        void Delete(Vehicle vehicle);


    }
}
