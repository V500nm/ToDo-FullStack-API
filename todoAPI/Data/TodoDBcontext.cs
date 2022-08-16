
using Microsoft.EntityFrameworkCore;
using todoAPI.models;

namespace todoAPI.Data
{
    public class TodoDBcontext : DbContext
    {
        public TodoDBcontext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<taskMain> Tasks { get; set; } 
    }
}
