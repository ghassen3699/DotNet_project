using firstDotNetApplication.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace firstDotNetApplication.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Categorie> Categories { get; set; }


    }
}
