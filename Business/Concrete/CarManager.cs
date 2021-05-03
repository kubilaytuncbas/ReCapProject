using Business.Abstract;
using Business.Constants;
using Business.DependencyResolvers.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        IBrandService _brandService;
        ICarDal _carDal;

        public CarManager(ICarDal carDal,IBrandService brandService)
        {
            _carDal = carDal;
            _brandService = brandService;
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
            //business codes
            IResult result = BusinessRules.Run(CheckIfCountOfCarId(car.Id), CheckIfSameName(car.CarName), CheckIfCountOfBrand());
             
            if (result!=null)
            {
                return result;
            }
            _carDal.Add(car);
            return new SuccessResult();
            
            
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
            
        }

        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour==16)
            {
                return new ErrorDataResult<List<Car>>(_carDal.GetAll(), Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.CarAdded);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return  new SuccessDataResult<Car>(_carDal.Get(p=>p.Id==carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(b => b.BrandId == id));
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id));
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
        private IResult CheckIfCountOfCarId(int carId)
        {
            var result = _carDal.GetAll(p => p.Id == carId).Count;
            if (result >= 10)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IResult CheckIfSameName(string carName)
        {
            var result2 = _carDal.GetAll(p => p.CarName == carName).Any();
            if (result2)
            {
                return new ErrorResult(Messages.SameCarName);
            }
            return new SuccessResult();

        }
        private IResult CheckIfCountOfBrand()
        {
            var result2 = _brandService.GetAll();
            if (result2.Data.Count>=15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
