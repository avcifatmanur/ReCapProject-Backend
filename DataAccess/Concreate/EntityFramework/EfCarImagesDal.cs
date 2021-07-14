using Core.DataAccess.EntityFramework;
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
    public class EfCarImagesDal : EfEntityRepositoryBase<CarImages, RentCarContext>, ICarImagesDal
    {
        public void Add(CarImages entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public CarImages Get(Expression<Func<CarImages, bool>> filter)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return context.Set<CarImages>().SingleOrDefault(filter);

            }
        }

        public List<CarImages> GetAll(Expression<Func<CarImages, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return filter == null ? context.Set<CarImages>().ToList()
                    : context.Set<CarImages>().Where(filter).ToList();

            }
        }

        public void Update(Color entity)
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
