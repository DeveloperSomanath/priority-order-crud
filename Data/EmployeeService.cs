using EmployeeBlazorCRUD.DataContext;
using EmployeeBlazorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeBlazorCRUD.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _applicationDbContext.Employees.ToListAsync();
        }
        public async Task<bool> InsertEmployee(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = await _applicationDbContext.Employees.FirstOrDefaultAsync(c => c.Id.Equals(id));
            return employee;
        }
        public async Task<bool> UpdateEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> UpdateEmployeeOrder(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                var existingEmployee = await _applicationDbContext.Employees.FindAsync(employee.Id);
                if (existingEmployee != null)
                {
                    existingEmployee.DisplayOrder = employee.DisplayOrder;
                }
            }

            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
        public async Task<List<Employee>> GetAllEmployeesOrdered()
        {
            return await _applicationDbContext.Employees
                .OrderBy(e => e.DisplayOrder == 0 ? int.MaxValue : e.DisplayOrder) 
                .ToListAsync();
        }

    }
}