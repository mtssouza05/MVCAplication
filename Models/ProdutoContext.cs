using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models
{
    public class ProdutoContext: DbContext
    {
        public ProdutoContext(DbContextOptions<ProdutoContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<ProdutoModel> Produto { get; set; }
    }
}
