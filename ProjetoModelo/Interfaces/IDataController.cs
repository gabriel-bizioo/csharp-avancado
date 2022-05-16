using System;
using System.Collections.Generic;
using System.Text;

namespace Interfaces
{
    public interface IDataController<T, O>
    {
        public T findById(int id);

        public List<T> getAll();

        //public int save();

        //public void update(T obj);

        //public void delete(T obj);

        public T convertModelToDTO();
    }
}
