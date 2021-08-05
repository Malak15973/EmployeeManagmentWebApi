using EmployeeManagmentWebApi.DAL.Entites;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeManagmentWebApi.DAL.DBContainer
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Department>().HasData(
                new Department  { DepartmentId = 1,DepartmentName = "IT" },
                new Department { DepartmentId = 2, DepartmentName = "HR" },
                new Department { DepartmentId = 3, DepartmentName = "Payroll" },
                new Department { DepartmentId = 4, DepartmentName = "Admin" }
            );

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 1,
                FirstName = "Malak",
                LastName = "Emad",
                Email = "Malak@test.com",
                DateOfBrith = new DateTime(2000, 6, 7),
                Gender = Gender.Male,
                DepartmentId = 1,
                PhotoPath = "images/malak.png"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 2,
                FirstName = "Mena",
                LastName = "Emad",
                Email = "Mena@test.com",
                DateOfBrith = new DateTime(2002, 12, 22),
                Gender = Gender.Male,
                DepartmentId = 2,
                PhotoPath = "images/mena.jpg"
            });

            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                EmployeeId = 3,
                FirstName = "Marina",
                LastName = "Fawzy",
                Email = "Marina@test.com",
                DateOfBrith = new DateTime(1999, 11, 11),
                Gender = Gender.Female,
                DepartmentId = 3,
                PhotoPath = "images/marina.png"
            });

        }
    }
}
