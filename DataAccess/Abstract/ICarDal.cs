using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetAll(Car car);
        List<Car> GetById(Car car);
        void Add(Car car);
        void Delete(Car car);
        void Uptade(Car car);
        List<Car> GetAll();
    }
}
