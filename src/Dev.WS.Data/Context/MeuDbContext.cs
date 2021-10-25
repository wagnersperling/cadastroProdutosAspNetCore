using Dev.WS.Business.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Dev.WS.Data.Context
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MeuDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }

    }
}

//Install-Package Microsoft.EntityFrameworkCore -v 2.2.0
//Install-Package Microsoft.EntityFrameworkCore.Relational -v 2.2.0

//Criar migration
//Add-Migration Initial -Verbose -Context MeuDbContext

//Para criar um script do banco
//Install-Package Microsoft.EntityFrameworkCore.SqlServer -v 2.2.0
//Script-Migration -Context MeuDbContext
//Script-Migration -Context ApplicationDbContext

//Para criar o banco do Identity
//Update-Database -Context ApplicationDbContext
//Para criar o banco da aplicação
//Update-Database -Context MeuDbContext
