using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentCarContext>, IRentalDal
    {
        public void Add(Rental entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Rental entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return context.Set<Rental>().SingleOrDefault(filter);

            }
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return filter == null ? context.Set<Rental>().ToList()
                    : context.Set<Rental>().Where(filter).ToList();

            }
        }

        public void Update(Rental entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentCarContext context = new RentCarContext())
            {
                var result = from v in context.Cars
                             join r in context.Rentals
                             on v.CarId equals r.CarId
                             join c in context.Customers
                             on r.CustomerNo equals c.CustomerId
                             join b in context.Brands
                             on v.BrandId equals b.BrandId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = b.BrandName,
                                 CustomerName = c.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate

                             };
                return result.ToList();
            }
        }
    }
}
