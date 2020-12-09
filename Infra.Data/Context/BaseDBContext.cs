using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infra.Data.Context
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options)
        {

        }

        public DbSet<ClientesModel> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<ClientesModel>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

            base.OnModelCreating(builder);

        }


    }
}
