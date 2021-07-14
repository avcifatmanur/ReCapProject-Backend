using Core.Utilities.Results;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<CarImages> GetById(int imageId);
        IDataResult<List<CarImages>> GetImagesByCarId(int carId);
        IResult Add(IFormFile file, CarImages carImage);
        IResult Update(IFormFile file,CarImages carImage);
        IResult Delete(CarImages carImage);
    }
}
