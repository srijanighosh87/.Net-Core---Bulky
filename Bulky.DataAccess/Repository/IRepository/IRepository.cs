using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.Repository.IRepository
{
    //Repository pattern
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        //Expression<Func<T, bool>> filter
        //This is a parameter of the method.
        //It accepts an expression that represents a filter condition.
        //In this case, it's an expression tree (Expression) that takes a Func<T, bool> delegate.
        //The Func<T, bool> represents a function that takes an object of type T and returns a boolean value.
        T GetFirstOrDefault(Expression<Func<T, bool>> filter);

        void Insert(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
    }
}
