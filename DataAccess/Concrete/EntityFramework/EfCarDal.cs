using DataAccess.Abstract;
using Entities.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICarDal
    {
        public void Add(Car entity)
        {
            using (CarsInfoContext context=new CarsInfoContext())
            {
                if (entity.Description.Length>=2 && entity.DailyPrice>0)
                {

                    var addedEntity = context.Entry(entity);
                    addedEntity.State = EntityState.Added;
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("En az 2 karakter kullanabilirsiniz");
                }
                
            }
        }

        public void Delete(Car entity)
        {
            using (CarsInfoContext context = new CarsInfoContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (CarsInfoContext context = new CarsInfoContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (CarsInfoContext context = new CarsInfoContext())
            {
                return filter == null ? context.Set<Car>().ToList() : context.Set<Car>().Where(filter).ToList();
            }
        }

        public void Uptade(Car entity)
        {
            using (CarsInfoContext context = new CarsInfoContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
                
            }
        }
    }
}
