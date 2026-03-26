using Microsoft.EntityFrameworkCore;
using WebApiApplication.Data;
using WebApiApplication.Models;

namespace WebApiApplication
{
    public class EmployeeService:IEmployee
    {
        private readonly EmpContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EmployeeService(EmpContext _context, IWebHostEnvironment webHostEnvironment)
        {
            this._context = _context;
            this.webHostEnvironment = webHostEnvironment;
        }
        public async Task<Employee> AddEmployeeAsync(Employee emp, IFormFile image)
        {
            if (image != null && image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "uploads", imageName);
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath)!);

                using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);

                emp.ImagePath = "/uploads/" + imagePath;
            }
            await _context.employees.AddAsync(emp);
            await _context.SaveChangesAsync();
            return emp;
        }

        public async Task<Employee?> DeleteEmployeeAsync(int id)
        {
            var existing = await _context.employees.FindAsync(id);
            if (existing == null)
            {
                return null;
            }
            _context.employees.Remove(existing);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<List<Employee>> GetAllEmployeesAsync(int pageNumber, int pageSize)
        {
            return await _context.employees.Skip((pageNumber - 1) + pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Employee?> GetEmployeesByIdAsync(int id)
        {
            return await _context.employees.FindAsync(id);
        }

        public async Task<Employee?> UpdateEmployeeAsync(Employee updatedEmp, IFormFile? image)
        {

            var existing = await _context.employees.FindAsync(updatedEmp.Id);
            if (existing == null)
            {
                return null;
            }

            if (image != null && image.Length > 0)
            {
                var imageName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                var imagePath = Path.Combine(webHostEnvironment.WebRootPath, "uploads", imageName);
                Directory.CreateDirectory(Path.GetDirectoryName(imagePath)!);

                using var stream = new FileStream(imagePath, FileMode.Create);
                await image.CopyToAsync(stream);

                updatedEmp.ImagePath = "/uploads/" + imagePath;
            }

            existing.FirstName = updatedEmp.FirstName;
            existing.LastName = updatedEmp.LastName;
            existing.Email = updatedEmp.Email;
            existing.Age = updatedEmp.Age;

            await _context.SaveChangesAsync();

            return existing;
        }
    }
}
