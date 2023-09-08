using AjaxPractice.Entities;
using Microsoft.EntityFrameworkCore;

namespace AjaxPractice.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
    }
}
