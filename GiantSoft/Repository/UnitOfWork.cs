using GiantSoft.Data;
using GiantSoft.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        //define DatabaseContext as _context. then IGenericRepository of class type Brand, Category and ....
        private readonly DatabaseContext _context;
        private IGenericRepository<Brand> _brands;
        private IGenericRepository<Category> _categories;
        private IGenericRepository<Comment> _comments;
        private IGenericRepository<Feedback> _feedbacks;
        private IGenericRepository<Product> _products;
        private IGenericRepository<Journal> _journals;
        private IGenericRepository<Whishlist> _whishlists;
        private IGenericRepository<Payment> _payments;

        public UnitOfWork(DatabaseContext context)
        {
            _context = context;
        }

        //set Brands to =. if _brands are null then return object of GenericRepository of type Brand
        //basically telling what it should return when someone calls UnitOfWork.Brands
        //return new GenericRepository<Brand>(_context) providing context which represents database
        public IGenericRepository<Brand> Brands => _brands ??= new GenericRepository<Brand>(_context);

        public IGenericRepository<Category> Categories => _categories ??= new GenericRepository<Category>(_context);

        public IGenericRepository<Feedback> Feedbacks => _feedbacks ??= new GenericRepository<Feedback>(_context);

        public IGenericRepository<Product> Products => _products ??= new GenericRepository<Product>(_context);
        public IGenericRepository<Journal> Journals => _journals ??= new GenericRepository<Journal>(_context);

        public IGenericRepository<Whishlist> Whishlists => _whishlists ??= new GenericRepository<Whishlist>(_context);
        public IGenericRepository<Payment> Payments => _payments ??= new GenericRepository<Payment>(_context);

        public IGenericRepository<Comment> Comments => _comments ??= new GenericRepository<Comment>(_context);

        public void Dispose()
        {
            //dispose is like garbage collector. when operations are done please Free up memory
            //kill any memory that connection to database was using, all recourses it was using
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Implementing save operation of IUnitOfWork
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
