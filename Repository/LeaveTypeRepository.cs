using Leave_Management.Contracts;
using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly ApplicationDbContext _db; //ApplicationDbContext es como un puente de la aplicación hacia la base de datos, donde se obtienen todos los métodos para la manipulación de la base de datos

        public LeaveTypeRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public bool Create(LeaveType entity)
        {
            _db.LeaveTypes.Add(entity);
            return Save();
        }

        public bool Delete(LeaveType entity)
        {
            _db.LeaveTypes.Remove(entity);
            return Save();
        }

        public ICollection<LeaveType> FindAll()
        {
            return _db.LeaveTypes.ToList();
        }

        public LeaveType FindById(int id)
        {
            return _db.LeaveTypes.Find(id);
        }

        public ICollection<LeaveType> GetEmployeesByLeaveType(int id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var changes = _db.SaveChanges() > 0;
            return changes;
        }

        public bool Update(LeaveType entity)
        {
            _db.LeaveTypes.Update(entity);
            return Save();
        }
    }
}
