namespace Domain
{
    public class Person
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Edited { get; set; }
    }
}