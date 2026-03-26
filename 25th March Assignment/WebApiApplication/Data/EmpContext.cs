using Microsoft.EntityFrameworkCore;
using WebApiApplication.Models;

namespace WebApiApplication.Data
{
    public class EmpContext : DbContext
    {
        public EmpContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> employees { set; get; }
    }
}
