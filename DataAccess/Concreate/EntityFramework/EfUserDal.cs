using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concreate.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, RentCarContext>, IUserDal
    {
        public void Add(User entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (RentCarContext context = new RentCarContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return context.Set<User>().SingleOrDefault(filter);

            }
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (RentCarContext context = new RentCarContext())
            {
                return filter == null ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();

            }
        }

        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new RentCarContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList(); 

            }
        }

        public void Update(User entity)
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
