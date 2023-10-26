namespace E_NompiloPHC.Models
{
    public class Departmenty
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public ICollection<ApplicationUser> Employees { get; set; }
    }
}
