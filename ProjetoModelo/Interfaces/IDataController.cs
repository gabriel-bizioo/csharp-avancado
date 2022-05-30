using System;
using System.Collections.Generic;

namespace Interfaces;
public interface IDataController<T, O>
{
    //public T findById(int id);

    //public List<T> getAll();

    //public int save();

    // public static void update(int id,T obj);

    // public void delete(int id, T obj);

    public T convertModelToDTO();
}