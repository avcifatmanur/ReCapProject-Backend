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
        IResult Add(Vehicle car);
        IResult Update(Vehicle car);
        IResult Delete(Vehicle car);
        IResult AddTransactional(Vehicle car);
        IDataResult<List<Vehicle>> GetAll();
        IDataResult<Vehicle> GetById(int id);
        IDataResult<List<CarDetailDto>> GetCarsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailsById(int id);
        IDataResult<List<CarDetailDto>> GetCarDetailsByBrandAndColor(int brandId, int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        
    }
}
