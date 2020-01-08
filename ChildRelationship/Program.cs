using System;
using System.Linq;
using ChildRelationship.Entities;

namespace ChildRelationship
{
    class Program
    {
        static void Main(string[] args)
        {
            //referências:
            //  opção 1:          https://social.technet.microsoft.com/wiki/contents/articles/36707.entity-framework-deleting-an-item-from-a-collection.aspx
            //  opção 2 (melhor): https://marisks.net/2015/05/20/handling-child-collections-in-entity-framework/


            using (var ctx = new Context())
            {
                foreach (var d in ctx.Departments.ToList())
                {
                    Console.WriteLine($"Dpto.: {d.Name}");
                    foreach (var c in d.Contacts)
                        Console.WriteLine($"Cont.: {c.Name}");

                    Console.WriteLine("");
                }
            }

            // Adding new item
            using (var context = new Context())
            {
                var dpto = context.Departments.Find(1);
                dpto.Contacts.Add(new Contact() { Name = "Flavio" } );
                context.SaveChanges();
            }

            // Removing item
            using (var context = new Context())
            {
                var dpto = context.Departments.Find(2);
                var contact1 = dpto.Contacts.First();
                dpto.Contacts.Remove(contact1);
                var contact2 = dpto.Contacts.First();
                contact2.Name += " - alterado";
                context.SaveChanges();
            }

            // Removing all items
            using (var context = new Context())
            {
                var dpto = context.Departments.Find(3);
                dpto.Contacts.Clear();
                context.SaveChanges();
            }

            Console.ReadKey();
        }
    }
}
