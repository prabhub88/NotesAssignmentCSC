using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Infrastructure
{
    public class NotesDbContextFactory : IDesignTimeDbContextFactory<NotesDBContext>
    {

        public NotesDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<NotesDBContext>();

            // Use your actual connection string here or read from config
            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=NotesDB; Integrated Security=true;TrustServerCertificate=True;");

            return new NotesDBContext(optionsBuilder.Options);
        }

    }
}
