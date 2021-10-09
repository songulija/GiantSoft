using GiantSoft.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GiantSoft.IRepository
{
    /// <summary>
    /// it will inherit from IDissposable
    /// IUnitOfWork will act as register for every variation of GenericRepository
    /// relative to class T. IDisposable provides mechanism for releasing unmanaged resources
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        //now we have eight tables. some people instead of Countries
        //SO we could just Call IUnitOfWork.Brands, Categories ... operationName that we want to call
        IGenericRepository<Brand> Brands { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Feedback> Feedbacks { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Image> Images { get; }
        IGenericRepository<Journal> Journals { get; }
        IGenericRepository<Whishlist> Whishlists { get; }
        IGenericRepository<Payment> Payments { get; }

        //then we have one more operation which is Save(). to call save when adding, updating
        //but this is outside repository becouse if there are multiple changes made at time it can be cought in one operation
        Task Save();
    }
}
