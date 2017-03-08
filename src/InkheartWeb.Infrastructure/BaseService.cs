using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InkheartWeb.Infrastructure
{
    public class BaseService<T> where T : class, new()
    {
        public SqlSugarClient Db
        {
            get { return DaoFactory.GetSqlSugarClient(); }
        }
        #region 查询
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="whereLambda">lambda表达式</param>
        /// <returns></returns>
        public T GetEntities(Expression<Func<T, bool>> whereLambda)
        {
            return Db.Queryable<T>().Where(whereLambda).FirstOrDefault();
        }
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageSize">每页显示的条数</param>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="total">总共的条数</param>
        /// <param name="wherelambda">查询条件</param>
        /// <param name="orderByLambda">分页依据</param>
        /// <param name="isAsc">排序</param>
        /// <returns></returns>
        public List<T> GetPageEntities(int pageSize, int pageIndex, out int total,
    Expression<Func<T, bool>> wherelambda,
    Expression<Func<T, object>> orderByLambda,
    bool isAsc
    )
        {
            using (Db)
            {
                total = Db.Queryable<T>().Where(wherelambda).Count();
                if (isAsc)//升序
                {
                    var temp = Db.Queryable<T>().Where(wherelambda)
                       .OrderBy<T>(orderByLambda, OrderByType.Asc)
                       .Skip(pageSize * (pageIndex - 1))
                       .Take(pageSize).ToList();
                    return temp;
                }
                else//降序
                {
                    var temp = Db.Queryable<T>().Where(wherelambda)
                 .OrderBy<T>(orderByLambda, OrderByType.Desc)
                 .Skip(pageSize * (pageIndex - 1))
                 .Take(pageSize).ToList();
                    return temp;
                }
            }
        }

        #endregion

        #region 增加
        /// <summary>
        /// 插入增加
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns></returns>
        public T Add(T entity)
        {
            using (Db)
            {
                Db.Insert(entity);
                return entity;
            }

        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Update(T entity)
        {
            using (Db)
            {
                return Db.Update(entity);
            }
            //return true;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(T entity)
        {
            using (Db)
            {
                return Db.Delete(entity);
            }

            //return true;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool Delete(Expression<Func<T, bool>> whereLambda)
        {
            using (Db)
            {
                return Db.Delete<T>(whereLambda);
            }
        }
        #endregion



        #region 查找实例化视图对象的集合

        public List<T> GetViewModel(string sql)
        {
            using (Db)
            {
                return Db.SqlQuery<T>(sql);
            }
        }

        #endregion

        #region 获取所有的实例
        /// <summary>
        /// 获取所有的实例
        /// </summary>
        /// <param name="wherelambda"></param>
        /// <returns>List<T></returns>
        public List<T> GetAllEntities(Expression<Func<T, bool>> wherelambda)
        {
            var list = Db.Queryable<T>().Where(wherelambda).ToList();
            return list;
        }
        #endregion
    }
}
