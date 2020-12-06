using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Domain.User.SeedWork
{
    public class BaseRepository<T> where T : class, new()
    {

        private SqlSugarClient db;
        public SqlSugarClient DB
        {
            get
            {
                this.db = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = "Data Source=.;Initial Catalog=LazyShop.User;Persist Security Info=True;User ID=lazyshop;Password=123456",
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true,
                    IsShardSameThread = true
                });
                return db;
            }
        }


        /// <summary>
        /// 查询过滤
        /// </summary>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        public List<T> SelectEntities(Expression<Func<T, bool>> whereLambda)
        {
            var queryable = this.DB.Queryable<T>();
            return queryable.Where(whereLambda).ToList();
        }



        /// <summary>
        /// 分页
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalCount"></param>
        /// <param name="whereLambda"></param>
        /// <param name="orderbyLambda"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        public List<T> SelectPageEntities(int pageIndex, int pageSize, out int totalCount,
            Expression<Func<T, bool>> whereLambda,
            Expression<Func<T, object>> orderbyLambda, bool isAsc)
        {
            var queryable = this.DB.Queryable<T>();
            var temp = queryable.Where(whereLambda);
            totalCount = temp.Count();
            if (isAsc) //升序
            {
                temp = temp.OrderBy(orderbyLambda, OrderByType.Asc).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            else
            {
                temp = temp.OrderBy(orderbyLambda, OrderByType.Desc).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return temp.ToList();
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            var deleteable = this.DB.Deleteable(entity);
            return deleteable.ExecuteCommand() > 0;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            var updateable = this.DB.Updateable(entity);
            return updateable.ExecuteCommand() > 0;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            var insertable = this.DB.Insertable(entity);
            return insertable.ExecuteCommand() > 0 ? entity : null;
        }

        /// <summary>
        /// 开始事务
        /// </summary>
        public void BeginTran()
        {
            this.DB.BeginTran();
        }

        /// <summary>
        /// 结束事务
        /// </summary>
        public void CommitTran()
        {
            this.DB.CommitTran();
        }

        /// <summary>
        /// 回滚
        /// </summary>
        public void RollbackTran()
        {
            this.DB.RollbackTran();
        }

    }
}
