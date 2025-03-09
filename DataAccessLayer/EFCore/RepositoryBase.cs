using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly RepositoryContext _repositoryContext;
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext; 
        }
        public void Create(T entity)
        {
            try
            {
                _repositoryContext.Set<T>().Add(entity);
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                _repositoryContext.Remove(entity);
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            try
            {
              if(!trackChanges)
                {
                    return _repositoryContext.Set<T>().AsNoTracking();
                }
                else
                {
                    return _repositoryContext.Set<T>();
                   
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            try
            {
                if(!trackChanges)
                {
                    return _repositoryContext.Set<T>().Where(expression).AsNoTracking();
                }
                else
                {
                    return _repositoryContext.Set<T>().Where(expression);
                }
            }
            catch (Exception err)
            {

                throw new Exception(err.Message);
            }
        }

        public void Update(T entity) => _repositoryContext.Set<T>().Update(entity);

    }
}
