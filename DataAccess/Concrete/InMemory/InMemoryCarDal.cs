using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            { 
                //new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=190000,ModelYear="1958",Car="Camaro temiz manuel"},
                //new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=130000,ModelYear="2008",Description="ford focus temiz manuel"},
                //new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=300000,ModelYear="2018",Description="nissan temiz otomatik"},
                //new Car{CarId=4,BrandId=4,ColorId=4,DailyPrice=270000,ModelYear="1999",Description="ferrari temiz otomatik"},
                //new Car{CarId=5,BrandId=5,ColorId=5,DailyPrice=255000,ModelYear="2020",Description="VW temiz otomatik"}


            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(car);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Car car)
        {
            return _cars;
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(Car car)
        {
            return _cars.Where(p => p.Id == car.Id).ToList();

        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carsToUptade = _cars.SingleOrDefault(p => p.Id == car.Id);
            carsToUptade.BrandId = car.BrandId;
            carsToUptade.ColorId = car.ColorId;
            carsToUptade.DailyPrice = car.DailyPrice;
            carsToUptade.CarName = car.CarName;
            carsToUptade.ModelYear = car.ModelYear;
        }
    }
}
