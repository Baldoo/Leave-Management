using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    public interface IRepositoryBase<T> where T : class  //<T> where T : class esto es par indicarle que cualquier clase puede hacer uso de esta interfaz
    {
        //Basci CRUD (Create, Read, Update, Delete)
        ICollection<T> FindAll();
        T FindById(int id);
        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        bool Save();
    }
}
