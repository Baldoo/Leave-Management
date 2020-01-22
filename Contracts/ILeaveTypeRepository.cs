using Leave_Management.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Contracts
{
    public interface ILeaveTypeRepository : IRepositoryBase<LeaveType> //Se agrega la llamada a la interfaz base mandadole la clase con la que va a trabajar
    {
        ICollection<LeaveType> GetEmployeesByLeaveType(int id);
    }
}
