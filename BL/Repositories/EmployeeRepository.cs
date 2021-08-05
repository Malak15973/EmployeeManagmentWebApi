using EmployeeManagmentWebApi.BL.Interfaces;
using EmployeeManagmentWebApi.DAL.DBContainer;
using EmployeeManagmentWebApi.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagmentWebApi.BL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDBContext db;

        public EmployeeRepository(AppDBContext db)
        {
            this.db = db;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await db.Employees.AddAsync(employee);
            await db.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployee(int employeeId)
        {
            var employee = await db.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            if (employee != null)
            {
                db.Employees.Remove(employee);
                await db.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
           return  await db.Employees.Include(e=>e.Department).FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await db.Employees.Include(e => e.Department).FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await db.Employees.Include(e => e.Department).ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = db.Employees;

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.FirstName.Contains(name)
                            || e.LastName.Contains(name));
            }

            if (gender != null)
            {
                query = query.Where(e => e.Gender == gender);
            }

            return await query.ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await db.Employees.FirstOrDefaultAsync(e=>e.EmployeeId==employee.EmployeeId);
            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Email = employee.Email;
                result.DateOfBrith = employee.DateOfBrith;
                result.Gender = employee.Gender;
                if (employee.DepartmentId != 0)
                {
                    result.DepartmentId = employee.DepartmentId;
                }
                else if (employee.Department != null)
                {
                    result.DepartmentId = employee.Department.DepartmentId;
                }
                result.PhotoPath = employee.PhotoPath;

                await db.SaveChangesAsync();

                return result;
            }

            return null;

        }
    }
}
