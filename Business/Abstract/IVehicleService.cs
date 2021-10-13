using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<List<Vehicle>> GetAll();
        IDataResult<Vehicle> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Vehicle>> GetCarsByBrandId(int id);
        IDataResult<List<Vehicle>> GetCarsByColorId(int id);
        IResult Add(Vehicle car);
        IResult Update(Vehicle car);
        IResult Delete(Vehicle car);
        IResult AddTransactional(Vehicle car);

    }
}
