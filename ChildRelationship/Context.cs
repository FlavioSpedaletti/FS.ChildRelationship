using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using ChildRelationship.Entities;

namespace ChildRelationship
{
    public class Context : DbContext
    {
        public Context() : base("name=childrelationship") { }

        public DbSet<Department> Departments { get; set; }

        //precisa definir a chave composta para excluir as entidades-filhas automaticamente
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Contacts)
                .WithOptional()
                .HasForeignKey(c => c.DepartmentId);

            modelBuilder.Entity<Contact>()
                .HasKey(c => new { c.Id, c.DepartmentId })
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
