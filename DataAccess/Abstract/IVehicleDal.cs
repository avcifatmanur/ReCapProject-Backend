using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concreate;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;


namespace DataAccess.Abstract
{
    public interface IVehicleDal:IEntityRepository<Vehicle>
    {
        List<CarDetailDto> GetCarDetails();
    }
}
