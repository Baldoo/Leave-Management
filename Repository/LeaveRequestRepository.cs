using Leave_Management.Contracts;
using Leave_Management.Data;
using LeaveRequests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Repository
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly ApplicationDbContext _db; //ApplicationDbContext es como un puente de la aplicación hacia la base de datos, donde se obtienen todos los métodos para la manipulación de la base de datos

        public LeaveRequestRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public bool Create(LeaveRequest entity)
        {
            _db.LeaveRequests.Add(entity);
            return Save();
        }

        public bool Delete(LeaveRequest entity)
        {
            _db.LeaveRequests.Remove(entity);
            return Save();
        }

        public ICollection<LeaveRequest> FindAll()
        {
            return _db.LeaveRequests.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).ToList();
        }

        public LeaveRequest FindById(int id)
        {
            return _db.LeaveRequests.Include(q => q.RequestingEmployee).Include(q => q.ApprovedBy).Include(q => q.LeaveType).FirstOrDefault(q => q.Id == id);
        }

        public ICollection<LeaveRequest> GetLeaveRequestsByEmployee(string id)
        {
            return FindAll().Where(q => q.RequestingEmployeeId == id).ToList();
        }

        public bool isExists(int id)
        {
            var exists = _db.LeaveRequests.Any(x => x.Id == id);
            return exists;
        }

        public bool Save()
        {
            var changes = _db.SaveChanges() > 0;
            return changes;
        }

        public bool Update(LeaveRequest entity)
        {
            _db.LeaveRequests.Update(entity);
            return Save();
        }
    }
}
