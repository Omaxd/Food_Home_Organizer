using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer.Interfaces;
using DataLayer.Model;

namespace DataLayer.Repositories
{
    public abstract class Repository<T> : IRepository<T> 
        where T : BaseEntity
    {
        protected readonly IList<T> database;

        protected Repository(IList<T> items)
        {
            database = items;
        }

        public T GetById(Guid? id)
        {
            T item = database
                .Where(i => i.Id.Equals(id))
                .Where(i => !i.IsDeleted)
                .FirstOrDefault();

            return item;
        }

        public IList<T> GetAll()
        {
            IList<T> items = database
                .Where(i => !i.IsDeleted)
                .ToList();

            return items;
        }

        public T CreateOrUpdate(T item)
        {
            return item.Id == null ? Add(item) : Update(item);
        }

        public T Add(T item)
        {
            item.Id = Guid.NewGuid();
            database.Add(item);

            return item;
        }

        public T Update(T item)
        {
            T updated = database
                .FirstOrDefault(i => i.Id.Equals(item.Id));

            if (updated == null) 
                throw new ArgumentException("Provided item does not exist and can't be updated.");

            CopyProperties(item, updated);

            return updated;
        }


        public void Delete(T item)
        {
            Delete(item?.Id);
        }

        public void Delete(Guid? id)
        {
            T existingItem = database.FirstOrDefault(i => i.Id.Equals(id));

            if (existingItem == null) 
                throw new ArgumentException("Provided item does not exist and can't be updated.");

            existingItem.IsDeleted = true;

            Update(existingItem);
        }

        /// <summary>
        ///     Copy all property values from one object to another. Source object is modified.
        /// </summary>
        /// <param name="source"> Source object which property values will be copied. </param>
        /// <param name="destination"> Destination object which properties will be modified. </param>
        private void CopyProperties(T source, T destination)
        {
            foreach (var property in typeof(T).GetProperties())
                if (property.CanWrite)
                    property.SetValue(destination, property.GetValue(source, null), null);
        }
    }
}