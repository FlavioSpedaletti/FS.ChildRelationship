namespace ChildRelationship.Entities
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
}
