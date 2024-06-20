using Microsoft.EntityFrameworkCore;
using testing.Models;

namespace testing.Data
{
    public class AddDbContext : DbContext
    {
        public AddDbContext(DbContextOptions<AddDbContext> options) : base(options){

     }
        public DbSet<DemoTest> DemoTest { get; set; }
    }
     

}
