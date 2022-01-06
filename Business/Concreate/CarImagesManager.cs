using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concreate
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;

        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        [ValidationAspect(typeof(CarImagesValidator))]

        public IResult Add(IFormFile file, CarImages carImage)
        {
            var imageCount = _carImagesDal.GetAll(c => c.CarId == carImage.CarId).Count;

            if (imageCount >= 5)
            {
                return new ErrorResult(Messages.CarCheckImageLimited);
            }

            var imageResult = FileHelper.Add(file);

            if (!imageResult.Success)
            {
                return new ErrorResult(imageResult.Message);
            }
            carImage.ImagePath = CreateNewPath(file);
            _carImagesDal.Add(carImage);
            return new SuccessResult(Messages.AddedCarImages);
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Delete(CarImages carImage)
        {
            var image = _carImagesDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.NotFoundImage);
            }
            FileHelper.Delete(image.ImagePath);
            _carImagesDal.Delete(carImage);
            return new SuccessResult(Messages.DeletedImage);
        }
        [ValidationAspect(typeof(CarImagesValidator))]
        public IResult Update(IFormFile file, CarImages carImage)
        {
            var image = _carImagesDal.Get(c => c.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult(Messages.NotFoundImage);
            }
            var updatedFile = FileHelper.Update(file,image.ImagePath);
            carImage.ImagePath = CreateNewPath(file);
            //carImage.ImagePath = updatedFile;
            carImage.Date = DateTime.Now;
            _carImagesDal.Update(carImage);
            return new SuccessResult(Messages.UpdatedImage);

        }

        public IDataResult<List<CarImages>> GetAll()
        {
            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll());
        }

        [ValidationAspect(typeof(CarImagesValidator))]
        public IDataResult<CarImages> GetById(int imageId)
        {
            return new SuccessDataResult<CarImages>(_carImagesDal.Get(c => c.Id == imageId));
        }

       
        public IDataResult<List<CarImages>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImages>>(result.Message);
            }

            return new SuccessDataResult<List<CarImages>>(CheckIfCarImageNull(carId).Data);
        }
        private string CreateNewPath(IFormFile file)
        {
            var fileInfo = new FileInfo(file.FileName);
            var newPath =
                $@"{Environment.CurrentDirectory}\wwwroot\Images\{Guid.NewGuid()}_{DateTime.Now.Month}_{DateTime.Now.Day}_{DateTime.Now.Year}{fileInfo.Extension}";

            return newPath;
        }


        private IResult CheckIfImageLimit(int carId)
        {
            var carImageCount = _carImagesDal.GetAll(c => c.CarId == carId).Count;
            if (carImageCount>5)
            {
                return new ErrorResult(Messages.CarCheckImageLimited);
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImages>> CheckIfCarImageNull(int carImageId)
        {
            try
            {
                string path = Environment.CurrentDirectory + @"\images\logo.jpg";
                var result = _carImagesDal.GetAll(c => c.CarId == carImageId).Any();
                if (!result)
                {
                    List<CarImages> carimage = new List<CarImages>();
                    carimage.Add(new CarImages { CarId = carImageId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImages>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImages>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImages>>(_carImagesDal.GetAll(p => p.CarId == carImageId).ToList());
        }
    }
}
