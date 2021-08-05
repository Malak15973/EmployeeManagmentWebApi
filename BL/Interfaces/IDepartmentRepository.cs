using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeManagmentWebApi.DAL.Entites;

namespace EmployeeManagmentWebApi.BL.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int departmentId);
    }
}
