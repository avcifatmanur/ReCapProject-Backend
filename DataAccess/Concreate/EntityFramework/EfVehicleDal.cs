using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfVehicleDal :EfEntityRepositoryBase<Vehicle,RentCarContext> , IVehicleDal
    {
       
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {

                var result = from v in context.Cars
                             join b in context.Brands on v.BrandId equals b.BrandId
                             join c in context.Colors on v.ColorId equals c.ColorId
                             let image=(from img in context.CarImage where v.CarId==img.CarId
                                        select img.ImagePath)
                             select new CarDetailDto
                             {
                                 carId = v.CarId,
                                 brandId=b.BrandId,
                                 colorId=c.ColorId,
                                 carName = v.VehicleName,
                                 brandName = b.BrandName,
                                 colorName = c.ColorName,
                                 DailyPrice = v.DailyPrice,
                                 ModelYear = v.ModelYear,
                                 Description = v.Description,
                                 ImagePath = image.Any()? image.FirstOrDefault(): new CarImages
                                 {
                                     ImagePath= "images/logo.jpg"
                                 }.ImagePath

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }
 
    }
}
