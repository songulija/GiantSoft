using GiantSoft.Data;
using GiantSoft.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GiantSoft.Repository
{
    /// <summary>
    /// GenericRepository will take take generic T(which means its prepared to take any type of class)
    /// it inherits from IGenericRepository(inherit its methods) where T is class
    /// I will provide Brands, Categories or some other table class
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<T> _db;
        /// <summary>
        /// dependency injection is basically. whatever we load on Startup is available application wide
        /// so we dont need to instantiate everytime. so we just make reference to already existing ojbect
        /// becouse it was defined in Startup. In constructor we define DatabaseContext, it's accessing it from Startup procedure
        /// THEN set _db equal to context.Set<T>. t has to be Table name
        /// </summary>
        /// <param name="context"></param>
        /// <param name="db"></param>
        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _db = _context.Set<T>();
        }

        /// <summary>
        /// Delete record from provided table. Find
        /// record with provided id and delete it
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(int id)
        {
            var entity = await _db.FindAsync(id);
            _db.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _db.RemoveRange(entities);
        }
        /// <summary>
        /// For Get method. First we basically get record from that table
        /// then check if there was includes requirement(if we want to include additional detail)
        /// provide expression like b => b.Id == id. to find by id
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="include"></param>
        /// <returns></returns>
        public async Task<T> Get(System.Linq.Expressions.Expression<Func<T, bool>> expression, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            //like we would want when getting Product also include Brand object. filling our Brand
            //property in Prodct object field. we then will inlude to query whatever properties that were asked for
            //if in includes list you have added five foreign keys it will loop five times
            if (include != null)
            {
                //applying include to query
                query = include(query);
            }
            //but we probably dont want to include something all the time for speed purposes
            //AsNoTracking means any record that is retrieved with this function is not tracked
            //its send to client and entity framework doesnt care about it
            //expression means that it allows us to put LAMBDA expression like h => h.Id = id, its basically condition(bool)
            //that allows us to be very flexible. becouse i can write different expressions
            return await query.AsNoTracking().FirstOrDefaultAsync(expression);
        }

        public async Task<IList<T>> GetAll(System.Linq.Expressions.Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Func<IQueryable<T>, Microsoft.EntityFrameworkCore.Query.IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _db;
            //check if there was expression. like we want to get list of Products
            //where product name is Nike sss. Then Filter query for me please
            if (expression != null)
            {
                query = query.Where(expression);
            }

            //like we would want when getting Product also include Brand object. filling our Brand
            //property in Country object field. we then will inlude to query whatever properties that were asked for
            //if in includes list you have added five foreign keys it will loop five times
            if (include != null)
            {
                query = include(query);
            }
            //then order if neccessary. like person put Dessending or accending
            if (orderBy != null)
            {
                query = orderBy(query);
            }

            //but we probably dont want to include something all the time for speed purposes
            //AsNoTracking means any record that is retrieved with this function is not tracked
            //its send to client and entity framework doesnt care about it
            //expression means that it allows us to put LAMBDA expression like h => h.Id = id, its basically condition(bool)
            return await query.AsNoTracking().ToListAsync();
        }
        /// <summary>
        /// For Insert method have to provide entity(object) that you want to insert
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task Insert(T entity)
        {
            await _db.AddAsync(entity);
        }
        /// <summary>
        /// For InsertRange method have to provide entities(list of object) that you want to insert
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task InsertRange(IEnumerable<T> entities)
        {
            await _db.AddRangeAsync(entities);
        }
        /// <summary>
        /// For Update method. We have to part operation. One to attach entity to db
        /// When data comes it might not be attached. basically pay attention to this, check if you have it already
        /// check if there is any difference between it and what is in database. like there are certain fields that are different
        /// and those fields only be updated
        /// </summary>
        public void Update(T entity)
        {
            _db.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
