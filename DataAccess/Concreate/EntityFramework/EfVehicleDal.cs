using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfVehicleDal : IVehicleDal
    {
        public void Add(Vehicle entity)
        {
            using (RentCarContext context=new RentCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Vehicle entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Vehicle Get(Expression<Func<Vehicle, bool>> filter)
        {
            using (RentCarContext context=new RentCarContext())
            {
                return context.Set<Vehicle>().SingleOrDefault(filter);

            }
        }

        public List<Vehicle> GetAll(Expression<Func<Vehicle, bool>> filter = null)
        {
            using (RentCarContext context=new RentCarContext())
            {
                return filter == null ? context.Set<Vehicle>().ToList()
                    : context.Set<Vehicle>().Where(filter).ToList();

            }
        }

        public void Update(Vehicle entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
       
    }
}
