using EmployeeManagmentWebApi.BL.Interfaces;
using EmployeeManagmentWebApi.DAL.DBContainer;
using EmployeeManagmentWebApi.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentWebApi.BL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDBContext db;

        public DepartmentRepository(AppDBContext db)
        {
            this.db = db;
        }
        public async Task<Department> GetDepartment(int departmentId)
        {
            return  await db.Departments.FirstOrDefaultAsync(d=>d.DepartmentId == departmentId);
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await db.Departments.ToListAsync();
        }
    }
}
