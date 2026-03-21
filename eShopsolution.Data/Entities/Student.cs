using Microsoft.AspNetCore.Identity;

namespace eShopSolution.Data.Entities
{
    public class Student : IdentityUser
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age  { get; set; }
        public string Country { get; set; }
        public int Socre { get; set; }
    }
}