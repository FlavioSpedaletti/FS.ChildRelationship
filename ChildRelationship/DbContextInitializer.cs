using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using ChildRelationship.Entities;

namespace ChildRelationship
{
    public class DbContextInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            context.Departments.AddOrUpdate(d => d.Name, new Department()
            {
                Name = "Dpto 1",
                Contacts = new List<Contact>()
                {
                    new Contact() { Name = "João 1" },
                    new Contact() { Name = "Maria 1" }
                }
            });
            context.SaveChanges();

            context.Departments.AddOrUpdate(d => d.Name, new Department()
            {
                Name = "Dpto 2",
                Contacts = new List<Contact>()
                {
                    new Contact() { Name = "Arnaldo 2" },
                    new Contact() { Name = "Rosa 2" }
                }
            });
            context.SaveChanges();

            context.Departments.AddOrUpdate(d => d.Name, new Department()
            {
                Name = "Dpto 3",
                Contacts = new List<Contact>()
                {
                    new Contact() { Name = "Jabor 3" },
                    new Contact() { Name = "Juca 3" },
                    new Contact() { Name = "Antonieta 3" }
                }
            });
            context.SaveChanges();

            Department department = context.Departments.FirstOrDefault();
            Contact contact = department.Contacts.FirstOrDefault();
            department.Contacts.Remove(contact);

            context.SaveChanges();
        }
    }
}
