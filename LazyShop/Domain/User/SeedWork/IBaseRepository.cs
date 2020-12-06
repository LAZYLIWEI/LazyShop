using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.User.SeedWork
{
    public interface IBaseRepository<T> where T : class, new()
    {
        List<T> SelectEntities(Expression<Func<T, bool>> whereLamdba);
        List<T> SelectPageEntities(int pageIndex, int pageSize, out int totalCount,
            Expression<Func<T, bool>> whereLamdba,
            Expression<Func<T, object>> orderbyLamdba, bool isAsc);
        bool DeleteEntity(T entity);
        bool UpdateEntity(T entity);
        T AddEntity(T entity);
        void BeginTran();
        void CommitTran();
        void RollbackTran();
    }
}
