using DataLayer.Model;
using System;
using System.Collections.Generic;

namespace DataLayer.Interfaces
{
    public interface IRepository<T> 
        where T : BaseEntity
    {
        T GetById(Guid? id);

        IList<T> GetAll();

        T CreateOrUpdate(T item);

        T Add(T item);

        T Update(T item);

        void Delete(T item);

        void Delete(Guid? id);
    }
}
